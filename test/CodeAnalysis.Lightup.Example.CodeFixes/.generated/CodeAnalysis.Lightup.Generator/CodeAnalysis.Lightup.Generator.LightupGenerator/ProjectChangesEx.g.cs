﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.ProjectChanges.</summary>
    public static partial class ProjectChangesEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.ProjectChanges";

        private delegate global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentId> GetAddedAnalyzerConfigDocumentsDelegate0(global::Microsoft.CodeAnalysis.ProjectChanges _obj);
        private delegate global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentId> GetChangedAnalyzerConfigDocumentsDelegate1(global::Microsoft.CodeAnalysis.ProjectChanges _obj);
        private delegate global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentId> GetRemovedAnalyzerConfigDocumentsDelegate2(global::Microsoft.CodeAnalysis.ProjectChanges _obj);

        private static readonly GetAddedAnalyzerConfigDocumentsDelegate0 GetAddedAnalyzerConfigDocumentsFunc0;
        private static readonly GetChangedAnalyzerConfigDocumentsDelegate1 GetChangedAnalyzerConfigDocumentsFunc1;
        private static readonly GetRemovedAnalyzerConfigDocumentsDelegate2 GetRemovedAnalyzerConfigDocumentsFunc2;

        static ProjectChangesEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            GetAddedAnalyzerConfigDocumentsFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<GetAddedAnalyzerConfigDocumentsDelegate0>(wrappedType, "GetAddedAnalyzerConfigDocuments");
            GetChangedAnalyzerConfigDocumentsFunc1 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<GetChangedAnalyzerConfigDocumentsDelegate1>(wrappedType, "GetChangedAnalyzerConfigDocuments");
            GetRemovedAnalyzerConfigDocumentsFunc2 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<GetRemovedAnalyzerConfigDocumentsDelegate2>(wrappedType, "GetRemovedAnalyzerConfigDocuments");
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentId> GetAddedAnalyzerConfigDocuments(this global::Microsoft.CodeAnalysis.ProjectChanges _obj)
        {
            return GetAddedAnalyzerConfigDocumentsFunc0(_obj);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentId> GetChangedAnalyzerConfigDocuments(this global::Microsoft.CodeAnalysis.ProjectChanges _obj)
        {
            return GetChangedAnalyzerConfigDocumentsFunc1(_obj);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentId> GetRemovedAnalyzerConfigDocuments(this global::Microsoft.CodeAnalysis.ProjectChanges _obj)
        {
            return GetRemovedAnalyzerConfigDocumentsFunc2(_obj);
        }
    }
}