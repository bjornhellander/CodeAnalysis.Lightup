﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Diagnostics.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext.</summary>
    public static partial class OperationBlockStartAnalysisContextEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext";

        private delegate global::System.Nullable<global::Microsoft.CodeAnalysis.Text.TextSpan> FilterSpanGetterDelegate(global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTree FilterTreeGetterDelegate(global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext _obj);
        private delegate global::System.Boolean IsGeneratedCodeGetterDelegate(global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext _obj);

        private static readonly FilterSpanGetterDelegate FilterSpanGetterFunc;
        private static readonly FilterTreeGetterDelegate FilterTreeGetterFunc;
        private static readonly IsGeneratedCodeGetterDelegate IsGeneratedCodeGetterFunc;

        static OperationBlockStartAnalysisContextEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            FilterSpanGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<FilterSpanGetterDelegate>(wrappedType, nameof(FilterSpan));
            FilterTreeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<FilterTreeGetterDelegate>(wrappedType, nameof(FilterTree));
            IsGeneratedCodeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsGeneratedCodeGetterDelegate>(wrappedType, nameof(IsGeneratedCode));
        }

        /// <summary>Property added in version 4.7.0.0.</summary>
        public static global::System.Nullable<global::Microsoft.CodeAnalysis.Text.TextSpan> FilterSpan(this global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext _obj)
        {
            return FilterSpanGetterFunc(_obj);
        }

        /// <summary>Property added in version 4.7.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SyntaxTree FilterTree(this global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext _obj)
        {
            return FilterTreeGetterFunc(_obj);
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public static global::System.Boolean IsGeneratedCode(this global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext _obj)
        {
            return IsGeneratedCodeGetterFunc(_obj);
        }
    }
}