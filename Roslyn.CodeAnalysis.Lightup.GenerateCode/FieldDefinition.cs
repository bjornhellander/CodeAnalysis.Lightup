﻿namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class FieldDefinition : MemberDefinition
{
    public FieldDefinition(string name, TypeReference type, bool isNullable, bool isStatic)
    {
        Name = name;
        Type = type;
        IsNullable = isNullable;
        IsStatic = isStatic;
    }

    public string Name { get; }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public bool IsStatic { get; }
}