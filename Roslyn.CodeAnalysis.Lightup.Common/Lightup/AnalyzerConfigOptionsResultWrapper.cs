﻿// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Struct added in Roslyn version 3.8.0.0</summary>
    public readonly struct AnalyzerConfigOptionsResultWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.AnalyzerConfigOptionsResult";

        public static readonly Type? WrappedType;

        private delegate ImmutableDictionary<String, String> AnalyzerOptionsDelegate(object? _obj);
        private delegate ImmutableArray<Diagnostic> DiagnosticsDelegate(object? _obj);
        private delegate ImmutableDictionary<String, ReportDiagnostic> TreeOptionsDelegate(object? _obj);

        private static readonly AnalyzerOptionsDelegate AnalyzerOptionsFunc;
        private static readonly DiagnosticsDelegate DiagnosticsFunc;
        private static readonly TreeOptionsDelegate TreeOptionsFunc;

        private readonly object? wrappedObject;

        static AnalyzerConfigOptionsResultWrapper()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            AnalyzerOptionsFunc = LightupHelper.CreateGetAccessor<AnalyzerOptionsDelegate>(WrappedType, nameof(AnalyzerOptions));
            DiagnosticsFunc = LightupHelper.CreateGetAccessor<DiagnosticsDelegate>(WrappedType, nameof(Diagnostics));
            TreeOptionsFunc = LightupHelper.CreateGetAccessor<TreeOptionsDelegate>(WrappedType, nameof(TreeOptions));
        }

        private AnalyzerConfigOptionsResultWrapper(object? obj)
        {
            wrappedObject = obj;
        }

        public readonly ImmutableDictionary<String, String> AnalyzerOptions
            => AnalyzerOptionsFunc(wrappedObject);

        public readonly ImmutableArray<Diagnostic> Diagnostics
            => DiagnosticsFunc(wrappedObject);

        public readonly ImmutableDictionary<String, ReportDiagnostic> TreeOptions
            => TreeOptionsFunc(wrappedObject);

        public static bool Is(object? obj)
            => LightupHelper.Is(obj, WrappedType);

        public static AnalyzerConfigOptionsResultWrapper As(object? obj)
        {
            var obj2 = LightupHelper.As<object>(obj, WrappedType);
            return new AnalyzerConfigOptionsResultWrapper(obj2);
        }

        public object? Unwrap()
            => wrappedObject;
    }
}