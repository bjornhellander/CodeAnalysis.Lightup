﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Emit.Lightup
{
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.Emit.MethodInstrumentation. Added in version 4.8.0.0.</summary>
    public readonly partial struct MethodInstrumentationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Emit.MethodInstrumentation";

        private static readonly System.Type? WrappedType; // NOTE: Used via reflection

        private delegate System.Collections.Immutable.ImmutableArray<Microsoft.CodeAnalysis.Emit.InstrumentationKind> KindsGetterDelegate(System.Object? _obj);
        private delegate void KindsSetterDelegate(System.Object? _obj, System.Collections.Immutable.ImmutableArray<Microsoft.CodeAnalysis.Emit.InstrumentationKind> _value);

        private static readonly KindsGetterDelegate KindsGetterFunc;
        private static readonly KindsSetterDelegate KindsSetterFunc;

        private readonly System.Object? wrappedObject;

        static MethodInstrumentationWrapper()
        {
            WrappedType = CommonLightupHelper.FindType(WrappedTypeName);

            KindsGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<KindsGetterDelegate>(WrappedType, nameof(Kinds));
            KindsSetterFunc = CommonLightupHelper.CreateInstanceSetAccessor<KindsSetterDelegate>(WrappedType, nameof(Kinds));
        }

        private MethodInstrumentationWrapper(System.Object? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.8.0.0.</summary>
        public readonly System.Collections.Immutable.ImmutableArray<Microsoft.CodeAnalysis.Emit.InstrumentationKind> Kinds
        {
            get => KindsGetterFunc(wrappedObject);
            set => KindsSetterFunc(wrappedObject, value);
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(System.Object? obj)
            => CommonLightupHelper.Is(obj, WrappedType);

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static MethodInstrumentationWrapper As(System.Object? obj)
        {
            var obj2 = CommonLightupHelper.As<System.Object>(obj, WrappedType);
            return new MethodInstrumentationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public System.Object? Unwrap()
            => wrappedObject;
    }
}