﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IRaiseEventOperation. Added in version 2.6.0.0.</summary>
    public partial struct IRaiseEventOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IRaiseEventOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Operations.Lightup.IArgumentOperationWrapper> ArgumentsGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.Operations.Lightup.IEventReferenceOperationWrapper EventReferenceGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);

        private static readonly ArgumentsGetterDelegate ArgumentsGetterFunc;
        private static readonly EventReferenceGetterDelegate EventReferenceGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation wrappedObject;

        static IRaiseEventOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ArgumentsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ArgumentsGetterDelegate>(WrappedType, nameof(Arguments));
            EventReferenceGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<EventReferenceGetterDelegate>(WrappedType, nameof(EventReference));
        }

        private IRaiseEventOperationWrapper(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Operations.Lightup.IArgumentOperationWrapper> Arguments
        {
            get { return ArgumentsGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Operations.Lightup.IEventReferenceOperationWrapper EventReference
        {
            get { return EventReferenceGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static IRaiseEventOperationWrapper Wrap(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new IRaiseEventOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Unwrap()
        {
            return wrappedObject;
        }
    }
}
