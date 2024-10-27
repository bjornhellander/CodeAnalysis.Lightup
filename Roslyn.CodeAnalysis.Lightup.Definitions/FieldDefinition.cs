// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System.Diagnostics;

[DebuggerDisplay("{Name}")]
public class FieldDefinition : MemberDefinition
{
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

    public string Name { get; }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public bool IsReadOnly { get; }

    public bool IsStatic { get; }
}
