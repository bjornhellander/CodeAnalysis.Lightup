﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax.</summary>
    public static partial class NamespaceDeclarationSyntaxEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax";

        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTokenList ModifiersGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj);

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax AddAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax AddModifiersDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.SyntaxToken[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax UpdateDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers, global::Microsoft.CodeAnalysis.SyntaxToken namespaceKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.NameSyntax name, global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax> externs, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax> usings, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax> members, global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken, global::Microsoft.CodeAnalysis.SyntaxToken semicolonToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax WithAttributeListsDelegate3(global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax WithModifiersDelegate4(global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;
        private static readonly ModifiersGetterDelegate ModifiersGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly AddModifiersDelegate1 AddModifiersFunc1;
        private static readonly UpdateDelegate2 UpdateFunc2;
        private static readonly WithAttributeListsDelegate3 WithAttributeListsFunc3;
        private static readonly WithModifiersDelegate4 WithModifiersFunc4;

        static NamespaceDeclarationSyntaxEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(wrappedType, nameof(AttributeLists));
            ModifiersGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ModifiersGetterDelegate>(wrappedType, nameof(Modifiers));

            AddAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(wrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            AddModifiersFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddModifiersDelegate1>(wrappedType, "AddModifiers", "itemsSyntaxToken[]");
            UpdateFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate2>(wrappedType, "Update", "attributeListsSyntaxList`1", "modifiersSyntaxTokenList", "namespaceKeywordSyntaxToken", "nameNameSyntax", "openBraceTokenSyntaxToken", "externsSyntaxList`1", "usingsSyntaxList`1", "membersSyntaxList`1", "closeBraceTokenSyntaxToken", "semicolonTokenSyntaxToken");
            WithAttributeListsFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate3>(wrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
            WithModifiersFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithModifiersDelegate4>(wrappedType, "WithModifiers", "modifiersSyntaxTokenList");
        }

        /// <summary>Property added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj)
        {
            return AttributeListsGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTokenList Modifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj)
        {
            return ModifiersGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax AddAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
        {
            return AddAttributeListsFunc0(_obj, items);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax AddModifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.SyntaxToken[] items)
        {
            return AddModifiersFunc1(_obj, items);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax Update(this global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers, global::Microsoft.CodeAnalysis.SyntaxToken namespaceKeyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.NameSyntax name, global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax> externs, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax> usings, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax> members, global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken, global::Microsoft.CodeAnalysis.SyntaxToken semicolonToken)
        {
            return UpdateFunc2(_obj, attributeLists, modifiers, namespaceKeyword, name, openBraceToken, externs, usings, members, closeBraceToken, semicolonToken);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax WithAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
        {
            return WithAttributeListsFunc3(_obj, attributeLists);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax WithModifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers)
        {
            return WithModifiersFunc4(_obj, modifiers);
        }
    }
}
