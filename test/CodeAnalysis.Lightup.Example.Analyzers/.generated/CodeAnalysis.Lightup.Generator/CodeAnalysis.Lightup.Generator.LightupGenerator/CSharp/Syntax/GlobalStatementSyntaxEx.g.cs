﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax.</summary>
    public static partial class GlobalStatementSyntaxEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax";

        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTokenList ModifiersGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj);

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax AddAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax AddModifiersDelegate1(global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, params global::Microsoft.CodeAnalysis.SyntaxToken[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax UpdateDelegate2(global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax WithAttributeListsDelegate3(global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax WithModifiersDelegate4(global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;
        private static readonly ModifiersGetterDelegate ModifiersGetterFunc;

        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly AddModifiersDelegate1 AddModifiersFunc1;
        private static readonly UpdateDelegate2 UpdateFunc2;
        private static readonly WithAttributeListsDelegate3 WithAttributeListsFunc3;
        private static readonly WithModifiersDelegate4 WithModifiersFunc4;

        static GlobalStatementSyntaxEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(wrappedType, nameof(AttributeLists));
            ModifiersGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ModifiersGetterDelegate>(wrappedType, nameof(Modifiers));

            AddAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(wrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            AddModifiersFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddModifiersDelegate1>(wrappedType, "AddModifiers", "itemsSyntaxToken[]");
            UpdateFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate2>(wrappedType, "Update", "attributeListsSyntaxList`1", "modifiersSyntaxTokenList", "statementStatementSyntax");
            WithAttributeListsFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate3>(wrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
            WithModifiersFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithModifiersDelegate4>(wrappedType, "WithModifiers", "modifiersSyntaxTokenList");
        }

        /// <summary>Property added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj)
        {
            return AttributeListsGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTokenList Modifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj)
        {
            return ModifiersGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax AddAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
        {
            return AddAttributeListsFunc0(_obj, items);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax AddModifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, params global::Microsoft.CodeAnalysis.SyntaxToken[] items)
        {
            return AddModifiersFunc1(_obj, items);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax Update(this global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers, global::Microsoft.CodeAnalysis.CSharp.Syntax.StatementSyntax statement)
        {
            return UpdateFunc2(_obj, attributeLists, modifiers, statement);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax WithAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
        {
            return WithAttributeListsFunc3(_obj, attributeLists);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax WithModifiers(this global::Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers)
        {
            return WithModifiersFunc4(_obj, modifiers);
        }
    }
}