﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax.</summary>
    public static partial class XmlAttributeSyntaxEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax";

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax WithEndQuoteTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken endQuoteToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax WithEqualsTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken equalsToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax WithNameDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlNameSyntax name);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax WithStartQuoteTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken startQuoteToken);

        private static readonly WithEndQuoteTokenDelegate0 WithEndQuoteTokenFunc0;
        private static readonly WithEqualsTokenDelegate0 WithEqualsTokenFunc0;
        private static readonly WithNameDelegate0 WithNameFunc0;
        private static readonly WithStartQuoteTokenDelegate0 WithStartQuoteTokenFunc0;

        static XmlAttributeSyntaxEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            WithEndQuoteTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithEndQuoteTokenDelegate0>(wrappedType, "WithEndQuoteToken", "endQuoteTokenSyntaxToken");
            WithEqualsTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithEqualsTokenDelegate0>(wrappedType, "WithEqualsToken", "equalsTokenSyntaxToken");
            WithNameFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithNameDelegate0>(wrappedType, "WithName", "nameXmlNameSyntax");
            WithStartQuoteTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithStartQuoteTokenDelegate0>(wrappedType, "WithStartQuoteToken", "startQuoteTokenSyntaxToken");
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax WithEndQuoteToken(this global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken endQuoteToken)
        {
            return WithEndQuoteTokenFunc0(_obj, endQuoteToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax WithEqualsToken(this global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken equalsToken)
        {
            return WithEqualsTokenFunc0(_obj, equalsToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax WithName(this global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlNameSyntax name)
        {
            return WithNameFunc0(_obj, name);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax WithStartQuoteToken(this global::Microsoft.CodeAnalysis.CSharp.Syntax.XmlAttributeSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken startQuoteToken)
        {
            return WithStartQuoteTokenFunc0(_obj, startQuoteToken);
        }
    }
}
