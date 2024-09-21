// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Collections.Generic;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal abstract class TypeDefinition : BaseTypeDefinition
{
    public TypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName)
    {
    }

    public List<ConstructorDefinition> Constructors { get; } = [];

    public List<FieldDefinition> Fields { get; } = [];

    public List<EventDefinition> Events { get; } = [];

    public List<PropertyDefinition> Properties { get; } = [];

    public List<IndexerDefinition> Indexers { get; } = [];

    public List<MethodDefinition> Methods { get; } = [];
}
