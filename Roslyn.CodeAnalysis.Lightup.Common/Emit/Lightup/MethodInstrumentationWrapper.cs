﻿// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.Emit.Lightup
{
    /// <summary>Struct added in Roslyn version 4.8.0.0</summary>
    public readonly struct MethodInstrumentationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Emit.MethodInstrumentation";

        public static readonly Type? WrappedType;

        private delegate ImmutableArray<InstrumentationKind> KindsDelegate(object? _obj);

        private static readonly KindsDelegate KindsFunc;

        private readonly object? wrappedObject;

        static MethodInstrumentationWrapper()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            KindsFunc = LightupHelper.CreateGetAccessor<KindsDelegate>(WrappedType, nameof(Kinds));
        }

        private MethodInstrumentationWrapper(object? obj)
        {
            wrappedObject = obj;
        }

        public readonly ImmutableArray<InstrumentationKind> Kinds
            => KindsFunc(wrappedObject);

        public static bool Is(object? obj)
            => LightupHelper.Is(obj, WrappedType);

        public static MethodInstrumentationWrapper As(object? obj)
        {
            var obj2 = LightupHelper.As<object>(obj, WrappedType);
            return new MethodInstrumentationWrapper(obj2);
        }

        public object? Unwrap()
            => wrappedObject;
    }
}