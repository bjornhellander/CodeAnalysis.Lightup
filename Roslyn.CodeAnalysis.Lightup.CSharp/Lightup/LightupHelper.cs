// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Reflection;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Roslyn.CodeAnalysis.Lightup.Support;

    internal class LightupHelper : LightupHelperBase
    {
        private static readonly Assembly CSharpAssembly = typeof(ClassDeclarationSyntax).Assembly;

        internal static Type? FindType(string wrappedTypeName)
        {
            return FindType(CSharpAssembly, wrappedTypeName);
        }
    }
}
