namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal abstract class TypeDefinition
{
    protected TypeDefinition(AssemblyKind assemblyKind, Version? assemblyVersion, string name, Type type)
    {
        AssemblyKind = assemblyKind;
        AssemblyVersion = assemblyVersion;
        Name = name;
        Type = type;
    }

    public AssemblyKind AssemblyKind { get; }

    public Version? AssemblyVersion { get; }

    public string Name { get; }

    public Type Type { get; set; }
}
