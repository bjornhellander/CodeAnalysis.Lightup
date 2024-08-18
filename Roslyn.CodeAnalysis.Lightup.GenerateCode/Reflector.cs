namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        [AssemblyKind.CSharpWorkspaces] = "Microsoft.CodeAnalysis.CSharp.Workspaces",
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
                typeDef = CreateEmptyTypeDefinition(assemblyKind, isBaselineVersion ? null : assemblyVersion, type);
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
            else if (typeDef is InterfaceTypeDefinition interfaceTypeDef)
            {
                UpdateInterfaceType(interfaceTypeDef, type);
            }
            else
            {
                Assert.Fail("Unhandled type");
            }
        }
    }

    private static TypeDefinition? CreateEmptyTypeDefinition(
        AssemblyKind assemblyKind,
        Version? version,
        Type type)
    {
        if (type.IsEnum)
        {
            return CreateEmptyEnumTypeDefinition(assemblyKind, version, type);
        }
        else if (type.IsClass)
        {
            return CreateEmptyClassTypeDefinition(assemblyKind, version, type);
        }
        else if (type.IsValueType)
        {
            // TODO: Handle structs
            return null;
        }
        else if (type.IsInterface)
        {
            return CreateEmptyInterfaceTypeDefinition(assemblyKind, version, type);
        }
        else
        {
            Assert.Fail("Unhandled type");
            return null;
        }
    }

    private static EnumTypeDefinition CreateEmptyEnumTypeDefinition(
        AssemblyKind assemblyKind,
        Version? version,
        Type type)
    {
        var underlyingTypeName = type.GetEnumUnderlyingType().FullName;
        Assert.IsTrue(underlyingTypeName != null, "Could not get enum's underlying type");

        var isFlagsEnum = type.GetCustomAttribute<FlagsAttribute>() != null;

        return new EnumTypeDefinition(
            assemblyKind,
            version,
            type.Name,
            type.Namespace!,
            type.FullName!,
            underlyingTypeName,
            isFlagsEnum);
    }

    private static ClassTypeDefinition CreateEmptyClassTypeDefinition(
        AssemblyKind assemblyKind,
        Version? version,
        Type type)
    {
        var baseClassRef = type.BaseType != null ? CreateTypeReference(type.BaseType) : null;

        return new ClassTypeDefinition(
            assemblyKind,
            version,
            type.Name,
            type.Namespace!,
            type.FullName!,
            baseClassRef,
            IsStaticType(type));
    }

    private static InterfaceTypeDefinition CreateEmptyInterfaceTypeDefinition(
        AssemblyKind assemblyKind,
        Version? version,
        Type type)
    {
        var interfaces = type.GetInterfaces();
        var interfaceTypeRefs = interfaces.Select(CreateTypeReference).ToImmutableArray();

        return new InterfaceTypeDefinition(
            assemblyKind,
            version,
            type.Name,
            type.Namespace!,
            type.FullName!,
            interfaceTypeRefs);
    }

    private static void UpdateEnumType(EnumTypeDefinition enumTypeDef, Type type, Version? version)
    {
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
        // TODO: Check which members are actually new
        var propertyDefs = CreatePropertyDefinitions(type);
        classTypeDef.Properties.Clear();
        classTypeDef.Properties.AddRange(propertyDefs);

        var methodDefs = CreateMethodDefinitions(type);
        classTypeDef.Methods.Clear();
        classTypeDef.Methods.AddRange(methodDefs);

        Assert.IsTrue(classTypeDef.IsStatic == IsStaticType(type), "IsStatic has changed");
    }

    private static bool IsStaticType(Type type)
    {
        var result = type.IsAbstract && type.IsSealed;
        return result;
    }

    private static void UpdateInterfaceType(InterfaceTypeDefinition interfaceTypeDef, Type type)
    {
        // TODO: Check which members are actually new
        var propertyDefs = CreatePropertyDefinitions(type);
        interfaceTypeDef.Properties.Clear();
        interfaceTypeDef.Properties.AddRange(propertyDefs);

        var methodDefs = CreateMethodDefinitions(type);
        interfaceTypeDef.Methods.Clear();
        interfaceTypeDef.Methods.AddRange(methodDefs);
    }

    private static List<PropertyDefinition> CreatePropertyDefinitions(Type type)
    {
        var properties = type
            .GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .OfType<PropertyInfo>()
            .OrderBy(x => x.Name)
            .ToList();
        var result = properties.Select(CreatePropertyDefinition).ToList();
        return result;
    }

    private static PropertyDefinition CreatePropertyDefinition(PropertyInfo property)
    {
        var typeRef = CreateTypeReference(property.PropertyType);

        var nullabilityInfo = new NullabilityInfoContext().Create(property);
        var isNullable = !property.PropertyType.IsValueType && nullabilityInfo.ReadState != NullabilityState.NotNull;

        // TODO: Handle setter as well
        var accessor = property.GetMethod;
        Assert.IsTrue(accessor != null, "");

        var result = new PropertyDefinition(
            property.Name,
            typeRef,
            isNullable,
            accessor.IsStatic);
        return result;
    }

    private static List<MethodDefinition> CreateMethodDefinitions(Type type)
    {
        // TODO: Handle generic methods
        var methods = type
            .GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .OfType<MethodInfo>()
            .Where(x => !x.Attributes.HasFlag(MethodAttributes.SpecialName))
            .Where(x => !x.IsGenericMethod)
            .OrderBy(x => x.Name).ThenBy(x => x.GetParameters().Length)
            .ToList();
        var result = methods.Select(CreateMethodDefinition).ToList();
        return result;
    }

    private static MethodDefinition CreateMethodDefinition(MethodInfo method)
    {
        // TODO: Check nullability for return type
        var returnTypeRef = method.ReturnType != typeof(void) ? CreateTypeReference(method.ReturnType) : null;

        var parameters = method.GetParameters();
        var parameterDefs = parameters.Select(CreateParameterDefinitions).ToList();

        var result = new MethodDefinition(
            method.Name,
            method.IsStatic,
            returnTypeRef,
            parameterDefs);
        return result;
    }

    private static ParameterDefinition CreateParameterDefinitions(ParameterInfo parameter)
    {
        var name = parameter.Name;
        Assert.IsTrue(name != null, "Could not get parameter name");

        var isParams = parameter.IsDefined(typeof(ParamArrayAttribute));

        GetParameterModeAndProperType(parameter, out var parameterMode, out var parameterType);

        var typeRef = CreateTypeReference(parameterType);

        var nullabilityInfoContext = new NullabilityInfoContext();
        var nullabilityInfo = nullabilityInfoContext.Create(parameter);
        var isNullable = !parameterType.IsValueType && nullabilityInfo.WriteState != NullabilityState.NotNull;

        return new ParameterDefinition(
            name,
            isParams,
            typeRef,
            isNullable,
            parameterMode);
    }

    private static void GetParameterModeAndProperType(
        ParameterInfo parameter,
        out ParameterMode parameterMode,
        out Type parameterType)
    {
        switch ((parameter.ParameterType.IsByRef, parameter.IsIn, parameter.IsOut, parameter.IsRetval))
        {
            case (false, false, false, false):
                parameterMode = ParameterMode.None;
                parameterType = parameter.ParameterType;
                return;

            case (true, true, false, false):
                parameterMode = ParameterMode.In;
                break;

            case (true, false, true, false):
                parameterMode = ParameterMode.Out;
                break;

            default:
                Assert.Fail("Unexpected parameter mode");
                parameterMode = ParameterMode.None;
                parameterType = parameter.ParameterType;
                return;
        }

        var properType = parameter.ParameterType.GetElementType();
        Assert.IsTrue(properType != null, "Could not get parameter's proper type");
        parameterType = properType;
    }

    private static TypeReference CreateTypeReference(Type type)
    {
        if (type.IsByRef)
        {
            Assert.Fail("Unexpected by ref type");
        }

        if (type.IsGenericParameter)
        {
            return new GenericTypeParameterReference(type, type.Name);
        }
        else if (type.IsArray)
        {
            var elementType = type.GetElementType();
            Assert.IsTrue(elementType != null, "Could not get array's element type");
            var elementTypeRef = CreateTypeReference(elementType);

            return new ArrayTypeReference(type, elementTypeRef);
        }
        else if (type.IsGenericType && !type.IsGenericTypeDefinition)
        {
            var originalType = type.GetGenericTypeDefinition();
            var originalTypeRef = CreateTypeReference(originalType);

            var typeName = type.Name.Substring(0, type.Name.IndexOf('`'));

            var typeArgumentsRefs = type.GenericTypeArguments.Select(CreateTypeReference).ToList();

            return new GenericTypeReference(type, originalTypeRef, typeArgumentsRefs);
        }
        else if (type.IsGenericType)
        {
            var typeName = type.Name.Substring(0, type.Name.IndexOf('`'));

            var fullTypeName = type.FullName;
            Assert.IsTrue(fullTypeName != null, "Could not get type's full name");

            return new NamedTypeReference(type, typeName, fullTypeName);
        }
        else
        {
            var fullTypeName = type.FullName;
            Assert.IsTrue(fullTypeName != null, "Could not get type's full name");

            return new NamedTypeReference(type, type.Name, fullTypeName);
        }
    }
}
