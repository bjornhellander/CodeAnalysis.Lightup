namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal abstract class MemberDefinition
{
    public MemberDefinition()
    {
    }

    public Version? AssemblyVersion { get; set; }
}
