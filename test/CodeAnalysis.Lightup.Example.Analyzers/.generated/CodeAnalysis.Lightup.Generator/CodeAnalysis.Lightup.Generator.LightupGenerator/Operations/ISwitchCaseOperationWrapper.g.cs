﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.ISwitchCaseOperation. Added in version 2.6.0.0.</summary>
    public partial struct ISwitchCaseOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.ISwitchCaseOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IOperation> BodyGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Operations.Lightup.ICaseClauseOperationWrapper> ClausesGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.ILocalSymbol> LocalsGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);

        private static readonly BodyGetterDelegate BodyGetterFunc;
        private static readonly ClausesGetterDelegate ClausesGetterFunc;
        private static readonly LocalsGetterDelegate LocalsGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation wrappedObject;

        static ISwitchCaseOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            BodyGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<BodyGetterDelegate>(WrappedType, nameof(Body));
            ClausesGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ClausesGetterDelegate>(WrappedType, nameof(Clauses));
            LocalsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<LocalsGetterDelegate>(WrappedType, nameof(Locals));
        }

        private ISwitchCaseOperationWrapper(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IOperation> Body
        {
            get { return BodyGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Operations.Lightup.ICaseClauseOperationWrapper> Clauses
        {
            get { return ClausesGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.ILocalSymbol> Locals
        {
            get { return LocalsGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ISwitchCaseOperationWrapper Wrap(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new ISwitchCaseOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Unwrap()
        {
            return wrappedObject;
        }
    }
}
