using System;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class ClassTypeDefinition : TypeDefinition
{
    public ClassTypeDefinition(Version? assemblyVersion, string name, Type type)
        : base(assemblyVersion, name, type)
    {
    }
}
