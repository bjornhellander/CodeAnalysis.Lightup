﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax.</summary>
    public static partial class UsingStatementSyntaxEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax";

        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken AwaitKeywordGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj);

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax AddAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax UpdateDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken usingKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax? declaration, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax UpdateDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken usingKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax? declaration, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax WithAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax WithAwaitKeywordDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;
        private static readonly AwaitKeywordGetterDelegate AwaitKeywordGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly UpdateDelegate0 UpdateFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithAttributeListsDelegate0 WithAttributeListsFunc0;
        private static readonly WithAwaitKeywordDelegate0 WithAwaitKeywordFunc0;

        static UsingStatementSyntaxEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(wrappedType, nameof(AttributeLists));
            AwaitKeywordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AwaitKeywordGetterDelegate>(wrappedType, nameof(AwaitKeyword));

            AddAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(wrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            UpdateFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate0>(wrappedType, "Update", "awaitKeywordSyntaxToken", "usingKeywordSyntaxToken", "openParenTokenSyntaxToken", "declarationVariableDeclarationSyntax", "expressionExpressionSyntax", "closeParenTokenSyntaxToken", "statementStatementSyntax");
            UpdateFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(wrappedType, "Update", "attributeListsSyntaxList`1", "awaitKeywordSyntaxToken", "usingKeywordSyntaxToken", "openParenTokenSyntaxToken", "declarationVariableDeclarationSyntax", "expressionExpressionSyntax", "closeParenTokenSyntaxToken", "statementStatementSyntax");
            WithAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate0>(wrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
            WithAwaitKeywordFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAwaitKeywordDelegate0>(wrappedType, "WithAwaitKeyword", "awaitKeywordSyntaxToken");
        }

        /// <summary>Property added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj)
        {
            return AttributeListsGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxToken AwaitKeyword(this global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj)
        {
            return AwaitKeywordGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax AddAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
        {
            return AddAttributeListsFunc0(_obj, items);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax Update(this global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken usingKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax? declaration, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return UpdateFunc0(_obj, awaitKeyword, usingKeyword, openParenToken, declaration, expression, closeParenToken, statement);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax Update(this global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken usingKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax? declaration, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return UpdateFunc1(_obj, attributeLists, awaitKeyword, usingKeyword, openParenToken, declaration, expression, closeParenToken, statement);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax WithAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
        {
            return WithAttributeListsFunc0(_obj, attributeLists);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax WithAwaitKeyword(this global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword)
        {
            return WithAwaitKeywordFunc0(_obj, awaitKeyword);
        }
    }
}
