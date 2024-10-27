// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;
using System.Xml.Serialization;

public abstract class MemberDefinition
{
    [XmlIgnore]
    public Version? AssemblyVersion { get; set; }

    [XmlElement("AssemblyVersion")]
    public string? AssemblyVersionString
    {
        get => AssemblyVersion?.ToString();
        set => AssemblyVersion = string.IsNullOrEmpty(value) ? null : new Version(value);
    }
}
