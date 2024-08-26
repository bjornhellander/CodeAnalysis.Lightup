namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System.Diagnostics;

[DebuggerDisplay("{Name}")]
internal class EventDefinition : MemberDefinition
{
    public EventDefinition(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
