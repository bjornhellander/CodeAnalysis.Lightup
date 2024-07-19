namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal class EnumValueDefinition
{
    public EnumValueDefinition(Version? version, string name, int value)
    {
        Version = version;
        Name = name;
        Value = value;
    }

    public Version? Version { get; }

    public string Name { get; }

    public int Value { get; }
}
