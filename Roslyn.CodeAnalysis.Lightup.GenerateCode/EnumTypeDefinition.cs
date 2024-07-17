using System;
using System.Collections.Generic;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class EnumTypeDefinition : TypeDefinition
{
    public EnumTypeDefinition(Version? assemblyVersion, string name, Type type)
        : base(assemblyVersion, name, type)
    {
    }

    public readonly List<EnumValueDefinition> Values = [];
}
