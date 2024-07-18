using System;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class EnumValueDefinition
{
    public EnumValueDefinition(Version? version, string name, int value)
    {
        Version = version;
        Name = name;
        Value = value;
    }

    public readonly Version? Version;
    public readonly string Name;
    public readonly int Value;
}
