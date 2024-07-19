namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal class ClassTypeDefinition : TypeDefinition
{
    public ClassTypeDefinition(AssemblyKind assemblyKind, Version? assemblyVersion, string name, Type type, bool isStatic)
        : base(assemblyKind, assemblyVersion, name, type)
    {
        IsStatic = isStatic;
    }

    public bool IsStatic { get; }
}
