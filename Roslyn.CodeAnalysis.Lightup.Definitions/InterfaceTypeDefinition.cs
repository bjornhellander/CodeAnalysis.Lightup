// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
public class InterfaceTypeDefinition : TypeDefinition
{
    public InterfaceTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        TypeDefinition? enclosingType)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName, enclosingType)
    {
        BaseInterface = null;
    }

    public TypeReference? BaseInterface { get; set; }
}
