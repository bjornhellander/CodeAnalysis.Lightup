﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor.</summary>
    public static partial class CSharpSyntaxVisitorExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor";

        private delegate void VisitBinaryPatternDelegate0(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.BinaryPatternSyntaxWrapper node);
        private delegate void VisitCollectionExpressionDelegate1(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.CollectionExpressionSyntaxWrapper node);
        private delegate void VisitDefaultConstraintDelegate2(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.DefaultConstraintSyntaxWrapper node);
        private delegate void VisitExpressionColonDelegate3(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExpressionColonSyntaxWrapper node);
        private delegate void VisitExpressionElementDelegate4(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExpressionElementSyntaxWrapper node);
        private delegate void VisitFileScopedNamespaceDeclarationDelegate5(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FileScopedNamespaceDeclarationSyntaxWrapper node);
        private delegate void VisitFunctionPointerCallingConventionDelegate6(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerCallingConventionSyntaxWrapper node);
        private delegate void VisitFunctionPointerParameterDelegate7(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerParameterSyntaxWrapper node);
        private delegate void VisitFunctionPointerParameterListDelegate8(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerParameterListSyntaxWrapper node);
        private delegate void VisitFunctionPointerTypeDelegate9(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerTypeSyntaxWrapper node);
        private delegate void VisitFunctionPointerUnmanagedCallingConventionDelegate10(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerUnmanagedCallingConventionSyntaxWrapper node);
        private delegate void VisitFunctionPointerUnmanagedCallingConventionListDelegate11(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerUnmanagedCallingConventionListSyntaxWrapper node);
        private delegate void VisitImplicitObjectCreationExpressionDelegate12(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitObjectCreationExpressionSyntaxWrapper node);
        private delegate void VisitLineDirectivePositionDelegate13(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper node);
        private delegate void VisitLineSpanDirectiveTriviaDelegate14(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineSpanDirectiveTriviaSyntaxWrapper node);
        private delegate void VisitListPatternDelegate15(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ListPatternSyntaxWrapper node);
        private delegate void VisitParenthesizedPatternDelegate16(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper node);
        private delegate void VisitPrimaryConstructorBaseTypeDelegate17(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.PrimaryConstructorBaseTypeSyntaxWrapper node);
        private delegate void VisitRecordDeclarationDelegate18(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.RecordDeclarationSyntaxWrapper node);
        private delegate void VisitRelationalPatternDelegate19(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.RelationalPatternSyntaxWrapper node);
        private delegate void VisitScopedTypeDelegate20(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ScopedTypeSyntaxWrapper node);
        private delegate void VisitSlicePatternDelegate21(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SlicePatternSyntaxWrapper node);
        private delegate void VisitSpreadElementDelegate22(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SpreadElementSyntaxWrapper node);
        private delegate void VisitTypePatternDelegate23(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.TypePatternSyntaxWrapper node);
        private delegate void VisitUnaryPatternDelegate24(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.UnaryPatternSyntaxWrapper node);
        private delegate void VisitWithExpressionDelegate25(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper node);

        private static readonly VisitBinaryPatternDelegate0 VisitBinaryPatternFunc0;
        private static readonly VisitCollectionExpressionDelegate1 VisitCollectionExpressionFunc1;
        private static readonly VisitDefaultConstraintDelegate2 VisitDefaultConstraintFunc2;
        private static readonly VisitExpressionColonDelegate3 VisitExpressionColonFunc3;
        private static readonly VisitExpressionElementDelegate4 VisitExpressionElementFunc4;
        private static readonly VisitFileScopedNamespaceDeclarationDelegate5 VisitFileScopedNamespaceDeclarationFunc5;
        private static readonly VisitFunctionPointerCallingConventionDelegate6 VisitFunctionPointerCallingConventionFunc6;
        private static readonly VisitFunctionPointerParameterDelegate7 VisitFunctionPointerParameterFunc7;
        private static readonly VisitFunctionPointerParameterListDelegate8 VisitFunctionPointerParameterListFunc8;
        private static readonly VisitFunctionPointerTypeDelegate9 VisitFunctionPointerTypeFunc9;
        private static readonly VisitFunctionPointerUnmanagedCallingConventionDelegate10 VisitFunctionPointerUnmanagedCallingConventionFunc10;
        private static readonly VisitFunctionPointerUnmanagedCallingConventionListDelegate11 VisitFunctionPointerUnmanagedCallingConventionListFunc11;
        private static readonly VisitImplicitObjectCreationExpressionDelegate12 VisitImplicitObjectCreationExpressionFunc12;
        private static readonly VisitLineDirectivePositionDelegate13 VisitLineDirectivePositionFunc13;
        private static readonly VisitLineSpanDirectiveTriviaDelegate14 VisitLineSpanDirectiveTriviaFunc14;
        private static readonly VisitListPatternDelegate15 VisitListPatternFunc15;
        private static readonly VisitParenthesizedPatternDelegate16 VisitParenthesizedPatternFunc16;
        private static readonly VisitPrimaryConstructorBaseTypeDelegate17 VisitPrimaryConstructorBaseTypeFunc17;
        private static readonly VisitRecordDeclarationDelegate18 VisitRecordDeclarationFunc18;
        private static readonly VisitRelationalPatternDelegate19 VisitRelationalPatternFunc19;
        private static readonly VisitScopedTypeDelegate20 VisitScopedTypeFunc20;
        private static readonly VisitSlicePatternDelegate21 VisitSlicePatternFunc21;
        private static readonly VisitSpreadElementDelegate22 VisitSpreadElementFunc22;
        private static readonly VisitTypePatternDelegate23 VisitTypePatternFunc23;
        private static readonly VisitUnaryPatternDelegate24 VisitUnaryPatternFunc24;
        private static readonly VisitWithExpressionDelegate25 VisitWithExpressionFunc25;

        static CSharpSyntaxVisitorExtensions()
        {
            var wrappedType = CSharpLightupHelper.FindType(WrappedTypeName);

            VisitBinaryPatternFunc0 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitBinaryPatternDelegate0>(wrappedType, "VisitBinaryPattern", "nodeBinaryPatternSyntax");
            VisitCollectionExpressionFunc1 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitCollectionExpressionDelegate1>(wrappedType, "VisitCollectionExpression", "nodeCollectionExpressionSyntax");
            VisitDefaultConstraintFunc2 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitDefaultConstraintDelegate2>(wrappedType, "VisitDefaultConstraint", "nodeDefaultConstraintSyntax");
            VisitExpressionColonFunc3 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitExpressionColonDelegate3>(wrappedType, "VisitExpressionColon", "nodeExpressionColonSyntax");
            VisitExpressionElementFunc4 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitExpressionElementDelegate4>(wrappedType, "VisitExpressionElement", "nodeExpressionElementSyntax");
            VisitFileScopedNamespaceDeclarationFunc5 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitFileScopedNamespaceDeclarationDelegate5>(wrappedType, "VisitFileScopedNamespaceDeclaration", "nodeFileScopedNamespaceDeclarationSyntax");
            VisitFunctionPointerCallingConventionFunc6 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerCallingConventionDelegate6>(wrappedType, "VisitFunctionPointerCallingConvention", "nodeFunctionPointerCallingConventionSyntax");
            VisitFunctionPointerParameterFunc7 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerParameterDelegate7>(wrappedType, "VisitFunctionPointerParameter", "nodeFunctionPointerParameterSyntax");
            VisitFunctionPointerParameterListFunc8 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerParameterListDelegate8>(wrappedType, "VisitFunctionPointerParameterList", "nodeFunctionPointerParameterListSyntax");
            VisitFunctionPointerTypeFunc9 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerTypeDelegate9>(wrappedType, "VisitFunctionPointerType", "nodeFunctionPointerTypeSyntax");
            VisitFunctionPointerUnmanagedCallingConventionFunc10 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerUnmanagedCallingConventionDelegate10>(wrappedType, "VisitFunctionPointerUnmanagedCallingConvention", "nodeFunctionPointerUnmanagedCallingConventionSyntax");
            VisitFunctionPointerUnmanagedCallingConventionListFunc11 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerUnmanagedCallingConventionListDelegate11>(wrappedType, "VisitFunctionPointerUnmanagedCallingConventionList", "nodeFunctionPointerUnmanagedCallingConventionListSyntax");
            VisitImplicitObjectCreationExpressionFunc12 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitImplicitObjectCreationExpressionDelegate12>(wrappedType, "VisitImplicitObjectCreationExpression", "nodeImplicitObjectCreationExpressionSyntax");
            VisitLineDirectivePositionFunc13 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitLineDirectivePositionDelegate13>(wrappedType, "VisitLineDirectivePosition", "nodeLineDirectivePositionSyntax");
            VisitLineSpanDirectiveTriviaFunc14 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitLineSpanDirectiveTriviaDelegate14>(wrappedType, "VisitLineSpanDirectiveTrivia", "nodeLineSpanDirectiveTriviaSyntax");
            VisitListPatternFunc15 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitListPatternDelegate15>(wrappedType, "VisitListPattern", "nodeListPatternSyntax");
            VisitParenthesizedPatternFunc16 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitParenthesizedPatternDelegate16>(wrappedType, "VisitParenthesizedPattern", "nodeParenthesizedPatternSyntax");
            VisitPrimaryConstructorBaseTypeFunc17 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitPrimaryConstructorBaseTypeDelegate17>(wrappedType, "VisitPrimaryConstructorBaseType", "nodePrimaryConstructorBaseTypeSyntax");
            VisitRecordDeclarationFunc18 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitRecordDeclarationDelegate18>(wrappedType, "VisitRecordDeclaration", "nodeRecordDeclarationSyntax");
            VisitRelationalPatternFunc19 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitRelationalPatternDelegate19>(wrappedType, "VisitRelationalPattern", "nodeRelationalPatternSyntax");
            VisitScopedTypeFunc20 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitScopedTypeDelegate20>(wrappedType, "VisitScopedType", "nodeScopedTypeSyntax");
            VisitSlicePatternFunc21 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitSlicePatternDelegate21>(wrappedType, "VisitSlicePattern", "nodeSlicePatternSyntax");
            VisitSpreadElementFunc22 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitSpreadElementDelegate22>(wrappedType, "VisitSpreadElement", "nodeSpreadElementSyntax");
            VisitTypePatternFunc23 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitTypePatternDelegate23>(wrappedType, "VisitTypePattern", "nodeTypePatternSyntax");
            VisitUnaryPatternFunc24 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitUnaryPatternDelegate24>(wrappedType, "VisitUnaryPattern", "nodeUnaryPatternSyntax");
            VisitWithExpressionFunc25 = CSharpLightupHelper.CreateInstanceMethodAccessor<VisitWithExpressionDelegate25>(wrappedType, "VisitWithExpression", "nodeWithExpressionSyntax");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitBinaryPattern(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.BinaryPatternSyntaxWrapper node)
            => VisitBinaryPatternFunc0(_obj, node);

        /// <summary>Method added in version 4.8.0.0.</summary>
        public static void VisitCollectionExpression(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.CollectionExpressionSyntaxWrapper node)
            => VisitCollectionExpressionFunc1(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitDefaultConstraint(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.DefaultConstraintSyntaxWrapper node)
            => VisitDefaultConstraintFunc2(_obj, node);

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static void VisitExpressionColon(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExpressionColonSyntaxWrapper node)
            => VisitExpressionColonFunc3(_obj, node);

        /// <summary>Method added in version 4.8.0.0.</summary>
        public static void VisitExpressionElement(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExpressionElementSyntaxWrapper node)
            => VisitExpressionElementFunc4(_obj, node);

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static void VisitFileScopedNamespaceDeclaration(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FileScopedNamespaceDeclarationSyntaxWrapper node)
            => VisitFileScopedNamespaceDeclarationFunc5(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitFunctionPointerCallingConvention(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerCallingConventionSyntaxWrapper node)
            => VisitFunctionPointerCallingConventionFunc6(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitFunctionPointerParameter(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerParameterSyntaxWrapper node)
            => VisitFunctionPointerParameterFunc7(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitFunctionPointerParameterList(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerParameterListSyntaxWrapper node)
            => VisitFunctionPointerParameterListFunc8(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitFunctionPointerType(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerTypeSyntaxWrapper node)
            => VisitFunctionPointerTypeFunc9(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitFunctionPointerUnmanagedCallingConvention(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerUnmanagedCallingConventionSyntaxWrapper node)
            => VisitFunctionPointerUnmanagedCallingConventionFunc10(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitFunctionPointerUnmanagedCallingConventionList(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerUnmanagedCallingConventionListSyntaxWrapper node)
            => VisitFunctionPointerUnmanagedCallingConventionListFunc11(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitImplicitObjectCreationExpression(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ImplicitObjectCreationExpressionSyntaxWrapper node)
            => VisitImplicitObjectCreationExpressionFunc12(_obj, node);

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static void VisitLineDirectivePosition(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper node)
            => VisitLineDirectivePositionFunc13(_obj, node);

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static void VisitLineSpanDirectiveTrivia(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineSpanDirectiveTriviaSyntaxWrapper node)
            => VisitLineSpanDirectiveTriviaFunc14(_obj, node);

        /// <summary>Method added in version 4.4.0.0.</summary>
        public static void VisitListPattern(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ListPatternSyntaxWrapper node)
            => VisitListPatternFunc15(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitParenthesizedPattern(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedPatternSyntaxWrapper node)
            => VisitParenthesizedPatternFunc16(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitPrimaryConstructorBaseType(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.PrimaryConstructorBaseTypeSyntaxWrapper node)
            => VisitPrimaryConstructorBaseTypeFunc17(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitRecordDeclaration(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.RecordDeclarationSyntaxWrapper node)
            => VisitRecordDeclarationFunc18(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitRelationalPattern(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.RelationalPatternSyntaxWrapper node)
            => VisitRelationalPatternFunc19(_obj, node);

        /// <summary>Method added in version 4.4.0.0.</summary>
        public static void VisitScopedType(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ScopedTypeSyntaxWrapper node)
            => VisitScopedTypeFunc20(_obj, node);

        /// <summary>Method added in version 4.4.0.0.</summary>
        public static void VisitSlicePattern(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SlicePatternSyntaxWrapper node)
            => VisitSlicePatternFunc21(_obj, node);

        /// <summary>Method added in version 4.8.0.0.</summary>
        public static void VisitSpreadElement(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.SpreadElementSyntaxWrapper node)
            => VisitSpreadElementFunc22(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitTypePattern(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.TypePatternSyntaxWrapper node)
            => VisitTypePatternFunc23(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitUnaryPattern(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.UnaryPatternSyntaxWrapper node)
            => VisitUnaryPatternFunc24(_obj, node);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitWithExpression(this Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor _obj, Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.WithExpressionSyntaxWrapper node)
            => VisitWithExpressionFunc25(_obj, node);
    }
}