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

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Class added in Roslyn version </summary>
    public static class SwitchStatementSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.SwitchStatementSyntax";

        public static readonly Type? WrappedType;

        private delegate SyntaxList<AttributeListSyntax> AttributeListsGetterDelegate(SwitchStatementSyntax? _obj);

        private delegate SwitchStatementSyntax AddAttributeListsDelegate0(SwitchStatementSyntax? _obj, params AttributeListSyntax[] items);
        private delegate SwitchStatementSyntax UpdateDelegate1(SwitchStatementSyntax? _obj, SyntaxList<AttributeListSyntax> attributeLists, SyntaxToken switchKeyword, SyntaxToken openParenToken, ExpressionSyntax expression, SyntaxToken closeParenToken, SyntaxToken openBraceToken, SyntaxList<SwitchSectionSyntax> sections, SyntaxToken closeBraceToken);
        private delegate SwitchStatementSyntax WithAttributeListsDelegate2(SwitchStatementSyntax? _obj, SyntaxList<AttributeListSyntax> attributeLists);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithAttributeListsDelegate2 WithAttributeListsFunc2;

        static SwitchStatementSyntaxExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = LightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(WrappedType, nameof(AttributeLists));

            AddAttributeListsFunc0 = LightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(WrappedType, nameof(AddAttributeLists));
            UpdateFunc1 = LightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(WrappedType, nameof(Update));
            WithAttributeListsFunc2 = LightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate2>(WrappedType, nameof(WithAttributeLists));
        }

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SyntaxList<AttributeListSyntax> AttributeLists(this SwitchStatementSyntax _obj)
            => AttributeListsGetterFunc(_obj);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SwitchStatementSyntax AddAttributeLists(this SwitchStatementSyntax wrappedObject, params AttributeListSyntax[] items)
            => AddAttributeListsFunc0(wrappedObject, items);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SwitchStatementSyntax Update(this SwitchStatementSyntax wrappedObject, SyntaxList<AttributeListSyntax> attributeLists, SyntaxToken switchKeyword, SyntaxToken openParenToken, ExpressionSyntax expression, SyntaxToken closeParenToken, SyntaxToken openBraceToken, SyntaxList<SwitchSectionSyntax> sections, SyntaxToken closeBraceToken)
            => UpdateFunc1(wrappedObject, attributeLists, switchKeyword, openParenToken, expression, closeParenToken, openBraceToken, sections, closeBraceToken);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static SwitchStatementSyntax WithAttributeLists(this SwitchStatementSyntax wrappedObject, SyntaxList<AttributeListSyntax> attributeLists)
            => WithAttributeListsFunc2(wrappedObject, attributeLists);
    }
}