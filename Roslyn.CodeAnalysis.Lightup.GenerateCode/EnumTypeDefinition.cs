// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Collections.Generic;

internal class EnumTypeDefinition : BaseTypeDefinition
{
    public EnumTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        string underlyingTypeName,
        bool isFlagsEnum)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName)
    {
        UnderlyingTypeName = underlyingTypeName;
        IsFlagsEnum = isFlagsEnum;
    }

    public string UnderlyingTypeName { get; }

    public bool IsFlagsEnum { get; }

    public List<EnumValueDefinition> Values { get; } = [];
}
