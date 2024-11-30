// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;
using System.Collections.Generic;

public class ConstructorDefinition : MemberDefinition
{
    [Obsolete("Only intended for serializer")]
    public ConstructorDefinition()
        : base()
    {
        Parameters = [];
    }

    public ConstructorDefinition(List<ParameterDefinition> parameters, bool isStatic)
    {
        Parameters = parameters;
        IsStatic = isStatic;
    }

    public List<ParameterDefinition> Parameters { get; set; }

    public bool IsStatic { get; set; }
}
