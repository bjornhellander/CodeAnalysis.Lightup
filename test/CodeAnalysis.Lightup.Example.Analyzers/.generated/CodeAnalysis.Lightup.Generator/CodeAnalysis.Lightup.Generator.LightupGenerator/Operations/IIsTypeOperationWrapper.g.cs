﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IIsTypeOperation. Added in version 2.6.0.0.</summary>
    public partial struct IIsTypeOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IIsTypeOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::System.Boolean IsNegatedGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.ITypeSymbol TypeOperandGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.IOperation ValueOperandGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);

        private static readonly IsNegatedGetterDelegate IsNegatedGetterFunc;
        private static readonly TypeOperandGetterDelegate TypeOperandGetterFunc;
        private static readonly ValueOperandGetterDelegate ValueOperandGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation wrappedObject;

        static IIsTypeOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            IsNegatedGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsNegatedGetterDelegate>(WrappedType, nameof(IsNegated));
            TypeOperandGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<TypeOperandGetterDelegate>(WrappedType, nameof(TypeOperand));
            ValueOperandGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ValueOperandGetterDelegate>(WrappedType, nameof(ValueOperand));
        }

        private IIsTypeOperationWrapper(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::System.Boolean IsNegated
        {
            get { return IsNegatedGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.ITypeSymbol TypeOperand
        {
            get { return TypeOperandGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation ValueOperand
        {
            get { return ValueOperandGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static IIsTypeOperationWrapper Wrap(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new IIsTypeOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Unwrap()
        {
            return wrappedObject;
        }
    }
}
