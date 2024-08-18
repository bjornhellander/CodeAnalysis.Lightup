namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal class GenericTypeParameterReference : TypeReference
{
    public GenericTypeParameterReference(Type nativeType, string name)
        : base(nativeType)
    {
        Name = name;
    }

    public string Name { get; }
}
