// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

using System;
using System.Diagnostics;

namespace CodeAnalysis.Lightup.Definitions;

[DebuggerDisplay("{Name}")]
public class NamedTypeReference : TypeReference
{
    [Obsolete("Only intended for serializer")]
    public NamedTypeReference()
        : base()
    {
        Name = "";
        Namespace = "";
        FullName = "";
    }

    public NamedTypeReference(string nativeName, string name, string @namespace, string fullName)
        : base(nativeName)
    {
        Name = name;
        Namespace = @namespace;
        FullName = fullName;
    }

    public string Name { get; set; }

    public string Namespace { get; set; }

    public string FullName { get; set; }
}
