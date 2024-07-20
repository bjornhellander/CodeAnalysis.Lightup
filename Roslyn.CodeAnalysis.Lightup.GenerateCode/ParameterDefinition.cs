namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class ParameterDefinition
{
    public ParameterDefinition(string name, TypeReference type, bool isNullable, ParameterMode mode)
    {
        Name = name;
        Type = type;
        IsNullable = isNullable;
        Mode = mode;
    }

    public string Name { get; }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public ParameterMode Mode { get; }
}
