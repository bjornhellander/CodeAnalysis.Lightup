// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
public class PropertyDefinition : MemberDefinition
{
    [Obsolete("Only intended for serializer")]
    public PropertyDefinition()
        : base()
    {
        Name = "";
        Type = new NamedTypeReference();
    }

    public PropertyDefinition(
        string name,
        TypeReference type,
        bool isNullable,
        bool hasSetter,
        bool isStatic)
    {
        Name = name;
        Type = type;
        IsNullable = isNullable;
        HasSetter = hasSetter;
        IsStatic = isStatic;
    }

    public string Name { get; set; }

    public TypeReference Type { get; set; }

    public bool IsNullable { get; set; }

    public bool HasSetter { get; set; }

    public bool IsStatic { get; set; }
}
