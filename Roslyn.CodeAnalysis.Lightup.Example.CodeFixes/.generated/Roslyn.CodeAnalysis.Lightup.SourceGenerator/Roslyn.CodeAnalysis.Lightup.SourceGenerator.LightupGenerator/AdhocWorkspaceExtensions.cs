﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.AdhocWorkspace.</summary>
    public static partial class AdhocWorkspaceExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.AdhocWorkspace";

        private delegate void CloseAnalyzerConfigDocumentDelegate0(Microsoft.CodeAnalysis.AdhocWorkspace? _obj, Microsoft.CodeAnalysis.DocumentId? documentId);
        private delegate void OpenAnalyzerConfigDocumentDelegate1(Microsoft.CodeAnalysis.AdhocWorkspace? _obj, Microsoft.CodeAnalysis.DocumentId? documentId, System.Boolean activate);

        private static readonly CloseAnalyzerConfigDocumentDelegate0 CloseAnalyzerConfigDocumentFunc0;
        private static readonly OpenAnalyzerConfigDocumentDelegate1 OpenAnalyzerConfigDocumentFunc1;

        static AdhocWorkspaceExtensions()
        {
            var wrappedType = WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            CloseAnalyzerConfigDocumentFunc0 = WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<CloseAnalyzerConfigDocumentDelegate0>(wrappedType, "CloseAnalyzerConfigDocument", "documentIdDocumentId");
            OpenAnalyzerConfigDocumentFunc1 = WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<OpenAnalyzerConfigDocumentDelegate1>(wrappedType, "OpenAnalyzerConfigDocument", "documentIdDocumentId", "activateBoolean");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void CloseAnalyzerConfigDocument(this Microsoft.CodeAnalysis.AdhocWorkspace _obj, Microsoft.CodeAnalysis.DocumentId? documentId)
            => CloseAnalyzerConfigDocumentFunc0(_obj, documentId);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void OpenAnalyzerConfigDocument(this Microsoft.CodeAnalysis.AdhocWorkspace _obj, Microsoft.CodeAnalysis.DocumentId? documentId, System.Boolean activate)
            => OpenAnalyzerConfigDocumentFunc1(_obj, documentId, activate);
    }
}