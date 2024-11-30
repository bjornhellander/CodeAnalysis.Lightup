// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Definitions;

using System;
using System.Collections.Generic;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
public abstract class TypeDefinition : BaseTypeDefinition
{
    [Obsolete("Only intended for serializer")]
    protected TypeDefinition()
        : base()
    {
    }

    protected TypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        string? enclosingTypeFullName)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName, enclosingTypeFullName)
    {
    }

    public List<ConstructorDefinition> Constructors { get; } = [];

    public List<FieldDefinition> Fields { get; } = [];

    public List<EventDefinition> Events { get; } = [];

    public List<PropertyDefinition> Properties { get; } = [];

    public List<IndexerDefinition> Indexers { get; } = [];

    public List<MethodDefinition> Methods { get; } = [];
}
