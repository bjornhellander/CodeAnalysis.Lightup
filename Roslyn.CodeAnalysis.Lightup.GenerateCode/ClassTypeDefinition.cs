namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Collections.Generic;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class ClassTypeDefinition : TypeDefinition
{
    public ClassTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        TypeReference? baseClass,
        bool isStatic)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName)
    {
        BaseClass = baseClass;
        IsStatic = isStatic;
    }

    public TypeReference? BaseClass { get; }

    public bool IsStatic { get; }

    public List<PropertyDefinition> Properties { get; } = new();

    public List<MethodDefinition> Methods { get; } = new();
}
