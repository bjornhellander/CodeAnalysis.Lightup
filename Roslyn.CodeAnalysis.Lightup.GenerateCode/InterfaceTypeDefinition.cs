// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
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
}
