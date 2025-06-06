﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.ITypeSymbol.</summary>
    public static partial class ITypeSymbolEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.ITypeSymbol";

        private delegate global::Microsoft.CodeAnalysis.IParameterSymbol? ExtensionParameterGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsExtensionGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsNativeIntegerTypeGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsReadOnlyGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsRecordGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsRefLikeTypeGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsTupleTypeGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsUnmanagedTypeGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::Microsoft.CodeAnalysis.Lightup.NullableAnnotationEx NullableAnnotationGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);

        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.SymbolDisplayPart> ToDisplayPartsDelegate0(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format);
        private delegate global::System.String ToDisplayStringDelegate0(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.SymbolDisplayPart> ToMinimalDisplayPartsDelegate0(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::System.Int32 position, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format);
        private delegate global::System.String ToMinimalDisplayStringDelegate0(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::System.Int32 position, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format);
        private delegate global::Microsoft.CodeAnalysis.ITypeSymbol WithNullableAnnotationDelegate0(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableAnnotationEx nullableAnnotation);

        private static readonly ExtensionParameterGetterDelegate ExtensionParameterGetterFunc;
        private static readonly IsExtensionGetterDelegate IsExtensionGetterFunc;
        private static readonly IsNativeIntegerTypeGetterDelegate IsNativeIntegerTypeGetterFunc;
        private static readonly IsReadOnlyGetterDelegate IsReadOnlyGetterFunc;
        private static readonly IsRecordGetterDelegate IsRecordGetterFunc;
        private static readonly IsRefLikeTypeGetterDelegate IsRefLikeTypeGetterFunc;
        private static readonly IsTupleTypeGetterDelegate IsTupleTypeGetterFunc;
        private static readonly IsUnmanagedTypeGetterDelegate IsUnmanagedTypeGetterFunc;
        private static readonly NullableAnnotationGetterDelegate NullableAnnotationGetterFunc;

        private static readonly ToDisplayPartsDelegate0 ToDisplayPartsFunc0;
        private static readonly ToDisplayStringDelegate0 ToDisplayStringFunc0;
        private static readonly ToMinimalDisplayPartsDelegate0 ToMinimalDisplayPartsFunc0;
        private static readonly ToMinimalDisplayStringDelegate0 ToMinimalDisplayStringFunc0;
        private static readonly WithNullableAnnotationDelegate0 WithNullableAnnotationFunc0;

        static ITypeSymbolEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ExtensionParameterGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ExtensionParameterGetterDelegate>(wrappedType, nameof(ExtensionParameter));
            IsExtensionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsExtensionGetterDelegate>(wrappedType, nameof(IsExtension));
            IsNativeIntegerTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsNativeIntegerTypeGetterDelegate>(wrappedType, nameof(IsNativeIntegerType));
            IsReadOnlyGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsReadOnlyGetterDelegate>(wrappedType, nameof(IsReadOnly));
            IsRecordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsRecordGetterDelegate>(wrappedType, nameof(IsRecord));
            IsRefLikeTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsRefLikeTypeGetterDelegate>(wrappedType, nameof(IsRefLikeType));
            IsTupleTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsTupleTypeGetterDelegate>(wrappedType, nameof(IsTupleType));
            IsUnmanagedTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsUnmanagedTypeGetterDelegate>(wrappedType, nameof(IsUnmanagedType));
            NullableAnnotationGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<NullableAnnotationGetterDelegate>(wrappedType, nameof(NullableAnnotation));

            ToDisplayPartsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<ToDisplayPartsDelegate0>(wrappedType, "ToDisplayParts", "topLevelNullabilityNullableFlowState", "formatSymbolDisplayFormat");
            ToDisplayStringFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<ToDisplayStringDelegate0>(wrappedType, "ToDisplayString", "topLevelNullabilityNullableFlowState", "formatSymbolDisplayFormat");
            ToMinimalDisplayPartsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<ToMinimalDisplayPartsDelegate0>(wrappedType, "ToMinimalDisplayParts", "semanticModelSemanticModel", "topLevelNullabilityNullableFlowState", "positionInt32", "formatSymbolDisplayFormat");
            ToMinimalDisplayStringFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<ToMinimalDisplayStringDelegate0>(wrappedType, "ToMinimalDisplayString", "semanticModelSemanticModel", "topLevelNullabilityNullableFlowState", "positionInt32", "formatSymbolDisplayFormat");
            WithNullableAnnotationFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<WithNullableAnnotationDelegate0>(wrappedType, "WithNullableAnnotation", "nullableAnnotationNullableAnnotation");
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.IParameterSymbol? ExtensionParameter(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj)
        {
            return ExtensionParameterGetterFunc(_obj);
        }

        /// <summary>Property added in version 4.14.0.0.</summary>
        public static global::System.Boolean IsExtension(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj)
        {
            return IsExtensionGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.7.0.0.</summary>
        public static global::System.Boolean IsNativeIntegerType(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj)
        {
            return IsNativeIntegerTypeGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.1.0.0.</summary>
        public static global::System.Boolean IsReadOnly(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj)
        {
            return IsReadOnlyGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.9.0.0.</summary>
        public static global::System.Boolean IsRecord(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj)
        {
            return IsRecordGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public static global::System.Boolean IsRefLikeType(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj)
        {
            return IsRefLikeTypeGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public static global::System.Boolean IsTupleType(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj)
        {
            return IsTupleTypeGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public static global::System.Boolean IsUnmanagedType(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj)
        {
            return IsUnmanagedTypeGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.5.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.NullableAnnotationEx NullableAnnotation(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj)
        {
            return NullableAnnotationGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.1.0.0.</summary>
        public static global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.SymbolDisplayPart> ToDisplayParts(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format)
        {
            return ToDisplayPartsFunc0(_obj, topLevelNullability, format);
        }

        /// <summary>Method added in version 3.1.0.0.</summary>
        public static global::System.String ToDisplayString(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format)
        {
            return ToDisplayStringFunc0(_obj, topLevelNullability, format);
        }

        /// <summary>Method added in version 3.1.0.0.</summary>
        public static global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.SymbolDisplayPart> ToMinimalDisplayParts(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::System.Int32 position, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format)
        {
            return ToMinimalDisplayPartsFunc0(_obj, semanticModel, topLevelNullability, position, format);
        }

        /// <summary>Method added in version 3.1.0.0.</summary>
        public static global::System.String ToMinimalDisplayString(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::System.Int32 position, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format)
        {
            return ToMinimalDisplayStringFunc0(_obj, semanticModel, topLevelNullability, position, format);
        }

        /// <summary>Method added in version 3.5.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ITypeSymbol WithNullableAnnotation(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableAnnotationEx nullableAnnotation)
        {
            return WithNullableAnnotationFunc0(_obj, nullableAnnotation);
        }
    }
}
