﻿namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Reflection;
    using Microsoft.CodeAnalysis.CSharp.Formatting;

    internal class LightupHelper : LightupHelperBase
    {
        private static readonly Assembly CSharpWorkspacesAssembly = typeof(CSharpFormattingOptions).Assembly;

        public static Type? FindType(string wrappedTypeName)
        {
            return FindType(CSharpWorkspacesAssembly, wrappedTypeName);
        }
    }
}