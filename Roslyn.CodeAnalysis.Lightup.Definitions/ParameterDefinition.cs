// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

public class ParameterDefinition
{
    public ParameterDefinition(string name, bool isParams, TypeReference type, bool isNullable, ParameterMode mode)
    {
        Name = name;
        IsParams = isParams;
        Type = type;
        IsNullable = isNullable;
        Mode = mode;
    }

    public string Name { get; }

    public bool IsParams { get; }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public ParameterMode Mode { get; }
}
