﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Host.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Host.IPersistentStorageService.</summary>
    public static partial class IPersistentStorageServiceExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Host.IPersistentStorageService";

        private delegate System.Threading.Tasks.ValueTask<Microsoft.CodeAnalysis.Host.IPersistentStorage> GetStorageAsyncDelegate0(Microsoft.CodeAnalysis.Host.IPersistentStorageService? _obj, Microsoft.CodeAnalysis.Solution solution, System.Threading.CancellationToken cancellationToken);

        private static readonly GetStorageAsyncDelegate0 GetStorageAsyncFunc0;

        static IPersistentStorageServiceExtensions()
        {
            var wrappedType = WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            GetStorageAsyncFunc0 = WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<GetStorageAsyncDelegate0>(wrappedType, "GetStorageAsync", "solutionSolution", "cancellationTokenCancellationToken");
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static System.Threading.Tasks.ValueTask<Microsoft.CodeAnalysis.Host.IPersistentStorage> GetStorageAsync(this Microsoft.CodeAnalysis.Host.IPersistentStorageService _obj, Microsoft.CodeAnalysis.Solution solution, System.Threading.CancellationToken cancellationToken)
            => GetStorageAsyncFunc0(_obj, solution, cancellationToken);
    }
}