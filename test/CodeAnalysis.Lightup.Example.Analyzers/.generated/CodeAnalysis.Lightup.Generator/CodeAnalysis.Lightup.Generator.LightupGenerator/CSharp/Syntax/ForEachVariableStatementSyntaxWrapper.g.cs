﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax. Added in version 2.0.0.0.</summary>
    public partial struct ForEachVariableStatementSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.ForEachVariableStatementSyntax";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken AwaitKeywordGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken CloseParenTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax ExpressionGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken ForEachKeywordGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken InKeywordGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken OpenParenTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax StatementGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax VariableGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj);

        private delegate void AcceptDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper AddAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper UpdateDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper UpdateDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper UpdateDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithAwaitKeywordDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithCloseParenTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithExpressionDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithForEachKeywordDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithInKeywordDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithOpenParenTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithStatementDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithVariableDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;
        private static readonly AwaitKeywordGetterDelegate AwaitKeywordGetterFunc;
        private static readonly CloseParenTokenGetterDelegate CloseParenTokenGetterFunc;
        private static readonly ExpressionGetterDelegate ExpressionGetterFunc;
        private static readonly ForEachKeywordGetterDelegate ForEachKeywordGetterFunc;
        private static readonly InKeywordGetterDelegate InKeywordGetterFunc;
        private static readonly OpenParenTokenGetterDelegate OpenParenTokenGetterFunc;
        private static readonly StatementGetterDelegate StatementGetterFunc;
        private static readonly VariableGetterDelegate VariableGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly UpdateDelegate0 UpdateFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly UpdateDelegate2 UpdateFunc2;
        private static readonly WithAttributeListsDelegate0 WithAttributeListsFunc0;
        private static readonly WithAwaitKeywordDelegate0 WithAwaitKeywordFunc0;
        private static readonly WithCloseParenTokenDelegate0 WithCloseParenTokenFunc0;
        private static readonly WithExpressionDelegate0 WithExpressionFunc0;
        private static readonly WithForEachKeywordDelegate0 WithForEachKeywordFunc0;
        private static readonly WithInKeywordDelegate0 WithInKeywordFunc0;
        private static readonly WithOpenParenTokenDelegate0 WithOpenParenTokenFunc0;
        private static readonly WithStatementDelegate0 WithStatementFunc0;
        private static readonly WithVariableDelegate0 WithVariableFunc0;

        private readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax wrappedObject;

        static ForEachVariableStatementSyntaxWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(WrappedType, nameof(AttributeLists));
            AwaitKeywordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AwaitKeywordGetterDelegate>(WrappedType, nameof(AwaitKeyword));
            CloseParenTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CloseParenTokenGetterDelegate>(WrappedType, nameof(CloseParenToken));
            ExpressionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ExpressionGetterDelegate>(WrappedType, nameof(Expression));
            ForEachKeywordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ForEachKeywordGetterDelegate>(WrappedType, nameof(ForEachKeyword));
            InKeywordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<InKeywordGetterDelegate>(WrappedType, nameof(InKeyword));
            OpenParenTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<OpenParenTokenGetterDelegate>(WrappedType, nameof(OpenParenToken));
            StatementGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<StatementGetterDelegate>(WrappedType, nameof(Statement));
            VariableGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<VariableGetterDelegate>(WrappedType, nameof(Variable));

            AcceptFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            AddAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(WrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            UpdateFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate0>(WrappedType, "Update", "forEachKeywordSyntaxToken", "openParenTokenSyntaxToken", "variableExpressionSyntax", "inKeywordSyntaxToken", "expressionExpressionSyntax", "closeParenTokenSyntaxToken", "statementStatementSyntax");
            UpdateFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(WrappedType, "Update", "awaitKeywordSyntaxToken", "forEachKeywordSyntaxToken", "openParenTokenSyntaxToken", "variableExpressionSyntax", "inKeywordSyntaxToken", "expressionExpressionSyntax", "closeParenTokenSyntaxToken", "statementStatementSyntax");
            UpdateFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate2>(WrappedType, "Update", "attributeListsSyntaxList`1", "awaitKeywordSyntaxToken", "forEachKeywordSyntaxToken", "openParenTokenSyntaxToken", "variableExpressionSyntax", "inKeywordSyntaxToken", "expressionExpressionSyntax", "closeParenTokenSyntaxToken", "statementStatementSyntax");
            WithAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate0>(WrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
            WithAwaitKeywordFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAwaitKeywordDelegate0>(WrappedType, "WithAwaitKeyword", "awaitKeywordSyntaxToken");
            WithCloseParenTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithCloseParenTokenDelegate0>(WrappedType, "WithCloseParenToken", "closeParenTokenSyntaxToken");
            WithExpressionFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithExpressionDelegate0>(WrappedType, "WithExpression", "expressionExpressionSyntax");
            WithForEachKeywordFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithForEachKeywordDelegate0>(WrappedType, "WithForEachKeyword", "forEachKeywordSyntaxToken");
            WithInKeywordFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithInKeywordDelegate0>(WrappedType, "WithInKeyword", "inKeywordSyntaxToken");
            WithOpenParenTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithOpenParenTokenDelegate0>(WrappedType, "WithOpenParenToken", "openParenTokenSyntaxToken");
            WithStatementFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithStatementDelegate0>(WrappedType, "WithStatement", "statementStatementSyntax");
            WithVariableFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithVariableDelegate0>(WrappedType, "WithVariable", "variableExpressionSyntax");
        }

        private ForEachVariableStatementSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists
        {
            get { return AttributeListsGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken AwaitKeyword
        {
            get { return AwaitKeywordGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken CloseParenToken
        {
            get { return CloseParenTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax Expression
        {
            get { return ExpressionGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken ForEachKeyword
        {
            get { return ForEachKeywordGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken InKeyword
        {
            get { return InKeywordGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken OpenParenToken
        {
            get { return OpenParenTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax Statement
        {
            get { return StatementGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax Variable
        {
            get { return VariableGetterFunc(wrappedObject); }
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static explicit operator ForEachVariableStatementSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax obj)
        {
            return Wrap(obj);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax(ForEachVariableStatementSyntaxWrapper obj)
        {
            return obj.Unwrap();
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ForEachVariableStatementSyntaxWrapper Wrap(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Wrap<global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax>(obj, WrappedType);
            return new ForEachVariableStatementSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public void Accept(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
        {
            AcceptFunc0(wrappedObject, visitor);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper AddAttributeLists(params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
        {
            return AddAttributeListsFunc0(wrappedObject, items);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper Update(global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return UpdateFunc0(wrappedObject, forEachKeyword, openParenToken, variable, inKeyword, expression, closeParenToken, statement);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper Update(global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return UpdateFunc1(wrappedObject, awaitKeyword, forEachKeyword, openParenToken, variable, inKeyword, expression, closeParenToken, statement);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper Update(global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable, global::Microsoft.CodeAnalysis.SyntaxToken inKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return UpdateFunc2(wrappedObject, attributeLists, awaitKeyword, forEachKeyword, openParenToken, variable, inKeyword, expression, closeParenToken, statement);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithAttributeLists(global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
        {
            return WithAttributeListsFunc0(wrappedObject, attributeLists);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithAwaitKeyword(global::Microsoft.CodeAnalysis.SyntaxToken awaitKeyword)
        {
            return WithAwaitKeywordFunc0(wrappedObject, awaitKeyword);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithCloseParenToken(global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken)
        {
            return WithCloseParenTokenFunc0(wrappedObject, closeParenToken);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithExpression(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax expression)
        {
            return WithExpressionFunc0(wrappedObject, expression);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithForEachKeyword(global::Microsoft.CodeAnalysis.SyntaxToken forEachKeyword)
        {
            return WithForEachKeywordFunc0(wrappedObject, forEachKeyword);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithInKeyword(global::Microsoft.CodeAnalysis.SyntaxToken inKeyword)
        {
            return WithInKeywordFunc0(wrappedObject, inKeyword);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithOpenParenToken(global::Microsoft.CodeAnalysis.SyntaxToken openParenToken)
        {
            return WithOpenParenTokenFunc0(wrappedObject, openParenToken);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithStatement(global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return WithStatementFunc0(wrappedObject, statement);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ForEachVariableStatementSyntaxWrapper WithVariable(global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax variable)
        {
            return WithVariableFunc0(wrappedObject, variable);
        }
    }
}
