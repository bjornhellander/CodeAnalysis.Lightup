namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Reflection;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal class LightupHelper : LightupHelperBase
    {
        private static readonly Assembly CSharpAssembly = typeof(ClassDeclarationSyntax).Assembly;

        internal static Type? FindType(string wrappedTypeName)
        {
            return FindType(CSharpAssembly, wrappedTypeName);
        }
    }
}
