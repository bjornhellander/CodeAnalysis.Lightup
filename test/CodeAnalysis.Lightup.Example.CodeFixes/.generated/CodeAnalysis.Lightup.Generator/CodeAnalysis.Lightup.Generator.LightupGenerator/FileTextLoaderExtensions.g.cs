﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.FileTextLoader.</summary>
    public static partial class FileTextLoaderExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.FileTextLoader";

        private delegate global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.TextAndVersion> LoadTextAndVersionAsyncDelegate0(global::Microsoft.CodeAnalysis.FileTextLoader? _obj, global::Microsoft.CodeAnalysis.Lightup.LoadTextOptionsWrapper options, global::System.Threading.CancellationToken cancellationToken);

        private static readonly LoadTextAndVersionAsyncDelegate0 LoadTextAndVersionAsyncFunc0;

        static FileTextLoaderExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            LoadTextAndVersionAsyncFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<LoadTextAndVersionAsyncDelegate0>(wrappedType, "LoadTextAndVersionAsync", "optionsLoadTextOptions", "cancellationTokenCancellationToken");
        }

        /// <summary>Method added in version 4.8.0.0.</summary>
        public static global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.TextAndVersion> LoadTextAndVersionAsync(this global::Microsoft.CodeAnalysis.FileTextLoader _obj, global::Microsoft.CodeAnalysis.Lightup.LoadTextOptionsWrapper options, global::System.Threading.CancellationToken cancellationToken)
        {
            return LoadTextAndVersionAsyncFunc0(_obj, options, cancellationToken);
        }
    }
}