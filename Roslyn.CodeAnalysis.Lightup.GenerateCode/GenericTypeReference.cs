namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Collections.Generic;

internal class GenericTypeReference : TypeReference
{
    public GenericTypeReference(TypeReference originalType, List<TypeReference> typeArguments)
    {
        OriginalType = originalType;
        TypeArguments = typeArguments;
    }

    public TypeReference OriginalType { get; }

    public List<TypeReference> TypeArguments { get; }
}
