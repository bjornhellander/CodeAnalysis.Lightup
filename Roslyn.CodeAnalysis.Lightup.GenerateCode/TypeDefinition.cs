using System;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal abstract class TypeDefinition
{
    protected TypeDefinition(Version? assemblyVersion, string name, Type type)
    {
        AssemblyVersion = assemblyVersion;
        Name = name;
        Type = type;
    }

    public readonly Version? AssemblyVersion;
    public readonly string Name;
    public Type Type;
}
