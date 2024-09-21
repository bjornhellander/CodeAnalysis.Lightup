// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class PropertyDefinition : MemberDefinition
{
    public PropertyDefinition(string name, TypeReference type, bool isNullable, bool hasSetter, bool isStatic)
    {
        Name = name;
        Type = type;
        IsNullable = isNullable;
        HasSetter = hasSetter;
        IsStatic = isStatic;
    }

    public string Name { get; }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public bool HasSetter { get; }

    public bool IsStatic { get; }
}
