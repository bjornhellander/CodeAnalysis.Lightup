﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IInvocationOperation.</summary>
    public static partial class IInvocationOperationExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IInvocationOperation";

        private delegate Microsoft.CodeAnalysis.ITypeSymbol? ConstrainedToTypeGetterDelegate(Microsoft.CodeAnalysis.Operations.IInvocationOperation? _obj);

        private static readonly ConstrainedToTypeGetterDelegate ConstrainedToTypeGetterFunc;

        static IInvocationOperationExtensions()
        {
            var wrappedType = CommonLightupHelper.FindType(WrappedTypeName);

            ConstrainedToTypeGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<ConstrainedToTypeGetterDelegate>(wrappedType, nameof(ConstrainedToType));
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public static Microsoft.CodeAnalysis.ITypeSymbol? ConstrainedToType(this Microsoft.CodeAnalysis.Operations.IInvocationOperation _obj)
            => ConstrainedToTypeGetterFunc(_obj);
    }
}