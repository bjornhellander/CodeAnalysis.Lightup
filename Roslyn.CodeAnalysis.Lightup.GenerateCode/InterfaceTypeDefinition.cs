namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class InterfaceTypeDefinition : TypeDefinition
{
    public InterfaceTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        ImmutableArray<TypeReference> interfaces)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName)
    {
        Interfaces = interfaces;
    }

    public ImmutableArray<TypeReference> Interfaces { get; }

    public List<PropertyDefinition> Properties { get; } = new();

    public List<MethodDefinition> Methods { get; } = new();
}
