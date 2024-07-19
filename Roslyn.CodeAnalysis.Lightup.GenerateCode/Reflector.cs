namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

internal class Reflector
{
    private static readonly Dictionary<AssemblyKind, string> AssemblyNames = new()
    {
        [AssemblyKind.Common] = "Microsoft.CodeAnalysis",
        [AssemblyKind.CSharp] = "Microsoft.CodeAnalysis.CSharp",
        [AssemblyKind.Workspaces] = "Microsoft.CodeAnalysis.Workspaces",
    };

    public static void CollectTypes(
        string testProjectName,
        string rootFolder,
        Dictionary<string, TypeDefinition> typeDefs,
        bool isBaselineVersion)
    {
        var testProjectFolder = Path.Combine(rootFolder, testProjectName, "bin");
        var testAssemblyPaths = Directory.GetFiles(testProjectFolder, $"{testProjectName}.dll", SearchOption.AllDirectories);
        var testAssemblyPath = testAssemblyPaths.SingleOrDefault();
        Assert.IsTrue(testAssemblyPath != null, $"Could not find test assembly in {testProjectFolder}");
        var testProjectBinFolder = Path.GetDirectoryName(testAssemblyPath);
        Assert.IsTrue(testProjectBinFolder != null, "Could not get test projects's bin folder");

        var assemblyLoadContext = new AssemblyLoadContext(testProjectName);
        assemblyLoadContext.Resolving += ResolveAssembly;

        foreach (var assemblyKind in Enum.GetValues<AssemblyKind>())
        {
            CollectTypes(assemblyLoadContext, typeDefs, isBaselineVersion, assemblyKind);
        }

        Assembly? ResolveAssembly(AssemblyLoadContext context, AssemblyName assemblyName)
        {
            var assemblyPath = Path.Combine(testProjectBinFolder, assemblyName.Name + ".dll");
            var assembly = context.LoadFromAssemblyPath(assemblyPath);
            return assembly;
        }
    }

    private static void CollectTypes(
        AssemblyLoadContext assemblyLoadContext,
        Dictionary<string, TypeDefinition> typeDefs,
        bool isBaselineVersion,
        AssemblyKind assemblyKind)
    {
        var assemblyName = AssemblyNames[assemblyKind];

        var assembly = assemblyLoadContext.LoadFromAssemblyName(new AssemblyName(assemblyName));
        var assemblyVersion = assembly.GetName().Version;
        Assert.IsTrue(assemblyVersion != null, "Could not get assembly version");

        var types = assembly.GetTypes().Where(x => x.IsPublic).ToList();
        foreach (var type in types)
        {
            var name = type.FullName;
            Assert.IsTrue(name != null, "Could not get type's full name");

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
                Assert.Fail("Unhandled type");
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
            Assert.Fail("Unhandled type");
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
                // NOTE: Some enums have a value called Count, containing the number of defined values
                Assert.IsTrue(duplicateValueDef.Value == value || name == "Count", "Unexpected enum value");
                continue;
            }

            var enumValueDef = new EnumValueDefinition(version, name, value);
            enumTypeDef.Values.Add(enumValueDef);
        }
    }

    private static void UpdateClassType(ClassTypeDefinition classTypeDef, Type type)
    {
        classTypeDef.Type = type;

        Assert.IsTrue(classTypeDef.IsStatic == IsStaticType(type), "IsStatic has changed");
    }

    private static bool IsStaticType(Type type)
    {
        var result = type.IsAbstract && type.IsSealed;
        return result;
    }
}
