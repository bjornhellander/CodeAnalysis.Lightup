// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Reflection;
    using Roslyn.CodeAnalysis.Lightup.Support;

    internal class LightupHelper : LightupHelperBase
    {
        private static readonly Assembly WorkspacesCommonAssembly = typeof(WorkspaceChangeKind).Assembly;

        public static Type? FindType(string wrappedTypeName)
        {
            return FindType(WorkspacesCommonAssembly, wrappedTypeName);
        }
    }
}
