﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax.</summary>
    public static partial class LocalDeclarationStatementSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax";

        private delegate Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax? _obj);

        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax AddAttributeListsDelegate0(Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax? _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax UpdateDelegate1(Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax? _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, Microsoft.CodeAnalysis.SyntaxToken usingKeyword, Microsoft.CodeAnalysis.SyntaxTokenList modifiers, Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax declaration, Microsoft.CodeAnalysis.SyntaxToken semicolonToken);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax WithAttributeListsDelegate2(Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax? _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithAttributeListsDelegate2 WithAttributeListsFunc2;

        static LocalDeclarationStatementSyntaxExtensions()
        {
            var wrappedType = CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(wrappedType, nameof(AttributeLists));

            AddAttributeListsFunc0 = CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(wrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            UpdateFunc1 = CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(wrappedType, "Update", "attributeListsSyntaxList`1", "awaitKeywordSyntaxToken", "usingKeywordSyntaxToken", "modifiersSyntaxTokenList", "declarationVariableDeclarationSyntax", "semicolonTokenSyntaxToken");
            WithAttributeListsFunc2 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate2>(wrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax _obj)
            => AttributeListsGetterFunc(_obj);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax AddAttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
            => AddAttributeListsFunc0(_obj, items);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax Update(this Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, Microsoft.CodeAnalysis.SyntaxToken awaitKeyword, Microsoft.CodeAnalysis.SyntaxToken usingKeyword, Microsoft.CodeAnalysis.SyntaxTokenList modifiers, Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax declaration, Microsoft.CodeAnalysis.SyntaxToken semicolonToken)
            => UpdateFunc1(_obj, attributeLists, awaitKeyword, usingKeyword, modifiers, declaration, semicolonToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax WithAttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
            => WithAttributeListsFunc2(_obj, attributeLists);
    }
}