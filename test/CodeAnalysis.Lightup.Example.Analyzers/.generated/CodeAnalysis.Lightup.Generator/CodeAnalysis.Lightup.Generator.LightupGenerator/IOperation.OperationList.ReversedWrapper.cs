﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
public partial class IOperationExtensions {
public partial struct OperationListWrapper {
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.IOperation+OperationList+Reversed. Added in version 4.4.0.0.</summary>
    public readonly partial struct ReversedWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.IOperation+OperationList+Reversed";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::System.Int32 CountGetterDelegate(global::System.Object? _obj);

        private delegate global::Microsoft.CodeAnalysis.Lightup.IOperationExtensions.OperationListWrapper.ReversedWrapper.EnumeratorWrapper GetEnumeratorDelegate0(global::System.Object? _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IOperation> ToImmutableArrayDelegate1(global::System.Object? _obj);

        private static readonly CountGetterDelegate CountGetterFunc;

        private static readonly GetEnumeratorDelegate0 GetEnumeratorFunc0;
        private static readonly ToImmutableArrayDelegate1 ToImmutableArrayFunc1;

        private readonly global::System.Object? wrappedObject;

        static ReversedWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            CountGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<CountGetterDelegate>(WrappedType, nameof(Count));

            GetEnumeratorFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<GetEnumeratorDelegate0>(WrappedType, "GetEnumerator");
            ToImmutableArrayFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<ToImmutableArrayDelegate1>(WrappedType, "ToImmutableArray");
        }

        private ReversedWrapper(global::System.Object? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public readonly global::System.Int32 Count
        {
            get => CountGetterFunc(wrappedObject);
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
            => global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static ReversedWrapper As(global::System.Object? obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.As<global::System.Object>(obj, WrappedType);
            return new ReversedWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object? Unwrap()
            => wrappedObject;

        /// <summary>Method added in version 4.4.0.0.</summary>
        public readonly global::Microsoft.CodeAnalysis.Lightup.IOperationExtensions.OperationListWrapper.ReversedWrapper.EnumeratorWrapper GetEnumerator()
            => GetEnumeratorFunc0(wrappedObject);

        /// <summary>Method added in version 4.4.0.0.</summary>
        public readonly global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IOperation> ToImmutableArray()
            => ToImmutableArrayFunc1(wrappedObject);
    }
}
}
}