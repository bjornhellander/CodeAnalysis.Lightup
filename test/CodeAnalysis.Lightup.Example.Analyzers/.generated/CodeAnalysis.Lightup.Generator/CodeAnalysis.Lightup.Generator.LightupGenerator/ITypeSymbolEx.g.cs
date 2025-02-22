﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.ITypeSymbol.</summary>
    public static partial class ITypeSymbolEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.ITypeSymbol";

        private delegate global::System.Boolean IsNativeIntegerTypeGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsReadOnlyGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsRecordGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsRefLikeTypeGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsTupleTypeGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::System.Boolean IsUnmanagedTypeGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);
        private delegate global::Microsoft.CodeAnalysis.Lightup.NullableAnnotationEx NullableAnnotationGetterDelegate(global::Microsoft.CodeAnalysis.ITypeSymbol _obj);

        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.SymbolDisplayPart> ToDisplayPartsDelegate0(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format);
        private delegate global::System.String ToDisplayStringDelegate1(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.SymbolDisplayPart> ToMinimalDisplayPartsDelegate2(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::System.Int32 position, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format);
        private delegate global::System.String ToMinimalDisplayStringDelegate3(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::System.Int32 position, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format);
        private delegate global::Microsoft.CodeAnalysis.ITypeSymbol WithNullableAnnotationDelegate4(global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableAnnotationEx nullableAnnotation);

        private static readonly IsNativeIntegerTypeGetterDelegate IsNativeIntegerTypeGetterFunc;
        private static readonly IsReadOnlyGetterDelegate IsReadOnlyGetterFunc;
        private static readonly IsRecordGetterDelegate IsRecordGetterFunc;
        private static readonly IsRefLikeTypeGetterDelegate IsRefLikeTypeGetterFunc;
        private static readonly IsTupleTypeGetterDelegate IsTupleTypeGetterFunc;
        private static readonly IsUnmanagedTypeGetterDelegate IsUnmanagedTypeGetterFunc;
        private static readonly NullableAnnotationGetterDelegate NullableAnnotationGetterFunc;

        private static readonly ToDisplayPartsDelegate0 ToDisplayPartsFunc0;
        private static readonly ToDisplayStringDelegate1 ToDisplayStringFunc1;
        private static readonly ToMinimalDisplayPartsDelegate2 ToMinimalDisplayPartsFunc2;
        private static readonly ToMinimalDisplayStringDelegate3 ToMinimalDisplayStringFunc3;
        private static readonly WithNullableAnnotationDelegate4 WithNullableAnnotationFunc4;

        static ITypeSymbolEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            IsNativeIntegerTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsNativeIntegerTypeGetterDelegate>(wrappedType, nameof(IsNativeIntegerType));
            IsReadOnlyGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsReadOnlyGetterDelegate>(wrappedType, nameof(IsReadOnly));
            IsRecordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsRecordGetterDelegate>(wrappedType, nameof(IsRecord));
            IsRefLikeTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsRefLikeTypeGetterDelegate>(wrappedType, nameof(IsRefLikeType));
            IsTupleTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsTupleTypeGetterDelegate>(wrappedType, nameof(IsTupleType));
            IsUnmanagedTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsUnmanagedTypeGetterDelegate>(wrappedType, nameof(IsUnmanagedType));
            NullableAnnotationGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<NullableAnnotationGetterDelegate>(wrappedType, nameof(NullableAnnotation));

            ToDisplayPartsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<ToDisplayPartsDelegate0>(wrappedType, "ToDisplayParts", "topLevelNullabilityNullableFlowState", "formatSymbolDisplayFormat");
            ToDisplayStringFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<ToDisplayStringDelegate1>(wrappedType, "ToDisplayString", "topLevelNullabilityNullableFlowState", "formatSymbolDisplayFormat");
            ToMinimalDisplayPartsFunc2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<ToMinimalDisplayPartsDelegate2>(wrappedType, "ToMinimalDisplayParts", "semanticModelSemanticModel", "topLevelNullabilityNullableFlowState", "positionInt32", "formatSymbolDisplayFormat");
            ToMinimalDisplayStringFunc3 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<ToMinimalDisplayStringDelegate3>(wrappedType, "ToMinimalDisplayString", "semanticModelSemanticModel", "topLevelNullabilityNullableFlowState", "positionInt32", "formatSymbolDisplayFormat");
            WithNullableAnnotationFunc4 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<WithNullableAnnotationDelegate4>(wrappedType, "WithNullableAnnotation", "nullableAnnotationNullableAnnotation");
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
            return ToDisplayStringFunc1(_obj, topLevelNullability, format);
        }

        /// <summary>Method added in version 3.1.0.0.</summary>
        public static global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.SymbolDisplayPart> ToMinimalDisplayParts(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::System.Int32 position, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format)
        {
            return ToMinimalDisplayPartsFunc2(_obj, semanticModel, topLevelNullability, position, format);
        }

        /// <summary>Method added in version 3.1.0.0.</summary>
        public static global::System.String ToMinimalDisplayString(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::Microsoft.CodeAnalysis.Lightup.NullableFlowStateEx topLevelNullability, global::System.Int32 position, global::Microsoft.CodeAnalysis.SymbolDisplayFormat? format)
        {
            return ToMinimalDisplayStringFunc3(_obj, semanticModel, topLevelNullability, position, format);
        }

        /// <summary>Method added in version 3.5.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.ITypeSymbol WithNullableAnnotation(this global::Microsoft.CodeAnalysis.ITypeSymbol _obj, global::Microsoft.CodeAnalysis.Lightup.NullableAnnotationEx nullableAnnotation)
        {
            return WithNullableAnnotationFunc4(_obj, nullableAnnotation);
        }
    }
}
