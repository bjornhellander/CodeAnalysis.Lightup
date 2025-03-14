﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IInterpolatedStringHandlerArgumentPlaceholderOperation. Added in version 4.1.0.0.</summary>
    public partial struct IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IInterpolatedStringHandlerArgumentPlaceholderOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::System.Int32 ArgumentIndexGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.Operations.Lightup.InterpolatedStringArgumentPlaceholderKindEx PlaceholderKindGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);

        private static readonly ArgumentIndexGetterDelegate ArgumentIndexGetterFunc;
        private static readonly PlaceholderKindGetterDelegate PlaceholderKindGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation wrappedObject;

        static IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ArgumentIndexGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ArgumentIndexGetterDelegate>(WrappedType, nameof(ArgumentIndex));
            PlaceholderKindGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<PlaceholderKindGetterDelegate>(WrappedType, nameof(PlaceholderKind));
        }

        private IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::System.Int32 ArgumentIndex
        {
            get { return ArgumentIndexGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Operations.Lightup.InterpolatedStringArgumentPlaceholderKindEx PlaceholderKind
        {
            get { return PlaceholderKindGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper Wrap(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Unwrap()
        {
            return wrappedObject;
        }
    }
}
