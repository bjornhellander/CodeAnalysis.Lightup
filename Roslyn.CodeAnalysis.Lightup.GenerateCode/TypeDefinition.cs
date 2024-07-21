namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal abstract class TypeDefinition
{
    protected TypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName)
    {
        AssemblyKind = assemblyKind;
        AssemblyVersion = assemblyVersion;
        Name = name;
        Namespace = @namespace;
        FullName = fullName;
    }

    public AssemblyKind AssemblyKind { get; }

    public Version? AssemblyVersion { get; }

    public string Name { get; }

    public string Namespace { get; }

    public string FullName { get; }
}
