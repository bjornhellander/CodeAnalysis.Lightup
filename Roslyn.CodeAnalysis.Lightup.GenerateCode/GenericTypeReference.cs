// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Collections.Generic;

internal class GenericTypeReference : TypeReference
{
    public GenericTypeReference(Type nativeType, TypeReference originalType, List<TypeReference> typeArguments)
        : base(nativeType)
    {
        OriginalType = originalType;
        TypeArguments = typeArguments;
    }

    public TypeReference OriginalType { get; }

    public List<TypeReference> TypeArguments { get; }
}
