﻿// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Interface added in Roslyn version 3.8.0.0</summary>
    public readonly struct INegatedPatternOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.INegatedPatternOperation";

        public static readonly Type? WrappedType;

        private delegate IPatternOperation PatternDelegate(IPatternOperation? _obj);

        private static readonly PatternDelegate PatternFunc;

        private readonly IPatternOperation? wrappedObject;

        static INegatedPatternOperationWrapper()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            PatternFunc = LightupHelper.CreateGetAccessor<PatternDelegate>(WrappedType, nameof(Pattern));
        }

        private INegatedPatternOperationWrapper(IPatternOperation? obj)
        {
            wrappedObject = obj;
        }

        public readonly IPatternOperation Pattern
            => PatternFunc(wrappedObject);

        public static bool Is(object? obj)
            => LightupHelper.Is(obj, WrappedType);

        public static INegatedPatternOperationWrapper As(object? obj)
        {
            var obj2 = LightupHelper.As<IPatternOperation>(obj, WrappedType);
            return new INegatedPatternOperationWrapper(obj2);
        }

        public IPatternOperation? Unwrap()
            => wrappedObject;
    }
}