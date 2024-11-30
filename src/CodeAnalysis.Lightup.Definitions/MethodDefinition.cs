// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;
using System.Collections.Generic;

public class MethodDefinition : MemberDefinition
{
    [Obsolete("Only intended for serializer")]
    public MethodDefinition()
        : base()
    {
        Name = "";
        Parameters = [];
    }

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

    public string Name { get; set; }

    public bool IsStatic { get; set; }

    public bool IsExtensionMethod { get; set; }

    public TypeReference? ReturnType { get; set; }

    public bool IsNullable { get; set; }

    public List<ParameterDefinition> Parameters { get; }
}
