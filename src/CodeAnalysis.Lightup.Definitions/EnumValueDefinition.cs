// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;
using System.Xml.Serialization;

public class EnumValueDefinition
{
    [Obsolete("Only intended for serializer")]
    public EnumValueDefinition()
        : base()
    {
        Name = "";
    }

    public EnumValueDefinition(Version? assemblyVersion, string name, int value)
    {
        AssemblyVersion = assemblyVersion;
        Name = name;
        Value = value;
    }

    [XmlIgnore]
    public Version? AssemblyVersion { get; set; }

    [XmlElement("AssemblyVersion")]
    public string? AssemblyVersionString
    {
        get => AssemblyVersion?.ToString();
        set => AssemblyVersion = string.IsNullOrEmpty(value) ? null : new Version(value);
    }

    public bool IsRemoved { get; set; }

    public string Name { get; set; }

    public int Value { get; set; }
}
