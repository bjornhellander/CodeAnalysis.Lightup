// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
public class ClassTypeDefinition : TypeDefinition
{
    [Obsolete("Only intended for serializer")]
    public ClassTypeDefinition()
        : base()
    {
    }

    public ClassTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        bool isStatic,
        bool isAbstract,
        string? enclosingTypeFullName)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName, enclosingTypeFullName)
    {
        BaseClass = null;
        IsStatic = isStatic;
        IsAbstract = isAbstract;
    }

    public TypeReference? BaseClass { get; set; }

    public bool IsStatic { get; set; }

    public bool IsAbstract { get; set; }
}
