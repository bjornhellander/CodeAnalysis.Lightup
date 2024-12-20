﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.IConversionOperation.</summary>
    public static partial class IConversionOperationExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IConversionOperation";

        private delegate global::Microsoft.CodeAnalysis.ITypeSymbol? ConstrainedToTypeGetterDelegate(global::Microsoft.CodeAnalysis.Operations.IConversionOperation? _obj);

        private static readonly ConstrainedToTypeGetterDelegate ConstrainedToTypeGetterFunc;

        static IConversionOperationExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ConstrainedToTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ConstrainedToTypeGetterDelegate>(wrappedType, nameof(ConstrainedToType));
        }

        /// <summary>Property added in version 4.3.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ITypeSymbol? ConstrainedToType(this global::Microsoft.CodeAnalysis.Operations.IConversionOperation _obj)
        {
            return ConstrainedToTypeGetterFunc(_obj);
        }
    }
}
