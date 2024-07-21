namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class PropertyDefinition
{
    public PropertyDefinition(string name, TypeReference type, bool isNullable, bool isStatic)
    {
        Name = name;
        Type = type;
        IsNullable = isNullable;
        IsStatic = isStatic;
    }

    public string Name { get; }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public bool IsStatic { get; }
}
