﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IWithOperation. Added in version 3.8.0.0.</summary>
    public readonly partial struct IWithOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IWithOperation";

        private static readonly System.Type? WrappedType; // NOTE: Used via reflection

        private delegate Microsoft.CodeAnalysis.IMethodSymbol? CloneMethodGetterDelegate(Microsoft.CodeAnalysis.IOperation? _obj);
        private delegate Microsoft.CodeAnalysis.Operations.IObjectOrCollectionInitializerOperation InitializerGetterDelegate(Microsoft.CodeAnalysis.IOperation? _obj);
        private delegate Microsoft.CodeAnalysis.IOperation OperandGetterDelegate(Microsoft.CodeAnalysis.IOperation? _obj);

        private static readonly CloneMethodGetterDelegate CloneMethodGetterFunc;
        private static readonly InitializerGetterDelegate InitializerGetterFunc;
        private static readonly OperandGetterDelegate OperandGetterFunc;

        private readonly Microsoft.CodeAnalysis.IOperation? wrappedObject;

        static IWithOperationWrapper()
        {
            WrappedType = CommonLightupHelper.FindType(WrappedTypeName);

            CloneMethodGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<CloneMethodGetterDelegate>(WrappedType, nameof(CloneMethod));
            InitializerGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<InitializerGetterDelegate>(WrappedType, nameof(Initializer));
            OperandGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<OperandGetterDelegate>(WrappedType, nameof(Operand));
        }

        private IWithOperationWrapper(Microsoft.CodeAnalysis.IOperation? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.IMethodSymbol? CloneMethod
        {
            get => CloneMethodGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.Operations.IObjectOrCollectionInitializerOperation Initializer
        {
            get => InitializerGetterFunc(wrappedObject);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public readonly Microsoft.CodeAnalysis.IOperation Operand
        {
            get => OperandGetterFunc(wrappedObject);
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(System.Object? obj)
            => CommonLightupHelper.Is(obj, WrappedType);

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static IWithOperationWrapper As(System.Object? obj)
        {
            var obj2 = CommonLightupHelper.As<Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new IWithOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public Microsoft.CodeAnalysis.IOperation? Unwrap()
            => wrappedObject;
    }
}