// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class NamedTypeReference : TypeReference
{
    public NamedTypeReference(Type nativeType, string name, string @namespace, string fullName)
        : base(nativeType)
    {
        Name = name;
        Namespace = @namespace;
        FullName = fullName;
    }

    public string Name { get; }

    public string Namespace { get; }

    public string FullName { get; }
}
