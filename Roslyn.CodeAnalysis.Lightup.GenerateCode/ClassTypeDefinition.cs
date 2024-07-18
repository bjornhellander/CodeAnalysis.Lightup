using System;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class ClassTypeDefinition : TypeDefinition
{
    public ClassTypeDefinition(AssemblyKind assemblyKind, Version? assemblyVersion, string name, Type type, bool isStatic)
        : base(assemblyKind, assemblyVersion, name, type)
    {
        IsStatic = isStatic;
    }

    public readonly bool IsStatic;
}
