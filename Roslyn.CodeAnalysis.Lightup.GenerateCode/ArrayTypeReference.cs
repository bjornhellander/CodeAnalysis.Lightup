namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class ArrayTypeReference : TypeReference
{
    public ArrayTypeReference(TypeReference elementType)
    {
        ElementType = elementType;
    }

    public TypeReference ElementType { get; }
}
