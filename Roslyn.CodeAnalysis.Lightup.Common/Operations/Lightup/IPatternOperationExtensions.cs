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

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Interface added in Roslyn version </summary>
    public static class IPatternOperationExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IPatternOperation";

        public static readonly Type? WrappedType;

        private delegate ITypeSymbol NarrowedTypeGetterDelegate(IPatternOperation? _obj);

        private static readonly NarrowedTypeGetterDelegate NarrowedTypeGetterFunc;

        static IPatternOperationExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            NarrowedTypeGetterFunc = LightupHelper.CreateInstanceGetAccessor<NarrowedTypeGetterDelegate>(WrappedType, nameof(NarrowedType));
        }

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static ITypeSymbol NarrowedType(this IPatternOperation _obj)
            => NarrowedTypeGetterFunc(_obj);
    }
}