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
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.Diagnostics.Lightup
{
    /// <summary>Struct added in Roslyn version </summary>
    public static class SymbolAnalysisContextExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Diagnostics.SymbolAnalysisContext";

        public static readonly Type? WrappedType;

        private delegate Nullable<TextSpan> FilterSpanGetterDelegate(SymbolAnalysisContext? _obj);
        private delegate SyntaxTree? FilterTreeGetterDelegate(SymbolAnalysisContext? _obj);
        private delegate Boolean IsGeneratedCodeGetterDelegate(SymbolAnalysisContext? _obj);

        private static readonly FilterSpanGetterDelegate FilterSpanGetterFunc;
        private static readonly FilterTreeGetterDelegate FilterTreeGetterFunc;
        private static readonly IsGeneratedCodeGetterDelegate IsGeneratedCodeGetterFunc;

        static SymbolAnalysisContextExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            FilterSpanGetterFunc = LightupHelper.CreateInstanceGetAccessor<FilterSpanGetterDelegate>(WrappedType, nameof(FilterSpan));
            FilterTreeGetterFunc = LightupHelper.CreateInstanceGetAccessor<FilterTreeGetterDelegate>(WrappedType, nameof(FilterTree));
            IsGeneratedCodeGetterFunc = LightupHelper.CreateInstanceGetAccessor<IsGeneratedCodeGetterDelegate>(WrappedType, nameof(IsGeneratedCode));
        }

        /// <summary>Added in Roslyn version 4.8.0.0</summary>
        public static Nullable<TextSpan> FilterSpan(this SymbolAnalysisContext _obj)
            => FilterSpanGetterFunc(_obj);

        /// <summary>Added in Roslyn version 4.8.0.0</summary>
        public static SyntaxTree? FilterTree(this SymbolAnalysisContext _obj)
            => FilterTreeGetterFunc(_obj);

        /// <summary>Added in Roslyn version 4.4.0.0</summary>
        public static Boolean IsGeneratedCode(this SymbolAnalysisContext _obj)
            => IsGeneratedCodeGetterFunc(_obj);
    }
}