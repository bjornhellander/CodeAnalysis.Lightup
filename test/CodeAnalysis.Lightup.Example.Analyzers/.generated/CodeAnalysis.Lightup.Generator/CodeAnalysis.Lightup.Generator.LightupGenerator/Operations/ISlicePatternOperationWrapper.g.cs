﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.ISlicePatternOperation. Added in version 4.4.0.0.</summary>
    public partial struct ISlicePatternOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.ISlicePatternOperation";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::Microsoft.CodeAnalysis.Operations.IPatternOperation? PatternGetterDelegate(global::Microsoft.CodeAnalysis.Operations.IPatternOperation? _obj);
        private delegate global::Microsoft.CodeAnalysis.ISymbol? SliceSymbolGetterDelegate(global::Microsoft.CodeAnalysis.Operations.IPatternOperation? _obj);

        private static readonly PatternGetterDelegate PatternGetterFunc;
        private static readonly SliceSymbolGetterDelegate SliceSymbolGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.Operations.IPatternOperation? wrappedObject;

        static ISlicePatternOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            PatternGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<PatternGetterDelegate>(WrappedType, nameof(Pattern));
            SliceSymbolGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<SliceSymbolGetterDelegate>(WrappedType, nameof(SliceSymbol));
        }

        private ISlicePatternOperationWrapper(global::Microsoft.CodeAnalysis.Operations.IPatternOperation? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Operations.IPatternOperation? Pattern
        {
            get { return PatternGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public global::Microsoft.CodeAnalysis.ISymbol? SliceSymbol
        {
            get { return SliceSymbolGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static ISlicePatternOperationWrapper As(global::System.Object? obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.As<global::Microsoft.CodeAnalysis.Operations.IPatternOperation>(obj, WrappedType);
            return new ISlicePatternOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.Operations.IPatternOperation? Unwrap()
        {
            return wrappedObject;
        }
    }
}