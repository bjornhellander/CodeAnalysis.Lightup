// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System.Collections.Generic;

// NOTE: Indexers can not be static
public class IndexerDefinition : MemberDefinition
{
    public IndexerDefinition(
        TypeReference type,
        bool isNullable,
        List<ParameterDefinition> parameters,
        bool hasSetter)
    {
        Type = type;
        IsNullable = isNullable;
        Parameters = parameters;
        HasSetter = hasSetter;
    }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public List<ParameterDefinition> Parameters { get; }

    public bool HasSetter { get; }
}
