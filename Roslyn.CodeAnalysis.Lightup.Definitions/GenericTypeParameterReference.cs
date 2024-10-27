// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;

public class GenericTypeParameterReference : TypeReference
{
    public GenericTypeParameterReference(Type nativeType, string name)
        : base(nativeType)
    {
        Name = name;
    }

    public string Name { get; }
}
