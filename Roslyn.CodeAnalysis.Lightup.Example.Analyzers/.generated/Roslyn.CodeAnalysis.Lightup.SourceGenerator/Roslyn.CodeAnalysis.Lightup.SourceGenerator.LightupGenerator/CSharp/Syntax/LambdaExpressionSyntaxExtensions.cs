﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax.</summary>
    public static partial class LambdaExpressionSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax";

        private delegate Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax? _obj);

        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax AddAttributeListsDelegate0(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax? _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddBlockAttributeListsDelegate1(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax? _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddBlockStatementsDelegate2(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax? _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax[] items);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax AddModifiersDelegate3(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax? _obj, params Microsoft.CodeAnalysis.SyntaxToken[] items);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax WithAttributeListsDelegate4(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax? _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax WithBlockDelegate5(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax? block);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax WithExpressionBodyDelegate6(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax? _obj, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expressionBody);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax WithModifiersDelegate7(Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax? _obj, Microsoft.CodeAnalysis.SyntaxTokenList modifiers);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly AddBlockAttributeListsDelegate1 AddBlockAttributeListsFunc1;
        private static readonly AddBlockStatementsDelegate2 AddBlockStatementsFunc2;
        private static readonly AddModifiersDelegate3 AddModifiersFunc3;
        private static readonly WithAttributeListsDelegate4 WithAttributeListsFunc4;
        private static readonly WithBlockDelegate5 WithBlockFunc5;
        private static readonly WithExpressionBodyDelegate6 WithExpressionBodyFunc6;
        private static readonly WithModifiersDelegate7 WithModifiersFunc7;

        static LambdaExpressionSyntaxExtensions()
        {
            var wrappedType = CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(wrappedType, nameof(AttributeLists));

            AddAttributeListsFunc0 = CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(wrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            AddBlockAttributeListsFunc1 = CSharpLightupHelper.CreateInstanceMethodAccessor<AddBlockAttributeListsDelegate1>(wrappedType, "AddBlockAttributeLists", "itemsAttributeListSyntax[]");
            AddBlockStatementsFunc2 = CSharpLightupHelper.CreateInstanceMethodAccessor<AddBlockStatementsDelegate2>(wrappedType, "AddBlockStatements", "itemsStatementSyntax[]");
            AddModifiersFunc3 = CSharpLightupHelper.CreateInstanceMethodAccessor<AddModifiersDelegate3>(wrappedType, "AddModifiers", "itemsSyntaxToken[]");
            WithAttributeListsFunc4 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate4>(wrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
            WithBlockFunc5 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithBlockDelegate5>(wrappedType, "WithBlock", "blockBlockSyntax");
            WithExpressionBodyFunc6 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithExpressionBodyDelegate6>(wrappedType, "WithExpressionBody", "expressionBodyExpressionSyntax");
            WithModifiersFunc7 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithModifiersDelegate7>(wrappedType, "WithModifiers", "modifiersSyntaxTokenList");
        }

        /// <summary>Property added in version 4.0.0.0.</summary>
        public static Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax _obj)
            => AttributeListsGetterFunc(_obj);

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax AddAttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
            => AddAttributeListsFunc0(_obj, items);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddBlockAttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
            => AddBlockAttributeListsFunc1(_obj, items);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddBlockStatements(this Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax[] items)
            => AddBlockStatementsFunc2(_obj, items);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax AddModifiers(this Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax _obj, params Microsoft.CodeAnalysis.SyntaxToken[] items)
            => AddModifiersFunc3(_obj, items);

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax WithAttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
            => WithAttributeListsFunc4(_obj, attributeLists);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax WithBlock(this Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax _obj, Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax? block)
            => WithBlockFunc5(_obj, block);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax WithExpressionBody(this Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax _obj, Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expressionBody)
            => WithExpressionBodyFunc6(_obj, expressionBody);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax WithModifiers(this Microsoft.CodeAnalysis.CSharp.Syntax.LambdaExpressionSyntax _obj, Microsoft.CodeAnalysis.SyntaxTokenList modifiers)
            => WithModifiersFunc7(_obj, modifiers);
    }
}