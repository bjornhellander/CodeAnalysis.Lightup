namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Collections.Generic;

internal class ConstructorDefinition : MemberDefinition
{
    public ConstructorDefinition(List<ParameterDefinition> parameters, bool isStatic)
    {
        Parameters = parameters;
        IsStatic = isStatic;
    }

    public List<ParameterDefinition> Parameters { get; }

    public bool IsStatic { get; }
}
