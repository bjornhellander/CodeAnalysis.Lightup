﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.CSharpCompilation.</summary>
    public static partial class CSharpCompilationEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.CSharpCompilation";

        private delegate global::Microsoft.CodeAnalysis.SemanticModel GetSemanticModelDelegate0(global::Microsoft.CodeAnalysis.CSharp.CSharpCompilation _obj, global::Microsoft.CodeAnalysis.SyntaxTree syntaxTree, global::Microsoft.CodeAnalysis.Lightup.SemanticModelOptionsEx options);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.MetadataReference> GetUsedAssemblyReferencesDelegate1(global::Microsoft.CodeAnalysis.CSharp.CSharpCompilation _obj, global::System.Threading.CancellationToken cancellationToken);

        private static readonly GetSemanticModelDelegate0 GetSemanticModelFunc0;
        private static readonly GetUsedAssemblyReferencesDelegate1 GetUsedAssemblyReferencesFunc1;

        static CSharpCompilationEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            GetSemanticModelFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<GetSemanticModelDelegate0>(wrappedType, "GetSemanticModel", "syntaxTreeSyntaxTree", "optionsSemanticModelOptions");
            GetUsedAssemblyReferencesFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<GetUsedAssemblyReferencesDelegate1>(wrappedType, "GetUsedAssemblyReferences", "cancellationTokenCancellationToken");
        }

        /// <summary>Method added in version 4.10.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SemanticModel GetSemanticModel(this global::Microsoft.CodeAnalysis.CSharp.CSharpCompilation _obj, global::Microsoft.CodeAnalysis.SyntaxTree syntaxTree, global::Microsoft.CodeAnalysis.Lightup.SemanticModelOptionsEx options)
        {
            return GetSemanticModelFunc0(_obj, syntaxTree, options);
        }

        /// <summary>Method added in version 3.10.0.0.</summary>
        public static global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.MetadataReference> GetUsedAssemblyReferences(this global::Microsoft.CodeAnalysis.CSharp.CSharpCompilation _obj, global::System.Threading.CancellationToken cancellationToken)
        {
            return GetUsedAssemblyReferencesFunc1(_obj, cancellationToken);
        }
    }
}