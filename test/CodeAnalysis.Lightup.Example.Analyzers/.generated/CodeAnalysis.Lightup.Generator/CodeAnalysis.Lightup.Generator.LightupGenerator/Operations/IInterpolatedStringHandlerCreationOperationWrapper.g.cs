﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IInterpolatedStringHandlerCreationOperation. Added in version 4.1.0.0.</summary>
    public partial struct IInterpolatedStringHandlerCreationOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IInterpolatedStringHandlerCreationOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.IOperation ContentGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::System.Boolean HandlerAppendCallsReturnBoolGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.IOperation HandlerCreationGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::System.Boolean HandlerCreationHasSuccessParameterGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);

        private static readonly ContentGetterDelegate ContentGetterFunc;
        private static readonly HandlerAppendCallsReturnBoolGetterDelegate HandlerAppendCallsReturnBoolGetterFunc;
        private static readonly HandlerCreationGetterDelegate HandlerCreationGetterFunc;
        private static readonly HandlerCreationHasSuccessParameterGetterDelegate HandlerCreationHasSuccessParameterGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation wrappedObject;

        static IInterpolatedStringHandlerCreationOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ContentGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ContentGetterDelegate>(WrappedType, nameof(Content));
            HandlerAppendCallsReturnBoolGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<HandlerAppendCallsReturnBoolGetterDelegate>(WrappedType, nameof(HandlerAppendCallsReturnBool));
            HandlerCreationGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<HandlerCreationGetterDelegate>(WrappedType, nameof(HandlerCreation));
            HandlerCreationHasSuccessParameterGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<HandlerCreationHasSuccessParameterGetterDelegate>(WrappedType, nameof(HandlerCreationHasSuccessParameter));
        }

        private IInterpolatedStringHandlerCreationOperationWrapper(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Content
        {
            get { return ContentGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::System.Boolean HandlerAppendCallsReturnBool
        {
            get { return HandlerAppendCallsReturnBoolGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation HandlerCreation
        {
            get { return HandlerCreationGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::System.Boolean HandlerCreationHasSuccessParameter
        {
            get { return HandlerCreationHasSuccessParameterGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static IInterpolatedStringHandlerCreationOperationWrapper Wrap(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new IInterpolatedStringHandlerCreationOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Unwrap()
        {
            return wrappedObject;
        }
    }
}
