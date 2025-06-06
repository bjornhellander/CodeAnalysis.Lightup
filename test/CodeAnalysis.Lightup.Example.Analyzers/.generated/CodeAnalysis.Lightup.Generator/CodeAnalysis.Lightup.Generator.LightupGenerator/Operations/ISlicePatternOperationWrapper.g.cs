﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.ISlicePatternOperation. Added in version 4.1.0.0.</summary>
    public partial struct ISlicePatternOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.ISlicePatternOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.Operations.Lightup.IPatternOperationWrapper? PatternGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.ISymbol? SliceSymbolGetterDelegate(global::System.Object _obj);

        private static readonly PatternGetterDelegate PatternGetterFunc;
        private static readonly SliceSymbolGetterDelegate SliceSymbolGetterFunc;

        private readonly global::System.Object wrappedObject;

        static ISlicePatternOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            PatternGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<PatternGetterDelegate>(WrappedType, nameof(Pattern));
            SliceSymbolGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<SliceSymbolGetterDelegate>(WrappedType, nameof(SliceSymbol));
        }

        private ISlicePatternOperationWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Operations.Lightup.IPatternOperationWrapper? Pattern
        {
            get { return PatternGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.1.0.0.</summary>
        public global::Microsoft.CodeAnalysis.ISymbol? SliceSymbol
        {
            get { return SliceSymbolGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ISlicePatternOperationWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new ISlicePatternOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }
    }
}
