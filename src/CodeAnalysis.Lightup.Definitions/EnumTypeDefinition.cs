// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;
using System.Collections.Generic;

public class EnumTypeDefinition : BaseTypeDefinition
{
    [Obsolete("Only intended for serializer")]
    protected EnumTypeDefinition()
    {
        UnderlyingTypeName = "";
    }

    public EnumTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        string underlyingTypeName,
        bool isFlagsEnum,
        string? enclosingTypeFullName)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName, enclosingTypeFullName)
    {
        UnderlyingTypeName = underlyingTypeName;
        IsFlagsEnum = isFlagsEnum;
    }

    public string UnderlyingTypeName { get; set; }

    public bool IsFlagsEnum { get; set; }

    public List<EnumValueDefinition> Values { get; } = [];
}
