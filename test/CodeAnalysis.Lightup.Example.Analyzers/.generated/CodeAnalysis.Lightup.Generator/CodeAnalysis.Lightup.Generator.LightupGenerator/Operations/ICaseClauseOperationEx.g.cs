﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.ICaseClauseOperation.</summary>
    public static partial class ICaseClauseOperationEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.ICaseClauseOperation";

        private delegate global::Microsoft.CodeAnalysis.ILabelSymbol? LabelGetterDelegate(global::Microsoft.CodeAnalysis.Operations.ICaseClauseOperation _obj);

        private static readonly LabelGetterDelegate LabelGetterFunc;

        static ICaseClauseOperationEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            LabelGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<LabelGetterDelegate>(wrappedType, nameof(Label));
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ILabelSymbol? Label(this global::Microsoft.CodeAnalysis.Operations.ICaseClauseOperation _obj)
        {
            return LabelGetterFunc(_obj);
        }
    }
}
