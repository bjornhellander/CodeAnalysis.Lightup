﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.ProjectInfo.</summary>
    public static partial class ProjectInfoEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.ProjectInfo";

        private delegate global::System.Collections.Generic.IReadOnlyList<global::Microsoft.CodeAnalysis.DocumentInfo> AnalyzerConfigDocumentsGetterDelegate(global::Microsoft.CodeAnalysis.ProjectInfo _obj);
        private delegate global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper CompilationOutputInfoGetterDelegate(global::Microsoft.CodeAnalysis.ProjectInfo _obj);
        private delegate global::System.String? OutputRefFilePathGetterDelegate(global::Microsoft.CodeAnalysis.ProjectInfo _obj);

        private delegate global::Microsoft.CodeAnalysis.ProjectInfo CreateDelegate0(global::Microsoft.CodeAnalysis.ProjectId id, global::Microsoft.CodeAnalysis.VersionStamp version, global::System.String name, global::System.String assemblyName, global::System.String language, global::System.String? filePath, global::System.String? outputFilePath, global::Microsoft.CodeAnalysis.CompilationOptions? compilationOptions, global::Microsoft.CodeAnalysis.ParseOptions? parseOptions, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentInfo>? documents, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.ProjectReference>? projectReferences, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.MetadataReference>? metadataReferences, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.Diagnostics.AnalyzerReference>? analyzerReferences, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentInfo>? additionalDocuments, global::System.Boolean isSubmission, global::System.Type? hostObjectType, global::System.String? outputRefFilePath);

        private delegate global::Microsoft.CodeAnalysis.ProjectInfo WithAnalyzerConfigDocumentsDelegate0(global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentInfo>? analyzerConfigDocuments);
        private delegate global::Microsoft.CodeAnalysis.ProjectInfo WithCompilationOutputInfoDelegate1(global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper info);
        private delegate global::Microsoft.CodeAnalysis.ProjectInfo WithDefaultNamespaceDelegate2(global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::System.String? defaultNamespace);
        private delegate global::Microsoft.CodeAnalysis.ProjectInfo WithIdDelegate3(global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::Microsoft.CodeAnalysis.ProjectId id);
        private delegate global::Microsoft.CodeAnalysis.ProjectInfo WithOutputRefFilePathDelegate4(global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::System.String? outputRefFilePath);

        private static readonly AnalyzerConfigDocumentsGetterDelegate AnalyzerConfigDocumentsGetterFunc;
        private static readonly CompilationOutputInfoGetterDelegate CompilationOutputInfoGetterFunc;
        private static readonly OutputRefFilePathGetterDelegate OutputRefFilePathGetterFunc;

        private static readonly CreateDelegate0 CreateFunc0;

        private static readonly WithAnalyzerConfigDocumentsDelegate0 WithAnalyzerConfigDocumentsFunc0;
        private static readonly WithCompilationOutputInfoDelegate1 WithCompilationOutputInfoFunc1;
        private static readonly WithDefaultNamespaceDelegate2 WithDefaultNamespaceFunc2;
        private static readonly WithIdDelegate3 WithIdFunc3;
        private static readonly WithOutputRefFilePathDelegate4 WithOutputRefFilePathFunc4;

        static ProjectInfoEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            AnalyzerConfigDocumentsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<AnalyzerConfigDocumentsGetterDelegate>(wrappedType, nameof(AnalyzerConfigDocuments));
            CompilationOutputInfoGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<CompilationOutputInfoGetterDelegate>(wrappedType, nameof(CompilationOutputInfo));
            OutputRefFilePathGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<OutputRefFilePathGetterDelegate>(wrappedType, nameof(OutputRefFilePath));

            CreateFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate0>(wrappedType, "Create", "idProjectId", "versionVersionStamp", "nameString", "assemblyNameString", "languageString", "filePathString", "outputFilePathString", "compilationOptionsCompilationOptions", "parseOptionsParseOptions", "documentsIEnumerable`1", "projectReferencesIEnumerable`1", "metadataReferencesIEnumerable`1", "analyzerReferencesIEnumerable`1", "additionalDocumentsIEnumerable`1", "isSubmissionBoolean", "hostObjectTypeType", "outputRefFilePathString");

            WithAnalyzerConfigDocumentsFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<WithAnalyzerConfigDocumentsDelegate0>(wrappedType, "WithAnalyzerConfigDocuments", "analyzerConfigDocumentsIEnumerable`1");
            WithCompilationOutputInfoFunc1 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<WithCompilationOutputInfoDelegate1>(wrappedType, "WithCompilationOutputInfo", "infoCompilationOutputInfo&");
            WithDefaultNamespaceFunc2 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<WithDefaultNamespaceDelegate2>(wrappedType, "WithDefaultNamespace", "defaultNamespaceString");
            WithIdFunc3 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<WithIdDelegate3>(wrappedType, "WithId", "idProjectId");
            WithOutputRefFilePathFunc4 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<WithOutputRefFilePathDelegate4>(wrappedType, "WithOutputRefFilePath", "outputRefFilePathString");
        }

        /// <summary>Property added in version 3.2.0.0.</summary>
        public static global::System.Collections.Generic.IReadOnlyList<global::Microsoft.CodeAnalysis.DocumentInfo> AnalyzerConfigDocuments(this global::Microsoft.CodeAnalysis.ProjectInfo _obj)
        {
            return AnalyzerConfigDocumentsGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.7.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper CompilationOutputInfo(this global::Microsoft.CodeAnalysis.ProjectInfo _obj)
        {
            return CompilationOutputInfoGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public static global::System.String? OutputRefFilePath(this global::Microsoft.CodeAnalysis.ProjectInfo _obj)
        {
            return OutputRefFilePathGetterFunc(_obj);
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ProjectInfo Create(global::Microsoft.CodeAnalysis.ProjectId id, global::Microsoft.CodeAnalysis.VersionStamp version, global::System.String name, global::System.String assemblyName, global::System.String language, global::System.String? filePath, global::System.String? outputFilePath, global::Microsoft.CodeAnalysis.CompilationOptions? compilationOptions, global::Microsoft.CodeAnalysis.ParseOptions? parseOptions, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentInfo>? documents, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.ProjectReference>? projectReferences, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.MetadataReference>? metadataReferences, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.Diagnostics.AnalyzerReference>? analyzerReferences, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentInfo>? additionalDocuments, global::System.Boolean isSubmission, global::System.Type? hostObjectType, global::System.String? outputRefFilePath)
        {
            return CreateFunc0(id, version, name, assemblyName, language, filePath, outputFilePath, compilationOptions, parseOptions, documents, projectReferences, metadataReferences, analyzerReferences, additionalDocuments, isSubmission, hostObjectType, outputRefFilePath);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ProjectInfo WithAnalyzerConfigDocuments(this global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.DocumentInfo>? analyzerConfigDocuments)
        {
            return WithAnalyzerConfigDocumentsFunc0(_obj, analyzerConfigDocuments);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ProjectInfo WithCompilationOutputInfo(this global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper info)
        {
            return WithCompilationOutputInfoFunc1(_obj, info);
        }

        /// <summary>Method added in version 3.3.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ProjectInfo WithDefaultNamespace(this global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::System.String? defaultNamespace)
        {
            return WithDefaultNamespaceFunc2(_obj, defaultNamespace);
        }

        /// <summary>Method added in version 4.12.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ProjectInfo WithId(this global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::Microsoft.CodeAnalysis.ProjectId id)
        {
            return WithIdFunc3(_obj, id);
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ProjectInfo WithOutputRefFilePath(this global::Microsoft.CodeAnalysis.ProjectInfo _obj, global::System.String? outputRefFilePath)
        {
            return WithOutputRefFilePathFunc4(_obj, outputRefFilePath);
        }
    }
}
