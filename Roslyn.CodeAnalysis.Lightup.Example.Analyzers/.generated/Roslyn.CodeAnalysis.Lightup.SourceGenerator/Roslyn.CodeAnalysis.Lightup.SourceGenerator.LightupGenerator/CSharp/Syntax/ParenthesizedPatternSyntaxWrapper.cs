﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedPatternSyntax. Added in version 3.8.0.0.</summary>
    public readonly partial struct ParenthesizedPatternSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedPatternSyntax";

        private static readonly System.Type? WrappedType; // NOTE: Used via reflection

        private delegate Microsoft.CodeAnalysis.SyntaxToken CloseParenTokenGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj);
        private delegate Microsoft.CodeAnalysis.SyntaxToken OpenParenTokenGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax PatternGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj);

        private delegate void AcceptDelegate0(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper UpdateDelegate1(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, Microsoft.CodeAnalysis.SyntaxToken openParenToken, Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern, Microsoft.CodeAnalysis.SyntaxToken closeParenToken);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithCloseParenTokenDelegate2(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, Microsoft.CodeAnalysis.SyntaxToken closeParenToken);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithOpenParenTokenDelegate3(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, Microsoft.CodeAnalysis.SyntaxToken openParenToken);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithPatternDelegate4(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern);

        private static readonly CloseParenTokenGetterDelegate CloseParenTokenGetterFunc;
        private static readonly OpenParenTokenGetterDelegate OpenParenTokenGetterFunc;
        private static readonly PatternGetterDelegate PatternGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithCloseParenTokenDelegate2 WithCloseParenTokenFunc2;
        private static readonly WithOpenParenTokenDelegate3 WithOpenParenTokenFunc3;
        private static readonly WithPatternDelegate4 WithPatternFunc4;

        private readonly Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? wrappedObject;

        static ParenthesizedPatternSyntaxWrapper()
        {
            WrappedType = CSharpLightupHelper.FindType(WrappedTypeName);

            CloseParenTokenGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<CloseParenTokenGetterDelegate>(WrappedType, nameof(CloseParenToken));
            OpenParenTokenGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<OpenParenTokenGetterDelegate>(WrappedType, nameof(OpenParenToken));
            PatternGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<PatternGetterDelegate>(WrappedType, nameof(Pattern));

            AcceptFunc0 = CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            UpdateFunc1 = CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(WrappedType, "Update", "openParenTokenSyntaxToken", "patternPatternSyntax", "closeParenTokenSyntaxToken");
            WithCloseParenTokenFunc2 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithCloseParenTokenDelegate2>(WrappedType, "WithCloseParenToken", "closeParenTokenSyntaxToken");
            WithOpenParenTokenFunc3 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithOpenParenTokenDelegate3>(WrappedType, "WithOpenParenToken", "openParenTokenSyntaxToken");
            WithPatternFunc4 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithPatternDelegate4>(WrappedType, "WithPattern", "patternPatternSyntax");
        }

        private ParenthesizedPatternSyntaxWrapper(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.SyntaxToken CloseParenToken
        {
            get => CloseParenTokenGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.SyntaxToken OpenParenToken
        {
            get => OpenParenTokenGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax Pattern
        {
            get => PatternGetterFunc(wrappedObject);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax?(ParenthesizedPatternSyntaxWrapper obj)
            => obj.Unwrap();

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(System.Object? obj)
            => CSharpLightupHelper.Is(obj, WrappedType);

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static ParenthesizedPatternSyntaxWrapper As(System.Object? obj)
        {
            var obj2 = CSharpLightupHelper.As<Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax>(obj, WrappedType);
            return new ParenthesizedPatternSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? Unwrap()
            => wrappedObject;

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly void Accept(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
            => AcceptFunc0(wrappedObject, visitor);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper Update(Microsoft.CodeAnalysis.SyntaxToken openParenToken, Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern, Microsoft.CodeAnalysis.SyntaxToken closeParenToken)
            => UpdateFunc1(wrappedObject, openParenToken, pattern, closeParenToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithCloseParenToken(Microsoft.CodeAnalysis.SyntaxToken closeParenToken)
            => WithCloseParenTokenFunc2(wrappedObject, closeParenToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithOpenParenToken(Microsoft.CodeAnalysis.SyntaxToken openParenToken)
            => WithOpenParenTokenFunc3(wrappedObject, openParenToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper WithPattern(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern)
            => WithPatternFunc4(wrappedObject, pattern);
    }
}