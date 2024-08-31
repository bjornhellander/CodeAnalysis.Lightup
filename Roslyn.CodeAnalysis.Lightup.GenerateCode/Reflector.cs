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
        Dictionary<string, BaseTypeDefinition> typeDefs,
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
        Dictionary<string, BaseTypeDefinition> typeDefs,
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

            // TODO: Handle generic types as well
            if (type.IsGenericType)
            {
                continue;
            }

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
            else if (typeDef is StructTypeDefinition structTypeDef)
            {
                UpdateStructType(structTypeDef, type, isBaselineVersion ? null : assemblyVersion);
            }
            else if (typeDef is ClassTypeDefinition classTypeDef)
            {
                UpdateClassType(classTypeDef, type, isBaselineVersion ? null : assemblyVersion);
            }
            else if (typeDef is InterfaceTypeDefinition interfaceTypeDef)
            {
                UpdateInterfaceType(interfaceTypeDef, type, isBaselineVersion ? null : assemblyVersion);
            }
            else
            {
                Assert.Fail("Unhandled type");
            }
        }
    }

    private static BaseTypeDefinition? CreateEmptyTypeDefinition(
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
            return CreateEmptyStructTypeDefinition(assemblyKind, version, type);
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

    private static StructTypeDefinition CreateEmptyStructTypeDefinition(
        AssemblyKind assemblyKind,
        Version? version,
        Type type)
    {
        return new StructTypeDefinition(
            assemblyKind,
            version,
            type.Name,
            type.Namespace!,
            type.FullName!);
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

    private static void UpdateStructType(StructTypeDefinition structTypeDef, Type type, Version? assemblyVersion)
    {
        UpdateType(structTypeDef, type, assemblyVersion);
    }

    private static void UpdateClassType(ClassTypeDefinition classTypeDef, Type type, Version? assemblyVersion)
    {
        UpdateType(classTypeDef, type, assemblyVersion);

        Assert.IsTrue(classTypeDef.IsStatic == IsStaticType(type), "IsStatic has changed");
    }

    private static bool IsStaticType(Type type)
    {
        var result = type.IsAbstract && type.IsSealed;
        return result;
    }

    private static void UpdateInterfaceType(InterfaceTypeDefinition interfaceTypeDef, Type type, Version? assemblyVersion)
    {
        UpdateType(interfaceTypeDef, type, assemblyVersion);
    }

    private static void UpdateType(TypeDefinition typeDef, Type type, Version? assemblyVersion)
    {
        var memberInfos = type
            .GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .OrderBy(x => x.Name)
            .ToList();
        foreach (var memberInfo in memberInfos)
        {
            switch (memberInfo)
            {
                case FieldInfo field:
                    var fieldDef = CreateFieldDefinition(field);
                    AddOrUpdate(typeDef.Fields, fieldDef, AreEqual, assemblyVersion);
                    break;

                case EventInfo @event:
                    var eventDef = CreateEventDefinition(@event);
                    AddOrUpdate(typeDef.Events, eventDef, AreEqual, assemblyVersion);
                    break;

                case PropertyInfo property when property.GetIndexParameters().Length == 0:
                    var propertyDef = CreatePropertyDefinition(property);
                    AddOrUpdate(typeDef.Properties, propertyDef, AreEqual, assemblyVersion);
                    break;

                case PropertyInfo property:
                    var indexerDef = CreateIndexerDefinition(property);
                    AddOrUpdate(typeDef.Indexers, indexerDef, AreEqual, assemblyVersion);
                    break;

                // TODO: Handle generic methods
                // TODO: Handle methods overridden from System.Object
                case MethodInfo method:
                    {
                        if (!method.Attributes.HasFlag(MethodAttributes.SpecialName) &&
                            !method.IsGenericMethod &&
                            method.GetBaseDefinition().DeclaringType != typeof(object))
                        {
                            var methodDef = CreateMethodDefinition(method);
                            AddOrUpdate(typeDef.Methods, methodDef, AreEqual, assemblyVersion);
                        }

                        break;
                    }

                case ConstructorInfo constructor:
                    var constructorDef = CreateConstructorDefinition(constructor);
                    AddOrUpdate(typeDef.Constructors, constructorDef, AreEqual, assemblyVersion);
                    break;

                // TODO: Check if we need to handle anything else
                case Type:
                    break;

                default:
                    Assert.Fail($"Unexpected member type {memberInfo.GetType().Name}");
                    break;
            }
        }
    }

    private static void AddOrUpdate<T>(
        List<T> memberDefs,
        T memberDef,
        Func<T, T, bool> areEqual,
        Version? assemblyVersion)
        where T : MemberDefinition
    {
        var equalDef = memberDefs.SingleOrDefault(x => areEqual(x, memberDef));
        if (equalDef != null)
        {
            var i = memberDefs.IndexOf(equalDef);
            memberDefs[i] = memberDef;
            memberDef.AssemblyVersion = equalDef.AssemblyVersion;
        }
        else
        {
            memberDefs.Add(memberDef);
            memberDef.AssemblyVersion = assemblyVersion;
        }
    }

    private static ConstructorDefinition CreateConstructorDefinition(ConstructorInfo constructor)
    {
        var parameters = constructor.GetParameters();
        var parameterDefs = parameters.Select(CreateParameterDefinitions).ToList();

        var result = new ConstructorDefinition(
            parameterDefs,
            constructor.IsStatic);
        return result;
    }

    private static bool AreEqual(ConstructorDefinition x, ConstructorDefinition y)
    {
        if (x.IsStatic != y.IsStatic)
        {
            return false;
        }

        if (x.Parameters.Count != y.Parameters.Count)
        {
            return false;
        }

        for (var i = 0; i < x.Parameters.Count; i++)
        {
            if (!AreEqual(x.Parameters[i].Type, y.Parameters[i].Type))
            {
                return false;
            }
        }

        return true;
    }

    private static FieldDefinition CreateFieldDefinition(FieldInfo field)
    {
        var typeRef = CreateTypeReference(field.FieldType);

        var nullabilityInfo = new NullabilityInfoContext().Create(field);
        var isNullable = !field.FieldType.IsValueType && nullabilityInfo.ReadState != NullabilityState.NotNull;

        var result = new FieldDefinition(
            field.Name,
            typeRef,
            isNullable,
            field.IsStatic);
        return result;
    }

    private static bool AreEqual(FieldDefinition x, FieldDefinition y)
    {
        if (x.Name != y.Name)
        {
            return false;
        }

        if (!AreEqual(x.Type, y.Type))
        {
            return false;
        }

        if (x.IsStatic != y.IsStatic)
        {
            return false;
        }

        return true;
    }

    private static EventDefinition CreateEventDefinition(EventInfo @event)
    {
        Assert.IsTrue(@event.EventHandlerType != null, "Expected an event handler type");
        var typeRef = CreateTypeReference(@event.EventHandlerType);

        var method = @event.AddMethod ?? @event.RemoveMethod;
        Assert.IsTrue(method != null, "Expected add or remove method");

        var result = new EventDefinition(
            @event.Name,
            typeRef,
            method.IsStatic);
        return result;
    }

    private static bool AreEqual(EventDefinition x, EventDefinition y)
    {
        if (x.Name != y.Name)
        {
            return false;
        }

        if (x.IsStatic != y.IsStatic)
        {
            return false;
        }

        if (!AreEqual(x.Type, y.Type))
        {
            return false;
        }

        return true;
    }

    private static PropertyDefinition CreatePropertyDefinition(PropertyInfo property)
    {
        var typeRef = CreateTypeReference(property.PropertyType);

        var nullabilityInfo = new NullabilityInfoContext().Create(property);
        var isNullable = !property.PropertyType.IsValueType && nullabilityInfo.ReadState != NullabilityState.NotNull;

        var accessor = property.GetMethod;
        Assert.IsTrue(accessor != null, "Expected a getter");

        var result = new PropertyDefinition(
            property.Name,
            typeRef,
            isNullable,
            property.SetMethod?.IsPublic ?? false,
            accessor.IsStatic);
        return result;
    }

    private static bool AreEqual(PropertyDefinition x, PropertyDefinition y)
    {
        if (x.Name != y.Name)
        {
            return false;
        }

        if (x.IsStatic != y.IsStatic)
        {
            return false;
        }

        if (!AreEqual(x.Type, y.Type))
        {
            return false;
        }

        return true;
    }

    private static IndexerDefinition CreateIndexerDefinition(PropertyInfo property)
    {
        var typeRef = CreateTypeReference(property.PropertyType);

        var nullabilityInfo = new NullabilityInfoContext().Create(property);
        var isNullable = !property.PropertyType.IsValueType && nullabilityInfo.ReadState != NullabilityState.NotNull;

        var accessor = property.GetMethod;
        Assert.IsTrue(accessor != null, "Expected a getter");

        var parameters = property.GetIndexParameters();
        var parameterDefs = parameters.Select(CreateParameterDefinitions).ToList();

        var result = new IndexerDefinition(
            typeRef,
            isNullable,
            parameterDefs,
            property.SetMethod?.IsPublic ?? false);
        return result;
    }

    private static bool AreEqual(IndexerDefinition x, IndexerDefinition y)
    {
        if (!AreEqual(x.Type, y.Type))
        {
            return false;
        }

        if (x.Parameters.Count != y.Parameters.Count)
        {
            return false;
        }

        for (var i = 0; i < x.Parameters.Count; i++)
        {
            if (!AreEqual(x.Parameters[i].Type, y.Parameters[i].Type))
            {
                return false;
            }
        }

        return true;
    }

    private static MethodDefinition CreateMethodDefinition(MethodInfo method)
    {
        var returnTypeRef = method.ReturnType != typeof(void) ? CreateTypeReference(method.ReturnType) : null;

        var nullabilityInfoContext = new NullabilityInfoContext();
        var nullabilityInfo = nullabilityInfoContext.Create(method.ReturnParameter);
        var isNullable = !method.ReturnType.IsValueType && nullabilityInfo.WriteState != NullabilityState.NotNull;

        var parameters = method.GetParameters();
        var parameterDefs = parameters.Select(CreateParameterDefinitions).ToList();

        var result = new MethodDefinition(
            method.Name,
            method.IsStatic,
            returnTypeRef,
            isNullable,
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

    private static bool AreEqual(MethodDefinition x, MethodDefinition y)
    {
        if (x.Name != y.Name)
        {
            return false;
        }

        if (x.IsStatic != y.IsStatic)
        {
            return false;
        }

        if (!AreEqual(x.ReturnType, y.ReturnType))
        {
            return false;
        }

        if (x.Parameters.Count != y.Parameters.Count)
        {
            return false;
        }

        for (var i = 0; i < x.Parameters.Count; i++)
        {
            if (!AreEqual(x.Parameters[i].Type, y.Parameters[i].Type))
            {
                return false;
            }
        }

        return true;
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

            var typeName = type.Name[..type.Name.IndexOf('`')];

            var typeArgumentsRefs = type.GenericTypeArguments.Select(CreateTypeReference).ToList();

            return new GenericTypeReference(type, originalTypeRef, typeArgumentsRefs);
        }
        else if (type.IsGenericType)
        {
            var typeName = type.Name[..type.Name.IndexOf('`')];

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

    private static bool AreEqual(TypeReference? x, TypeReference? y)
    {
        if (x == null && y == null)
        {
            return true;
        }

        if (x == null || y == null)
        {
            return false;
        }

        return x switch
        {
            NamedTypeReference x2 => y is NamedTypeReference y2 && AreEqual(x2, y2),
            GenericTypeReference x2 => y is GenericTypeReference y2 && AreEqual(x2, y2),
            ArrayTypeReference x2 => y is ArrayTypeReference y2 && AreEqual(x2, y2),
            _ => throw new NotImplementedException(),
        };
    }

    private static bool AreEqual(NamedTypeReference x, NamedTypeReference y)
    {
        return x.FullName == y.FullName;
    }

    private static bool AreEqual(GenericTypeReference x, GenericTypeReference y)
    {
        if (!AreEqual(x.OriginalType, y.OriginalType))
        {
            return false;
        }

        if (x.TypeArguments.Count != y.TypeArguments.Count)
        {
            return false;
        }

        for (var i = 0; i < x.TypeArguments.Count; i++)
        {
            if (!AreEqual(x.TypeArguments[i], y.TypeArguments[i]))
            {
                return false;
            }
        }

        return true;
    }

    private static bool AreEqual(ArrayTypeReference x, ArrayTypeReference y)
    {
        return AreEqual(x.ElementType, y.ElementType);
    }
}
