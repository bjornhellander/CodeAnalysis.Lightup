// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;
using System.Xml.Serialization;

[XmlInclude(typeof(ArrayTypeReference))]
[XmlInclude(typeof(GenericTypeReference))]
[XmlInclude(typeof(GenericTypeParameterReference))]
[XmlInclude(typeof(NamedTypeReference))]
public abstract class TypeReference
{
    [Obsolete("Only intended for serializer")]
    protected TypeReference()
    {
        NativeName = "";
    }

    protected TypeReference(Type nativeType)
    {
        NativeName = nativeType.Name;
    }

    public string NativeName { get; set; }
}
