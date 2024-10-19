// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

#pragma warning disable SA1516 // Elements should be separated by blank line
#pragma warning disable SA1201 // Elements should appear in the correct order

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.CodeAnalysis.Lightup
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;
    using Roslyn.CodeAnalysis.Lightup.Support;

    // TODO: Implement remaining members
    public readonly struct SeparatedSyntaxListWrapper<TNode>
    {
        private static readonly Type? WrappedType; // NOTE: Possibly used via reflection

        private delegate int CountDelegate(object? obj);
        private delegate SeparatedSyntaxListWrapper<TNode> AddRangeDelegate(object? obj, IEnumerable<TNode> arg1);

        private static readonly CountDelegate CountAccessor;
        private static readonly AddRangeDelegate AddRangeAccessor;

        private readonly object? wrappedObject;

        static SeparatedSyntaxListWrapper()
        {
            var wrapperNodeType = typeof(TNode);
            var wrappedNodeTypeField = wrapperNodeType.GetField("WrappedType", BindingFlags.Static | BindingFlags.NonPublic);
            var wrappedNodeType = (Type)wrappedNodeTypeField.GetValue(null);
            WrappedType = wrappedNodeType != null ? typeof(SeparatedSyntaxList<>).MakeGenericType(wrappedNodeType) : null;

            CountAccessor = LightupHelperBase.CreateInstanceGetAccessor<CountDelegate>(WrappedType, nameof(Count));
            AddRangeAccessor = LightupHelperBase.CreateInstanceMethodAccessor<AddRangeDelegate>(WrappedType, nameof(AddRange), "nodesIEnumerable`1");
        }

        private SeparatedSyntaxListWrapper(object? obj)
        {
            wrappedObject = obj;
        }

        public readonly int Count
            => CountAccessor(wrappedObject);

        public readonly int SeparatorCount
            => throw new NotImplementedException();

        public readonly TextSpan FullSpan
            => throw new NotImplementedException();

        public readonly TextSpan Span
            => throw new NotImplementedException();

        public readonly TNode this[int index]
            => throw new NotImplementedException();

        public static implicit operator SeparatedSyntaxListWrapper<SyntaxNode>(SeparatedSyntaxListWrapper<TNode> nodes)
            => throw new NotImplementedException();

        public static implicit operator SeparatedSyntaxListWrapper<TNode>(SeparatedSyntaxListWrapper<SyntaxNode> nodes)
            => throw new NotImplementedException();

        public static bool Is(object? obj)
        {
            if (obj != null && obj.GetType() != WrappedType)
            {
                obj = null;
            }

            return obj != null;
        }

        public static SeparatedSyntaxListWrapper<TNode> As(object? obj)
        {
            if (obj != null && obj.GetType() != WrappedType)
            {
                obj = null;
            }

            return new SeparatedSyntaxListWrapper<TNode>(obj);
        }

        public readonly object? Unwrap()
            => wrappedObject;

        public readonly SyntaxToken GetSeparator(int index)
            => throw new NotImplementedException();

        public readonly IEnumerable<SyntaxToken> GetSeparators()
            => throw new NotImplementedException();

        public readonly override string ToString()
            => throw new NotImplementedException();

        public readonly string ToFullString()
            => throw new NotImplementedException();

        public readonly TNode First()
            => throw new NotImplementedException();

        public readonly TNode FirstOrDefault()
            => throw new NotImplementedException();

        public readonly TNode Last()
            => throw new NotImplementedException();

        public TNode LastOrDefault()
            => throw new NotImplementedException();

        public readonly bool Contains(TNode node)
            => throw new NotImplementedException();

        public readonly int IndexOf(TNode node)
            => throw new NotImplementedException();

        public readonly int IndexOf(Func<TNode, bool> predicate)
            => throw new NotImplementedException();

        public readonly int LastIndexOf(TNode node)
            => throw new NotImplementedException();

        public readonly int LastIndexOf(Func<TNode, bool> predicate)
            => throw new NotImplementedException();

        public readonly bool Any()
            => throw new NotImplementedException();

        public readonly SyntaxNodeOrTokenList GetWithSeparators()
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> Add(TNode node)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> AddRange(IEnumerable<TNode> nodes)
            => AddRangeAccessor(wrappedObject, nodes);

        public readonly SeparatedSyntaxListWrapper<TNode> Insert(int index, TNode node)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> InsertRange(int index, IEnumerable<TNode> nodes)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> RemoveAt(int index)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> Remove(TNode node)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> Replace(TNode nodeInList, TNode newNode)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> ReplaceRange(TNode nodeInList, IEnumerable<TNode> newNodes)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> ReplaceSeparator(SyntaxToken separatorToken, SyntaxToken newSeparator)
            => throw new NotImplementedException();
    }
}
