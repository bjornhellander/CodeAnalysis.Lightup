﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax.</summary>
    public static partial class UsingStatementSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax";

        private delegate Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax? _obj);

        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax AddAttributeListsDelegate0(Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax? _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax UpdateDelegate1(Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax? _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, Microsoft.CodeAnalysis.SyntaxToken usingKeyword, Microsoft.CodeAnalysis.SyntaxToken openParenToken, Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax? declaration, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expression, Microsoft.CodeAnalysis.SyntaxToken closeParenToken, Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax WithAttributeListsDelegate2(Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax? _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithAttributeListsDelegate2 WithAttributeListsFunc2;

        static UsingStatementSyntaxExtensions()
        {
            var wrappedType = CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(wrappedType, nameof(AttributeLists));

            AddAttributeListsFunc0 = CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(wrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            UpdateFunc1 = CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(wrappedType, "Update", "attributeListsSyntaxList`1", "awaitKeywordSyntaxToken", "usingKeywordSyntaxToken", "openParenTokenSyntaxToken", "declarationVariableDeclarationSyntax", "expressionExpressionSyntax", "closeParenTokenSyntaxToken", "statementStatementSyntax");
            WithAttributeListsFunc2 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate2>(wrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj)
            => AttributeListsGetterFunc(_obj);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax AddAttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
            => AddAttributeListsFunc0(_obj, items);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax Update(this Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, Microsoft.CodeAnalysis.SyntaxToken usingKeyword, Microsoft.CodeAnalysis.SyntaxToken openParenToken, Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax? declaration, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expression, Microsoft.CodeAnalysis.SyntaxToken closeParenToken, Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
            => UpdateFunc1(_obj, attributeLists, awaitKeyword, usingKeyword, openParenToken, declaration, expression, closeParenToken, statement);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax WithAttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
            => WithAttributeListsFunc2(_obj, attributeLists);
    }
}