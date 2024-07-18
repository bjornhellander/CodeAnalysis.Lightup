using System;
using System.Collections.Generic;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class EnumTypeDefinition : TypeDefinition
{
    public EnumTypeDefinition(AssemblyKind assemblyKind, Version? assemblyVersion, string name, Type type)
        : base(assemblyKind, assemblyVersion, name, type)
    {
    }

    public readonly List<EnumValueDefinition> Values = [];
}
