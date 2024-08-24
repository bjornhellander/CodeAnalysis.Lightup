namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Collections.Generic;

internal class IndexerDefinition
{
    public IndexerDefinition(
        string name,
        TypeReference type,
        bool isNullable,
        List<ParameterDefinition> parameters,
        bool hasSetter,
        bool isStatic)
    {
        Name = name;
        Type = type;
        IsNullable = isNullable;
        Parameters = parameters;
        HasSetter = hasSetter;
        IsStatic = isStatic;
    }

    public string Name { get; }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public List<ParameterDefinition> Parameters { get; }

    public bool HasSetter { get; }

    public bool IsStatic { get; }
}
