﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.FlowAnalysis.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.FlowAnalysis.IFlowCaptureReferenceOperation.</summary>
    public static partial class IFlowCaptureReferenceOperationExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.FlowAnalysis.IFlowCaptureReferenceOperation";

        private delegate global::System.Boolean IsInitializationGetterDelegate(global::Microsoft.CodeAnalysis.FlowAnalysis.IFlowCaptureReferenceOperation? _obj);

        private static readonly IsInitializationGetterDelegate IsInitializationGetterFunc;

        static IFlowCaptureReferenceOperationExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            IsInitializationGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsInitializationGetterDelegate>(wrappedType, nameof(IsInitialization));
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public static global::System.Boolean IsInitialization(this global::Microsoft.CodeAnalysis.FlowAnalysis.IFlowCaptureReferenceOperation _obj)
        {
            return IsInitializationGetterFunc(_obj);
        }
    }
}
