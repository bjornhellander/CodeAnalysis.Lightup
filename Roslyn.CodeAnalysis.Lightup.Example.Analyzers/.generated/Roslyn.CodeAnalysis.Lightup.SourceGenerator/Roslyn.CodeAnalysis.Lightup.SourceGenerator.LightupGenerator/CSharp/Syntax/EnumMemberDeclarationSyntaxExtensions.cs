﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax.</summary>
    public static partial class EnumMemberDeclarationSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax";

        private delegate Microsoft.CodeAnalysis.SyntaxTokenList ModifiersGetterDelegate(Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax? _obj);

        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax AddModifiersDelegate0(Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax? _obj, params Microsoft.CodeAnalysis.SyntaxToken[] items);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax UpdateDelegate1(Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax? _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, Microsoft.CodeAnalysis.SyntaxTokenList modifiers, Microsoft.CodeAnalysis.SyntaxToken identifier, Microsoft.CodeAnalysis.CSharp.Syntax.EqualsValueClauseSyntax? equalsValue);
        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax WithModifiersDelegate2(Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax? _obj, Microsoft.CodeAnalysis.SyntaxTokenList modifiers);

        private static readonly ModifiersGetterDelegate ModifiersGetterFunc;

        private static readonly AddModifiersDelegate0 AddModifiersFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithModifiersDelegate2 WithModifiersFunc2;

        static EnumMemberDeclarationSyntaxExtensions()
        {
            var wrappedType = CSharpLightupHelper.FindType(WrappedTypeName);

            ModifiersGetterFunc = CSharpLightupHelper.CreateInstanceGetAccessor<ModifiersGetterDelegate>(wrappedType, nameof(Modifiers));

            AddModifiersFunc0 = CSharpLightupHelper.CreateInstanceMethodAccessor<AddModifiersDelegate0>(wrappedType, "AddModifiers", "itemsSyntaxToken[]");
            UpdateFunc1 = CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(wrappedType, "Update", "attributeListsSyntaxList`1", "modifiersSyntaxTokenList", "identifierSyntaxToken", "equalsValueEqualsValueClauseSyntax");
            WithModifiersFunc2 = CSharpLightupHelper.CreateInstanceMethodAccessor<WithModifiersDelegate2>(wrappedType, "WithModifiers", "modifiersSyntaxTokenList");
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.SyntaxTokenList Modifiers(this Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax _obj)
            => ModifiersGetterFunc(_obj);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax AddModifiers(this Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax _obj, params Microsoft.CodeAnalysis.SyntaxToken[] items)
            => AddModifiersFunc0(_obj, items);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax Update(this Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax _obj, Microsoft.CodeAnalysis.SyntaxList<Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, Microsoft.CodeAnalysis.SyntaxTokenList modifiers, Microsoft.CodeAnalysis.SyntaxToken identifier, Microsoft.CodeAnalysis.CSharp.Syntax.EqualsValueClauseSyntax? equalsValue)
            => UpdateFunc1(_obj, attributeLists, modifiers, identifier, equalsValue);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax WithModifiers(this Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax _obj, Microsoft.CodeAnalysis.SyntaxTokenList modifiers)
            => WithModifiersFunc2(_obj, modifiers);
    }
}