﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax.</summary>
    public static partial class MemberDeclarationSyntaxEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax";

        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTokenList ModifiersGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj);

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax AddAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax AddModifiersDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.SyntaxToken[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax WithAttributeListsDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax WithModifiersDelegate3(global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;
        private static readonly ModifiersGetterDelegate ModifiersGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly AddModifiersDelegate1 AddModifiersFunc1;
        private static readonly WithAttributeListsDelegate2 WithAttributeListsFunc2;
        private static readonly WithModifiersDelegate3 WithModifiersFunc3;

        static MemberDeclarationSyntaxEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(wrappedType, nameof(AttributeLists));
            ModifiersGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ModifiersGetterDelegate>(wrappedType, nameof(Modifiers));

            AddAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(wrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            AddModifiersFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddModifiersDelegate1>(wrappedType, "AddModifiers", "itemsSyntaxToken[]");
            WithAttributeListsFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate2>(wrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
            WithModifiersFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithModifiersDelegate3>(wrappedType, "WithModifiers", "modifiersSyntaxTokenList");
        }

        /// <summary>Property added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj)
        {
            return AttributeListsGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTokenList Modifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj)
        {
            return ModifiersGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax AddAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
        {
            return AddAttributeListsFunc0(_obj, items);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax AddModifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.SyntaxToken[] items)
        {
            return AddModifiersFunc1(_obj, items);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax WithAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
        {
            return WithAttributeListsFunc2(_obj, attributeLists);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax WithModifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers)
        {
            return WithModifiersFunc3(_obj, modifiers);
        }
    }
}
