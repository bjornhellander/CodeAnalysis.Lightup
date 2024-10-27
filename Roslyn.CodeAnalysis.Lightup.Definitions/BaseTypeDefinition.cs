// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

using System;

public abstract class BaseTypeDefinition
{
    protected BaseTypeDefinition(
        AssemblyKind assemblyKind,
        Version? assemblyVersion,
        string name,
        string @namespace,
        string fullName,
        string? enclosingTypeName)
    {
        AssemblyKind = assemblyKind;
        AssemblyVersion = assemblyVersion;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        EnclosingTypeFullName = enclosingTypeName;
    }

    public AssemblyKind AssemblyKind { get; }

    public Version? AssemblyVersion { get; }

    public string Name { get; }

    public string Namespace { get; }

    public string FullName { get; }

    public string? EnclosingTypeFullName { get; }

    public string GeneratedName { get; set; } = "";

    public bool IsUpdated { get; set; }

    public string GeneratedFileName { get; set; } = "";
}
