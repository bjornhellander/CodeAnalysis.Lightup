﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.WithExpressionSyntax. Added in version 3.8.0.0.</summary>
    public readonly partial struct WithExpressionSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.WithExpressionSyntax";

        private static readonly System.Type? WrappedType; // NOTE: Used via reflection

        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax ExpressionGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? _obj);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax InitializerGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? _obj);
        private delegate Microsoft.CodeAnalysis.SyntaxToken WithKeywordGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? _obj);

        private delegate void AcceptDelegate0(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? _obj, Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper AddInitializerExpressionsDelegate1(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax[] items);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper UpdateDelegate2(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, Microsoft.CodeAnalysis.SyntaxToken withKeyword, Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax initializer);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper WithExpressionDelegate3(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper WithInitializerDelegate4(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax initializer);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper WithWithKeywordDelegate5(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? _obj, Microsoft.CodeAnalysis.SyntaxToken withKeyword);

        private static readonly ExpressionGetterDelegate ExpressionGetterFunc;
        private static readonly InitializerGetterDelegate InitializerGetterFunc;
        private static readonly WithKeywordGetterDelegate WithKeywordGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly AddInitializerExpressionsDelegate1 AddInitializerExpressionsFunc1;
        private static readonly UpdateDelegate2 UpdateFunc2;
        private static readonly WithExpressionDelegate3 WithExpressionFunc3;
        private static readonly WithInitializerDelegate4 WithInitializerFunc4;
        private static readonly WithWithKeywordDelegate5 WithWithKeywordFunc5;

        private readonly Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? wrappedObject;

        static WithExpressionSyntaxWrapper()
        {
            WrappedType = CSharpLightupHelper.FindType(WrappedTypeName);

            ExpressionGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<ExpressionGetterDelegate>(WrappedType, nameof(Expression));
            InitializerGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<InitializerGetterDelegate>(WrappedType, nameof(Initializer));
            WithKeywordGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<WithKeywordGetterDelegate>(WrappedType, nameof(WithKeyword));

            AcceptFunc0 = CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            AddInitializerExpressionsFunc1 = CSharpLightupHelper.CreateInstanceMethodAccessor<AddInitializerExpressionsDelegate1>(WrappedType, "AddInitializerExpressions", "itemsExpressionSyntax[]");
            UpdateFunc2 = CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate2>(WrappedType, "Update", "expressionExpressionSyntax", "withKeywordSyntaxToken", "initializerInitializerExpressionSyntax");
            WithExpressionFunc3 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithExpressionDelegate3>(WrappedType, "WithExpression", "expressionExpressionSyntax");
            WithInitializerFunc4 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithInitializerDelegate4>(WrappedType, "WithInitializer", "initializerInitializerExpressionSyntax");
            WithWithKeywordFunc5 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithWithKeywordDelegate5>(WrappedType, "WithWithKeyword", "withKeywordSyntaxToken");
        }

        private WithExpressionSyntaxWrapper(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax Expression
        {
            get => ExpressionGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax Initializer
        {
            get => InitializerGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.SyntaxToken WithKeyword
        {
            get => WithKeywordGetterFunc(wrappedObject);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax?(WithExpressionSyntaxWrapper obj)
            => obj.Unwrap();

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(System.Object? obj)
            => CSharpLightupHelper.Is(obj, WrappedType);

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static WithExpressionSyntaxWrapper As(System.Object? obj)
        {
            var obj2 = CSharpLightupHelper.As<Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax>(obj, WrappedType);
            return new WithExpressionSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? Unwrap()
            => wrappedObject;

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly void Accept(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
            => AcceptFunc0(wrappedObject, visitor);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper AddInitializerExpressions(params Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax[] items)
            => AddInitializerExpressionsFunc1(wrappedObject, items);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper Update(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, Microsoft.CodeAnalysis.SyntaxToken withKeyword, Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax initializer)
            => UpdateFunc2(wrappedObject, expression, withKeyword, initializer);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper WithExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression)
            => WithExpressionFunc3(wrappedObject, expression);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper WithInitializer(Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax initializer)
            => WithInitializerFunc4(wrappedObject, initializer);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper WithWithKeyword(Microsoft.CodeAnalysis.SyntaxToken withKeyword)
            => WithWithKeywordFunc5(wrappedObject, withKeyword);
    }
}