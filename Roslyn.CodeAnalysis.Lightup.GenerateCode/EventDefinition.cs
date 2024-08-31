namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Diagnostics;

// NOTE: Events can not be static
[DebuggerDisplay("{Name}")]
internal class EventDefinition : MemberDefinition
{
    public EventDefinition(string name, TypeReference type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; }

    public TypeReference Type { get; }
}
