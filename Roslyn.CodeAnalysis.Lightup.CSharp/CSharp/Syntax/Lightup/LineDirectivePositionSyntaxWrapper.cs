﻿// <auto-generated/>

#nullable enable

using Microsoft.CodeAnalysis.Lightup;
using System;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    public readonly struct LineDirectivePositionSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.LineDirectivePositionSyntax";

        private static readonly Type? WrappedType;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken> CharacterFunc;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken> CloseParenTokenFunc;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken> CommaTokenFunc;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken> LineFunc;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken> OpenParenTokenFunc;
        private static readonly Action<CSharpSyntaxNode?, CSharpSyntaxVisitor> AcceptFunc0;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken, SyntaxToken, SyntaxToken, SyntaxToken, SyntaxToken, LineDirectivePositionSyntaxWrapper> UpdateFunc1;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper> WithCharacterFunc2;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper> WithCloseParenTokenFunc3;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper> WithCommaTokenFunc4;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper> WithLineFunc5;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper> WithOpenParenTokenFunc6;

        private readonly CSharpSyntaxNode? WrappedObject;

        static LineDirectivePositionSyntaxWrapper()
        {
            WrappedType = LightupHelper.FindSyntaxType(WrappedTypeName);
            CharacterFunc = LightupHelper.CreateGetAccessor<CSharpSyntaxNode?, SyntaxToken>(WrappedType, nameof(Character));
            CloseParenTokenFunc = LightupHelper.CreateGetAccessor<CSharpSyntaxNode?, SyntaxToken>(WrappedType, nameof(CloseParenToken));
            CommaTokenFunc = LightupHelper.CreateGetAccessor<CSharpSyntaxNode?, SyntaxToken>(WrappedType, nameof(CommaToken));
            LineFunc = LightupHelper.CreateGetAccessor<CSharpSyntaxNode?, SyntaxToken>(WrappedType, nameof(Line));
            OpenParenTokenFunc = LightupHelper.CreateGetAccessor<CSharpSyntaxNode?, SyntaxToken>(WrappedType, nameof(OpenParenToken));
            AcceptFunc0 = LightupHelper.CreateVoidMethodAccessor<LineDirectivePositionSyntaxWrapper, CSharpSyntaxNode?, CSharpSyntaxVisitor>(WrappedType, nameof(Accept));
            UpdateFunc1 = LightupHelper.CreateMethodAccessor<LineDirectivePositionSyntaxWrapper, CSharpSyntaxNode?, SyntaxToken, SyntaxToken, SyntaxToken, SyntaxToken, SyntaxToken, LineDirectivePositionSyntaxWrapper>(WrappedType, nameof(Update));
            WithCharacterFunc2 = LightupHelper.CreateMethodAccessor<LineDirectivePositionSyntaxWrapper, CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper>(WrappedType, nameof(WithCharacter));
            WithCloseParenTokenFunc3 = LightupHelper.CreateMethodAccessor<LineDirectivePositionSyntaxWrapper, CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper>(WrappedType, nameof(WithCloseParenToken));
            WithCommaTokenFunc4 = LightupHelper.CreateMethodAccessor<LineDirectivePositionSyntaxWrapper, CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper>(WrappedType, nameof(WithCommaToken));
            WithLineFunc5 = LightupHelper.CreateMethodAccessor<LineDirectivePositionSyntaxWrapper, CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper>(WrappedType, nameof(WithLine));
            WithOpenParenTokenFunc6 = LightupHelper.CreateMethodAccessor<LineDirectivePositionSyntaxWrapper, CSharpSyntaxNode?, SyntaxToken, LineDirectivePositionSyntaxWrapper>(WrappedType, nameof(WithOpenParenToken));
        }

        private LineDirectivePositionSyntaxWrapper(CSharpSyntaxNode? obj)
        {
            WrappedObject = obj;
        }

        public readonly SyntaxToken Character
            => CharacterFunc(WrappedObject);

        public readonly SyntaxToken CloseParenToken
            => CloseParenTokenFunc(WrappedObject);

        public readonly SyntaxToken CommaToken
            => CommaTokenFunc(WrappedObject);

        public readonly SyntaxToken Line
            => LineFunc(WrappedObject);

        public readonly SyntaxToken OpenParenToken
            => OpenParenTokenFunc(WrappedObject);

        public static implicit operator CSharpSyntaxNode?(LineDirectivePositionSyntaxWrapper obj)
            => obj.Unwrap();

        public static bool Is(object? obj)
            => LightupHelper.Is(obj, WrappedType);

        public static LineDirectivePositionSyntaxWrapper As(object? obj)
        {
            var obj2 = LightupHelper.As<CSharpSyntaxNode>(obj, WrappedType);
            return new LineDirectivePositionSyntaxWrapper(obj2);
        }

        public CSharpSyntaxNode? Unwrap()
            => WrappedObject;

        public readonly void Accept(CSharpSyntaxVisitor visitor)
            => AcceptFunc0(WrappedObject, visitor);

        public readonly LineDirectivePositionSyntaxWrapper Update(SyntaxToken openParenToken, SyntaxToken line, SyntaxToken commaToken, SyntaxToken character, SyntaxToken closeParenToken)
            => UpdateFunc1(WrappedObject, openParenToken, line, commaToken, character, closeParenToken);

        public readonly LineDirectivePositionSyntaxWrapper WithCharacter(SyntaxToken character)
            => WithCharacterFunc2(WrappedObject, character);

        public readonly LineDirectivePositionSyntaxWrapper WithCloseParenToken(SyntaxToken closeParenToken)
            => WithCloseParenTokenFunc3(WrappedObject, closeParenToken);

        public readonly LineDirectivePositionSyntaxWrapper WithCommaToken(SyntaxToken commaToken)
            => WithCommaTokenFunc4(WrappedObject, commaToken);

        public readonly LineDirectivePositionSyntaxWrapper WithLine(SyntaxToken line)
            => WithLineFunc5(WrappedObject, line);

        public readonly LineDirectivePositionSyntaxWrapper WithOpenParenToken(SyntaxToken openParenToken)
            => WithOpenParenTokenFunc6(WrappedObject, openParenToken);
    }
}