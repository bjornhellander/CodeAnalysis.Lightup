// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
public class EventDefinition : MemberDefinition
{
    [Obsolete("Only intended for serializer")]
    public EventDefinition()
        : base()
    {
        Name = "";
        Type = new NamedTypeReference();
    }

    public EventDefinition(string name, TypeReference type, bool isStatic)
    {
        Name = name;
        Type = type;
        IsStatic = isStatic;
    }

    public string Name { get; set; }

    public TypeReference Type { get; set; }

    public bool IsStatic { get; set; }
}
