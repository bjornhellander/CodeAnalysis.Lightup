using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class Reflector
{
    private const string CodeAnalysisAssemblyName = "Microsoft.CodeAnalysis.dll";
    private const string CodeAnalysisCSharpAssemblyName = "Microsoft.CodeAnalysis.CSharp.dll";

    public static void CollectTypes(
        string testProjectName,
        string rootFolder,
        Dictionary<string, TypeDefinition> typeDefs,
        bool isBaselineAssembly)
    {
        var testProjectFolder = Path.Combine(rootFolder, testProjectName);

        var codeAnalysisAssemblyPaths = Directory.GetFiles(testProjectFolder, CodeAnalysisAssemblyName, SearchOption.AllDirectories);
        var codeAnalysisAssemblyPath = codeAnalysisAssemblyPaths.SingleOrDefault();
        if (codeAnalysisAssemblyPath == null)
        {
            throw new Exception($"Unable to find {CodeAnalysisAssemblyName} in {testProjectFolder}");
        }

        var codeAnalysisCSharpAssemblyPaths = Directory.GetFiles(testProjectFolder, CodeAnalysisCSharpAssemblyName, SearchOption.AllDirectories);
        var codeAnalysisCSharpAssemblyPath = codeAnalysisCSharpAssemblyPaths.SingleOrDefault();
        if (codeAnalysisCSharpAssemblyPath == null)
        {
            throw new Exception($"Unable to find {CodeAnalysisCSharpAssemblyName} in {testProjectFolder}");
        }

        var assemblyLoadContext = new AssemblyLoadContext(testProjectName, true);
        var codeAnalysisAssembly = assemblyLoadContext.LoadFromAssemblyPath(codeAnalysisAssemblyPath);
        var codeAnalysisCSharpAssembly = assemblyLoadContext.LoadFromAssemblyPath(codeAnalysisCSharpAssemblyPath);

        var assemblyVersion = codeAnalysisCSharpAssembly.GetName().Version ?? throw new NullReferenceException();

        var types = codeAnalysisCSharpAssembly.GetTypes().Where(x => x.IsPublic).ToList();
        foreach (var type in types)
        {
            var name = type.FullName ?? throw new NullReferenceException();

            if (!typeDefs.TryGetValue(name, out var typeDef))
            {
                typeDef = CreateEmptyTypeDefinition(type, assemblyVersion);
                if (typeDef == null)
                {
                    continue;
                }

                typeDefs.Add(name, typeDef);
            }

            if (typeDef is EnumTypeDefinition enumTypeDef)
            {
                UpdateEnumType(enumTypeDef, type, isBaselineAssembly ? null : assemblyVersion);
            }
            else if (typeDef is ClassTypeDefinition classTypeDef)
            {
                UpdateClassType(classTypeDef, type);
            }
            else
            {
                Debug.Fail("Unexpected situation");
            }
        }
    }

    private static TypeDefinition? CreateEmptyTypeDefinition(Type type, Version? version)
    {
        if (type.IsEnum)
        {
            return new EnumTypeDefinition(version, type.Name, type);
        }
        else if (type.IsClass)
        {
            return new ClassTypeDefinition(version, type.Name, type);
        }
        else
        {
            // TODO: Check
            return null;
        }
    }

    private static void UpdateEnumType(EnumTypeDefinition enumTypeDef, Type type, Version? version)
    {
        enumTypeDef.Type = type;

        var fields = type.GetFields().Where(x => x.IsStatic && x.IsPublic);
        foreach (var field in fields)
        {
            var name = field.Name;
            var value = Convert.ToInt32(field.GetValue(null));

            var duplicateValueDef = enumTypeDef.Values.SingleOrDefault(x => x.Name == name);
            if (duplicateValueDef != null)
            {
                Debug.Assert(duplicateValueDef.Value == value);
                continue;
            }

            var enumValueDef = new EnumValueDefinition(version, name, value);
            enumTypeDef.Values.Add(enumValueDef);
        }
    }

    private static void UpdateClassType(ClassTypeDefinition classTypeDef, Type type)
    {
        classTypeDef.Type = type;
    }
}
