﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.UnaryPatternSyntax. Added in version 3.8.0.0.</summary>
    public readonly partial struct UnaryPatternSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.UnaryPatternSyntax";

        private static readonly System.Type? WrappedType; // NOTE: Used via reflection

        private delegate Microsoft.CodeAnalysis.SyntaxToken OperatorTokenGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax PatternGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj);

        private delegate void AcceptDelegate0(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.UnaryPatternSyntaxWrapper UpdateDelegate1(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, Microsoft.CodeAnalysis.SyntaxToken operatorToken, Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.UnaryPatternSyntaxWrapper WithOperatorTokenDelegate2(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, Microsoft.CodeAnalysis.SyntaxToken operatorToken);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.UnaryPatternSyntaxWrapper WithPatternDelegate3(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern);

        private static readonly OperatorTokenGetterDelegate OperatorTokenGetterFunc;
        private static readonly PatternGetterDelegate PatternGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithOperatorTokenDelegate2 WithOperatorTokenFunc2;
        private static readonly WithPatternDelegate3 WithPatternFunc3;

        private readonly Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? wrappedObject;

        static UnaryPatternSyntaxWrapper()
        {
            WrappedType = CSharpLightupHelper.FindType(WrappedTypeName);

            OperatorTokenGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<OperatorTokenGetterDelegate>(WrappedType, nameof(OperatorToken));
            PatternGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<PatternGetterDelegate>(WrappedType, nameof(Pattern));

            AcceptFunc0 = CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            UpdateFunc1 = CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(WrappedType, "Update", "operatorTokenSyntaxToken", "patternPatternSyntax");
            WithOperatorTokenFunc2 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithOperatorTokenDelegate2>(WrappedType, "WithOperatorToken", "operatorTokenSyntaxToken");
            WithPatternFunc3 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithPatternDelegate3>(WrappedType, "WithPattern", "patternPatternSyntax");
        }

        private UnaryPatternSyntaxWrapper(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.SyntaxToken OperatorToken
        {
            get => OperatorTokenGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax Pattern
        {
            get => PatternGetterFunc(wrappedObject);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax?(UnaryPatternSyntaxWrapper obj)
            => obj.Unwrap();

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(System.Object? obj)
            => CSharpLightupHelper.Is(obj, WrappedType);

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static UnaryPatternSyntaxWrapper As(System.Object? obj)
        {
            var obj2 = CSharpLightupHelper.As<Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax>(obj, WrappedType);
            return new UnaryPatternSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax? Unwrap()
            => wrappedObject;

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly void Accept(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
            => AcceptFunc0(wrappedObject, visitor);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.UnaryPatternSyntaxWrapper Update(Microsoft.CodeAnalysis.SyntaxToken operatorToken, Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern)
            => UpdateFunc1(wrappedObject, operatorToken, pattern);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.UnaryPatternSyntaxWrapper WithOperatorToken(Microsoft.CodeAnalysis.SyntaxToken operatorToken)
            => WithOperatorTokenFunc2(wrappedObject, operatorToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.UnaryPatternSyntaxWrapper WithPattern(Microsoft.CodeAnalysis.CSharp.Syntax.PatternSyntax pattern)
            => WithPatternFunc3(wrappedObject, pattern);
    }
}