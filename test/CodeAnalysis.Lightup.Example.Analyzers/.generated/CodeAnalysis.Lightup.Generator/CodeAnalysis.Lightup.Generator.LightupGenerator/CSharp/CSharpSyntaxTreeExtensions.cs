﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.</summary>
    public static partial class CSharpSyntaxTreeExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree";

        private delegate global::Microsoft.CodeAnalysis.SyntaxTree CreateDelegate0(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode root, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String? path, global::System.Text.Encoding? encoding, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTree CreateDelegate1(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode root, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String? path, global::System.Text.Encoding? encoding, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Nullable<global::System.Boolean> isGeneratedCode);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTree ParseTextDelegate2(global::Microsoft.CodeAnalysis.Text.SourceText text, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String path, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTree ParseTextDelegate3(global::Microsoft.CodeAnalysis.Text.SourceText text, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String path, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Nullable<global::System.Boolean> isGeneratedCode, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTree ParseTextDelegate4(global::System.String text, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String path, global::System.Text.Encoding? encoding, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTree ParseTextDelegate5(global::System.String text, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String path, global::System.Text.Encoding? encoding, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Nullable<global::System.Boolean> isGeneratedCode, global::System.Threading.CancellationToken cancellationToken);

        private delegate global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.Lightup.LineMappingWrapper> GetLineMappingsDelegate0(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree? _obj, global::System.Threading.CancellationToken cancellationToken);

        private static readonly CreateDelegate0 CreateFunc0;
        private static readonly CreateDelegate1 CreateFunc1;
        private static readonly ParseTextDelegate2 ParseTextFunc2;
        private static readonly ParseTextDelegate3 ParseTextFunc3;
        private static readonly ParseTextDelegate4 ParseTextFunc4;
        private static readonly ParseTextDelegate5 ParseTextFunc5;

        private static readonly GetLineMappingsDelegate0 GetLineMappingsFunc0;

        static CSharpSyntaxTreeExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            CreateFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateStaticMethodAccessor<CreateDelegate0>(wrappedType, "Create", "rootCSharpSyntaxNode", "optionsCSharpParseOptions", "pathString", "encodingEncoding", "diagnosticOptionsImmutableDictionary`2");
            CreateFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateStaticMethodAccessor<CreateDelegate1>(wrappedType, "Create", "rootCSharpSyntaxNode", "optionsCSharpParseOptions", "pathString", "encodingEncoding", "diagnosticOptionsImmutableDictionary`2", "isGeneratedCodeNullable`1");
            ParseTextFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateStaticMethodAccessor<ParseTextDelegate2>(wrappedType, "ParseText", "textSourceText", "optionsCSharpParseOptions", "pathString", "diagnosticOptionsImmutableDictionary`2", "cancellationTokenCancellationToken");
            ParseTextFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateStaticMethodAccessor<ParseTextDelegate3>(wrappedType, "ParseText", "textSourceText", "optionsCSharpParseOptions", "pathString", "diagnosticOptionsImmutableDictionary`2", "isGeneratedCodeNullable`1", "cancellationTokenCancellationToken");
            ParseTextFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateStaticMethodAccessor<ParseTextDelegate4>(wrappedType, "ParseText", "textString", "optionsCSharpParseOptions", "pathString", "encodingEncoding", "diagnosticOptionsImmutableDictionary`2", "cancellationTokenCancellationToken");
            ParseTextFunc5 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateStaticMethodAccessor<ParseTextDelegate5>(wrappedType, "ParseText", "textString", "optionsCSharpParseOptions", "pathString", "encodingEncoding", "diagnosticOptionsImmutableDictionary`2", "isGeneratedCodeNullable`1", "cancellationTokenCancellationToken");

            GetLineMappingsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<GetLineMappingsDelegate0>(wrappedType, "GetLineMappings", "cancellationTokenCancellationToken");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTree Create(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode root, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String? path, global::System.Text.Encoding? encoding, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions)
            => CreateFunc0(root, options, path, encoding, diagnosticOptions);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTree Create(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode root, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String? path, global::System.Text.Encoding? encoding, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Nullable<global::System.Boolean> isGeneratedCode)
            => CreateFunc1(root, options, path, encoding, diagnosticOptions, isGeneratedCode);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTree ParseText(global::Microsoft.CodeAnalysis.Text.SourceText text, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String path, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Threading.CancellationToken cancellationToken)
            => ParseTextFunc2(text, options, path, diagnosticOptions, cancellationToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTree ParseText(global::Microsoft.CodeAnalysis.Text.SourceText text, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String path, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Nullable<global::System.Boolean> isGeneratedCode, global::System.Threading.CancellationToken cancellationToken)
            => ParseTextFunc3(text, options, path, diagnosticOptions, isGeneratedCode, cancellationToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTree ParseText(global::System.String text, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String path, global::System.Text.Encoding? encoding, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Threading.CancellationToken cancellationToken)
            => ParseTextFunc4(text, options, path, encoding, diagnosticOptions, cancellationToken);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTree ParseText(global::System.String text, global::Microsoft.CodeAnalysis.CSharp.CSharpParseOptions? options, global::System.String path, global::System.Text.Encoding? encoding, global::System.Collections.Immutable.ImmutableDictionary<global::System.String, global::Microsoft.CodeAnalysis.ReportDiagnostic>? diagnosticOptions, global::System.Nullable<global::System.Boolean> isGeneratedCode, global::System.Threading.CancellationToken cancellationToken)
            => ParseTextFunc5(text, options, path, encoding, diagnosticOptions, isGeneratedCode, cancellationToken);

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.Lightup.LineMappingWrapper> GetLineMappings(this global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree _obj, global::System.Threading.CancellationToken cancellationToken)
            => GetLineMappingsFunc0(_obj, cancellationToken);
    }
}