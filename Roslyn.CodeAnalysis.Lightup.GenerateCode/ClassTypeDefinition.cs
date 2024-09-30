// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class ClassTypeDefinition : TypeDefinition
{
    public ClassTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        bool isStatic)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName)
    {
        BaseClass = null;
        IsStatic = isStatic;
    }

    public TypeReference? BaseClass { get; set; }

    public bool IsStatic { get; }
}
