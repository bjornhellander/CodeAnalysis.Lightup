﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Rename.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Rename.Renamer.</summary>
    public static partial class RenamerEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Rename.Renamer";

        private delegate global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Rename.Lightup.RenamerEx.RenameDocumentActionSetWrapper> RenameDocumentAsyncDelegate0(global::Microsoft.CodeAnalysis.Document document, global::System.String? newDocumentName, global::System.Collections.Generic.IReadOnlyList<global::System.String>? newDocumentFolders, global::Microsoft.CodeAnalysis.Options.OptionSet? optionSet, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Rename.Lightup.RenamerEx.RenameDocumentActionSetWrapper> RenameDocumentAsyncDelegate1(global::Microsoft.CodeAnalysis.Document document, global::Microsoft.CodeAnalysis.Rename.Lightup.DocumentRenameOptionsWrapper options, global::System.String? newDocumentName, global::System.Collections.Generic.IReadOnlyList<global::System.String>? newDocumentFolders, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Solution> RenameSymbolAsyncDelegate0(global::Microsoft.CodeAnalysis.Solution solution, global::Microsoft.CodeAnalysis.ISymbol symbol, global::Microsoft.CodeAnalysis.Rename.Lightup.SymbolRenameOptionsWrapper options, global::System.String newName, global::System.Threading.CancellationToken cancellationToken);

        private static readonly RenameDocumentAsyncDelegate0 RenameDocumentAsyncFunc0;
        private static readonly RenameDocumentAsyncDelegate1 RenameDocumentAsyncFunc1;
        private static readonly RenameSymbolAsyncDelegate0 RenameSymbolAsyncFunc0;

        static RenamerEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            RenameDocumentAsyncFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<RenameDocumentAsyncDelegate0>(wrappedType, "RenameDocumentAsync", "documentDocument", "newDocumentNameString", "newDocumentFoldersIReadOnlyList`1", "optionSetOptionSet", "cancellationTokenCancellationToken");
            RenameDocumentAsyncFunc1 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<RenameDocumentAsyncDelegate1>(wrappedType, "RenameDocumentAsync", "documentDocument", "optionsDocumentRenameOptions", "newDocumentNameString", "newDocumentFoldersIReadOnlyList`1", "cancellationTokenCancellationToken");
            RenameSymbolAsyncFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<RenameSymbolAsyncDelegate0>(wrappedType, "RenameSymbolAsync", "solutionSolution", "symbolISymbol", "optionsSymbolRenameOptions", "newNameString", "cancellationTokenCancellationToken");
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Rename.Lightup.RenamerEx.RenameDocumentActionSetWrapper> RenameDocumentAsync(global::Microsoft.CodeAnalysis.Document document, global::System.String? newDocumentName, global::System.Collections.Generic.IReadOnlyList<global::System.String>? newDocumentFolders, global::Microsoft.CodeAnalysis.Options.OptionSet? optionSet, global::System.Threading.CancellationToken cancellationToken)
        {
            return RenameDocumentAsyncFunc0(document, newDocumentName, newDocumentFolders, optionSet, cancellationToken);
        }

        /// <summary>Method added in version 4.2.0.0.</summary>
        public static global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Rename.Lightup.RenamerEx.RenameDocumentActionSetWrapper> RenameDocumentAsync(global::Microsoft.CodeAnalysis.Document document, global::Microsoft.CodeAnalysis.Rename.Lightup.DocumentRenameOptionsWrapper options, global::System.String? newDocumentName, global::System.Collections.Generic.IReadOnlyList<global::System.String>? newDocumentFolders, global::System.Threading.CancellationToken cancellationToken)
        {
            return RenameDocumentAsyncFunc1(document, options, newDocumentName, newDocumentFolders, cancellationToken);
        }

        /// <summary>Method added in version 4.2.0.0.</summary>
        public static global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Solution> RenameSymbolAsync(global::Microsoft.CodeAnalysis.Solution solution, global::Microsoft.CodeAnalysis.ISymbol symbol, global::Microsoft.CodeAnalysis.Rename.Lightup.SymbolRenameOptionsWrapper options, global::System.String newName, global::System.Threading.CancellationToken cancellationToken)
        {
            return RenameSymbolAsyncFunc0(solution, symbol, options, newName, cancellationToken);
        }
    }
}
