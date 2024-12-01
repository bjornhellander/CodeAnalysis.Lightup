// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeAnalysis.Lightup.Definitions;
using Microsoft.CodeAnalysis;

[Generator]
public class LightupGenerator : IIncrementalGenerator
{
    private static readonly Lazy<Dictionary<string, BaseTypeDefinition>> Types = new(ReadTypes);

    private static Dictionary<string, BaseTypeDefinition> ReadTypes()
    {
        var typeList = TypesReader.Read();
        var types = typeList.ToDictionary(x => x.FullName, x => x);
        AnalyzeTypes(types);
        return types;
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<AdditionalText> configFiles = context.AdditionalTextsProvider.Where(Helpers.IsConfigurationFile);

        IncrementalValuesProvider<string> configFileContents = configFiles.Select((text, cancellationToken) => text.GetText(cancellationToken)!.ToString());

        context.RegisterSourceOutput(
            configFileContents,
            (context, value) => Execute(context, value));
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "TODO")]
    private static void Execute(SourceProductionContext context, string configFileContent)
    {
        if (Helpers.TryParseConfiguration(configFileContent, out var assemblies, out var baselineVersion, out var typesToInclude, out var _))
        {
            Writer.Write(context, assemblies, typesToInclude, Types.Value);
        }
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
        sb.Append(".cs");
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
