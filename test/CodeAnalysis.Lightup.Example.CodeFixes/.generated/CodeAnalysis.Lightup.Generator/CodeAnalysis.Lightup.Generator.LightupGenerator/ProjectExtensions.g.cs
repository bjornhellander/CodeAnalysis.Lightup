﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Project.</summary>
    public static partial class ProjectExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Project";

        private delegate global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.Lightup.AnalyzerConfigDocumentWrapper> AnalyzerConfigDocumentsGetterDelegate(global::Microsoft.CodeAnalysis.Project? _obj);
        private delegate global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper CompilationOutputInfoGetterDelegate(global::Microsoft.CodeAnalysis.Project? _obj);
        private delegate global::System.String? DefaultNamespaceGetterDelegate(global::Microsoft.CodeAnalysis.Project? _obj);
        private delegate global::Microsoft.CodeAnalysis.Host.Lightup.LanguageServicesWrapper ServicesGetterDelegate(global::Microsoft.CodeAnalysis.Project? _obj);

        private delegate global::Microsoft.CodeAnalysis.TextDocument AddAnalyzerConfigDocumentDelegate0(global::Microsoft.CodeAnalysis.Project? _obj, global::System.String name, global::Microsoft.CodeAnalysis.Text.SourceText text, global::System.Collections.Generic.IEnumerable<global::System.String>? folders, global::System.String? filePath);
        private delegate global::System.Boolean ContainsAnalyzerConfigDocumentDelegate1(global::Microsoft.CodeAnalysis.Project? _obj, global::Microsoft.CodeAnalysis.DocumentId documentId);
        private delegate global::Microsoft.CodeAnalysis.Lightup.AnalyzerConfigDocumentWrapper GetAnalyzerConfigDocumentDelegate2(global::Microsoft.CodeAnalysis.Project? _obj, global::Microsoft.CodeAnalysis.DocumentId documentId);
        private delegate global::System.Threading.Tasks.ValueTask<global::Microsoft.CodeAnalysis.Lightup.SourceGeneratedDocumentWrapper> GetSourceGeneratedDocumentAsyncDelegate3(global::Microsoft.CodeAnalysis.Project? _obj, global::Microsoft.CodeAnalysis.DocumentId documentId, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::System.Threading.Tasks.ValueTask<global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.Lightup.SourceGeneratedDocumentWrapper>> GetSourceGeneratedDocumentsAsyncDelegate4(global::Microsoft.CodeAnalysis.Project? _obj, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.Project RemoveAdditionalDocumentsDelegate5(global::Microsoft.CodeAnalysis.Project? _obj, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.DocumentId> documentIds);
        private delegate global::Microsoft.CodeAnalysis.Project RemoveAnalyzerConfigDocumentDelegate6(global::Microsoft.CodeAnalysis.Project? _obj, global::Microsoft.CodeAnalysis.DocumentId documentId);
        private delegate global::Microsoft.CodeAnalysis.Project RemoveAnalyzerConfigDocumentsDelegate7(global::Microsoft.CodeAnalysis.Project? _obj, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.DocumentId> documentIds);
        private delegate global::Microsoft.CodeAnalysis.Project RemoveDocumentsDelegate8(global::Microsoft.CodeAnalysis.Project? _obj, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.DocumentId> documentIds);
        private delegate global::Microsoft.CodeAnalysis.Project WithDefaultNamespaceDelegate9(global::Microsoft.CodeAnalysis.Project? _obj, global::System.String defaultNamespace);

        private static readonly AnalyzerConfigDocumentsGetterDelegate AnalyzerConfigDocumentsGetterFunc;
        private static readonly CompilationOutputInfoGetterDelegate CompilationOutputInfoGetterFunc;
        private static readonly DefaultNamespaceGetterDelegate DefaultNamespaceGetterFunc;
        private static readonly ServicesGetterDelegate ServicesGetterFunc;

        private static readonly AddAnalyzerConfigDocumentDelegate0 AddAnalyzerConfigDocumentFunc0;
        private static readonly ContainsAnalyzerConfigDocumentDelegate1 ContainsAnalyzerConfigDocumentFunc1;
        private static readonly GetAnalyzerConfigDocumentDelegate2 GetAnalyzerConfigDocumentFunc2;
        private static readonly GetSourceGeneratedDocumentAsyncDelegate3 GetSourceGeneratedDocumentAsyncFunc3;
        private static readonly GetSourceGeneratedDocumentsAsyncDelegate4 GetSourceGeneratedDocumentsAsyncFunc4;
        private static readonly RemoveAdditionalDocumentsDelegate5 RemoveAdditionalDocumentsFunc5;
        private static readonly RemoveAnalyzerConfigDocumentDelegate6 RemoveAnalyzerConfigDocumentFunc6;
        private static readonly RemoveAnalyzerConfigDocumentsDelegate7 RemoveAnalyzerConfigDocumentsFunc7;
        private static readonly RemoveDocumentsDelegate8 RemoveDocumentsFunc8;
        private static readonly WithDefaultNamespaceDelegate9 WithDefaultNamespaceFunc9;

        static ProjectExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            AnalyzerConfigDocumentsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<AnalyzerConfigDocumentsGetterDelegate>(wrappedType, nameof(AnalyzerConfigDocuments));
            CompilationOutputInfoGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<CompilationOutputInfoGetterDelegate>(wrappedType, nameof(CompilationOutputInfo));
            DefaultNamespaceGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<DefaultNamespaceGetterDelegate>(wrappedType, nameof(DefaultNamespace));
            ServicesGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<ServicesGetterDelegate>(wrappedType, nameof(Services));

            AddAnalyzerConfigDocumentFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<AddAnalyzerConfigDocumentDelegate0>(wrappedType, "AddAnalyzerConfigDocument", "nameString", "textSourceText", "foldersIEnumerable`1", "filePathString");
            ContainsAnalyzerConfigDocumentFunc1 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<ContainsAnalyzerConfigDocumentDelegate1>(wrappedType, "ContainsAnalyzerConfigDocument", "documentIdDocumentId");
            GetAnalyzerConfigDocumentFunc2 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<GetAnalyzerConfigDocumentDelegate2>(wrappedType, "GetAnalyzerConfigDocument", "documentIdDocumentId");
            GetSourceGeneratedDocumentAsyncFunc3 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<GetSourceGeneratedDocumentAsyncDelegate3>(wrappedType, "GetSourceGeneratedDocumentAsync", "documentIdDocumentId", "cancellationTokenCancellationToken");
            GetSourceGeneratedDocumentsAsyncFunc4 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<GetSourceGeneratedDocumentsAsyncDelegate4>(wrappedType, "GetSourceGeneratedDocumentsAsync", "cancellationTokenCancellationToken");
            RemoveAdditionalDocumentsFunc5 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<RemoveAdditionalDocumentsDelegate5>(wrappedType, "RemoveAdditionalDocuments", "documentIdsImmutableArray`1");
            RemoveAnalyzerConfigDocumentFunc6 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<RemoveAnalyzerConfigDocumentDelegate6>(wrappedType, "RemoveAnalyzerConfigDocument", "documentIdDocumentId");
            RemoveAnalyzerConfigDocumentsFunc7 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<RemoveAnalyzerConfigDocumentsDelegate7>(wrappedType, "RemoveAnalyzerConfigDocuments", "documentIdsImmutableArray`1");
            RemoveDocumentsFunc8 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<RemoveDocumentsDelegate8>(wrappedType, "RemoveDocuments", "documentIdsImmutableArray`1");
            WithDefaultNamespaceFunc9 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<WithDefaultNamespaceDelegate9>(wrappedType, "WithDefaultNamespace", "defaultNamespaceString");
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.Lightup.AnalyzerConfigDocumentWrapper> AnalyzerConfigDocuments(this global::Microsoft.CodeAnalysis.Project _obj)
        {
            return AnalyzerConfigDocumentsGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper CompilationOutputInfo(this global::Microsoft.CodeAnalysis.Project _obj)
        {
            return CompilationOutputInfoGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static global::System.String? DefaultNamespace(this global::Microsoft.CodeAnalysis.Project _obj)
        {
            return DefaultNamespaceGetterFunc(_obj);
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Host.Lightup.LanguageServicesWrapper Services(this global::Microsoft.CodeAnalysis.Project _obj)
        {
            return ServicesGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.TextDocument AddAnalyzerConfigDocument(this global::Microsoft.CodeAnalysis.Project _obj, global::System.String name, global::Microsoft.CodeAnalysis.Text.SourceText text, global::System.Collections.Generic.IEnumerable<global::System.String>? folders, global::System.String? filePath)
        {
            return AddAnalyzerConfigDocumentFunc0(_obj, name, text, folders, filePath);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::System.Boolean ContainsAnalyzerConfigDocument(this global::Microsoft.CodeAnalysis.Project _obj, global::Microsoft.CodeAnalysis.DocumentId documentId)
        {
            return ContainsAnalyzerConfigDocumentFunc1(_obj, documentId);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.AnalyzerConfigDocumentWrapper GetAnalyzerConfigDocument(this global::Microsoft.CodeAnalysis.Project _obj, global::Microsoft.CodeAnalysis.DocumentId documentId)
        {
            return GetAnalyzerConfigDocumentFunc2(_obj, documentId);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static global::System.Threading.Tasks.ValueTask<global::Microsoft.CodeAnalysis.Lightup.SourceGeneratedDocumentWrapper> GetSourceGeneratedDocumentAsync(this global::Microsoft.CodeAnalysis.Project _obj, global::Microsoft.CodeAnalysis.DocumentId documentId, global::System.Threading.CancellationToken cancellationToken)
        {
            return GetSourceGeneratedDocumentAsyncFunc3(_obj, documentId, cancellationToken);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public static global::System.Threading.Tasks.ValueTask<global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.Lightup.SourceGeneratedDocumentWrapper>> GetSourceGeneratedDocumentsAsync(this global::Microsoft.CodeAnalysis.Project _obj, global::System.Threading.CancellationToken cancellationToken)
        {
            return GetSourceGeneratedDocumentsAsyncFunc4(_obj, cancellationToken);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Project RemoveAdditionalDocuments(this global::Microsoft.CodeAnalysis.Project _obj, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.DocumentId> documentIds)
        {
            return RemoveAdditionalDocumentsFunc5(_obj, documentIds);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Project RemoveAnalyzerConfigDocument(this global::Microsoft.CodeAnalysis.Project _obj, global::Microsoft.CodeAnalysis.DocumentId documentId)
        {
            return RemoveAnalyzerConfigDocumentFunc6(_obj, documentId);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Project RemoveAnalyzerConfigDocuments(this global::Microsoft.CodeAnalysis.Project _obj, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.DocumentId> documentIds)
        {
            return RemoveAnalyzerConfigDocumentsFunc7(_obj, documentIds);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Project RemoveDocuments(this global::Microsoft.CodeAnalysis.Project _obj, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.DocumentId> documentIds)
        {
            return RemoveDocumentsFunc8(_obj, documentIds);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Project WithDefaultNamespace(this global::Microsoft.CodeAnalysis.Project _obj, global::System.String defaultNamespace)
        {
            return WithDefaultNamespaceFunc9(_obj, defaultNamespace);
        }
    }
}