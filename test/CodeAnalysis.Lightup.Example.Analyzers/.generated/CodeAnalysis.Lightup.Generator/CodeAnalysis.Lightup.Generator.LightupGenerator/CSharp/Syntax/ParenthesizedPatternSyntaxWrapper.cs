﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedPatternSyntax. Added in version 3.8.0.0.</summary>
    public readonly partial struct ParenthesizedPatternSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedPatternSyntax";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::Microsoft.CodeAnalysis.SyntaxToken CloseParenTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken OpenParenTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax PatternGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj);

        private delegate void AcceptDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper UpdateDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithCloseParenTokenDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithOpenParenTokenDelegate3(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithPatternDelegate4(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern);

        private static readonly CloseParenTokenGetterDelegate CloseParenTokenGetterFunc;
        private static readonly OpenParenTokenGetterDelegate OpenParenTokenGetterFunc;
        private static readonly PatternGetterDelegate PatternGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithCloseParenTokenDelegate2 WithCloseParenTokenFunc2;
        private static readonly WithOpenParenTokenDelegate3 WithOpenParenTokenFunc3;
        private static readonly WithPatternDelegate4 WithPatternFunc4;

        private readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? wrappedObject;

        static ParenthesizedPatternSyntaxWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            CloseParenTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CloseParenTokenGetterDelegate>(WrappedType, nameof(CloseParenToken));
            OpenParenTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<OpenParenTokenGetterDelegate>(WrappedType, nameof(OpenParenToken));
            PatternGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<PatternGetterDelegate>(WrappedType, nameof(Pattern));

            AcceptFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            UpdateFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(WrappedType, "Update", "openParenTokenSyntaxToken", "patternPatternSyntax", "closeParenTokenSyntaxToken");
            WithCloseParenTokenFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithCloseParenTokenDelegate2>(WrappedType, "WithCloseParenToken", "closeParenTokenSyntaxToken");
            WithOpenParenTokenFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithOpenParenTokenDelegate3>(WrappedType, "WithOpenParenToken", "openParenTokenSyntaxToken");
            WithPatternFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithPatternDelegate4>(WrappedType, "WithPattern", "patternPatternSyntax");
        }

        private ParenthesizedPatternSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly global::Microsoft.CodeAnalysis.SyntaxToken CloseParenToken
        {
            get => CloseParenTokenGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly global::Microsoft.CodeAnalysis.SyntaxToken OpenParenToken
        {
            get => OpenParenTokenGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax Pattern
        {
            get => PatternGetterFunc(wrappedObject);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax?(ParenthesizedPatternSyntaxWrapper obj)
            => obj.Unwrap();

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
            => global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static ParenthesizedPatternSyntaxWrapper As(global::System.Object? obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.As<global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax>(obj, WrappedType);
            return new ParenthesizedPatternSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? Unwrap()
            => wrappedObject;

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly void Accept(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
            => AcceptFunc0(wrappedObject, visitor);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper Update(global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken)
            => UpdateFunc1(wrappedObject, openParenToken, pattern, closeParenToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithCloseParenToken(global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken)
            => WithCloseParenTokenFunc2(wrappedObject, closeParenToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithOpenParenToken(global::Microsoft.CodeAnalysis.SyntaxToken openParenToken)
            => WithOpenParenTokenFunc3(wrappedObject, openParenToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithPattern(global::Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern)
            => WithPatternFunc4(wrappedObject, pattern);
    }
}