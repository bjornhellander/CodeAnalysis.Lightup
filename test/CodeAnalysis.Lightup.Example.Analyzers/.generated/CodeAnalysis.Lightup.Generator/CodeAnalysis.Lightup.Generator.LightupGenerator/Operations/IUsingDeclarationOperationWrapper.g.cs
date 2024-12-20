﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IUsingDeclarationOperation. Added in version 3.4.0.0.</summary>
    public partial struct IUsingDeclarationOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IUsingDeclarationOperation";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::Microsoft.CodeAnalysis.Operations.IVariableDeclarationGroupOperation DeclarationGroupGetterDelegate(global::Microsoft.CodeAnalysis.IOperation? _obj);
        private delegate global::System.Boolean IsAsynchronousGetterDelegate(global::Microsoft.CodeAnalysis.IOperation? _obj);

        private static readonly DeclarationGroupGetterDelegate DeclarationGroupGetterFunc;
        private static readonly IsAsynchronousGetterDelegate IsAsynchronousGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation? wrappedObject;

        static IUsingDeclarationOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            DeclarationGroupGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<DeclarationGroupGetterDelegate>(WrappedType, nameof(DeclarationGroup));
            IsAsynchronousGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsAsynchronousGetterDelegate>(WrappedType, nameof(IsAsynchronous));
        }

        private IUsingDeclarationOperationWrapper(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.4.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Operations.IVariableDeclarationGroupOperation DeclarationGroup
        {
            get { return DeclarationGroupGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.4.0.0.</summary>
        public global::System.Boolean IsAsynchronous
        {
            get { return IsAsynchronousGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static IUsingDeclarationOperationWrapper As(global::System.Object? obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.As<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new IUsingDeclarationOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation? Unwrap()
        {
            return wrappedObject;
        }
    }
}
