﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax.</summary>
    public static partial class LockStatementSyntaxEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax";

        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax _obj);

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax AddAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax UpdateDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxToken lockKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax WithAttributeListsDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithAttributeListsDelegate2 WithAttributeListsFunc2;

        static LockStatementSyntaxEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(wrappedType, nameof(AttributeLists));

            AddAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(wrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            UpdateFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(wrappedType, "Update", "attributeListsSyntaxList`1", "lockKeywordSyntaxToken", "openParenTokenSyntaxToken", "expressionExpressionSyntax", "closeParenTokenSyntaxToken", "statementStatementSyntax");
            WithAttributeListsFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate2>(wrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
        }

        /// <summary>Property added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax _obj)
        {
            return AttributeListsGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax AddAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
        {
            return AddAttributeListsFunc0(_obj, items);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax Update(this global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxToken lockKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return UpdateFunc1(_obj, attributeLists, lockKeyword, openParenToken, expression, closeParenToken, statement);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax WithAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
        {
            return WithAttributeListsFunc2(_obj, attributeLists);
        }
    }
}
