// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System.Collections.Generic;

public class MethodDefinition : MemberDefinition
{
    public MethodDefinition(
        string name,
        bool isStatic,
        bool isExtensionMethod,
        TypeReference? returnType,
        bool isNullable,
        List<ParameterDefinition> parameters)
    {
        Name = name;
        IsStatic = isStatic;
        IsExtensionMethod = isExtensionMethod;
        ReturnType = returnType;
        IsNullable = isNullable;
        Parameters = parameters;
    }

    public string Name { get; }

    public bool IsStatic { get; }

    public bool IsExtensionMethod { get; }

    public TypeReference? ReturnType { get; }

    public bool IsNullable { get; }

    public List<ParameterDefinition> Parameters { get; }
}
