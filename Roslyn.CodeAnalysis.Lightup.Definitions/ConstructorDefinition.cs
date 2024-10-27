// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System.Collections.Generic;

public class ConstructorDefinition : MemberDefinition
{
    public ConstructorDefinition(List<ParameterDefinition> parameters, bool isStatic)
    {
        Parameters = parameters;
        IsStatic = isStatic;
    }

    public List<ParameterDefinition> Parameters { get; }

    public bool IsStatic { get; }
}
