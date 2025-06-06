﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.InterceptableLocation. Added in version 4.11.0.0.</summary>
    public partial struct InterceptableLocationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.InterceptableLocation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::System.String DataGetterDelegate(global::System.Object _obj);
        private delegate global::System.Int32 VersionGetterDelegate(global::System.Object _obj);

        private delegate global::System.Boolean EqualsDelegate0(global::System.Object _obj, global::Microsoft.CodeAnalysis.CSharp.Lightup.InterceptableLocationWrapper? other);
        private delegate global::System.String GetDisplayLocationDelegate0(global::System.Object _obj);

        private static readonly DataGetterDelegate DataGetterFunc;
        private static readonly VersionGetterDelegate VersionGetterFunc;

        private static readonly EqualsDelegate0 EqualsFunc0;
        private static readonly GetDisplayLocationDelegate0 GetDisplayLocationFunc0;

        private readonly global::System.Object wrappedObject;

        static InterceptableLocationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            DataGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<DataGetterDelegate>(WrappedType, nameof(Data));
            VersionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<VersionGetterDelegate>(WrappedType, nameof(Version));

            EqualsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<EqualsDelegate0>(WrappedType, "Equals", "otherInterceptableLocation");
            GetDisplayLocationFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<GetDisplayLocationDelegate0>(WrappedType, "GetDisplayLocation");
        }

        private InterceptableLocationWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.11.0.0.</summary>
        public global::System.String Data
        {
            get { return DataGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.11.0.0.</summary>
        public global::System.Int32 Version
        {
            get { return VersionGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static InterceptableLocationWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new InterceptableLocationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 4.14.0.0.</summary>
        public global::System.Boolean Equals(global::Microsoft.CodeAnalysis.CSharp.Lightup.InterceptableLocationWrapper? other)
        {
            return EqualsFunc0(wrappedObject, other);
        }

        /// <summary>Method added in version 4.11.0.0.</summary>
        public global::System.String GetDisplayLocation()
        {
            return GetDisplayLocationFunc0(wrappedObject);
        }
    }
}
