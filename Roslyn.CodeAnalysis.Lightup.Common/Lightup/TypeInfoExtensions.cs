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
    /// <summary>Struct added in Roslyn version </summary>
    public static class TypeInfoExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.TypeInfo";

        public static readonly Type? WrappedType;

        private delegate NullabilityInfoWrapper ConvertedNullabilityGetterDelegate(TypeInfo? _obj);
        private delegate NullabilityInfoWrapper NullabilityGetterDelegate(TypeInfo? _obj);

        private static readonly ConvertedNullabilityGetterDelegate ConvertedNullabilityGetterFunc;
        private static readonly NullabilityGetterDelegate NullabilityGetterFunc;

        static TypeInfoExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            ConvertedNullabilityGetterFunc = LightupHelper.CreateInstanceGetAccessor<ConvertedNullabilityGetterDelegate>(WrappedType, nameof(ConvertedNullability));
            NullabilityGetterFunc = LightupHelper.CreateInstanceGetAccessor<NullabilityGetterDelegate>(WrappedType, nameof(Nullability));
        }

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static NullabilityInfoWrapper ConvertedNullability(this TypeInfo _obj)
            => ConvertedNullabilityGetterFunc(_obj);

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static NullabilityInfoWrapper Nullability(this TypeInfo _obj)
            => NullabilityGetterFunc(_obj);
    }
}