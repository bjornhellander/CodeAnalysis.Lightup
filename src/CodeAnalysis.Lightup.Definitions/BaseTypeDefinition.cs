// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;
using System.Xml.Serialization;

[XmlInclude(typeof(ClassTypeDefinition))]
[XmlInclude(typeof(StructTypeDefinition))]
[XmlInclude(typeof(InterfaceTypeDefinition))]
[XmlInclude(typeof(EnumTypeDefinition))]
public abstract class BaseTypeDefinition
{
    [Obsolete("Only intended for serializer")]
    protected BaseTypeDefinition()
    {
        Name = "";
        Namespace = "";
        FullName = "";
    }

    protected BaseTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        string? enclosingTypeName)
    {
        AssemblyKind = assemblyKind;
        AssemblyVersion = assemblyVersion;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        EnclosingTypeFullName = enclosingTypeName;
    }

    public AssemblyKind AssemblyKind { get; set; }

    [XmlIgnore]
    public Version? AssemblyVersion { get; set; }

    [XmlElement("AssemblyVersion")]
    public string? AssemblyVersionString
    {
        get => AssemblyVersion?.ToString();
        set => AssemblyVersion = string.IsNullOrEmpty(value) ? null : new Version(value);
    }

    public string Name { get; set; }

    public string Namespace { get; set; }

    public string FullName { get; set; }

    public string? EnclosingTypeFullName { get; set; }

    [XmlIgnore]
    public string GeneratedName { get; set; } = "";

    [XmlIgnore]
    public bool IsUpdated { get; set; }

    [XmlIgnore]
    public string GeneratedFileName { get; set; } = "";
}
