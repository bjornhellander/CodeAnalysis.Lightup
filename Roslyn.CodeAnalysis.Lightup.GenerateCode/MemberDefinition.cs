// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;

internal abstract class MemberDefinition
{
    public MemberDefinition()
    {
    }

    public Version? AssemblyVersion { get; set; }
}
