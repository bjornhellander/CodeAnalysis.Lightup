namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal class ArrayTypeReference : TypeReference
{
    public ArrayTypeReference(Type nativeType, TypeReference elementType)
        : base(nativeType)
    {
        ElementType = elementType;
    }

    public TypeReference ElementType { get; }
}
