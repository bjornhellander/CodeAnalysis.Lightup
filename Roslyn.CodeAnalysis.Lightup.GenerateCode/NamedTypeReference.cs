namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class NamedTypeReference : TypeReference
{
    public NamedTypeReference(Type nativeType, string name, string fullName)
        : base(nativeType)
    {
        Name = name;
        FullName = fullName;
    }

    public string Name { get; }

    public string FullName { get; }
}
