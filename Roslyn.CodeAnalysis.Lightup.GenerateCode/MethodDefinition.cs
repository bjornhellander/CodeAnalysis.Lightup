namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Collections.Generic;

internal class MethodDefinition
{
    public MethodDefinition(string name, bool isStatic, TypeReference? returnType, List<ParameterDefinition> parameters)
    {
        Name = name;
        IsStatic = isStatic;
        ReturnType = returnType;
        Parameters = parameters;
    }

    public string Name { get; }

    public bool IsStatic { get; }

    public TypeReference? ReturnType { get; }

    public List<ParameterDefinition> Parameters { get; }
}
