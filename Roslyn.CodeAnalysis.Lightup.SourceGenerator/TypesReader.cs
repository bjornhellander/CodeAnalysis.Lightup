// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.SourceGenerator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Roslyn.CodeAnalysis.Lightup.Definitions;

internal static class TypesReader
{
    private static readonly XNamespace XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";

    public static List<BaseTypeDefinition> Read()
    {
#if true
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("Roslyn.CodeAnalysis.Lightup.SourceGenerator.Types.xml")!;
        var doc = XDocument.Load(stream);
        var rootElement = doc.Root;
        var typeElements = rootElement.Elements()!;
        var typeDefs = typeElements.Select(x => CreateTypeDefinition(x)).ToList();
        return typeDefs;
#else
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("Roslyn.CodeAnalysis.Lightup.SourceGenerator.Types.xml")!;
        var serializer = new XmlSerializer(typeof(List<BaseTypeDefinition>));
        var typeDefs = (List<BaseTypeDefinition>)serializer.Deserialize(stream)!;
        return typeDefs;
#endif
    }

    private static BaseTypeDefinition CreateTypeDefinition(XElement typeElement)
    {
        var typeAttr = typeElement.Attribute(XsiNamespace + "type")?.Value;
        return typeAttr switch
        {
            "EnumTypeDefinition" => CreateEnumTypeDefinition(typeElement),
            "ClassTypeDefinition" => CreateClassTypeDefinition(typeElement),
            "InterfaceTypeDefinition" => CreateInterfaceTypeDefinition(typeElement),
            "StructTypeDefinition" => CreateStructTypeDefinition(typeElement),
            _ => throw new Exception("Unhandled type definition:" + typeAttr),
        };
    }

    private static EnumTypeDefinition CreateEnumTypeDefinition(XElement typeElement)
    {
        ParseBaseTypeDefinition(
            typeElement,
            out var assemblyKind,
            out var assemblyVersion,
            out var name,
            out var @namespace,
            out var fullName,
            out var enclosingTypeFullName);
        var underlyingTypeName = GetChildString(typeElement, "UnderlyingTypeName");
        var isFlagsEnum = GetChildBool(typeElement, "IsFlagsEnum");
        var result = new EnumTypeDefinition(
            assemblyKind,
            assemblyVersion,
            name,
            @namespace,
            fullName,
            underlyingTypeName,
            isFlagsEnum,
            enclosingTypeFullName);

        var values = CreateEnumValueDefinitions(typeElement);
        result.Values.AddRange(values);

        UpdatedBaseTypeDefinition(result, typeElement);

        return result;
    }

    private static List<EnumValueDefinition> CreateEnumValueDefinitions(XElement parent)
    {
        var element = GetChildElement(parent, "Values");
        var elements = GetChildElements(element, "EnumValueDefinition");
        var result = elements.Select(CreateEnumValueDefinition).ToList();
        return result;
    }

    private static EnumValueDefinition CreateEnumValueDefinition(XElement element)
    {
        var assemblyVersion = GetOptionalChildAssemblyVesion(element);
        var name = GetChildString(element, "Name");
        var value = GetChildInt(element, "Value");

        var result = new EnumValueDefinition(assemblyVersion, name, value);
        return result;
    }

    private static ClassTypeDefinition CreateClassTypeDefinition(XElement typeElement)
    {
        ParseBaseTypeDefinition(
            typeElement,
            out var assemblyKind,
            out var assemblyVersion,
            out var name,
            out var @namespace,
            out var fullName,
            out var enclosingTypeFullName);
        var isStatic = GetChildBool(typeElement, "IsStatic");
        var isAbstract = GetChildBool(typeElement, "IsAbstract");
        var result = new ClassTypeDefinition(
            assemblyKind,
            assemblyVersion,
            name,
            @namespace,
            fullName,
            isStatic,
            isAbstract,
            enclosingTypeFullName);

        var baseClass = CreateOptionalTypeReference(typeElement, "BaseClass");
        result.BaseClass = baseClass;

        UpdatedTypeDefinition(result, typeElement);
        UpdatedBaseTypeDefinition(result, typeElement);

        return result;
    }

    private static InterfaceTypeDefinition CreateInterfaceTypeDefinition(XElement typeElement)
    {
        ParseBaseTypeDefinition(
            typeElement,
            out var assemblyKind,
            out var assemblyVersion,
            out var name,
            out var @namespace,
            out var fullName,
            out var enclosingTypeFullName);
        var result = new InterfaceTypeDefinition(
            assemblyKind,
            assemblyVersion,
            name,
            @namespace,
            fullName,
            enclosingTypeFullName);

        var baseInterface = CreateOptionalTypeReference(typeElement, "BaseInterface");
        result.BaseInterface = baseInterface;

        UpdatedTypeDefinition(result, typeElement);
        UpdatedBaseTypeDefinition(result, typeElement);

        return result;
    }

    private static StructTypeDefinition CreateStructTypeDefinition(XElement typeElement)
    {
        ParseBaseTypeDefinition(
            typeElement,
            out var assemblyKind,
            out var assemblyVersion,
            out var name,
            out var @namespace,
            out var fullName,
            out var enclosingTypeFullName);
        var result = new StructTypeDefinition(
            assemblyKind,
            assemblyVersion,
            name,
            @namespace,
            fullName,
            enclosingTypeFullName);

        UpdatedTypeDefinition(result, typeElement);
        UpdatedBaseTypeDefinition(result, typeElement);

        return result;
    }

    private static void UpdatedTypeDefinition(
        TypeDefinition typeDef,
        XElement parent)
    {
        var constructors = CreateConstructorDefinitions(parent);
        typeDef.Constructors.AddRange(constructors);

        var fields = CreateFieldDefinitions(parent);
        typeDef.Fields.AddRange(fields);

        var events = CreateEventDefinitions(parent);
        typeDef.Events.AddRange(events);

        var properties = CreatePropertyDefinitions(parent);
        typeDef.Properties.AddRange(properties);

        var indexers = CreateIndexerDefinitions(parent);
        typeDef.Indexers.AddRange(indexers);

        var methods = CreateMethodDefinitions(parent);
        typeDef.Methods.AddRange(methods);
    }

    private static void UpdatedBaseTypeDefinition(
        BaseTypeDefinition typeDef,
        XElement parent)
    {
        var generatedName = GetChildString(parent, "GeneratedName");
        typeDef.GeneratedName = generatedName;

        var isUpdated = GetChildBool(parent, "IsUpdated");
        typeDef.IsUpdated = isUpdated;

        var generatedFileName = GetChildString(parent, "GeneratedFileName");
        typeDef.GeneratedFileName = generatedFileName;
    }

    private static List<ConstructorDefinition> CreateConstructorDefinitions(XElement parent)
    {
        var element = GetChildElement(parent, "Constructors");
        var elements = GetChildElements(element, "ConstructorDefinition");
        var result = elements.Select(CreateConstructorDefinition).ToList();
        return result;
    }

    private static ConstructorDefinition CreateConstructorDefinition(XElement element)
    {
        var isStatic = GetChildBool(element, "IsStatic");
        var parameters = CreateParameterDefinitions(element);

        var result = new ConstructorDefinition(
            parameters,
            isStatic);

        var assemblyVersion = GetOptionalChildAssemblyVesion(element);
        result.AssemblyVersion = assemblyVersion;

        return result;
    }

    private static List<FieldDefinition> CreateFieldDefinitions(XElement parent)
    {
        var element = GetChildElement(parent, "Fields");
        var elements = GetChildElements(element, "FieldDefinition");
        var result = elements.Select(CreateFieldDefinition).ToList();
        return result;
    }

    private static FieldDefinition CreateFieldDefinition(XElement element)
    {
        var name = GetChildString(element, "Name");
        var typeRef = CreateTypeReference(element, "Type");
        var isStatic = GetChildBool(element, "IsStatic");
        var isNullable = GetChildBool(element, "IsNullable");
        var isReadOnly = GetChildBool(element, "IsReadOnly");

        var result = new FieldDefinition(
            name,
            typeRef,
            isNullable,
            isReadOnly,
            isStatic);

        var assemblyVersion = GetOptionalChildAssemblyVesion(element);
        result.AssemblyVersion = assemblyVersion;

        return result;
    }

    private static List<EventDefinition> CreateEventDefinitions(XElement parent)
    {
        var element = GetChildElement(parent, "Events");
        var elements = GetChildElements(element, "EventDefinition");
        var result = elements.Select(CreateEventDefinition).ToList();
        return result;
    }

    private static EventDefinition CreateEventDefinition(XElement element)
    {
        var name = GetChildString(element, "Name");
        var typeRef = CreateTypeReference(element, "Type");
        var isStatic = GetChildBool(element, "IsStatic");

        var result = new EventDefinition(
            name,
            typeRef,
            isStatic);

        var assemblyVersion = GetOptionalChildAssemblyVesion(element);
        result.AssemblyVersion = assemblyVersion;

        return result;
    }

    private static List<PropertyDefinition> CreatePropertyDefinitions(XElement parent)
    {
        var element = GetChildElement(parent, "Properties");
        var elements = GetChildElements(element, "PropertyDefinition");
        var result = elements.Select(CreatePropertyDefinition).ToList();
        return result;
    }

    private static PropertyDefinition CreatePropertyDefinition(XElement element)
    {
        var name = GetChildString(element, "Name");
        var typeRef = CreateTypeReference(element, "Type");
        var isNullable = GetChildBool(element, "IsNullable");
        var hasSetter = GetChildBool(element, "HasSetter");
        var isStatic = GetChildBool(element, "IsStatic");

        var result = new PropertyDefinition(
            name,
            typeRef,
            isNullable,
            hasSetter,
            isStatic);

        var assemblyVersion = GetOptionalChildAssemblyVesion(element);
        result.AssemblyVersion = assemblyVersion;

        return result;
    }

    private static List<IndexerDefinition> CreateIndexerDefinitions(XElement parent)
    {
        var element = GetChildElement(parent, "Indexers");
        var elements = GetChildElements(element, "IndexerDefinition");
        var result = elements.Select(CreateIndexerDefinition).ToList();
        return result;
    }

    private static IndexerDefinition CreateIndexerDefinition(XElement element)
    {
        var typeRef = CreateTypeReference(element, "Type");
        var isNullable = GetChildBool(element, "IsNullable");
        var parameters = CreateParameterDefinitions(element);
        var hasSetter = GetChildBool(element, "HasSetter");

        var result = new IndexerDefinition(
            typeRef,
            isNullable,
            parameters,
            hasSetter);

        var assemblyVersion = GetOptionalChildAssemblyVesion(element);
        result.AssemblyVersion = assemblyVersion;

        return result;
    }

    private static List<MethodDefinition> CreateMethodDefinitions(XElement parent)
    {
        var element = GetChildElement(parent, "Methods");
        var elements = GetChildElements(element, "MethodDefinition");
        var result = elements.Select(CreateMethodDefinition).ToList();
        return result;
    }

    private static MethodDefinition CreateMethodDefinition(XElement element)
    {
        var name = GetChildString(element, "Name");
        var isStatic = GetChildBool(element, "IsStatic");
        var isExtensionMethod = GetChildBool(element, "IsExtensionMethod");
        var returnTypeRef = CreateOptionalTypeReference(element, "ReturnType");
        var isNullable = GetChildBool(element, "IsNullable");
        var parameters = CreateParameterDefinitions(element);

        var result = new MethodDefinition(
            name,
            isStatic,
            isExtensionMethod,
            returnTypeRef,
            isNullable,
            parameters);

        var assemblyVersion = GetOptionalChildAssemblyVesion(element);
        result.AssemblyVersion = assemblyVersion;

        return result;
    }

    private static List<ParameterDefinition> CreateParameterDefinitions(XElement parent)
    {
        var element = GetChildElement(parent, "Parameters");
        var elements = GetChildElements(element, "ParameterDefinition");
        var result = elements.Select(CreateParameterDefinition).ToList();
        return result;
    }

    private static ParameterDefinition CreateParameterDefinition(XElement element)
    {
        var name = GetChildString(element, "Name");
        var isParams = GetChildBool(element, "IsParams");
        var typeRef = CreateTypeReference(element, "Type");
        var isNullable = GetChildBool(element, "IsNullable");
        var mode = GetChildEnum<ParameterMode>(element, "Mode");

        var result = new ParameterDefinition(
            name,
            isParams,
            typeRef,
            isNullable,
            mode);
        return result;
    }

    private static void ParseBaseTypeDefinition(
        XElement element,
        out AssemblyKind assemblyKind,
        out Version? assemblyVersion,
        out string name,
        out string @namespace,
        out string fullName,
        out string? enclosingTypeFullName)
    {
        assemblyKind = GetChildEnum<AssemblyKind>(element, "AssemblyKind");
        assemblyVersion = GetOptionalChildAssemblyVesion(element);
        name = GetChildString(element, "Name");
        @namespace = GetChildString(element, "Namespace");
        fullName = GetChildString(element, "FullName");
        enclosingTypeFullName = GetOptionalChildString(element, "EnclosingTypeFullName");
    }

    private static TypeReference CreateTypeReference(XElement parent, string name)
    {
        var result = CreateOptionalTypeReference(parent, name);
        return result ?? throw new NullReferenceException();
    }

    private static TypeReference? CreateOptionalTypeReference(XElement parent, string name)
    {
        var element = GetOptionalChildElement(parent, name);
        if (element == null)
        {
            return null;
        }

        return CreateTypeReference(element);
    }

    private static TypeReference CreateTypeReference(XElement element)
    {
        var typeAttr = element.Attribute(XsiNamespace + "type")?.Value;
        return typeAttr switch
        {
            "NamedTypeReference" => CreateNamedTypeReference(element),
            "GenericTypeReference" => CreateGenericTypeReference(element),
            "ArrayTypeReference" => CreateArrayTypeReference(element),
            _ => throw new Exception("Unhandled type reference:" + typeAttr),
        };
    }

    private static NamedTypeReference CreateNamedTypeReference(XElement element)
    {
        var nativeName = GetChildString(element, "NativeName");
        var name = GetChildString(element, "Name");
        var @namespace = GetChildString(element, "Namespace");
        var fullName = GetChildString(element, "FullName");

        var result = new NamedTypeReference(
            nativeName,
            name,
            @namespace,
            fullName);
        return result;
    }

    private static GenericTypeReference CreateGenericTypeReference(XElement element)
    {
        var nativeName = GetChildString(element, "NativeName");
        var originalTypeRef = CreateTypeReference(element, "OriginalType");
        var typeParameters = CreateTypeArguments(element);

        var result = new GenericTypeReference(
            nativeName,
            originalTypeRef,
            typeParameters);
        return result;
    }

    private static ArrayTypeReference CreateArrayTypeReference(XElement element)
    {
        var nativeName = GetChildString(element, "NativeName");
        var elementTypeRef = CreateTypeReference(element, "ElementType");

        var result = new ArrayTypeReference(
            nativeName,
            elementTypeRef);
        return result;
    }

    private static List<TypeReference> CreateTypeArguments(XElement parent)
    {
        var element = GetChildElement(parent, "TypeArguments");
        var elements = GetChildElements(element, "TypeReference");
        var result = elements.Select(CreateTypeReference).ToList();
        return result;
    }

    private static IEnumerable<XElement> GetChildElements(XElement parent, string name)
    {
        var result = parent.Elements(name);
        return result;
    }

    private static XElement GetChildElement(XElement parent, string name)
    {
        var result = GetOptionalChildElement(parent, name);
        return result ?? throw new NullReferenceException();
    }

    private static XElement? GetOptionalChildElement(XElement parent, string name)
    {
        var result = parent.Element(name);
        return result;
    }

    private static string GetChildString(XElement parent, string name)
    {
        var result = GetOptionalChildString(parent, name);
        return result ?? throw new NullReferenceException();
    }

    private static string? GetOptionalChildString(XElement parent, string name)
    {
        var child = parent.Element(name);
        return child?.Value;
    }

    private static int GetChildInt(XElement parent, string name)
    {
        var child = parent.Element(name);
        var strValue = child.Value;
        var result = int.Parse(strValue);
        return result;
    }

    private static bool GetChildBool(XElement parent, string name)
    {
        var child = parent.Element(name);
        var strValue = child.Value;
        var result = bool.Parse(strValue);
        return result;
    }

    private static T GetChildEnum<T>(XElement parent, string name)
    {
        var strValue = parent.Element(name).Value;
        var result = (T)Enum.Parse(typeof(T), strValue);
        return result;
    }

    private static Version? GetOptionalChildAssemblyVesion(XElement parent)
    {
        var strValue = parent.Element("AssemblyVersion")?.Value;
        var result = strValue != null ? new Version(strValue) : null;
        return result;
    }
}
