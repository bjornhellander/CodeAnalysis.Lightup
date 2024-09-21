// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

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
