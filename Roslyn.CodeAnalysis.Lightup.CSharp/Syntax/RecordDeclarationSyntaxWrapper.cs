using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Roslyn.CodeAnalysis.Lightup.CSharp.Syntax
{
    public class RecordDeclarationSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.RecordDeclarationSyntax";

        private static readonly Type? WrappedType;
        private static readonly Func<SyntaxNode?, SyntaxToken> IdentifierFunc;
        private static readonly Func<SyntaxNode?, ParameterListSyntax?> ParameterListFunc;
        private static readonly Func<SyntaxNode?, SyntaxToken, RecordDeclarationSyntaxWrapper> WithIdentifierFunc;

        private readonly SyntaxNode? WrappedObject;

        static RecordDeclarationSyntaxWrapper()
        {
            WrappedType = WrapperHelper.FindSyntaxType(WrappedTypeName);
            IdentifierFunc = WrapperHelper.CreateGetAccessor<SyntaxToken>(WrappedType, nameof(Identifier));
            ParameterListFunc = WrapperHelper.CreateGetAccessor<ParameterListSyntax?>(WrappedType, nameof(ParameterList));
            WithIdentifierFunc = WrapperHelper.CreateMethodAccessor<SyntaxToken, RecordDeclarationSyntaxWrapper>(WrappedType, nameof(WithIdentifier));
        }

        private RecordDeclarationSyntaxWrapper(SyntaxNode? obj)
        {
            WrappedObject = obj;
        }

        public SyntaxToken Identifier
            => IdentifierFunc(WrappedObject);

        public ParameterListSyntax? ParameterList
            => ParameterListFunc(WrappedObject);

        public static implicit operator TypeDeclarationSyntax?(RecordDeclarationSyntaxWrapper obj)
            => obj.Unwrap();

        public static bool Is(SyntaxNode? obj)
            => WrapperHelper.Is(obj, WrappedType);

        public static RecordDeclarationSyntaxWrapper As(SyntaxNode? obj)
        {
            var obj2 = WrapperHelper.As(obj, WrappedType);
            return new RecordDeclarationSyntaxWrapper(obj2);
        }

        public TypeDeclarationSyntax? Unwrap()
            => (TypeDeclarationSyntax?)WrappedObject;

        public RecordDeclarationSyntaxWrapper WithIdentifier(SyntaxToken identifier)
            => WithIdentifierFunc(WrappedObject, identifier);
    }
}
