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
        private static readonly Func<SyntaxNode?, SyntaxToken, RecordDeclarationSyntaxWrapper> WithIdentifierFunc;
        private static readonly Func<SyntaxNode?, ParameterListSyntax?> ParameterListFunc;

        private readonly SyntaxNode? WrappedObject;

        static RecordDeclarationSyntaxWrapper()
        {
            WrappedType = WrapperHelper.FindSyntaxType(WrappedTypeName);
            IdentifierFunc = WrapperHelper.CreateGetAccessor<SyntaxToken>(WrappedType, nameof(Identifier));
            WithIdentifierFunc = WrapperHelper.CreateMethodAccessor<SyntaxToken, RecordDeclarationSyntaxWrapper>(WrappedType, nameof(WithIdentifier));
            ParameterListFunc = WrapperHelper.CreateGetAccessor<ParameterListSyntax?>(WrappedType, nameof(ParameterList));
        }

        private RecordDeclarationSyntaxWrapper(SyntaxNode? obj)
        {
            WrappedObject = obj;
        }

        public static bool Is(SyntaxNode? obj)
            => WrapperHelper.Is(obj, WrappedType);

        public static RecordDeclarationSyntaxWrapper As(SyntaxNode? obj)
        {
            var obj2 = WrapperHelper.As(obj, WrappedType);
            return new RecordDeclarationSyntaxWrapper(obj2);
        }

        public static implicit operator TypeDeclarationSyntax?(RecordDeclarationSyntaxWrapper obj)
            => obj.Unwrap();

        public TypeDeclarationSyntax? Unwrap()
            => (TypeDeclarationSyntax?)WrappedObject;

        public SyntaxToken Identifier => IdentifierFunc(WrappedObject);

        public ParameterListSyntax? ParameterList => ParameterListFunc(WrappedObject);

        public RecordDeclarationSyntaxWrapper WithIdentifier(SyntaxToken identifier)
            => WithIdentifierFunc(WrappedObject, identifier);
    }
}
