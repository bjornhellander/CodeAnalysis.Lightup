namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Collections.Generic;

// NOTE: Indexers can not be static
internal class IndexerDefinition : MemberDefinition
{
    public IndexerDefinition(
        TypeReference type,
        bool isNullable,
        List<ParameterDefinition> parameters,
        bool hasSetter)
    {
        Type = type;
        IsNullable = isNullable;
        Parameters = parameters;
        HasSetter = hasSetter;
    }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public List<ParameterDefinition> Parameters { get; }

    public bool HasSetter { get; }
}
