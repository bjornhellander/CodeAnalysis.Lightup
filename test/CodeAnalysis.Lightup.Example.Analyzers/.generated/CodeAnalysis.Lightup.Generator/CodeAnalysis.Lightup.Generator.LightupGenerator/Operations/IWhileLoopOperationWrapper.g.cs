﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IWhileLoopOperation. Added in version 2.6.0.0.</summary>
    public partial struct IWhileLoopOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IWhileLoopOperation";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::Microsoft.CodeAnalysis.IOperation? ConditionGetterDelegate(global::System.Object _obj);
        private delegate global::System.Boolean ConditionIsTopGetterDelegate(global::System.Object _obj);
        private delegate global::System.Boolean ConditionIsUntilGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.IOperation? IgnoredConditionGetterDelegate(global::System.Object _obj);

        private static readonly ConditionGetterDelegate ConditionGetterFunc;
        private static readonly ConditionIsTopGetterDelegate ConditionIsTopGetterFunc;
        private static readonly ConditionIsUntilGetterDelegate ConditionIsUntilGetterFunc;
        private static readonly IgnoredConditionGetterDelegate IgnoredConditionGetterFunc;

        private readonly global::System.Object wrappedObject;

        static IWhileLoopOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ConditionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ConditionGetterDelegate>(WrappedType, nameof(Condition));
            ConditionIsTopGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ConditionIsTopGetterDelegate>(WrappedType, nameof(ConditionIsTop));
            ConditionIsUntilGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ConditionIsUntilGetterDelegate>(WrappedType, nameof(ConditionIsUntil));
            IgnoredConditionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IgnoredConditionGetterDelegate>(WrappedType, nameof(IgnoredCondition));
        }

        private IWhileLoopOperationWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation? Condition
        {
            get { return ConditionGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::System.Boolean ConditionIsTop
        {
            get { return ConditionIsTopGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::System.Boolean ConditionIsUntil
        {
            get { return ConditionIsUntilGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation? IgnoredCondition
        {
            get { return IgnoredConditionGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static IWhileLoopOperationWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new IWhileLoopOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }
    }
}