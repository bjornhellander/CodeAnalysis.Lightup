﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax.</summary>
    public static partial class AnonymousFunctionExpressionSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax";

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax? BlockGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax? _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? ExpressionBodyGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax? _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTokenList ModifiersGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax? _obj);

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddBlockAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax? _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddBlockStatementsDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax? _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddModifiersDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax? _obj, params global::Microsoft.CodeAnalysis.SyntaxToken[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax WithBlockDelegate3(global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax? _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax? block);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax WithExpressionBodyDelegate4(global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax? _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expressionBody);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax WithModifiersDelegate5(global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax? _obj, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers);

        private static readonly BlockGetterDelegate BlockGetterFunc;
        private static readonly ExpressionBodyGetterDelegate ExpressionBodyGetterFunc;
        private static readonly ModifiersGetterDelegate ModifiersGetterFunc;

        private static readonly AddBlockAttributeListsDelegate0 AddBlockAttributeListsFunc0;
        private static readonly AddBlockStatementsDelegate1 AddBlockStatementsFunc1;
        private static readonly AddModifiersDelegate2 AddModifiersFunc2;
        private static readonly WithBlockDelegate3 WithBlockFunc3;
        private static readonly WithExpressionBodyDelegate4 WithExpressionBodyFunc4;
        private static readonly WithModifiersDelegate5 WithModifiersFunc5;

        static AnonymousFunctionExpressionSyntaxExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            BlockGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<BlockGetterDelegate>(wrappedType, nameof(Block));
            ExpressionBodyGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ExpressionBodyGetterDelegate>(wrappedType, nameof(ExpressionBody));
            ModifiersGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ModifiersGetterDelegate>(wrappedType, nameof(Modifiers));

            AddBlockAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddBlockAttributeListsDelegate0>(wrappedType, "AddBlockAttributeLists", "itemsAttributeListSyntax[]");
            AddBlockStatementsFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddBlockStatementsDelegate1>(wrappedType, "AddBlockStatements", "itemsStatementSyntax[]");
            AddModifiersFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddModifiersDelegate2>(wrappedType, "AddModifiers", "itemsSyntaxToken[]");
            WithBlockFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithBlockDelegate3>(wrappedType, "WithBlock", "blockBlockSyntax");
            WithExpressionBodyFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithExpressionBodyDelegate4>(wrappedType, "WithExpressionBody", "expressionBodyExpressionSyntax");
            WithModifiersFunc5 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithModifiersDelegate5>(wrappedType, "WithModifiers", "modifiersSyntaxTokenList");
        }

        /// <summary>Property added in version 3.4.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax? Block(this global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax _obj)
        {
            return BlockGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.4.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? ExpressionBody(this global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax _obj)
        {
            return ExpressionBodyGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTokenList Modifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax _obj)
        {
            return ModifiersGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddBlockAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
        {
            return AddBlockAttributeListsFunc0(_obj, items);
        }

        /// <summary>Method added in version 3.4.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddBlockStatements(this global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax[] items)
        {
            return AddBlockStatementsFunc1(_obj, items);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax AddModifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax _obj, params global::Microsoft.CodeAnalysis.SyntaxToken[] items)
        {
            return AddModifiersFunc2(_obj, items);
        }

        /// <summary>Method added in version 3.4.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax WithBlock(this global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax? block)
        {
            return WithBlockFunc3(_obj, block);
        }

        /// <summary>Method added in version 3.4.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax WithExpressionBody(this global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax? expressionBody)
        {
            return WithExpressionBodyFunc4(_obj, expressionBody);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax WithModifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousFunctionExpressionSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers)
        {
            return WithModifiersFunc5(_obj, modifiers);
        }
    }
}
