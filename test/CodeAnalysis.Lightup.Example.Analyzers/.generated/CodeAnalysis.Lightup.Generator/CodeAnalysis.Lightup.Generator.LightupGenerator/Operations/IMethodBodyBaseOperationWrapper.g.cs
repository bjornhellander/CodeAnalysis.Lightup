﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IMethodBodyBaseOperation. Added in version 2.8.0.0.</summary>
    public partial struct IMethodBodyBaseOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IMethodBodyBaseOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.Operations.Lightup.IBlockOperationWrapper? BlockBodyGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.Operations.Lightup.IBlockOperationWrapper? ExpressionBodyGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);

        private static readonly BlockBodyGetterDelegate BlockBodyGetterFunc;
        private static readonly ExpressionBodyGetterDelegate ExpressionBodyGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation wrappedObject;

        static IMethodBodyBaseOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            BlockBodyGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<BlockBodyGetterDelegate>(WrappedType, nameof(BlockBody));
            ExpressionBodyGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ExpressionBodyGetterDelegate>(WrappedType, nameof(ExpressionBody));
        }

        private IMethodBodyBaseOperationWrapper(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Operations.Lightup.IBlockOperationWrapper? BlockBody
        {
            get { return BlockBodyGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Operations.Lightup.IBlockOperationWrapper? ExpressionBody
        {
            get { return ExpressionBodyGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static IMethodBodyBaseOperationWrapper Wrap(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new IMethodBodyBaseOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Unwrap()
        {
            return wrappedObject;
        }
    }
}
