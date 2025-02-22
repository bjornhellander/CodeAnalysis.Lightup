﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.LoadTextOptions. Added in version 4.5.0.0.</summary>
    public partial struct LoadTextOptionsWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.LoadTextOptions";

        private static readonly global::System.Type? WrappedType;

        private delegate LoadTextOptionsWrapper ConstructorDelegate0(global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm checksumAlgorithm);

        private delegate global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm ChecksumAlgorithmGetterDelegate(global::System.Object _obj);

        private delegate global::System.Boolean EqualsDelegate0(global::System.Object _obj, global::Microsoft.CodeAnalysis.Lightup.LoadTextOptionsWrapper other);

        private static readonly ConstructorDelegate0 ConstructorFunc0;

        private static readonly ChecksumAlgorithmGetterDelegate ChecksumAlgorithmGetterFunc;

        private static readonly EqualsDelegate0 EqualsFunc0;

        private readonly global::System.Object wrappedObject;

        static LoadTextOptionsWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            ConstructorFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate0>(WrappedType, "checksumAlgorithmSourceHashAlgorithm");

            ChecksumAlgorithmGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<ChecksumAlgorithmGetterDelegate>(WrappedType, nameof(ChecksumAlgorithm));

            EqualsFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<EqualsDelegate0>(WrappedType, "Equals", "otherLoadTextOptions");
        }

        private LoadTextOptionsWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Constructor added in version 4.5.0.0.</summary>
        public static LoadTextOptionsWrapper Create(global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm checksumAlgorithm)
        {
            return ConstructorFunc0(checksumAlgorithm);
        }

        /// <summary>Property added in version 4.5.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm ChecksumAlgorithm
        {
            get { return ChecksumAlgorithmGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static LoadTextOptionsWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new LoadTextOptionsWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 4.5.0.0.</summary>
        public global::System.Boolean Equals(global::Microsoft.CodeAnalysis.Lightup.LoadTextOptionsWrapper other)
        {
            return EqualsFunc0(wrappedObject, other);
        }
    }
}
