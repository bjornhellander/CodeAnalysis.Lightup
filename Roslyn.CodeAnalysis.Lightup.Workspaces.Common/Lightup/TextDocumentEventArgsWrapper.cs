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

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Class added in Roslyn version 4.4.0.0</summary>
    public readonly struct TextDocumentEventArgsWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.TextDocumentEventArgs";

        public static readonly Type? WrappedType;

        private delegate TextDocument DocumentDelegate(EventArgs? _obj);

        private static readonly DocumentDelegate DocumentFunc;

        private readonly EventArgs? wrappedObject;

        static TextDocumentEventArgsWrapper()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            DocumentFunc = LightupHelper.CreateGetAccessor<DocumentDelegate>(WrappedType, nameof(Document));
        }

        private TextDocumentEventArgsWrapper(EventArgs? obj)
        {
            wrappedObject = obj;
        }

        public readonly TextDocument Document
            => DocumentFunc(wrappedObject);

        public static implicit operator EventArgs?(TextDocumentEventArgsWrapper obj)
            => obj.Unwrap();

        public static bool Is(object? obj)
            => LightupHelper.Is(obj, WrappedType);

        public static TextDocumentEventArgsWrapper As(object? obj)
        {
            var obj2 = LightupHelper.As<EventArgs>(obj, WrappedType);
            return new TextDocumentEventArgsWrapper(obj2);
        }

        public EventArgs? Unwrap()
            => wrappedObject;
    }
}