﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IPropertyInitializerOperation. Added in version 2.6.0.0.</summary>
    public partial struct IPropertyInitializerOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IPropertyInitializerOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IPropertySymbol> InitializedPropertiesGetterDelegate(global::System.Object _obj);

        private static readonly InitializedPropertiesGetterDelegate InitializedPropertiesGetterFunc;

        private readonly global::System.Object wrappedObject;

        static IPropertyInitializerOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            InitializedPropertiesGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<InitializedPropertiesGetterDelegate>(WrappedType, nameof(InitializedProperties));
        }

        private IPropertyInitializerOperationWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IPropertySymbol> InitializedProperties
        {
            get { return InitializedPropertiesGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static IPropertyInitializerOperationWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new IPropertyInitializerOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }
    }
}
