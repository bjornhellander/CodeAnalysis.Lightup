// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
public class FieldDefinition : MemberDefinition
{
    [Obsolete("Only intended for serializer")]
    public FieldDefinition()
        : base()
    {
        Name = "";
        Type = new NamedTypeReference();
    }

    public FieldDefinition(
        string name,
        TypeReference type,
        bool isNullable,
        bool isReadOnly,
        bool isStatic)
    {
        Name = name;
        Type = type;
        IsNullable = isNullable;
        IsReadOnly = isReadOnly;
        IsStatic = isStatic;
    }

    public string Name { get; set; }

    public TypeReference Type { get; set; }

    public bool IsNullable { get; set; }

    public bool IsReadOnly { get; set; }

    public bool IsStatic { get; set; }
}
