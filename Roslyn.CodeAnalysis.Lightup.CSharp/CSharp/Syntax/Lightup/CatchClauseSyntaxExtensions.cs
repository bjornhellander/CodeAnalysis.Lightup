﻿// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Class added in Roslyn version </summary>
    public static class CatchClauseSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.CatchClauseSyntax";

        public static readonly Type? WrappedType;

        private delegate CatchClauseSyntax AddBlockAttributeListsDelegate0(CatchClauseSyntax? _obj, params AttributeListSyntax[] items);

        private static readonly AddBlockAttributeListsDelegate0 AddBlockAttributeListsFunc0;

        static CatchClauseSyntaxExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            AddBlockAttributeListsFunc0 = LightupHelper.CreateInstanceMethodAccessor<AddBlockAttributeListsDelegate0>(WrappedType, nameof(AddBlockAttributeLists));
        }

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static CatchClauseSyntax AddBlockAttributeLists(this CatchClauseSyntax wrappedObject, params AttributeListSyntax[] items)
            => AddBlockAttributeListsFunc0(wrappedObject, items);
    }
}