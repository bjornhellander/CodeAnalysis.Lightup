﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.IOperation.</summary>
    public static partial class IOperationExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.IOperation";

        private delegate Microsoft.CodeAnalysis.Lightup.IOperationExtensions.OperationListWrapper ChildOperationsGetterDelegate(Microsoft.CodeAnalysis.IOperation? _obj);

        private static readonly ChildOperationsGetterDelegate ChildOperationsGetterFunc;

        static IOperationExtensions()
        {
            var wrappedType = CommonLightupHelper.FindType(WrappedTypeName);

            ChildOperationsGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<ChildOperationsGetterDelegate>(wrappedType, nameof(ChildOperations));
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public static Microsoft.CodeAnalysis.Lightup.IOperationExtensions.OperationListWrapper ChildOperations(this Microsoft.CodeAnalysis.IOperation _obj)
            => ChildOperationsGetterFunc(_obj);
    }
}