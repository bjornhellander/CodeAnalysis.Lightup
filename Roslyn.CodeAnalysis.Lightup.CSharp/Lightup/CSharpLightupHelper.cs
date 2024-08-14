namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Reflection;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class CSharpLightupHelper
    {
        private static readonly Assembly SyntaxNodeAssembly = typeof(ClassDeclarationSyntax).Assembly;

        internal static Type? FindSyntaxType(string wrappedTypeName)
        {
            return CommonLightupHelper.FindType(SyntaxNodeAssembly, wrappedTypeName);
        }
    }
}
