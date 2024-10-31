// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;

public class GenericTypeParameterReference : TypeReference
{
    [Obsolete("Only intended for serializer")]
    public GenericTypeParameterReference()
        : base()
    {
        Name = "";
    }

    public GenericTypeParameterReference(string nativeName, string name)
        : base(nativeName)
    {
        Name = name;
    }

    public string Name { get; set; }
}
