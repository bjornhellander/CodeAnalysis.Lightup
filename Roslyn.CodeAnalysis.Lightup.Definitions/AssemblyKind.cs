// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Definitions;

public enum AssemblyKind
{
    Common,
    CSharp,
    Workspaces, // TODO: Change name to WorkspacesCommon to match nuget package?
    CSharpWorkspaces,
}
