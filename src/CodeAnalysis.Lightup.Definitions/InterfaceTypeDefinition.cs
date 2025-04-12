// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

using System;
using System.Diagnostics;

namespace CodeAnalysis.Lightup.Definitions;

[DebuggerDisplay("{Name}")]
public class InterfaceTypeDefinition : TypeDefinition
{
    [Obsolete("Only intended for serializer")]
    protected InterfaceTypeDefinition()
    {
    }

    public InterfaceTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        string? enclosingTypeFullName)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName, enclosingTypeFullName)
    {
        BaseInterface = null;
    }

    public TypeReference? BaseInterface { get; set; }
}
