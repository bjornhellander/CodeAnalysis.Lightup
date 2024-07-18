using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class Reflector
{
    private static readonly Dictionary<AssemblyKind, string> AssemblyNames = new()
    {
        [AssemblyKind.Common] = "Microsoft.CodeAnalysis.dll",
        [AssemblyKind.CSharp] = "Microsoft.CodeAnalysis.CSharp.dll",
    };

    public static void CollectTypes(
        string testProjectName,
        string rootFolder,
        Dictionary<string, TypeDefinition> typeDefs,
        bool isBaselineVersion)
    {
        var assemblyLoadContext = new AssemblyLoadContext(testProjectName);
        CollectTypes(assemblyLoadContext, testProjectName, rootFolder, typeDefs, isBaselineVersion, AssemblyKind.Common);
        CollectTypes(assemblyLoadContext, testProjectName, rootFolder, typeDefs, isBaselineVersion, AssemblyKind.CSharp);
    }

    private static void CollectTypes(
        AssemblyLoadContext assemblyLoadContext,
        string testProjectName,
        string rootFolder,
        Dictionary<string, TypeDefinition> typeDefs,
        bool isBaselineVersion,
        AssemblyKind assemblyKind)
    {
        var testProjectFolder = Path.Combine(rootFolder, testProjectName);

        var assemblyName = AssemblyNames[assemblyKind];
        var assemblyPaths = Directory.GetFiles(testProjectFolder, assemblyName, SearchOption.AllDirectories);
        var assemblyPath = assemblyPaths.SingleOrDefault();
        if (assemblyPath == null)
        {
            throw new Exception($"Unable to find {assemblyName} in {testProjectFolder}");
        }

        var assembly = assemblyLoadContext.LoadFromAssemblyPath(assemblyPath);
        var assemblyVersion = assembly.GetName().Version ?? throw new NullReferenceException();

        var types = assembly.GetTypes().Where(x => x.IsPublic).ToList();
        foreach (var type in types)
        {
            var name = type.FullName ?? throw new NullReferenceException();

            if (!typeDefs.TryGetValue(name, out var typeDef))
            {
                typeDef = CreateEmptyTypeDefinition(type, isBaselineVersion ? null : assemblyVersion, assemblyKind);
                if (typeDef == null)
                {
                    continue;
                }

                typeDefs.Add(name, typeDef);
            }

            if (typeDef is EnumTypeDefinition enumTypeDef)
            {
                UpdateEnumType(enumTypeDef, type, isBaselineVersion ? null : assemblyVersion);
            }
            else if (typeDef is ClassTypeDefinition classTypeDef)
            {
                UpdateClassType(classTypeDef, type);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }

    private static TypeDefinition? CreateEmptyTypeDefinition(Type type, Version? version, AssemblyKind assemblyKind)
    {
        if (type.IsEnum)
        {
            return new EnumTypeDefinition(assemblyKind, version, type.Name, type);
        }
        else if (type.IsClass)
        {
            return new ClassTypeDefinition(assemblyKind, version, type.Name, type, IsStaticType(type));
        }
        else if (type.IsValueType)
        {
            // TODO: Handle structs
            return null;
        }
        else if (type.IsInterface)
        {
            // TODO: Handle interfaces
            return null;
        }
        else
        {
            throw new InvalidOperationException();
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
                // NOTE: Some enums have a value called Count, containing the number of defined values
                if (duplicateValueDef.Value != value && name != "Count")
                {
                    throw new InvalidOperationException();
                }

                continue;
            }

            var enumValueDef = new EnumValueDefinition(version, name, value);
            enumTypeDef.Values.Add(enumValueDef);
        }
    }

    private static void UpdateClassType(ClassTypeDefinition classTypeDef, Type type)
    {
        classTypeDef.Type = type;

        if (classTypeDef.IsStatic != IsStaticType(type))
        {
            throw new InvalidOperationException();
        }
    }

    private static bool IsStaticType(Type type)
    {
        var result = type.IsAbstract && type.IsSealed;
        return result;
    }
}
