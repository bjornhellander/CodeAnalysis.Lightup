namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Collections.Generic;

internal class EnumTypeDefinition : TypeDefinition
{
    public EnumTypeDefinition(AssemblyKind assemblyKind, Version? assemblyVersion, string name, Type type)
        : base(assemblyKind, assemblyVersion, name, type)
    {
    }

    public List<EnumValueDefinition> Values { get; } = [];
}
