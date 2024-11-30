// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
public class StructTypeDefinition : TypeDefinition
{
    [Obsolete("Only intended for serializer")]
    protected StructTypeDefinition()
        : base()
    {
    }

    public StructTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        string? enclosingTypeFullName)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName, enclosingTypeFullName)
    {
    }
}
