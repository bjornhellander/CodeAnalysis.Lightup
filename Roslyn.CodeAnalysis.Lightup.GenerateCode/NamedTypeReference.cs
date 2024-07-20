namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class NamedTypeReference : TypeReference
{
    public NamedTypeReference(string name, string fullName)
    {
        Name = name;
        FullName = fullName;
    }

    public string Name { get; }

    public string FullName { get; }
}
