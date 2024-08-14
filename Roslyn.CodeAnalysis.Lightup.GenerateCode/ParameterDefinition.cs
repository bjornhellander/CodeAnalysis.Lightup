namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class ParameterDefinition
{
    public ParameterDefinition(string name, bool isParams, TypeReference type, bool isNullable, ParameterMode mode)
    {
        Name = name;
        IsParams = isParams;
        Type = type;
        IsNullable = isNullable;
        Mode = mode;
    }

    public string Name { get; }

    public bool IsParams { get; }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public ParameterMode Mode { get; }
}
