// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal class EnumValueDefinition
{
    public EnumValueDefinition(Version? assemblyVersion, string name, int value)
    {
        AssemblyVersion = assemblyVersion;
        Name = name;
        Value = value;
    }

    public Version? AssemblyVersion { get; }

    public string Name { get; }

    public int Value { get; }
}
