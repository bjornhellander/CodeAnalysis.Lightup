﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax.</summary>
    public static partial class ForEachVariableStatementSyntaxEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax";

        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken AwaitKeywordGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj);

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax AddAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax UpdateDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax UpdateDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax WithAttributeListsDelegate3(global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax WithAwaitKeywordDelegate4(global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;
        private static readonly AwaitKeywordGetterDelegate AwaitKeywordGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly UpdateDelegate2 UpdateFunc2;
        private static readonly WithAttributeListsDelegate3 WithAttributeListsFunc3;
        private static readonly WithAwaitKeywordDelegate4 WithAwaitKeywordFunc4;

        static ForEachVariableStatementSyntaxEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(wrappedType, nameof(AttributeLists));
            AwaitKeywordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AwaitKeywordGetterDelegate>(wrappedType, nameof(AwaitKeyword));

            AddAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(wrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            UpdateFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(wrappedType, "Update", "awaitKeywordSyntaxToken", "forEachKeywordSyntaxToken", "openParenTokenSyntaxToken", "variableExpressionSyntax", "inKeywordSyntaxToken", "expressionExpressionSyntax", "closeParenTokenSyntaxToken", "statementStatementSyntax");
            UpdateFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate2>(wrappedType, "Update", "attributeListsSyntaxList`1", "awaitKeywordSyntaxToken", "forEachKeywordSyntaxToken", "openParenTokenSyntaxToken", "variableExpressionSyntax", "inKeywordSyntaxToken", "expressionExpressionSyntax", "closeParenTokenSyntaxToken", "statementStatementSyntax");
            WithAttributeListsFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate3>(wrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
            WithAwaitKeywordFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAwaitKeywordDelegate4>(wrappedType, "WithAwaitKeyword", "awaitKeywordSyntaxToken");
        }

        /// <summary>Property added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj)
        {
            return AttributeListsGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxToken AwaitKeyword(this global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj)
        {
            return AwaitKeywordGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax AddAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
        {
            return AddAttributeListsFunc0(_obj, items);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax Update(this global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return UpdateFunc1(_obj, awaitKeyword, forEachKeyword, openParenToken, variable, inKeyword, expression, closeParenToken, statement);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax Update(this global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return UpdateFunc2(_obj, attributeLists, awaitKeyword, forEachKeyword, openParenToken, variable, inKeyword, expression, closeParenToken, statement);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax WithAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
        {
            return WithAttributeListsFunc3(_obj, attributeLists);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax WithAwaitKeyword(this global::Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword)
        {
            return WithAwaitKeywordFunc4(_obj, awaitKeyword);
        }
    }
}
