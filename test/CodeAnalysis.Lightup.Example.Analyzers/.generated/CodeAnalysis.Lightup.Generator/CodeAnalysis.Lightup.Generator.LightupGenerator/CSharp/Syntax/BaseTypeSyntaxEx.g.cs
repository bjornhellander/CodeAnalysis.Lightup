﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax.</summary>
    public static partial class BaseTypeSyntaxEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax";

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax WithTypeDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax type);

        private static readonly WithTypeDelegate0 WithTypeFunc0;

        static BaseTypeSyntaxEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            WithTypeFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithTypeDelegate0>(wrappedType, "WithType", "typeTypeSyntax");
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax WithType(this global::Microsoft.CodeAnalysis.CSharp.Syntax.BaseTypeSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeSyntax type)
        {
            return WithTypeFunc0(_obj, type);
        }
    }
}