namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Collections.Generic;

internal class MethodDefinition : MemberDefinition
{
    public MethodDefinition(
        string name,
        bool isStatic,
        TypeReference? returnType,
        bool isNullable,
        List<ParameterDefinition> parameters)
    {
        Name = name;
        IsStatic = isStatic;
        ReturnType = returnType;
        IsNullable = isNullable;
        Parameters = parameters;
    }

    public string Name { get; }

    public bool IsStatic { get; }

    public TypeReference? ReturnType { get; }

    public bool IsNullable { get; }

    public List<ParameterDefinition> Parameters { get; }
}
