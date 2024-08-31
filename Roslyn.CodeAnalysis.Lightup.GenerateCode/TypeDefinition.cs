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

    public List<ConstructorDefinition> Constructors { get; } = new();

    public List<FieldDefinition> Fields { get; } = new();

    public List<EventDefinition> Events { get; } = new();

    public List<PropertyDefinition> Properties { get; } = new();

    public List<IndexerDefinition> Indexers { get; } = new();

    public List<MethodDefinition> Methods { get; } = new();
}
