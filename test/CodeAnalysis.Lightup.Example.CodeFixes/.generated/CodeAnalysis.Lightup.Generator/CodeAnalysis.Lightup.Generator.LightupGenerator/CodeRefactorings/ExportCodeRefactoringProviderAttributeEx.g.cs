﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CodeRefactorings.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute.</summary>
    public static partial class ExportCodeRefactoringProviderAttributeEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute";

        private delegate global::System.String[]? DocumentExtensionsGetterDelegate(global::Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute _obj);
        private delegate void DocumentExtensionsSetterDelegate(Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute _obj, global::System.String[]? _value);
        private delegate global::System.String[] DocumentKindsGetterDelegate(global::Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute _obj);
        private delegate void DocumentKindsSetterDelegate(Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute _obj, global::System.String[] _value);

        private static readonly DocumentExtensionsGetterDelegate DocumentExtensionsGetterFunc;
        private static readonly DocumentExtensionsSetterDelegate DocumentExtensionsSetterFunc;
        private static readonly DocumentKindsGetterDelegate DocumentKindsGetterFunc;
        private static readonly DocumentKindsSetterDelegate DocumentKindsSetterFunc;

        static ExportCodeRefactoringProviderAttributeEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            DocumentExtensionsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<DocumentExtensionsGetterDelegate>(wrappedType, nameof(DocumentExtensions));
            DocumentExtensionsSetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceSetAccessor<DocumentExtensionsSetterDelegate>(wrappedType, nameof(DocumentExtensions));
            DocumentKindsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<DocumentKindsGetterDelegate>(wrappedType, nameof(DocumentKinds));
            DocumentKindsSetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceSetAccessor<DocumentKindsSetterDelegate>(wrappedType, nameof(DocumentKinds));
        }

        /// <summary>Property added in version 4.5.0.0.</summary>
        public static global::System.String[]? DocumentExtensions(this global::Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute _obj)
        {
            return DocumentExtensionsGetterFunc(_obj);
        }

        /// <summary>Property added in version 4.5.0.0.</summary>
        public static void SetDocumentExtensions(this global::Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute _obj, global::System.String[]? _value)
        {
            DocumentExtensionsSetterFunc(_obj, _value);
        }

        /// <summary>Property added in version 4.5.0.0.</summary>
        public static global::System.String[] DocumentKinds(this global::Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute _obj)
        {
            return DocumentKindsGetterFunc(_obj);
        }

        /// <summary>Property added in version 4.5.0.0.</summary>
        public static void SetDocumentKinds(this global::Microsoft.CodeAnalysis.CodeRefactorings.ExportCodeRefactoringProviderAttribute _obj, global::System.String[] _value)
        {
            DocumentKindsSetterFunc(_obj, _value);
        }
    }
}
