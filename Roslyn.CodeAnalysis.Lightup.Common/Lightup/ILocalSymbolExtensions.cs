﻿// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Interface added in Roslyn version </summary>
    public static class ILocalSymbolExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.ILocalSymbol";

        public static readonly Type? WrappedType;

        private delegate Boolean IsForEachGetterDelegate(ILocalSymbol? _obj);
        private delegate Boolean IsUsingGetterDelegate(ILocalSymbol? _obj);
        private delegate NullableAnnotationEx NullableAnnotationGetterDelegate(ILocalSymbol? _obj);
        private delegate ScopedKindEx ScopedKindGetterDelegate(ILocalSymbol? _obj);

        private static readonly IsForEachGetterDelegate IsForEachGetterFunc;
        private static readonly IsUsingGetterDelegate IsUsingGetterFunc;
        private static readonly NullableAnnotationGetterDelegate NullableAnnotationGetterFunc;
        private static readonly ScopedKindGetterDelegate ScopedKindGetterFunc;

        static ILocalSymbolExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            IsForEachGetterFunc = LightupHelper.CreateInstanceGetAccessor<IsForEachGetterDelegate>(WrappedType, nameof(IsForEach));
            IsUsingGetterFunc = LightupHelper.CreateInstanceGetAccessor<IsUsingGetterDelegate>(WrappedType, nameof(IsUsing));
            NullableAnnotationGetterFunc = LightupHelper.CreateInstanceGetAccessor<NullableAnnotationGetterDelegate>(WrappedType, nameof(NullableAnnotation));
            ScopedKindGetterFunc = LightupHelper.CreateInstanceGetAccessor<ScopedKindGetterDelegate>(WrappedType, nameof(ScopedKind));
        }

        /// <summary>Added in Roslyn version 4.4.0.0</summary>
        public static Boolean IsForEach(this ILocalSymbol _obj)
            => IsForEachGetterFunc(_obj);

        /// <summary>Added in Roslyn version 4.4.0.0</summary>
        public static Boolean IsUsing(this ILocalSymbol _obj)
            => IsUsingGetterFunc(_obj);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static NullableAnnotationEx NullableAnnotation(this ILocalSymbol _obj)
            => NullableAnnotationGetterFunc(_obj);

        /// <summary>Added in Roslyn version 4.4.0.0</summary>
        public static ScopedKindEx ScopedKind(this ILocalSymbol _obj)
            => ScopedKindGetterFunc(_obj);
    }
}