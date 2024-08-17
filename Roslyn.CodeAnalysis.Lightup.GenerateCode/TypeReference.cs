namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal abstract class TypeReference
{
    private readonly Type nativeType;

    protected TypeReference(Type nativeType)
    {
        this.nativeType = nativeType;
    }

    public bool IsAssignableFrom(TypeReference typeRef)
    {
        return nativeType.IsAssignableFrom(typeRef.nativeType);
    }
}
