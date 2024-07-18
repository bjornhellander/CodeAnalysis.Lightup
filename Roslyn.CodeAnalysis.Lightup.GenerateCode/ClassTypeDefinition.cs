using System;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class ClassTypeDefinition : TypeDefinition
{
    public ClassTypeDefinition(Version? assemblyVersion, string name, Type type, bool isStatic)
        : base(assemblyVersion, name, type)
    {
        IsStatic = isStatic;
    }

    public readonly bool IsStatic;
}
