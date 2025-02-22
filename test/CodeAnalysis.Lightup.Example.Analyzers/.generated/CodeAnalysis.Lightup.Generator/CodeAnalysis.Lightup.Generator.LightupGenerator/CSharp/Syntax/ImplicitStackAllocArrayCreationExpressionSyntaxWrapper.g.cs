﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitStackAllocArrayCreationExpressionSyntax. Added in version 2.8.0.0.</summary>
    public partial struct ImplicitStackAllocArrayCreationExpressionSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitStackAllocArrayCreationExpressionSyntax";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.SyntaxToken CloseBracketTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax InitializerGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken OpenBracketTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken StackAllocKeywordGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj);

        private delegate void AcceptDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper AddInitializerExpressionsDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper UpdateDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken stackAllocKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openBracketToken, global::Microsoft.CodeAnalysis.SyntaxToken closeBracketToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax initializer);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper WithCloseBracketTokenDelegate3(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken closeBracketToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper WithInitializerDelegate4(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax initializer);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper WithOpenBracketTokenDelegate5(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken openBracketToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper WithStackAllocKeywordDelegate6(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken stackAllocKeyword);

        private static readonly CloseBracketTokenGetterDelegate CloseBracketTokenGetterFunc;
        private static readonly InitializerGetterDelegate InitializerGetterFunc;
        private static readonly OpenBracketTokenGetterDelegate OpenBracketTokenGetterFunc;
        private static readonly StackAllocKeywordGetterDelegate StackAllocKeywordGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly AddInitializerExpressionsDelegate1 AddInitializerExpressionsFunc1;
        private static readonly UpdateDelegate2 UpdateFunc2;
        private static readonly WithCloseBracketTokenDelegate3 WithCloseBracketTokenFunc3;
        private static readonly WithInitializerDelegate4 WithInitializerFunc4;
        private static readonly WithOpenBracketTokenDelegate5 WithOpenBracketTokenFunc5;
        private static readonly WithStackAllocKeywordDelegate6 WithStackAllocKeywordFunc6;

        private readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax wrappedObject;

        static ImplicitStackAllocArrayCreationExpressionSyntaxWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            CloseBracketTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CloseBracketTokenGetterDelegate>(WrappedType, nameof(CloseBracketToken));
            InitializerGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<InitializerGetterDelegate>(WrappedType, nameof(Initializer));
            OpenBracketTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<OpenBracketTokenGetterDelegate>(WrappedType, nameof(OpenBracketToken));
            StackAllocKeywordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<StackAllocKeywordGetterDelegate>(WrappedType, nameof(StackAllocKeyword));

            AcceptFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            AddInitializerExpressionsFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddInitializerExpressionsDelegate1>(WrappedType, "AddInitializerExpressions", "itemsExpressionSyntax[]");
            UpdateFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate2>(WrappedType, "Update", "stackAllocKeywordSyntaxToken", "openBracketTokenSyntaxToken", "closeBracketTokenSyntaxToken", "initializerInitializerExpressionSyntax");
            WithCloseBracketTokenFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithCloseBracketTokenDelegate3>(WrappedType, "WithCloseBracketToken", "closeBracketTokenSyntaxToken");
            WithInitializerFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithInitializerDelegate4>(WrappedType, "WithInitializer", "initializerInitializerExpressionSyntax");
            WithOpenBracketTokenFunc5 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithOpenBracketTokenDelegate5>(WrappedType, "WithOpenBracketToken", "openBracketTokenSyntaxToken");
            WithStackAllocKeywordFunc6 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithStackAllocKeywordDelegate6>(WrappedType, "WithStackAllocKeyword", "stackAllocKeywordSyntaxToken");
        }

        private ImplicitStackAllocArrayCreationExpressionSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken CloseBracketToken
        {
            get { return CloseBracketTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax Initializer
        {
            get { return InitializerGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken OpenBracketToken
        {
            get { return OpenBracketTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken StackAllocKeyword
        {
            get { return StackAllocKeywordGetterFunc(wrappedObject); }
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static explicit operator ImplicitStackAllocArrayCreationExpressionSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax obj)
        {
            return Wrap(obj);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax(ImplicitStackAllocArrayCreationExpressionSyntaxWrapper obj)
        {
            return obj.Unwrap();
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ImplicitStackAllocArrayCreationExpressionSyntaxWrapper Wrap(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Wrap<global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax>(obj, WrappedType);
            return new ImplicitStackAllocArrayCreationExpressionSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public void Accept(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
        {
            AcceptFunc0(wrappedObject, visitor);
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper AddInitializerExpressions(params global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax[] items)
        {
            return AddInitializerExpressionsFunc1(wrappedObject, items);
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper Update(global::Microsoft.CodeAnalysis.SyntaxToken stackAllocKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openBracketToken, global::Microsoft.CodeAnalysis.SyntaxToken closeBracketToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax initializer)
        {
            return UpdateFunc2(wrappedObject, stackAllocKeyword, openBracketToken, closeBracketToken, initializer);
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper WithCloseBracketToken(global::Microsoft.CodeAnalysis.SyntaxToken closeBracketToken)
        {
            return WithCloseBracketTokenFunc3(wrappedObject, closeBracketToken);
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper WithInitializer(global::Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax initializer)
        {
            return WithInitializerFunc4(wrappedObject, initializer);
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper WithOpenBracketToken(global::Microsoft.CodeAnalysis.SyntaxToken openBracketToken)
        {
            return WithOpenBracketTokenFunc5(wrappedObject, openBracketToken);
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitStackAllocArrayCreationExpressionSyntaxWrapper WithStackAllocKeyword(global::Microsoft.CodeAnalysis.SyntaxToken stackAllocKeyword)
        {
            return WithStackAllocKeywordFunc6(wrappedObject, stackAllocKeyword);
        }
    }
}
