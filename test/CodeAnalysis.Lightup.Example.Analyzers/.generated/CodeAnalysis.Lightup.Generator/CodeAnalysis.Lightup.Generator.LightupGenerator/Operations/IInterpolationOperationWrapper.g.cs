﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IInterpolationOperation. Added in version 2.6.0.0.</summary>
    public partial struct IInterpolationOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IInterpolationOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.IOperation? AlignmentGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.IOperation ExpressionGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.IOperation? FormatStringGetterDelegate(global::System.Object _obj);

        private static readonly AlignmentGetterDelegate AlignmentGetterFunc;
        private static readonly ExpressionGetterDelegate ExpressionGetterFunc;
        private static readonly FormatStringGetterDelegate FormatStringGetterFunc;

        private readonly global::System.Object wrappedObject;

        static IInterpolationOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            AlignmentGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<AlignmentGetterDelegate>(WrappedType, nameof(Alignment));
            ExpressionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ExpressionGetterDelegate>(WrappedType, nameof(Expression));
            FormatStringGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<FormatStringGetterDelegate>(WrappedType, nameof(FormatString));
        }

        private IInterpolationOperationWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation? Alignment
        {
            get { return AlignmentGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Expression
        {
            get { return ExpressionGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation? FormatString
        {
            get { return FormatStringGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static IInterpolationOperationWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new IInterpolationOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }
    }
}
