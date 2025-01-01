// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeAnalysis.Lightup.Definitions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

[Generator]
public class LightupGenerator : IIncrementalGenerator
{
    private static readonly ConcurrentDictionary<Version, Dictionary<string, BaseTypeDefinition>> TypesPerAssemblyVersion = new();

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var configFiles = context.AdditionalTextsProvider.Where(Helpers.IsConfigurationFile);
        var configFileContents = configFiles.Select((text, cancellationToken) => text.GetText(cancellationToken)!.ToString());

        var languageVersion = context.CompilationProvider.Select((compilation, cancellationToken) =>
        {
            var languageVersion = (compilation as CSharpCompilation)?.LanguageVersion;
            return languageVersion;
        });

        var generatorInput = configFileContents.Combine(languageVersion);
        context.RegisterSourceOutput(
            generatorInput,
            (context, input) => Execute(context, input.Left, input.Right));
    }

    private static void Execute(SourceProductionContext context, string configFileContent, LanguageVersion? languageVersion)
    {
        if (Helpers.TryParseConfiguration(
            configFileContent,
            out var assemblies,
            out var baselineVersion,
            out var typesToInclude,
            out var useFoldersInFilePaths,
            out var _))
        {
            var useNullableAnnotation = languageVersion >= LanguageVersion.CSharp8;
            var types = GetOrReadTypes(baselineVersion);
            Writer.Write(
                context,
                assemblies,
                typesToInclude,
                useNullableAnnotation,
                useFoldersInFilePaths,
                types);
        }
    }

    private static Dictionary<string, BaseTypeDefinition> GetOrReadTypes(Version baselineVersion)
    {
        return TypesPerAssemblyVersion.GetOrAdd(baselineVersion, ReadTypes);
    }

    private static Dictionary<string, BaseTypeDefinition> ReadTypes(Version baselineVersion)
    {
        var typeList = TypesReader.Read(baselineVersion);
        var types = typeList.ToDictionary(x => x.FullName, x => x);
        AnalyzeTypes(types);
        return types;
    }

    private static void AnalyzeTypes(Dictionary<string, BaseTypeDefinition> typeDefs)
    {
        foreach (var typeDef in typeDefs.Values)
        {
            var result = AnalyzeType(typeDef);
            if (result != null)
            {
                typeDef.GeneratedName = result.Value.GeneratedName;
                typeDef.IsUpdated = result.Value.IsUpdated;
                typeDef.GeneratedFileName = CreateGeneratedFileName(result.Value.GeneratedName, typeDef.EnclosingTypeFullName, typeDefs);
            }
        }
    }

    private static (string GeneratedName, bool IsUpdated)? AnalyzeType(BaseTypeDefinition typeDef)
    {
        if (typeDef is EnumTypeDefinition enumTypeDefinition)
        {
            if (typeDef.AssemblyVersion != null)
            {
                return ($"{typeDef.Name}Ex", false);
            }
            else if (HasNewValues(enumTypeDefinition))
            {
                return ($"{typeDef.Name}Ex", true);
            }
        }
        else if (typeDef is StructTypeDefinition structTypeDef)
        {
            if (typeDef.AssemblyVersion != null)
            {
                return ($"{typeDef.Name}Wrapper", false);
            }
            else if (HasNewMembers(structTypeDef))
            {
                // TODO: Use just "Ex" here as well? Not all members will be extension methods.
                return ($"{typeDef.Name}Extensions", true);
            }
        }
        else if (typeDef is ClassTypeDefinition classTypeDef)
        {
            if (typeDef.AssemblyVersion != null)
            {
                if (classTypeDef.IsStatic)
                {
                    return ($"{typeDef.Name}Ex", false);
                }
                else
                {
                    return ($"{typeDef.Name}Wrapper", false);
                }
            }
            else if (HasNewMembers(classTypeDef))
            {
                if (classTypeDef.IsStatic)
                {
                    return ($"{typeDef.Name}Ex", true);
                }
                else
                {
                    return ($"{typeDef.Name}Extensions", true);
                }
            }
        }
        else if (typeDef is InterfaceTypeDefinition interfaceTypeDef)
        {
            if (typeDef.AssemblyVersion != null)
            {
                return ($"{typeDef.Name}Wrapper", false);
            }
            else if (HasNewMembers(interfaceTypeDef))
            {
                return ($"{typeDef.Name}Extensions", true);
            }
        }

        return null;
    }

    private static bool HasNewValues(EnumTypeDefinition typeDef)
    {
        return typeDef.Values.Any(x => x.AssemblyVersion != null);
    }

    private static bool HasNewMembers(TypeDefinition typeDef)
    {
        return
            typeDef.Constructors.Any(x => x.AssemblyVersion != null) ||
            typeDef.Fields.Any(x => x.AssemblyVersion != null) ||
            typeDef.Events.Any(x => x.AssemblyVersion != null) ||
            typeDef.Properties.Any(x => x.AssemblyVersion != null) ||
            typeDef.Indexers.Any(x => x.AssemblyVersion != null) ||
            typeDef.Methods.Any(x => x.AssemblyVersion != null);
    }

    private static string CreateGeneratedFileName(
        string generatedName,
        string? enclosingTypeFullName,
        Dictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        AppendEnclosingType(sb, enclosingTypeFullName, typeDefs);
        sb.Append(generatedName);
        sb.Append(".g.cs");
        return sb.ToString();

        static void AppendEnclosingType(
            StringBuilder sb,
            string? enclosingTypeFullName,
            Dictionary<string, BaseTypeDefinition> typeDefs)
        {
            if (enclosingTypeFullName != null)
            {
                var enclosingType = typeDefs[enclosingTypeFullName];
                AppendEnclosingType(sb, enclosingType.EnclosingTypeFullName, typeDefs);
                sb.Append(enclosingType.Name);
                sb.Append(".");
            }
        }
    }
}
