using System;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal abstract class TypeDefinition
{
    protected TypeDefinition(AssemblyKind assemblyKind, Version? assemblyVersion, string name, Type type)
    {
        AssemblyKind = assemblyKind;
        AssemblyVersion = assemblyVersion;
        Name = name;
        Type = type;
    }

    public readonly AssemblyKind AssemblyKind;
    public readonly Version? AssemblyVersion;
    public readonly string Name;
    public Type Type;
}
