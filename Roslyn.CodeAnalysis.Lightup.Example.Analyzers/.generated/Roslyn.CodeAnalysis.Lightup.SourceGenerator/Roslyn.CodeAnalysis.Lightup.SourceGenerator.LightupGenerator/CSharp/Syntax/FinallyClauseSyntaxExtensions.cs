﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax.</summary>
    public static partial class FinallyClauseSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax";

        private delegate Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax AddBlockAttributeListsDelegate0(Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax? _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items);

        private static readonly AddBlockAttributeListsDelegate0 AddBlockAttributeListsFunc0;

        static FinallyClauseSyntaxExtensions()
        {
            var wrappedType = CSharpLightupHelper.FindType(WrappedTypeName);

            AddBlockAttributeListsFunc0 = CSharpLightupHelper.CreateInstanceMethodAccessor<AddBlockAttributeListsDelegate0>(wrappedType, "AddBlockAttributeLists", "itemsAttributeListSyntax[]");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax AddBlockAttributeLists(this Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax _obj, params Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax[] items)
            => AddBlockAttributeListsFunc0(_obj, items);
    }
}