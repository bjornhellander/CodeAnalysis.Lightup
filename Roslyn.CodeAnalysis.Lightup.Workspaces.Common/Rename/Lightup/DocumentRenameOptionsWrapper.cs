﻿// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.Rename.Lightup
{
    /// <summary>Struct added in Roslyn version 4.4.0.0</summary>
    public readonly struct DocumentRenameOptionsWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Rename.DocumentRenameOptions";

        public static readonly Type? WrappedType;

        private delegate Boolean RenameMatchingTypeInCommentsDelegate(object? _obj);
        private delegate Boolean RenameMatchingTypeInStringsDelegate(object? _obj);

        private delegate void DeconstructDelegate0(object? _obj, out Boolean RenameMatchingTypeInStrings, out Boolean RenameMatchingTypeInComments);
        private delegate Boolean EqualsDelegate1(object? _obj, DocumentRenameOptionsWrapper other);

        private static readonly RenameMatchingTypeInCommentsDelegate RenameMatchingTypeInCommentsFunc;
        private static readonly RenameMatchingTypeInStringsDelegate RenameMatchingTypeInStringsFunc;

        private static readonly DeconstructDelegate0 DeconstructFunc0;
        private static readonly EqualsDelegate1 EqualsFunc1;

        private readonly object? wrappedObject;

        static DocumentRenameOptionsWrapper()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            RenameMatchingTypeInCommentsFunc = LightupHelper.CreateGetAccessor<RenameMatchingTypeInCommentsDelegate>(WrappedType, nameof(RenameMatchingTypeInComments));
            RenameMatchingTypeInStringsFunc = LightupHelper.CreateGetAccessor<RenameMatchingTypeInStringsDelegate>(WrappedType, nameof(RenameMatchingTypeInStrings));

            DeconstructFunc0 = LightupHelper.CreateMethodAccessor<DeconstructDelegate0>(WrappedType, nameof(Deconstruct));
            EqualsFunc1 = LightupHelper.CreateMethodAccessor<EqualsDelegate1>(WrappedType, nameof(Equals));
        }

        private DocumentRenameOptionsWrapper(object? obj)
        {
            wrappedObject = obj;
        }

        public readonly Boolean RenameMatchingTypeInComments
            => RenameMatchingTypeInCommentsFunc(wrappedObject);

        public readonly Boolean RenameMatchingTypeInStrings
            => RenameMatchingTypeInStringsFunc(wrappedObject);

        public static bool Is(object? obj)
            => LightupHelper.Is(obj, WrappedType);

        public static DocumentRenameOptionsWrapper As(object? obj)
        {
            var obj2 = LightupHelper.As<object>(obj, WrappedType);
            return new DocumentRenameOptionsWrapper(obj2);
        }

        public object? Unwrap()
            => wrappedObject;

        public readonly void Deconstruct(out Boolean RenameMatchingTypeInStrings, out Boolean RenameMatchingTypeInComments)
            => DeconstructFunc0(wrappedObject, out RenameMatchingTypeInStrings, out RenameMatchingTypeInComments);

        public readonly Boolean Equals(DocumentRenameOptionsWrapper other)
            => EqualsFunc1(wrappedObject, other);
    }
}