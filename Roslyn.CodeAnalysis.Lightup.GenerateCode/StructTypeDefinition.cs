namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class StructTypeDefinition : TypeDefinition
{
    public StructTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName)
        : base(assemblyKind, assemblyVersion, name, @namespace, fullName)
    {
    }
}
