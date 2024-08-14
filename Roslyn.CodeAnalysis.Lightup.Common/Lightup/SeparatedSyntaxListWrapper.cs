namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis.Text;

    // TODO: Implement remaining members
    public readonly struct SeparatedSyntaxListWrapper<TNode>
    {
        public static readonly Type? WrappedType;

        private static readonly Func<object?, int> CountAccessor;
        private static readonly Func<object?, IEnumerable<TNode>, SeparatedSyntaxListWrapper<TNode>> AddRangeAccessor;

        private readonly object? wrappedObject;

        static SeparatedSyntaxListWrapper()
        {
            var wrapperNodeType = typeof(TNode);
            var wrappedNodeTypeField = wrapperNodeType.GetField("WrappedType");
            var wrappedNodeType = (Type)wrappedNodeTypeField.GetValue(null);
            WrappedType = wrappedNodeType != null ? typeof(SeparatedSyntaxList<>).MakeGenericType(wrappedNodeType) : null;

            CountAccessor = CommonLightupHelper.CreateGetAccessor<object?, int>(WrappedType, nameof(Count));
            AddRangeAccessor = CommonLightupHelper.CreateMethodAccessor<object?, IEnumerable<TNode>, SeparatedSyntaxListWrapper<TNode>>(WrappedType, nameof(AddRange));
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
