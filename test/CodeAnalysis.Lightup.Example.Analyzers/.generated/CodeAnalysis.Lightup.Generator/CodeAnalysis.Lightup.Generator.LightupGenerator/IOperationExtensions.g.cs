﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.IOperation.</summary>
    public static partial class IOperationExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.IOperation";

        private delegate global::Microsoft.CodeAnalysis.Lightup.IOperationExtensions.OperationListWrapper ChildOperationsGetterDelegate(global::Microsoft.CodeAnalysis.IOperation? _obj);

        private static readonly ChildOperationsGetterDelegate ChildOperationsGetterFunc;

        static IOperationExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ChildOperationsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ChildOperationsGetterDelegate>(wrappedType, nameof(ChildOperations));
        }

        /// <summary>Property added in version 4.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.IOperationExtensions.OperationListWrapper ChildOperations(this global::Microsoft.CodeAnalysis.IOperation _obj)
        {
            return ChildOperationsGetterFunc(_obj);
        }
    }
}
