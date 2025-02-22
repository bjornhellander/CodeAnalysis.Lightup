﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.SwitchExpressionSyntax. Added in version 3.0.0.0.</summary>
    public partial struct SwitchExpressionSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.SwitchExpressionSyntax";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionArmSyntaxWrapper> ArmsGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken CloseBraceTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax GoverningExpressionGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken OpenBraceTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken SwitchKeywordGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj);

        private delegate void AcceptDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper AddArmsDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionArmSyntaxWrapper[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper UpdateDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax governingExpression, global::Microsoft.CodeAnalysis.SyntaxToken switchKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken, global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionArmSyntaxWrapper> arms, global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithArmsDelegate3(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionArmSyntaxWrapper> arms);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithCloseBraceTokenDelegate4(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithGoverningExpressionDelegate5(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax governingExpression);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithOpenBraceTokenDelegate6(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithSwitchKeywordDelegate7(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken switchKeyword);

        private static readonly ArmsGetterDelegate ArmsGetterFunc;
        private static readonly CloseBraceTokenGetterDelegate CloseBraceTokenGetterFunc;
        private static readonly GoverningExpressionGetterDelegate GoverningExpressionGetterFunc;
        private static readonly OpenBraceTokenGetterDelegate OpenBraceTokenGetterFunc;
        private static readonly SwitchKeywordGetterDelegate SwitchKeywordGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly AddArmsDelegate1 AddArmsFunc1;
        private static readonly UpdateDelegate2 UpdateFunc2;
        private static readonly WithArmsDelegate3 WithArmsFunc3;
        private static readonly WithCloseBraceTokenDelegate4 WithCloseBraceTokenFunc4;
        private static readonly WithGoverningExpressionDelegate5 WithGoverningExpressionFunc5;
        private static readonly WithOpenBraceTokenDelegate6 WithOpenBraceTokenFunc6;
        private static readonly WithSwitchKeywordDelegate7 WithSwitchKeywordFunc7;

        private readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax wrappedObject;

        static SwitchExpressionSyntaxWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            ArmsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ArmsGetterDelegate>(WrappedType, nameof(Arms));
            CloseBraceTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CloseBraceTokenGetterDelegate>(WrappedType, nameof(CloseBraceToken));
            GoverningExpressionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<GoverningExpressionGetterDelegate>(WrappedType, nameof(GoverningExpression));
            OpenBraceTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<OpenBraceTokenGetterDelegate>(WrappedType, nameof(OpenBraceToken));
            SwitchKeywordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<SwitchKeywordGetterDelegate>(WrappedType, nameof(SwitchKeyword));

            AcceptFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            AddArmsFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddArmsDelegate1>(WrappedType, "AddArms", "itemsSwitchExpressionArmSyntax[]");
            UpdateFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate2>(WrappedType, "Update", "governingExpressionExpressionSyntax", "switchKeywordSyntaxToken", "openBraceTokenSyntaxToken", "armsSeparatedSyntaxList`1", "closeBraceTokenSyntaxToken");
            WithArmsFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithArmsDelegate3>(WrappedType, "WithArms", "armsSeparatedSyntaxList`1");
            WithCloseBraceTokenFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithCloseBraceTokenDelegate4>(WrappedType, "WithCloseBraceToken", "closeBraceTokenSyntaxToken");
            WithGoverningExpressionFunc5 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithGoverningExpressionDelegate5>(WrappedType, "WithGoverningExpression", "governingExpressionExpressionSyntax");
            WithOpenBraceTokenFunc6 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithOpenBraceTokenDelegate6>(WrappedType, "WithOpenBraceToken", "openBraceTokenSyntaxToken");
            WithSwitchKeywordFunc7 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithSwitchKeywordDelegate7>(WrappedType, "WithSwitchKeyword", "switchKeywordSyntaxToken");
        }

        private SwitchExpressionSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionArmSyntaxWrapper> Arms
        {
            get { return ArmsGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken CloseBraceToken
        {
            get { return CloseBraceTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax GoverningExpression
        {
            get { return GoverningExpressionGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken OpenBraceToken
        {
            get { return OpenBraceTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken SwitchKeyword
        {
            get { return SwitchKeywordGetterFunc(wrappedObject); }
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static explicit operator SwitchExpressionSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax obj)
        {
            return Wrap(obj);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax(SwitchExpressionSyntaxWrapper obj)
        {
            return obj.Unwrap();
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static SwitchExpressionSyntaxWrapper Wrap(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Wrap<global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax>(obj, WrappedType);
            return new SwitchExpressionSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public void Accept(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
        {
            AcceptFunc0(wrappedObject, visitor);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper AddArms(params global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionArmSyntaxWrapper[] items)
        {
            return AddArmsFunc1(wrappedObject, items);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper Update(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax governingExpression, global::Microsoft.CodeAnalysis.SyntaxToken switchKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken, global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionArmSyntaxWrapper> arms, global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken)
        {
            return UpdateFunc2(wrappedObject, governingExpression, switchKeyword, openBraceToken, arms, closeBraceToken);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithArms(global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionArmSyntaxWrapper> arms)
        {
            return WithArmsFunc3(wrappedObject, arms);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithCloseBraceToken(global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken)
        {
            return WithCloseBraceTokenFunc4(wrappedObject, closeBraceToken);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithGoverningExpression(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax governingExpression)
        {
            return WithGoverningExpressionFunc5(wrappedObject, governingExpression);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithOpenBraceToken(global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken)
        {
            return WithOpenBraceTokenFunc6(wrappedObject, openBraceToken);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SwitchExpressionSyntaxWrapper WithSwitchKeyword(global::Microsoft.CodeAnalysis.SyntaxToken switchKeyword)
        {
            return WithSwitchKeywordFunc7(wrappedObject, switchKeyword);
        }
    }
}
