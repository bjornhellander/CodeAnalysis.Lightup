// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal abstract class TypeReference
{
    private readonly Type nativeType;

    protected TypeReference(Type nativeType)
    {
        this.nativeType = nativeType;
    }

    public string NativeName => nativeType.Name;

    public bool IsAssignableFrom(TypeReference typeRef)
    {
        return nativeType.IsAssignableFrom(typeRef.nativeType);
    }
}
