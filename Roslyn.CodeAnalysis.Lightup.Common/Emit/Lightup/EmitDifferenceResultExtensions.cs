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

namespace Microsoft.CodeAnalysis.Emit.Lightup
{
    /// <summary>Class added in Roslyn version </summary>
    public static class EmitDifferenceResultExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Emit.EmitDifferenceResult";

        public static readonly Type? WrappedType;

        private delegate ImmutableArray<TypeDefinitionHandle> ChangedTypesGetterDelegate(EmitDifferenceResult? _obj);
        private delegate ImmutableArray<MethodDefinitionHandle> UpdatedMethodsGetterDelegate(EmitDifferenceResult? _obj);

        private static readonly ChangedTypesGetterDelegate ChangedTypesGetterFunc;
        private static readonly UpdatedMethodsGetterDelegate UpdatedMethodsGetterFunc;

        static EmitDifferenceResultExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            ChangedTypesGetterFunc = LightupHelper.CreateInstanceGetAccessor<ChangedTypesGetterDelegate>(WrappedType, nameof(ChangedTypes));
            UpdatedMethodsGetterFunc = LightupHelper.CreateInstanceGetAccessor<UpdatedMethodsGetterDelegate>(WrappedType, nameof(UpdatedMethods));
        }

        /// <summary>Added in Roslyn version 4.0.0.0</summary>
        public static ImmutableArray<TypeDefinitionHandle> ChangedTypes(this EmitDifferenceResult _obj)
            => ChangedTypesGetterFunc(_obj);

        /// <summary>Added in Roslyn version 4.0.0.0</summary>
        public static ImmutableArray<MethodDefinitionHandle> UpdatedMethods(this EmitDifferenceResult _obj)
            => UpdatedMethodsGetterFunc(_obj);
    }
}