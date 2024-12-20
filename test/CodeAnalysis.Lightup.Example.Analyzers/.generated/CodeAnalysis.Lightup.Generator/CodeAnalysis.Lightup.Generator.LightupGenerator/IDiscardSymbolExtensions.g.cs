﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.IDiscardSymbol.</summary>
    public static partial class IDiscardSymbolExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.IDiscardSymbol";

        private delegate global::Microsoft.CodeAnalysis.Lightup.NullableAnnotationEx NullableAnnotationGetterDelegate(global::Microsoft.CodeAnalysis.IDiscardSymbol? _obj);

        private static readonly NullableAnnotationGetterDelegate NullableAnnotationGetterFunc;

        static IDiscardSymbolExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            NullableAnnotationGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<NullableAnnotationGetterDelegate>(wrappedType, nameof(NullableAnnotation));
        }

        /// <summary>Property added in version 3.1.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.NullableAnnotationEx NullableAnnotation(this global::Microsoft.CodeAnalysis.IDiscardSymbol _obj)
        {
            return NullableAnnotationGetterFunc(_obj);
        }
    }
}
