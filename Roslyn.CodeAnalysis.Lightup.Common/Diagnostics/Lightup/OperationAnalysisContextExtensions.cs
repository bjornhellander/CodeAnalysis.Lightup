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
    public static class OperationAnalysisContextExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Diagnostics.OperationAnalysisContext";

        public static readonly Type? WrappedType;

        private delegate Nullable<TextSpan> FilterSpanGetterDelegate(OperationAnalysisContext? _obj);
        private delegate SyntaxTree FilterTreeGetterDelegate(OperationAnalysisContext? _obj);
        private delegate Boolean IsGeneratedCodeGetterDelegate(OperationAnalysisContext? _obj);

        private static readonly FilterSpanGetterDelegate FilterSpanGetterFunc;
        private static readonly FilterTreeGetterDelegate FilterTreeGetterFunc;
        private static readonly IsGeneratedCodeGetterDelegate IsGeneratedCodeGetterFunc;

        static OperationAnalysisContextExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            FilterSpanGetterFunc = LightupHelper.CreateInstanceGetAccessor<FilterSpanGetterDelegate>(WrappedType, nameof(FilterSpan));
            FilterTreeGetterFunc = LightupHelper.CreateInstanceGetAccessor<FilterTreeGetterDelegate>(WrappedType, nameof(FilterTree));
            IsGeneratedCodeGetterFunc = LightupHelper.CreateInstanceGetAccessor<IsGeneratedCodeGetterDelegate>(WrappedType, nameof(IsGeneratedCode));
        }

        /// <summary>Added in Roslyn version 4.8.0.0</summary>
        public static Nullable<TextSpan> FilterSpan(this OperationAnalysisContext _obj)
            => FilterSpanGetterFunc(_obj);

        /// <summary>Added in Roslyn version 4.8.0.0</summary>
        public static SyntaxTree FilterTree(this OperationAnalysisContext _obj)
            => FilterTreeGetterFunc(_obj);

        /// <summary>Added in Roslyn version 4.4.0.0</summary>
        public static Boolean IsGeneratedCode(this OperationAnalysisContext _obj)
            => IsGeneratedCodeGetterFunc(_obj);
    }
}