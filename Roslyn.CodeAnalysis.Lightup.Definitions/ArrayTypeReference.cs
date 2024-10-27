// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;

public class ArrayTypeReference : TypeReference
{
    public ArrayTypeReference(Type nativeType, TypeReference elementType)
        : base(nativeType)
    {
        ElementType = elementType;
    }

    public TypeReference ElementType { get; }
}
