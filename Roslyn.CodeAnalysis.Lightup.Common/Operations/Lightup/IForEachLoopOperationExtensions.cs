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
    public static class IForEachLoopOperationExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.IForEachLoopOperation";

        public static readonly Type? WrappedType;

        private delegate Boolean IsAsynchronousGetterDelegate(IForEachLoopOperation? _obj);

        private static readonly IsAsynchronousGetterDelegate IsAsynchronousGetterFunc;

        static IForEachLoopOperationExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            IsAsynchronousGetterFunc = LightupHelper.CreateInstanceGetAccessor<IsAsynchronousGetterDelegate>(WrappedType, nameof(IsAsynchronous));
        }

        /// <summary>Added in Roslyn version 3.8.0.0</summary>
        public static Boolean IsAsynchronous(this IForEachLoopOperation _obj)
            => IsAsynchronousGetterFunc(_obj);
    }
}