﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Emit.Lightup
{
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.Emit.MethodInstrumentation. Added in version 4.8.0.0.</summary>
    public partial struct MethodInstrumentationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Emit.MethodInstrumentation";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.InstrumentationKind> KindsGetterDelegate(global::System.Object? _obj);
        private delegate void KindsSetterDelegate(System.Object? _obj, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.InstrumentationKind> _value);

        private static readonly KindsGetterDelegate KindsGetterFunc;
        private static readonly KindsSetterDelegate KindsSetterFunc;

        private readonly global::System.Object? wrappedObject;

        static MethodInstrumentationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            KindsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<KindsGetterDelegate>(WrappedType, nameof(Kinds));
            KindsSetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceSetAccessor<KindsSetterDelegate>(WrappedType, nameof(Kinds));
        }

        private MethodInstrumentationWrapper(global::System.Object? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.8.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.InstrumentationKind> Kinds
        {
            get { return KindsGetterFunc(wrappedObject); }
            set { KindsSetterFunc(wrappedObject, value); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static MethodInstrumentationWrapper As(global::System.Object? obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.As<global::System.Object>(obj, WrappedType);
            return new MethodInstrumentationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object? Unwrap()
        {
            return wrappedObject;
        }
    }
}