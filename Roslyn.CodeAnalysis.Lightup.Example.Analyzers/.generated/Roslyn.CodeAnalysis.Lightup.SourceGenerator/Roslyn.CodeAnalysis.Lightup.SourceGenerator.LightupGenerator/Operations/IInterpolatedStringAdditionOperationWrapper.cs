﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IInterpolatedStringAdditionOperation. Added in version 4.4.0.0.</summary>
    public readonly partial struct IInterpolatedStringAdditionOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IInterpolatedStringAdditionOperation";

        private static readonly System.Type? WrappedType; // NOTE: Used via reflection

        private delegate Microsoft.CodeAnalysis.IOperation LeftGetterDelegate(Microsoft.CodeAnalysis.IOperation? _obj);
        private delegate Microsoft.CodeAnalysis.IOperation RightGetterDelegate(Microsoft.CodeAnalysis.IOperation? _obj);

        private static readonly LeftGetterDelegate LeftGetterFunc;
        private static readonly RightGetterDelegate RightGetterFunc;

        private readonly Microsoft.CodeAnalysis.IOperation? wrappedObject;

        static IInterpolatedStringAdditionOperationWrapper()
        {
            WrappedType = CommonLightupHelper.FindType(WrappedTypeName);

            LeftGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<LeftGetterDelegate>(WrappedType, nameof(Left));
            RightGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<RightGetterDelegate>(WrappedType, nameof(Right));
        }

        private IInterpolatedStringAdditionOperationWrapper(Microsoft.CodeAnalysis.IOperation? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.IOperation Left
        {
            get => LeftGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.IOperation Right
        {
            get => RightGetterFunc(wrappedObject);
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(System.Object? obj)
            => CommonLightupHelper.Is(obj, WrappedType);

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static IInterpolatedStringAdditionOperationWrapper As(System.Object? obj)
        {
            var obj2 = CommonLightupHelper.As<Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new IInterpolatedStringAdditionOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public Microsoft.CodeAnalysis.IOperation? Unwrap()
            => wrappedObject;
    }
}