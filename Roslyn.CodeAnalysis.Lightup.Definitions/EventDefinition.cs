// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System.Diagnostics;

[DebuggerDisplay("{Name}")]
public class EventDefinition : MemberDefinition
{
    public EventDefinition(string name, TypeReference type, bool isStatic)
    {
        Name = name;
        Type = type;
        IsStatic = isStatic;
    }

    public string Name { get; }

    public TypeReference Type { get; }

    public bool IsStatic { get; }
}
