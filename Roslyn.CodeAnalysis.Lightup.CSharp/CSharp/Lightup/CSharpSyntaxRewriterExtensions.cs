﻿// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Lightup
{
    /// <summary>Class added in Roslyn version </summary>
    public static class CSharpSyntaxRewriterExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.CSharpSyntaxRewriter";

        public static readonly Type? WrappedType;

        private delegate SyntaxNode? VisitBinaryPatternDelegate0(CSharpSyntaxRewriter? _obj, BinaryPatternSyntaxWrapper node);
        private delegate SyntaxNode? VisitCollectionExpressionDelegate1(CSharpSyntaxRewriter? _obj, CollectionExpressionSyntaxWrapper node);
        private delegate SyntaxNode? VisitDefaultConstraintDelegate2(CSharpSyntaxRewriter? _obj, DefaultConstraintSyntaxWrapper node);
        private delegate SyntaxNode? VisitExpressionColonDelegate3(CSharpSyntaxRewriter? _obj, ExpressionColonSyntaxWrapper node);
        private delegate SyntaxNode? VisitExpressionElementDelegate4(CSharpSyntaxRewriter? _obj, ExpressionElementSyntaxWrapper node);
        private delegate SyntaxNode? VisitFileScopedNamespaceDeclarationDelegate5(CSharpSyntaxRewriter? _obj, FileScopedNamespaceDeclarationSyntaxWrapper node);
        private delegate SyntaxNode? VisitFunctionPointerCallingConventionDelegate6(CSharpSyntaxRewriter? _obj, FunctionPointerCallingConventionSyntaxWrapper node);
        private delegate SyntaxNode? VisitFunctionPointerParameterDelegate7(CSharpSyntaxRewriter? _obj, FunctionPointerParameterSyntaxWrapper node);
        private delegate SyntaxNode? VisitFunctionPointerParameterListDelegate8(CSharpSyntaxRewriter? _obj, FunctionPointerParameterListSyntaxWrapper node);
        private delegate SyntaxNode? VisitFunctionPointerTypeDelegate9(CSharpSyntaxRewriter? _obj, FunctionPointerTypeSyntaxWrapper node);
        private delegate SyntaxNode? VisitFunctionPointerUnmanagedCallingConventionDelegate10(CSharpSyntaxRewriter? _obj, FunctionPointerUnmanagedCallingConventionSyntaxWrapper node);
        private delegate SyntaxNode? VisitFunctionPointerUnmanagedCallingConventionListDelegate11(CSharpSyntaxRewriter? _obj, FunctionPointerUnmanagedCallingConventionListSyntaxWrapper node);
        private delegate SyntaxNode? VisitImplicitObjectCreationExpressionDelegate12(CSharpSyntaxRewriter? _obj, ImplicitObjectCreationExpressionSyntaxWrapper node);
        private delegate SyntaxNode? VisitLineDirectivePositionDelegate13(CSharpSyntaxRewriter? _obj, LineDirectivePositionSyntaxWrapper node);
        private delegate SyntaxNode? VisitLineSpanDirectiveTriviaDelegate14(CSharpSyntaxRewriter? _obj, LineSpanDirectiveTriviaSyntaxWrapper node);
        private delegate SyntaxNode? VisitListPatternDelegate15(CSharpSyntaxRewriter? _obj, ListPatternSyntaxWrapper node);
        private delegate SyntaxNode? VisitParenthesizedPatternDelegate16(CSharpSyntaxRewriter? _obj, ParenthesizedPatternSyntaxWrapper node);
        private delegate SyntaxNode? VisitPrimaryConstructorBaseTypeDelegate17(CSharpSyntaxRewriter? _obj, PrimaryConstructorBaseTypeSyntaxWrapper node);
        private delegate SyntaxNode? VisitRecordDeclarationDelegate18(CSharpSyntaxRewriter? _obj, RecordDeclarationSyntaxWrapper node);
        private delegate SyntaxNode? VisitRelationalPatternDelegate19(CSharpSyntaxRewriter? _obj, RelationalPatternSyntaxWrapper node);
        private delegate SyntaxNode? VisitScopedTypeDelegate20(CSharpSyntaxRewriter? _obj, ScopedTypeSyntaxWrapper node);
        private delegate SyntaxNode? VisitSlicePatternDelegate21(CSharpSyntaxRewriter? _obj, SlicePatternSyntaxWrapper node);
        private delegate SyntaxNode? VisitSpreadElementDelegate22(CSharpSyntaxRewriter? _obj, SpreadElementSyntaxWrapper node);
        private delegate SyntaxNode? VisitTypePatternDelegate23(CSharpSyntaxRewriter? _obj, TypePatternSyntaxWrapper node);
        private delegate SyntaxNode? VisitUnaryPatternDelegate24(CSharpSyntaxRewriter? _obj, UnaryPatternSyntaxWrapper node);
        private delegate SyntaxNode? VisitWithExpressionDelegate25(CSharpSyntaxRewriter? _obj, WithExpressionSyntaxWrapper node);

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

        static CSharpSyntaxRewriterExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            VisitBinaryPatternFunc0 = LightupHelper.CreateInstanceMethodAccessor<VisitBinaryPatternDelegate0>(WrappedType, nameof(VisitBinaryPattern));
            VisitCollectionExpressionFunc1 = LightupHelper.CreateInstanceMethodAccessor<VisitCollectionExpressionDelegate1>(WrappedType, nameof(VisitCollectionExpression));
            VisitDefaultConstraintFunc2 = LightupHelper.CreateInstanceMethodAccessor<VisitDefaultConstraintDelegate2>(WrappedType, nameof(VisitDefaultConstraint));
            VisitExpressionColonFunc3 = LightupHelper.CreateInstanceMethodAccessor<VisitExpressionColonDelegate3>(WrappedType, nameof(VisitExpressionColon));
            VisitExpressionElementFunc4 = LightupHelper.CreateInstanceMethodAccessor<VisitExpressionElementDelegate4>(WrappedType, nameof(VisitExpressionElement));
            VisitFileScopedNamespaceDeclarationFunc5 = LightupHelper.CreateInstanceMethodAccessor<VisitFileScopedNamespaceDeclarationDelegate5>(WrappedType, nameof(VisitFileScopedNamespaceDeclaration));
            VisitFunctionPointerCallingConventionFunc6 = LightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerCallingConventionDelegate6>(WrappedType, nameof(VisitFunctionPointerCallingConvention));
            VisitFunctionPointerParameterFunc7 = LightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerParameterDelegate7>(WrappedType, nameof(VisitFunctionPointerParameter));
            VisitFunctionPointerParameterListFunc8 = LightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerParameterListDelegate8>(WrappedType, nameof(VisitFunctionPointerParameterList));
            VisitFunctionPointerTypeFunc9 = LightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerTypeDelegate9>(WrappedType, nameof(VisitFunctionPointerType));
            VisitFunctionPointerUnmanagedCallingConventionFunc10 = LightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerUnmanagedCallingConventionDelegate10>(WrappedType, nameof(VisitFunctionPointerUnmanagedCallingConvention));
            VisitFunctionPointerUnmanagedCallingConventionListFunc11 = LightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerUnmanagedCallingConventionListDelegate11>(WrappedType, nameof(VisitFunctionPointerUnmanagedCallingConventionList));
            VisitImplicitObjectCreationExpressionFunc12 = LightupHelper.CreateInstanceMethodAccessor<VisitImplicitObjectCreationExpressionDelegate12>(WrappedType, nameof(VisitImplicitObjectCreationExpression));
            VisitLineDirectivePositionFunc13 = LightupHelper.CreateInstanceMethodAccessor<VisitLineDirectivePositionDelegate13>(WrappedType, nameof(VisitLineDirectivePosition));
            VisitLineSpanDirectiveTriviaFunc14 = LightupHelper.CreateInstanceMethodAccessor<VisitLineSpanDirectiveTriviaDelegate14>(WrappedType, nameof(VisitLineSpanDirectiveTrivia));
            VisitListPatternFunc15 = LightupHelper.CreateInstanceMethodAccessor<VisitListPatternDelegate15>(WrappedType, nameof(VisitListPattern));
            VisitParenthesizedPatternFunc16 = LightupHelper.CreateInstanceMethodAccessor<VisitParenthesizedPatternDelegate16>(WrappedType, nameof(VisitParenthesizedPattern));
            VisitPrimaryConstructorBaseTypeFunc17 = LightupHelper.CreateInstanceMethodAccessor<VisitPrimaryConstructorBaseTypeDelegate17>(WrappedType, nameof(VisitPrimaryConstructorBaseType));
            VisitRecordDeclarationFunc18 = LightupHelper.CreateInstanceMethodAccessor<VisitRecordDeclarationDelegate18>(WrappedType, nameof(VisitRecordDeclaration));
            VisitRelationalPatternFunc19 = LightupHelper.CreateInstanceMethodAccessor<VisitRelationalPatternDelegate19>(WrappedType, nameof(VisitRelationalPattern));
            VisitScopedTypeFunc20 = LightupHelper.CreateInstanceMethodAccessor<VisitScopedTypeDelegate20>(WrappedType, nameof(VisitScopedType));
            VisitSlicePatternFunc21 = LightupHelper.CreateInstanceMethodAccessor<VisitSlicePatternDelegate21>(WrappedType, nameof(VisitSlicePattern));
            VisitSpreadElementFunc22 = LightupHelper.CreateInstanceMethodAccessor<VisitSpreadElementDelegate22>(WrappedType, nameof(VisitSpreadElement));
            VisitTypePatternFunc23 = LightupHelper.CreateInstanceMethodAccessor<VisitTypePatternDelegate23>(WrappedType, nameof(VisitTypePattern));
            VisitUnaryPatternFunc24 = LightupHelper.CreateInstanceMethodAccessor<VisitUnaryPatternDelegate24>(WrappedType, nameof(VisitUnaryPattern));
            VisitWithExpressionFunc25 = LightupHelper.CreateInstanceMethodAccessor<VisitWithExpressionDelegate25>(WrappedType, nameof(VisitWithExpression));
        }

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitBinaryPattern(this CSharpSyntaxRewriter wrappedObject, BinaryPatternSyntaxWrapper node)
            => VisitBinaryPatternFunc0(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.8.0.0</summary>
        public static SyntaxNode? VisitCollectionExpression(this CSharpSyntaxRewriter wrappedObject, CollectionExpressionSyntaxWrapper node)
            => VisitCollectionExpressionFunc1(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitDefaultConstraint(this CSharpSyntaxRewriter wrappedObject, DefaultConstraintSyntaxWrapper node)
            => VisitDefaultConstraintFunc2(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.0.0.0</summary>
        public static SyntaxNode? VisitExpressionColon(this CSharpSyntaxRewriter wrappedObject, ExpressionColonSyntaxWrapper node)
            => VisitExpressionColonFunc3(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.8.0.0</summary>
        public static SyntaxNode? VisitExpressionElement(this CSharpSyntaxRewriter wrappedObject, ExpressionElementSyntaxWrapper node)
            => VisitExpressionElementFunc4(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.0.0.0</summary>
        public static SyntaxNode? VisitFileScopedNamespaceDeclaration(this CSharpSyntaxRewriter wrappedObject, FileScopedNamespaceDeclarationSyntaxWrapper node)
            => VisitFileScopedNamespaceDeclarationFunc5(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitFunctionPointerCallingConvention(this CSharpSyntaxRewriter wrappedObject, FunctionPointerCallingConventionSyntaxWrapper node)
            => VisitFunctionPointerCallingConventionFunc6(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitFunctionPointerParameter(this CSharpSyntaxRewriter wrappedObject, FunctionPointerParameterSyntaxWrapper node)
            => VisitFunctionPointerParameterFunc7(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitFunctionPointerParameterList(this CSharpSyntaxRewriter wrappedObject, FunctionPointerParameterListSyntaxWrapper node)
            => VisitFunctionPointerParameterListFunc8(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitFunctionPointerType(this CSharpSyntaxRewriter wrappedObject, FunctionPointerTypeSyntaxWrapper node)
            => VisitFunctionPointerTypeFunc9(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitFunctionPointerUnmanagedCallingConvention(this CSharpSyntaxRewriter wrappedObject, FunctionPointerUnmanagedCallingConventionSyntaxWrapper node)
            => VisitFunctionPointerUnmanagedCallingConventionFunc10(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitFunctionPointerUnmanagedCallingConventionList(this CSharpSyntaxRewriter wrappedObject, FunctionPointerUnmanagedCallingConventionListSyntaxWrapper node)
            => VisitFunctionPointerUnmanagedCallingConventionListFunc11(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitImplicitObjectCreationExpression(this CSharpSyntaxRewriter wrappedObject, ImplicitObjectCreationExpressionSyntaxWrapper node)
            => VisitImplicitObjectCreationExpressionFunc12(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.0.0.0</summary>
        public static SyntaxNode? VisitLineDirectivePosition(this CSharpSyntaxRewriter wrappedObject, LineDirectivePositionSyntaxWrapper node)
            => VisitLineDirectivePositionFunc13(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.0.0.0</summary>
        public static SyntaxNode? VisitLineSpanDirectiveTrivia(this CSharpSyntaxRewriter wrappedObject, LineSpanDirectiveTriviaSyntaxWrapper node)
            => VisitLineSpanDirectiveTriviaFunc14(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.4.0.0</summary>
        public static SyntaxNode? VisitListPattern(this CSharpSyntaxRewriter wrappedObject, ListPatternSyntaxWrapper node)
            => VisitListPatternFunc15(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitParenthesizedPattern(this CSharpSyntaxRewriter wrappedObject, ParenthesizedPatternSyntaxWrapper node)
            => VisitParenthesizedPatternFunc16(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitPrimaryConstructorBaseType(this CSharpSyntaxRewriter wrappedObject, PrimaryConstructorBaseTypeSyntaxWrapper node)
            => VisitPrimaryConstructorBaseTypeFunc17(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitRecordDeclaration(this CSharpSyntaxRewriter wrappedObject, RecordDeclarationSyntaxWrapper node)
            => VisitRecordDeclarationFunc18(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitRelationalPattern(this CSharpSyntaxRewriter wrappedObject, RelationalPatternSyntaxWrapper node)
            => VisitRelationalPatternFunc19(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.4.0.0</summary>
        public static SyntaxNode? VisitScopedType(this CSharpSyntaxRewriter wrappedObject, ScopedTypeSyntaxWrapper node)
            => VisitScopedTypeFunc20(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.4.0.0</summary>
        public static SyntaxNode? VisitSlicePattern(this CSharpSyntaxRewriter wrappedObject, SlicePatternSyntaxWrapper node)
            => VisitSlicePatternFunc21(wrappedObject, node);

        /// <summary>Added in Roslyn version 4.8.0.0</summary>
        public static SyntaxNode? VisitSpreadElement(this CSharpSyntaxRewriter wrappedObject, SpreadElementSyntaxWrapper node)
            => VisitSpreadElementFunc22(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitTypePattern(this CSharpSyntaxRewriter wrappedObject, TypePatternSyntaxWrapper node)
            => VisitTypePatternFunc23(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitUnaryPattern(this CSharpSyntaxRewriter wrappedObject, UnaryPatternSyntaxWrapper node)
            => VisitUnaryPatternFunc24(wrappedObject, node);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxNode? VisitWithExpression(this CSharpSyntaxRewriter wrappedObject, WithExpressionSyntaxWrapper node)
            => VisitWithExpressionFunc25(wrappedObject, node);
    }
}