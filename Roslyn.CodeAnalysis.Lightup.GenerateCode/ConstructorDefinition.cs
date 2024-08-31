namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Collections.Generic;

internal class ConstructorDefinition : MemberDefinition
{
    public ConstructorDefinition(
        List<ParameterDefinition> parameters)
    {
        Parameters = parameters;
    }

    public List<ParameterDefinition> Parameters { get; }
}
