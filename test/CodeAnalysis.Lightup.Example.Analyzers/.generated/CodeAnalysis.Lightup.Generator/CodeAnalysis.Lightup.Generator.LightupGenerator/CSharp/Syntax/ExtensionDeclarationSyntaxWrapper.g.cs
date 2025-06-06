﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.ExtensionDeclarationSyntax. Added in version 4.14.0.0.</summary>
    public partial struct ExtensionDeclarationSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.ExtensionDeclarationSyntax";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeListsGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.BaseListSyntax? BaseListGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken CloseBraceTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax> ConstraintClausesGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken IdentifierGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken KeywordGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax> MembersGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTokenList ModifiersGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken OpenBraceTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax? ParameterListGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken SemicolonTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax? TypeParameterListGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj);

        private delegate void AcceptDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddConstraintClausesDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddMembersDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddModifiersDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.SyntaxToken[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddParameterListParametersDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddTypeParameterListParametersDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterSyntax[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper UpdateDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers, global::Microsoft.CodeAnalysis.SyntaxToken keyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax? typeParameterList, global::Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax? parameterList, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax> constraintClauses, global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax> members, global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken, global::Microsoft.CodeAnalysis.SyntaxToken semicolonToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithCloseBraceTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithConstraintClausesDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax> constraintClauses);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithKeywordDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken keyword);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithMembersDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax> members);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithModifiersDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithOpenBraceTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithParameterListDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax? parameterList);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithSemicolonTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken semicolonToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithTypeParameterListDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax _obj, global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax? typeParameterList);

        private static readonly AttributeListsGetterDelegate AttributeListsGetterFunc;
        private static readonly BaseListGetterDelegate BaseListGetterFunc;
        private static readonly CloseBraceTokenGetterDelegate CloseBraceTokenGetterFunc;
        private static readonly ConstraintClausesGetterDelegate ConstraintClausesGetterFunc;
        private static readonly IdentifierGetterDelegate IdentifierGetterFunc;
        private static readonly KeywordGetterDelegate KeywordGetterFunc;
        private static readonly MembersGetterDelegate MembersGetterFunc;
        private static readonly ModifiersGetterDelegate ModifiersGetterFunc;
        private static readonly OpenBraceTokenGetterDelegate OpenBraceTokenGetterFunc;
        private static readonly ParameterListGetterDelegate ParameterListGetterFunc;
        private static readonly SemicolonTokenGetterDelegate SemicolonTokenGetterFunc;
        private static readonly TypeParameterListGetterDelegate TypeParameterListGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly AddAttributeListsDelegate0 AddAttributeListsFunc0;
        private static readonly AddConstraintClausesDelegate0 AddConstraintClausesFunc0;
        private static readonly AddMembersDelegate0 AddMembersFunc0;
        private static readonly AddModifiersDelegate0 AddModifiersFunc0;
        private static readonly AddParameterListParametersDelegate0 AddParameterListParametersFunc0;
        private static readonly AddTypeParameterListParametersDelegate0 AddTypeParameterListParametersFunc0;
        private static readonly UpdateDelegate0 UpdateFunc0;
        private static readonly WithAttributeListsDelegate0 WithAttributeListsFunc0;
        private static readonly WithCloseBraceTokenDelegate0 WithCloseBraceTokenFunc0;
        private static readonly WithConstraintClausesDelegate0 WithConstraintClausesFunc0;
        private static readonly WithKeywordDelegate0 WithKeywordFunc0;
        private static readonly WithMembersDelegate0 WithMembersFunc0;
        private static readonly WithModifiersDelegate0 WithModifiersFunc0;
        private static readonly WithOpenBraceTokenDelegate0 WithOpenBraceTokenFunc0;
        private static readonly WithParameterListDelegate0 WithParameterListFunc0;
        private static readonly WithSemicolonTokenDelegate0 WithSemicolonTokenFunc0;
        private static readonly WithTypeParameterListDelegate0 WithTypeParameterListFunc0;

        private readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax wrappedObject;

        static ExtensionDeclarationSyntaxWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            AttributeListsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<AttributeListsGetterDelegate>(WrappedType, nameof(AttributeLists));
            BaseListGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<BaseListGetterDelegate>(WrappedType, nameof(BaseList));
            CloseBraceTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CloseBraceTokenGetterDelegate>(WrappedType, nameof(CloseBraceToken));
            ConstraintClausesGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ConstraintClausesGetterDelegate>(WrappedType, nameof(ConstraintClauses));
            IdentifierGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<IdentifierGetterDelegate>(WrappedType, nameof(Identifier));
            KeywordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<KeywordGetterDelegate>(WrappedType, nameof(Keyword));
            MembersGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<MembersGetterDelegate>(WrappedType, nameof(Members));
            ModifiersGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ModifiersGetterDelegate>(WrappedType, nameof(Modifiers));
            OpenBraceTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<OpenBraceTokenGetterDelegate>(WrappedType, nameof(OpenBraceToken));
            ParameterListGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<ParameterListGetterDelegate>(WrappedType, nameof(ParameterList));
            SemicolonTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<SemicolonTokenGetterDelegate>(WrappedType, nameof(SemicolonToken));
            TypeParameterListGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<TypeParameterListGetterDelegate>(WrappedType, nameof(TypeParameterList));

            AcceptFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            AddAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddAttributeListsDelegate0>(WrappedType, "AddAttributeLists", "itemsAttributeListSyntax[]");
            AddConstraintClausesFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddConstraintClausesDelegate0>(WrappedType, "AddConstraintClauses", "itemsTypeParameterConstraintClauseSyntax[]");
            AddMembersFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddMembersDelegate0>(WrappedType, "AddMembers", "itemsMemberDeclarationSyntax[]");
            AddModifiersFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddModifiersDelegate0>(WrappedType, "AddModifiers", "itemsSyntaxToken[]");
            AddParameterListParametersFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddParameterListParametersDelegate0>(WrappedType, "AddParameterListParameters", "itemsParameterSyntax[]");
            AddTypeParameterListParametersFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddTypeParameterListParametersDelegate0>(WrappedType, "AddTypeParameterListParameters", "itemsTypeParameterSyntax[]");
            UpdateFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate0>(WrappedType, "Update", "attributeListsSyntaxList`1", "modifiersSyntaxTokenList", "keywordSyntaxToken", "typeParameterListTypeParameterListSyntax", "parameterListParameterListSyntax", "constraintClausesSyntaxList`1", "openBraceTokenSyntaxToken", "membersSyntaxList`1", "closeBraceTokenSyntaxToken", "semicolonTokenSyntaxToken");
            WithAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithAttributeListsDelegate0>(WrappedType, "WithAttributeLists", "attributeListsSyntaxList`1");
            WithCloseBraceTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithCloseBraceTokenDelegate0>(WrappedType, "WithCloseBraceToken", "closeBraceTokenSyntaxToken");
            WithConstraintClausesFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithConstraintClausesDelegate0>(WrappedType, "WithConstraintClauses", "constraintClausesSyntaxList`1");
            WithKeywordFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithKeywordDelegate0>(WrappedType, "WithKeyword", "keywordSyntaxToken");
            WithMembersFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithMembersDelegate0>(WrappedType, "WithMembers", "membersSyntaxList`1");
            WithModifiersFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithModifiersDelegate0>(WrappedType, "WithModifiers", "modifiersSyntaxTokenList");
            WithOpenBraceTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithOpenBraceTokenDelegate0>(WrappedType, "WithOpenBraceToken", "openBraceTokenSyntaxToken");
            WithParameterListFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithParameterListDelegate0>(WrappedType, "WithParameterList", "parameterListParameterListSyntax");
            WithSemicolonTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithSemicolonTokenDelegate0>(WrappedType, "WithSemicolonToken", "semicolonTokenSyntaxToken");
            WithTypeParameterListFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithTypeParameterListDelegate0>(WrappedType, "WithTypeParameterList", "typeParameterListTypeParameterListSyntax");
        }

        private ExtensionDeclarationSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> AttributeLists
        {
            get { return AttributeListsGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.BaseListSyntax? BaseList
        {
            get { return BaseListGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken CloseBraceToken
        {
            get { return CloseBraceTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax> ConstraintClauses
        {
            get { return ConstraintClausesGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken Identifier
        {
            get { return IdentifierGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken Keyword
        {
            get { return KeywordGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax> Members
        {
            get { return MembersGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxTokenList Modifiers
        {
            get { return ModifiersGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken OpenBraceToken
        {
            get { return OpenBraceTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax? ParameterList
        {
            get { return ParameterListGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken SemicolonToken
        {
            get { return SemicolonTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax? TypeParameterList
        {
            get { return TypeParameterListGetterFunc(wrappedObject); }
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static explicit operator ExtensionDeclarationSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax obj)
        {
            return Wrap(obj);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax(ExtensionDeclarationSyntaxWrapper obj)
        {
            return obj.Unwrap();
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ExtensionDeclarationSyntaxWrapper Wrap(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Wrap<global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax>(obj, WrappedType);
            return new ExtensionDeclarationSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeDeclarationSyntax Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public void Accept(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
        {
            AcceptFunc0(wrappedObject, visitor);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddAttributeLists(params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
        {
            return AddAttributeListsFunc0(wrappedObject, items);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddConstraintClauses(params global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax[] items)
        {
            return AddConstraintClausesFunc0(wrappedObject, items);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddMembers(params global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax[] items)
        {
            return AddMembersFunc0(wrappedObject, items);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddModifiers(params global::Microsoft.CodeAnalysis.SyntaxToken[] items)
        {
            return AddModifiersFunc0(wrappedObject, items);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddParameterListParameters(params global::Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax[] items)
        {
            return AddParameterListParametersFunc0(wrappedObject, items);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper AddTypeParameterListParameters(params global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterSyntax[] items)
        {
            return AddTypeParameterListParametersFunc0(wrappedObject, items);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper Update(global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists, global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers, global::Microsoft.CodeAnalysis.SyntaxToken keyword, global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax? typeParameterList, global::Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax? parameterList, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax> constraintClauses, global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken, global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax> members, global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken, global::Microsoft.CodeAnalysis.SyntaxToken semicolonToken)
        {
            return UpdateFunc0(wrappedObject, attributeLists, modifiers, keyword, typeParameterList, parameterList, constraintClauses, openBraceToken, members, closeBraceToken, semicolonToken);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithAttributeLists(global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax> attributeLists)
        {
            return WithAttributeListsFunc0(wrappedObject, attributeLists);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithCloseBraceToken(global::Microsoft.CodeAnalysis.SyntaxToken closeBraceToken)
        {
            return WithCloseBraceTokenFunc0(wrappedObject, closeBraceToken);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithConstraintClauses(global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax> constraintClauses)
        {
            return WithConstraintClausesFunc0(wrappedObject, constraintClauses);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithKeyword(global::Microsoft.CodeAnalysis.SyntaxToken keyword)
        {
            return WithKeywordFunc0(wrappedObject, keyword);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithMembers(global::Microsoft.CodeAnalysis.SyntaxList<global::Microsoft.CodeAnalysis.CSharp.Syntax.MemberDeclarationSyntax> members)
        {
            return WithMembersFunc0(wrappedObject, members);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithModifiers(global::Microsoft.CodeAnalysis.SyntaxTokenList modifiers)
        {
            return WithModifiersFunc0(wrappedObject, modifiers);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithOpenBraceToken(global::Microsoft.CodeAnalysis.SyntaxToken openBraceToken)
        {
            return WithOpenBraceTokenFunc0(wrappedObject, openBraceToken);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithParameterList(global::Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax? parameterList)
        {
            return WithParameterListFunc0(wrappedObject, parameterList);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithSemicolonToken(global::Microsoft.CodeAnalysis.SyntaxToken semicolonToken)
        {
            return WithSemicolonTokenFunc0(wrappedObject, semicolonToken);
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ExtensionDeclarationSyntaxWrapper WithTypeParameterList(global::Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax? typeParameterList)
        {
            return WithTypeParameterListFunc0(wrappedObject, typeParameterList);
        }
    }
}
