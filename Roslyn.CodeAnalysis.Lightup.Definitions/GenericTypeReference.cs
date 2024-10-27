// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;
using System.Collections.Generic;

public class GenericTypeReference : TypeReference
{
    [Obsolete("Only intended for serializer")]
    public GenericTypeReference()
        : base()
    {
        OriginalType = new NamedTypeReference();
        TypeArguments = [];
    }

    public GenericTypeReference(Type nativeType, TypeReference originalType, List<TypeReference> typeArguments)
        : base(nativeType)
    {
        OriginalType = originalType;
        TypeArguments = typeArguments;
    }

    public TypeReference OriginalType { get; set; }

    public List<TypeReference> TypeArguments { get; }
}
