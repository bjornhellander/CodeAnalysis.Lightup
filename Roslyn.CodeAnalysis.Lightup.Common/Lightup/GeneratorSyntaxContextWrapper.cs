﻿// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Struct added in Roslyn version 4.0.0.0</summary>
    public readonly struct GeneratorSyntaxContextWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.GeneratorSyntaxContext";

        public static readonly Type? WrappedType;

        private delegate SyntaxNode NodeDelegate(object? _obj);
        private delegate SemanticModel SemanticModelDelegate(object? _obj);

        private static readonly NodeDelegate NodeFunc;
        private static readonly SemanticModelDelegate SemanticModelFunc;

        private readonly object? wrappedObject;

        static GeneratorSyntaxContextWrapper()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            NodeFunc = LightupHelper.CreateGetAccessor<NodeDelegate>(WrappedType, nameof(Node));
            SemanticModelFunc = LightupHelper.CreateGetAccessor<SemanticModelDelegate>(WrappedType, nameof(SemanticModel));
        }

        private GeneratorSyntaxContextWrapper(object? obj)
        {
            wrappedObject = obj;
        }

        public readonly SyntaxNode Node
            => NodeFunc(wrappedObject);

        public readonly SemanticModel SemanticModel
            => SemanticModelFunc(wrappedObject);

        public static bool Is(object? obj)
            => LightupHelper.Is(obj, WrappedType);

        public static GeneratorSyntaxContextWrapper As(object? obj)
        {
            var obj2 = LightupHelper.As<object>(obj, WrappedType);
            return new GeneratorSyntaxContextWrapper(obj2);
        }

        public object? Unwrap()
            => wrappedObject;
    }
}