﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.ITupleBinaryOperation. Added in version 2.8.0.0.</summary>
    public partial struct ITupleBinaryOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.ITupleBinaryOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.IOperation LeftOperandGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.Operations.Lightup.BinaryOperatorKindEx OperatorKindGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.IOperation RightOperandGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);

        private static readonly LeftOperandGetterDelegate LeftOperandGetterFunc;
        private static readonly OperatorKindGetterDelegate OperatorKindGetterFunc;
        private static readonly RightOperandGetterDelegate RightOperandGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation wrappedObject;

        static ITupleBinaryOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            LeftOperandGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<LeftOperandGetterDelegate>(WrappedType, nameof(LeftOperand));
            OperatorKindGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<OperatorKindGetterDelegate>(WrappedType, nameof(OperatorKind));
            RightOperandGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<RightOperandGetterDelegate>(WrappedType, nameof(RightOperand));
        }

        private ITupleBinaryOperationWrapper(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation LeftOperand
        {
            get { return LeftOperandGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Operations.Lightup.BinaryOperatorKindEx OperatorKind
        {
            get { return OperatorKindGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation RightOperand
        {
            get { return RightOperandGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ITupleBinaryOperationWrapper Wrap(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new ITupleBinaryOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Unwrap()
        {
            return wrappedObject;
        }
    }
}
