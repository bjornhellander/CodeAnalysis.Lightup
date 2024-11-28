// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;

public class ParameterDefinition
{
    [Obsolete("Only intended for serializer")]
    public ParameterDefinition()
        : base()
    {
        Name = "";
        Type = new NamedTypeReference();
    }

    public ParameterDefinition(string name, bool isParams, TypeReference type, bool isNullable, ParameterMode mode)
    {
        Name = name;
        IsParams = isParams;
        Type = type;
        IsNullable = isNullable;
        Mode = mode;
    }

    public string Name { get; set; }

    public bool IsParams { get; set; }

    public TypeReference Type { get; set; }

    public bool IsNullable { get; set; }

    public ParameterMode Mode { get; set; }
}
