namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class EventDefinition : MemberDefinition
{
    public EventDefinition(string name, TypeReference type, bool isStatic)
    {
        Name = name;
        Type = type;
        IsStatic = isStatic;
    }

    public string Name { get; }

    public TypeReference Type { get; }

    public bool IsStatic { get; }
}
