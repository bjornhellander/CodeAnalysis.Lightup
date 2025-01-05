// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Collector;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using CodeAnalysis.Lightup.Definitions;

internal class Reflector
{
#pragma warning disable SA1311 // Static readonly fields should begin with upper-case letter
    private static readonly FieldComparer fieldComparer = new();
    private static readonly EventComparer eventComparer = new();
    private static readonly PropertyComparer propertyComparer = new();
    private static readonly IndexerComparer indexerComparer = new();
    private static readonly ConstructorComparer constructorComparer = new();
    private static readonly MethodComparer methodComparer = new();
    private static readonly EnumValueComparer enumValueComparer = new();
#pragma warning restore SA1311 // Static readonly fields should begin with upper-case letter

    private static readonly Dictionary<AssemblyKind, string> AssemblyNames = new()
    {
        [AssemblyKind.Common] = "Microsoft.CodeAnalysis",
        [AssemblyKind.CSharp] = "Microsoft.CodeAnalysis.CSharp",
        [AssemblyKind.WorkspacesCommon] = "Microsoft.CodeAnalysis.Workspaces",
        [AssemblyKind.CSharpWorkspaces] = "Microsoft.CodeAnalysis.CSharp.Workspaces",
    };

    public static Dictionary<string, BaseTypeDefinition> CollectTypes(
        IReadOnlyList<string> referenceProjectNames,
        string rootFolder)
    {
        var isFirst = true;
        var types = new Dictionary<string, BaseTypeDefinition>();
        foreach (var referenceProjectName in referenceProjectNames)
        {
            CollectTypes(referenceProjectName, rootFolder, types, isFirst);
            isFirst = false;
        }

        return types;
    }

    private static void CollectTypes(
        string referenceProjectName,
        string rootFolder,
        Dictionary<string, BaseTypeDefinition> typeDefs,
        bool isBaselineVersion)
    {
        var referenceProjectFolder = Path.Combine(rootFolder, "ref", referenceProjectName, "bin");
        var referenceAssemblyPaths = Directory.GetFiles(referenceProjectFolder, $"{referenceProjectName}.dll", SearchOption.AllDirectories);
        var referenceAssemblyPath = referenceAssemblyPaths.SingleOrDefault();
        Assert.IsTrue(referenceAssemblyPath != null, $"Could not find reference assembly in {referenceProjectFolder}");
        var referenceProjectBinFolder = Path.GetDirectoryName(referenceAssemblyPath);
        Assert.IsTrue(referenceProjectBinFolder != null, "Could not get reference projects's bin folder");

        var assemblyLoadContext = new AssemblyLoadContext(referenceProjectName);
        assemblyLoadContext.Resolving += ResolveAssembly;

        MarkTypesMembersAsRemoved(typeDefs.Values);

        foreach (var assemblyKind in Enum.GetValues<AssemblyKind>())
        {
            CollectTypes(assemblyLoadContext, typeDefs, isBaselineVersion, assemblyKind);
        }

        Assembly? ResolveAssembly(AssemblyLoadContext context, AssemblyName assemblyName)
        {
            var assemblyPath = Path.Combine(referenceProjectBinFolder, assemblyName.Name + ".dll");
            var assembly = context.LoadFromAssemblyPath(assemblyPath);
            return assembly;
        }
    }

    private static void MarkTypesMembersAsRemoved(IEnumerable<BaseTypeDefinition> typeDefs)
    {
        foreach (var typeDef in typeDefs)
        {
            typeDef.IsRemoved = true;

            switch (typeDef)
            {
                case TypeDefinition x:
                    MarkMembersAsRemoved(x);
                    break;

                case EnumTypeDefinition x:
                    MarkValuesAsRemoved(x);
                    break;

                default:
                    Assert.Fail($"Unexpected type {typeDef.GetType()}");
                    break;
            }
        }
    }

    private static void MarkValuesAsRemoved(EnumTypeDefinition enumTypeDef)
    {
        foreach (var enumValueDef in enumTypeDef.Values)
        {
            enumValueDef.IsRemoved = true;
        }
    }

    private static void MarkMembersAsRemoved(TypeDefinition typeDef)
    {
        foreach (var fieldDef in typeDef.Fields)
        {
            fieldDef.IsRemoved = true;
        }

        foreach (var eventDef in typeDef.Events)
        {
            eventDef.IsRemoved = true;
        }

        foreach (var propertyDef in typeDef.Properties)
        {
            propertyDef.IsRemoved = true;
        }

        foreach (var indexerDef in typeDef.Indexers)
        {
            indexerDef.IsRemoved = true;
        }

        foreach (var constructorDef in typeDef.Constructors)
        {
            constructorDef.IsRemoved = true;
        }

        foreach (var methodDef in typeDef.Methods)
        {
            methodDef.IsRemoved = true;
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
        VisitTypes(null, types, typeDefs, assemblyVersion, isBaselineVersion, assemblyKind, CreateEmptyTypeDefinition);
        VisitTypes(null, types, typeDefs, assemblyVersion, isBaselineVersion, assemblyKind, UpdateTypeDefinitions);
    }

    private static void VisitTypes(
        TypeDefinition? enclosingTypeDef,
        List<Type> types,
        Dictionary<string, BaseTypeDefinition> typeDefs,
        Version assemblyVersion,
        bool isBaselineVersion,
        AssemblyKind assemblyKind,
        Action<Type, string, Dictionary<string, BaseTypeDefinition>, TypeDefinition?, Version?, AssemblyKind> visit)
    {
        foreach (var type in types)
        {
            var name = type.FullName;
            Assert.IsTrue(name != null, "Could not get type's full name");

            // TODO: Handle generic types as well
            if (type.IsGenericType)
            {
                continue;
            }

            visit(type, name, typeDefs, enclosingTypeDef, isBaselineVersion ? null : assemblyVersion, assemblyKind);

            var typeDef = typeDefs[name] as TypeDefinition;
            var subTypes = type.GetNestedTypes().ToList();
            VisitTypes(typeDef, subTypes, typeDefs, assemblyVersion, isBaselineVersion, assemblyKind, visit);
        }
    }

    private static void CreateEmptyTypeDefinition(
        Type type,
        string name,
        Dictionary<string, BaseTypeDefinition> typeDefs,
        TypeDefinition? enclosingTypeDef,
        Version? assemblyVersion,
        AssemblyKind assemblyKind)
    {
        if (!typeDefs.ContainsKey(name))
        {
            var typeDef = CreateEmptyTypeDefinition(assemblyKind, assemblyVersion, type, enclosingTypeDef);
            if (typeDef == null)
            {
                return;
            }

            typeDefs.Add(name, typeDef);
        }
    }

    private static BaseTypeDefinition? CreateEmptyTypeDefinition(
        AssemblyKind assemblyKind,
        Version? version,
        Type type,
        TypeDefinition? enclosingTypeDef)
    {
        if (type.IsEnum)
        {
            return CreateEmptyEnumTypeDefinition(assemblyKind, version, type, enclosingTypeDef);
        }
        else if (type.IsClass)
        {
            return CreateEmptyClassTypeDefinition(assemblyKind, version, type, enclosingTypeDef);
        }
        else if (type.IsValueType)
        {
            return CreateEmptyStructTypeDefinition(assemblyKind, version, type, enclosingTypeDef);
        }
        else if (type.IsInterface)
        {
            return CreateEmptyInterfaceTypeDefinition(assemblyKind, version, type, enclosingTypeDef);
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
        Type type,
        TypeDefinition? enclosingTypeDef)
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
            isFlagsEnum,
            enclosingTypeDef?.FullName);
    }

    private static StructTypeDefinition CreateEmptyStructTypeDefinition(
        AssemblyKind assemblyKind,
        Version? version,
        Type type,
        TypeDefinition? enclosingTypeDef)
    {
        return new StructTypeDefinition(
            assemblyKind,
            version,
            type.Name,
            type.Namespace!,
            type.FullName!,
            enclosingTypeDef?.FullName);
    }

    private static ClassTypeDefinition CreateEmptyClassTypeDefinition(
        AssemblyKind assemblyKind,
        Version? version,
        Type type,
        TypeDefinition? enclosingTypeDef)
    {
        return new ClassTypeDefinition(
            assemblyKind,
            version,
            type.Name,
            type.Namespace!,
            type.FullName!,
            IsStaticType(type),
            IsAbstractType(type),
            enclosingTypeDef?.FullName);
    }

    private static InterfaceTypeDefinition CreateEmptyInterfaceTypeDefinition(
        AssemblyKind assemblyKind,
        Version? version,
        Type type,
        TypeDefinition? enclosingTypeDef)
    {
        return new InterfaceTypeDefinition(
            assemblyKind,
            version,
            type.Name,
            type.Namespace!,
            type.FullName!,
            enclosingTypeDef?.FullName);
    }

    private static void UpdateTypeDefinitions(
        Type type,
        string name,
        Dictionary<string, BaseTypeDefinition> typeDefs,
        TypeDefinition? enclosingTypeDef,
        Version? assemblyVersion,
        AssemblyKind assemblyKind)
    {
        _ = enclosingTypeDef;
        _ = assemblyKind;

        if (!typeDefs.TryGetValue(name, out var typeDef))
        {
            Assert.Fail("Could not find type");
        }

        typeDef.IsRemoved = false;

        if (typeDef is EnumTypeDefinition enumTypeDef)
        {
            UpdateEnumType(enumTypeDef, type, assemblyVersion);
        }
        else if (typeDef is StructTypeDefinition structTypeDef)
        {
            UpdateStructType(structTypeDef, type, assemblyVersion);
        }
        else if (typeDef is ClassTypeDefinition classTypeDef)
        {
            UpdateClassType(classTypeDef, type, assemblyVersion);
        }
        else if (typeDef is InterfaceTypeDefinition interfaceTypeDef)
        {
            UpdateInterfaceType(interfaceTypeDef, type, assemblyVersion);
        }
        else
        {
            Assert.Fail("Unhandled type");
        }
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
                duplicateValueDef.IsRemoved = false;

                if (duplicateValueDef.Value != value)
                {
                    duplicateValueDef.Value = value;
                    duplicateValueDef.AssemblyVersion = version;
                }
            }
            else
            {
                var enumValueDef = new EnumValueDefinition(version, name, value);
                enumTypeDef.Values.Add(enumValueDef);
            }
        }

        enumTypeDef.Values.Sort(enumValueComparer);
    }

    private static void UpdateStructType(StructTypeDefinition structTypeDef, Type type, Version? assemblyVersion)
    {
        UpdateType(structTypeDef, type, assemblyVersion);
    }

    private static void UpdateClassType(ClassTypeDefinition classTypeDef, Type type, Version? assemblyVersion)
    {
        UpdateType(classTypeDef, type, assemblyVersion);

        var baseType = GetClassBaseType(type);
        var baseClassRef = baseType != null ? CreateTypeReference(baseType) : null;
        classTypeDef.BaseClass = baseClassRef;

        Assert.IsTrue(classTypeDef.IsStatic == IsStaticType(type), "IsStatic has changed");
        //// TODO: Investigate how to handle a type changing "abstractness"
        classTypeDef.IsAbstract = IsAbstractType(type);
    }

    private static Type? GetClassBaseType(Type type)
    {
        var baseType = type.BaseType;
        if (baseType == null)
        {
            Assert.Fail("Could not get base type");
            return null;
        }
        else if (baseType.FullName == null)
        {
            Assert.Fail("Could not get base type name");
            return null;
        }
        else if (baseType.FullName == "System.Object")
        {
            return null;
        }
        else
        {
            return baseType;
        }
    }

    private static bool IsStaticType(Type type)
    {
        var result = type.IsAbstract && type.IsSealed;
        return result;
    }

    private static bool IsAbstractType(Type type)
    {
        var result = type.IsAbstract && !type.IsSealed;
        return result;
    }

    private static void UpdateInterfaceType(InterfaceTypeDefinition interfaceTypeDef, Type type, Version? assemblyVersion)
    {
        UpdateType(interfaceTypeDef, type, assemblyVersion);

        var baseType = GetInterfaceBaseType(type);
        var baseClassRef = baseType != null ? CreateTypeReference(baseType) : null;
        interfaceTypeDef.BaseInterface = baseClassRef;
    }

    private static Type? GetInterfaceBaseType(Type type)
    {
        if (type.Name == "IFunctionPointerTypeSymbol")
        {
        }

        var types = type.GetInterfaces().ToList();
        while (RemoveIndirectInterfaces(types))
        {
        }

        if (types.Count == 1)
        {
            return types[0];
        }
        else
        {
            return null;
        }

        static bool RemoveIndirectInterfaces(List<Type> types)
        {
            for (var i = 0; i < types.Count; i++)
            {
                var currType = types[i];

                for (var j = 0; j < i; j++)
                {
                    var prevType = types[j];
                    if (prevType.IsAssignableFrom(currType))
                    {
                        types.RemoveAt(j);
                        return true;
                    }
                    else if (currType.IsAssignableFrom(prevType))
                    {
                        types.RemoveAt(i);
                        return true;
                    }
                }
            }

            return false;
        }
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
                    AddOrUpdate(typeDef.Fields, fieldDef, AreEqual, assemblyVersion, fieldComparer);
                    break;

                case EventInfo @event:
                    var eventDef = CreateEventDefinition(@event);
                    AddOrUpdate(typeDef.Events, eventDef, AreEqual, assemblyVersion, eventComparer);
                    break;

                case PropertyInfo property when property.GetIndexParameters().Length == 0:
                    var propertyDef = CreatePropertyDefinition(property);
                    AddOrUpdate(typeDef.Properties, propertyDef, AreEqual, assemblyVersion, propertyComparer);
                    break;

                case PropertyInfo property:
                    var indexerDef = CreateIndexerDefinition(property);
                    AddOrUpdate(typeDef.Indexers, indexerDef, AreEqual, assemblyVersion, indexerComparer);
                    break;

                // TODO: Handle generic methods
                // TODO: Handle methods overridden from System.Object?
                case MethodInfo method:
                    {
                        if (!method.Attributes.HasFlag(MethodAttributes.SpecialName) &&
                            !method.IsGenericMethod &&
                            method.GetBaseDefinition().DeclaringType != typeof(object))
                        {
                            var methodDef = CreateMethodDefinition(method);
                            AddOrUpdate(typeDef.Methods, methodDef, AreEqual, assemblyVersion, methodComparer);
                        }

                        break;
                    }

                case ConstructorInfo constructor:
                    var constructorDef = CreateConstructorDefinition(constructor);
                    AddOrUpdate(typeDef.Constructors, constructorDef, AreEqual, assemblyVersion, constructorComparer);
                    break;

                case Type:
                    // Handled elsewhere, so nothing to do here
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
        Version? assemblyVersion,
        IComparer<T> comparer)
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
            memberDefs.Sort(comparer);
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

        // TODO: Should we handle consts differently?
        var result = new FieldDefinition(
            field.Name,
            typeRef,
            isNullable,
            field.IsLiteral || field.IsInitOnly, // NOTE: const => IsLiteral=true and IsInitOnly=false, readonly => IsLiteral=false and IsInitOnly=true
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
        // NOTE: This might be somewhat over-simplified, but probably good enough for this
        var isExtensionMethod = method.GetCustomAttribute<ExtensionAttribute>() != null;

        var returnTypeRef = method.ReturnType != typeof(void) ? CreateTypeReference(method.ReturnType) : null;

        var nullabilityInfoContext = new NullabilityInfoContext();
        var nullabilityInfo = nullabilityInfoContext.Create(method.ReturnParameter);
        var isNullable = !method.ReturnType.IsValueType && nullabilityInfo.WriteState != NullabilityState.NotNull;

        var parameters = method.GetParameters();
        var parameterDefs = parameters.Select(CreateParameterDefinitions).ToList();

        var result = new MethodDefinition(
            method.Name,
            method.IsStatic,
            isExtensionMethod,
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

            case (true, false, false, false):
                parameterMode = ParameterMode.Ref;
                break;

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
            return new GenericTypeParameterReference(type.Name, type.Name);
        }
        else if (type.IsArray)
        {
            var elementType = type.GetElementType();
            Assert.IsTrue(elementType != null, "Could not get array's element type");
            var elementTypeRef = CreateTypeReference(elementType);

            return new ArrayTypeReference(type.Name, elementTypeRef);
        }
        else if (type.IsGenericType && !type.IsGenericTypeDefinition)
        {
            var originalType = type.GetGenericTypeDefinition();
            var originalTypeRef = CreateTypeReference(originalType);

            var typeName = type.Name[..type.Name.IndexOf('`')];

            var typeArgumentsRefs = type.GenericTypeArguments.Select(CreateTypeReference).ToList();

            return new GenericTypeReference(type.Name, originalTypeRef, typeArgumentsRefs);
        }
        else if (type.IsGenericType)
        {
            var typeName = type.Name[..type.Name.IndexOf('`')];

            var fullTypeName = type.FullName;
            Assert.IsTrue(fullTypeName != null, "Could not get type's full name");

            return new NamedTypeReference(type.Name, typeName, type.Namespace ?? "", fullTypeName);
        }
        else
        {
            var fullTypeName = type.FullName;
            Assert.IsTrue(fullTypeName != null, "Could not get type's full name");

            return new NamedTypeReference(type.Name, type.Name, type.Namespace ?? "", fullTypeName);
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

    private class FieldComparer : IComparer<FieldDefinition>
    {
        public int Compare(FieldDefinition? x, FieldDefinition? y)
        {
            if (x == null || y == null)
            {
                throw new NotSupportedException();
            }

            return x.Name.CompareTo(y.Name);
        }
    }

    private class EventComparer : IComparer<EventDefinition>
    {
        public int Compare(EventDefinition? x, EventDefinition? y)
        {
            if (x == null || y == null)
            {
                throw new NotSupportedException();
            }

            return x.Name.CompareTo(y.Name);
        }
    }

    private class PropertyComparer : IComparer<PropertyDefinition>
    {
        public int Compare(PropertyDefinition? x, PropertyDefinition? y)
        {
            if (x == null || y == null)
            {
                throw new NotSupportedException();
            }

            return x.Name.CompareTo(y.Name);
        }
    }

    private class IndexerComparer : IComparer<IndexerDefinition>
    {
        public int Compare(IndexerDefinition? x, IndexerDefinition? y)
        {
            if (x == null || y == null)
            {
                throw new NotSupportedException();
            }

            var cmp = x.Parameters.Count.CompareTo(y.Parameters.Count);
            if (cmp != 0)
            {
                return cmp;
            }

            for (var i = 0; i < x.Parameters.Count; i++)
            {
                cmp = x.Parameters[i].Name.CompareTo(y.Parameters[i].Name);
                if (cmp != 0)
                {
                    return cmp;
                }
            }

            return 0;
        }
    }

    private class ConstructorComparer : IComparer<ConstructorDefinition>
    {
        public int Compare(ConstructorDefinition? x, ConstructorDefinition? y)
        {
            if (x == null || y == null)
            {
                throw new NotSupportedException();
            }

            var cmp = x.Parameters.Count.CompareTo(y.Parameters.Count);
            if (cmp != 0)
            {
                return cmp;
            }

            for (var i = 0; i < x.Parameters.Count; i++)
            {
                cmp = x.Parameters[i].Name.CompareTo(y.Parameters[i].Name);
                if (cmp != 0)
                {
                    return cmp;
                }
            }

            return 0;
        }
    }

    private class MethodComparer : IComparer<MethodDefinition>
    {
        public int Compare(MethodDefinition? x, MethodDefinition? y)
        {
            if (x == null || y == null)
            {
                throw new NotSupportedException();
            }

            var cmp = x.Name.CompareTo(y.Name);
            if (cmp != 0)
            {
                return cmp;
            }

            cmp = x.Parameters.Count.CompareTo(y.Parameters.Count);
            if (cmp != 0)
            {
                return cmp;
            }

            for (var i = 0; i < x.Parameters.Count; i++)
            {
                cmp = x.Parameters[i].Name.CompareTo(y.Parameters[i].Name);
                if (cmp != 0)
                {
                    return cmp;
                }
            }

            return 0;
        }
    }

    private class EnumValueComparer : IComparer<EnumValueDefinition>
    {
        public int Compare(EnumValueDefinition? x, EnumValueDefinition? y)
        {
            if (x == null || y == null)
            {
                throw new NotSupportedException();
            }

            return x.Name.CompareTo(y.Name);
        }
    }
}
