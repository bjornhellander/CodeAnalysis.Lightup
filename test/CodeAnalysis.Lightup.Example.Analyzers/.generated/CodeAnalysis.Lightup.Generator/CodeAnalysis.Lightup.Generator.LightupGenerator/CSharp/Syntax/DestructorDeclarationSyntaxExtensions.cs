﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax.</summary>
    public static partial class DestructorDeclarationSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax";

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax AddBodyAttributeListsDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax? _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);

        private static readonly AddBodyAttributeListsDelegate0 AddBodyAttributeListsFunc0;

        static DestructorDeclarationSyntaxExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            AddBodyAttributeListsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddBodyAttributeListsDelegate0>(wrappedType, "AddBodyAttributeLists", "itemsAttributeListSyntax[]");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax AddBodyAttributeLists(this global::Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
            => AddBodyAttributeListsFunc0(_obj, items);
    }
}