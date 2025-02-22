﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharpExtensions.</summary>
    public static partial class CSharpExtensionsEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharpExtensions";

        private delegate global::System.Boolean ContainsDirectiveDelegate0(global::Microsoft.CodeAnalysis.SyntaxNode node, global::Microsoft.CodeAnalysis.CSharp.SyntaxKind kind);

        private static readonly ContainsDirectiveDelegate0 ContainsDirectiveFunc0;

        static CSharpExtensionsEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            ContainsDirectiveFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateStaticMethodAccessor<ContainsDirectiveDelegate0>(wrappedType, "ContainsDirective", "nodeSyntaxNode", "kindSyntaxKind");
        }

        /// <summary>Method added in version 4.5.0.0.</summary>
        public static global::System.Boolean ContainsDirective(this global::Microsoft.CodeAnalysis.SyntaxNode node, global::Microsoft.CodeAnalysis.CSharp.SyntaxKind kind)
        {
            return ContainsDirectiveFunc0(node, kind);
        }
    }
}
