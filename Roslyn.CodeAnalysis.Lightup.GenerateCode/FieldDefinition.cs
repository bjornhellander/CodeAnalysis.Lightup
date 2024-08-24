namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class FieldDefinition
{
    public FieldDefinition(string name, bool isStatic)
    {
        Name = name;
        IsStatic = isStatic;
    }

    public string Name { get; }

    public bool IsStatic { get; }
}
