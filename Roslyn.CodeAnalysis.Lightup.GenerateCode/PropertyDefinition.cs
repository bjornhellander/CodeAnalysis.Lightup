namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class PropertyDefinition
{
    public PropertyDefinition(string name, TypeReference type, bool isNullable, bool hasSetter, bool isStatic)
    {
        Name = name;
        Type = type;
        IsNullable = isNullable;
        HasSetter = hasSetter;
        IsStatic = isStatic;
    }

    public string Name { get; }

    public TypeReference Type { get; }

    public bool IsNullable { get; }

    public bool HasSetter { get; }

    public bool IsStatic { get; }
}
