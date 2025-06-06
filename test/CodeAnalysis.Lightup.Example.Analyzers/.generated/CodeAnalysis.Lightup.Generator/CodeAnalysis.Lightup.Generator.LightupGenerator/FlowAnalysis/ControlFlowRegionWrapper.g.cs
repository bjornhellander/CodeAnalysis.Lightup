﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.FlowAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.FlowAnalysis.ControlFlowRegion. Added in version 2.9.0.0.</summary>
    public partial struct ControlFlowRegionWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.FlowAnalysis.ControlFlowRegion";

        private static readonly global::System.Type? WrappedType;

        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.CaptureIdWrapper> CaptureIdsGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowRegionWrapper? EnclosingRegionGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.ITypeSymbol? ExceptionTypeGetterDelegate(global::System.Object _obj);
        private delegate global::System.Int32 FirstBlockOrdinalGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowRegionKindEx KindGetterDelegate(global::System.Object _obj);
        private delegate global::System.Int32 LastBlockOrdinalGetterDelegate(global::System.Object _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IMethodSymbol> LocalFunctionsGetterDelegate(global::System.Object _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.ILocalSymbol> LocalsGetterDelegate(global::System.Object _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowRegionWrapper> NestedRegionsGetterDelegate(global::System.Object _obj);

        private static readonly CaptureIdsGetterDelegate CaptureIdsGetterFunc;
        private static readonly EnclosingRegionGetterDelegate EnclosingRegionGetterFunc;
        private static readonly ExceptionTypeGetterDelegate ExceptionTypeGetterFunc;
        private static readonly FirstBlockOrdinalGetterDelegate FirstBlockOrdinalGetterFunc;
        private static readonly KindGetterDelegate KindGetterFunc;
        private static readonly LastBlockOrdinalGetterDelegate LastBlockOrdinalGetterFunc;
        private static readonly LocalFunctionsGetterDelegate LocalFunctionsGetterFunc;
        private static readonly LocalsGetterDelegate LocalsGetterFunc;
        private static readonly NestedRegionsGetterDelegate NestedRegionsGetterFunc;

        private readonly global::System.Object wrappedObject;

        static ControlFlowRegionWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            CaptureIdsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<CaptureIdsGetterDelegate>(WrappedType, nameof(CaptureIds));
            EnclosingRegionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<EnclosingRegionGetterDelegate>(WrappedType, nameof(EnclosingRegion));
            ExceptionTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ExceptionTypeGetterDelegate>(WrappedType, nameof(ExceptionType));
            FirstBlockOrdinalGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<FirstBlockOrdinalGetterDelegate>(WrappedType, nameof(FirstBlockOrdinal));
            KindGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<KindGetterDelegate>(WrappedType, nameof(Kind));
            LastBlockOrdinalGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<LastBlockOrdinalGetterDelegate>(WrappedType, nameof(LastBlockOrdinal));
            LocalFunctionsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<LocalFunctionsGetterDelegate>(WrappedType, nameof(LocalFunctions));
            LocalsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<LocalsGetterDelegate>(WrappedType, nameof(Locals));
            NestedRegionsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<NestedRegionsGetterDelegate>(WrappedType, nameof(NestedRegions));
        }

        private ControlFlowRegionWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.CaptureIdWrapper> CaptureIds
        {
            get { return CaptureIdsGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowRegionWrapper? EnclosingRegion
        {
            get { return EnclosingRegionGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::Microsoft.CodeAnalysis.ITypeSymbol? ExceptionType
        {
            get { return ExceptionTypeGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::System.Int32 FirstBlockOrdinal
        {
            get { return FirstBlockOrdinalGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowRegionKindEx Kind
        {
            get { return KindGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::System.Int32 LastBlockOrdinal
        {
            get { return LastBlockOrdinalGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IMethodSymbol> LocalFunctions
        {
            get { return LocalFunctionsGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.ILocalSymbol> Locals
        {
            get { return LocalsGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowRegionWrapper> NestedRegions
        {
            get { return NestedRegionsGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ControlFlowRegionWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new ControlFlowRegionWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }
    }
}
