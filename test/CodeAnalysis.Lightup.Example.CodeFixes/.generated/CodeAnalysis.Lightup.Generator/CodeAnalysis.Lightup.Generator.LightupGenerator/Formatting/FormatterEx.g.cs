﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Formatting.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Formatting.Formatter.</summary>
    public static partial class FormatterEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Formatting.Formatter";

        private delegate global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Document> OrganizeImportsAsyncDelegate0(global::Microsoft.CodeAnalysis.Document document, global::System.Threading.CancellationToken cancellationToken);

        private static readonly OrganizeImportsAsyncDelegate0 OrganizeImportsAsyncFunc0;

        static FormatterEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            OrganizeImportsAsyncFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<OrganizeImportsAsyncDelegate0>(wrappedType, "OrganizeImportsAsync", "documentDocument", "cancellationTokenCancellationToken");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Document> OrganizeImportsAsync(global::Microsoft.CodeAnalysis.Document document, global::System.Threading.CancellationToken cancellationToken)
        {
            return OrganizeImportsAsyncFunc0(document, cancellationToken);
        }
    }
}