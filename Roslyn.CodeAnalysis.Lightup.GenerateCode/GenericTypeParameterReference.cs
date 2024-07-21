namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class GenericTypeParameterReference : TypeReference
{
    public GenericTypeParameterReference(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
