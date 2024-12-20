﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IInterpolatedStringAdditionOperation. Added in version 4.1.0.0.</summary>
    public partial struct IInterpolatedStringAdditionOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IInterpolatedStringAdditionOperation";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::Microsoft.CodeAnalysis.IOperation LeftGetterDelegate(global::Microsoft.CodeAnalysis.IOperation? _obj);
        private delegate global::Microsoft.CodeAnalysis.IOperation RightGetterDelegate(global::Microsoft.CodeAnalysis.IOperation? _obj);

        private static readonly LeftGetterDelegate LeftGetterFunc;
        private static readonly RightGetterDelegate RightGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation? wrappedObject;

        static IInterpolatedStringAdditionOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            LeftGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<LeftGetterDelegate>(WrappedType, nameof(Left));
            RightGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<RightGetterDelegate>(WrappedType, nameof(Right));
        }

        private IInterpolatedStringAdditionOperationWrapper(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Left
        {
            get { return LeftGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Right
        {
            get { return RightGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static IInterpolatedStringAdditionOperationWrapper As(global::System.Object? obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.As<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new IInterpolatedStringAdditionOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation? Unwrap()
        {
            return wrappedObject;
        }
    }
}
