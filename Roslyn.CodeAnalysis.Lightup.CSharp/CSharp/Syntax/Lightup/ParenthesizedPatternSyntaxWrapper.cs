﻿// <auto-generated/>

#nullable enable

using Microsoft.CodeAnalysis.Lightup;
using System;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    public readonly struct ParenthesizedPatternSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedPatternSyntax";

        private static readonly Type? WrappedType;
        private static readonly Func<PatternSyntax?, SyntaxToken> CloseParenTokenFunc;
        private static readonly Func<PatternSyntax?, SyntaxToken> OpenParenTokenFunc;
        private static readonly Func<PatternSyntax?, PatternSyntax> PatternFunc;
        private static readonly Action<PatternSyntax?, CSharpSyntaxVisitor> AcceptFunc0;
        private static readonly Func<PatternSyntax?, SyntaxToken, PatternSyntax, SyntaxToken, ParenthesizedPatternSyntaxWrapper> UpdateFunc1;
        private static readonly Func<PatternSyntax?, SyntaxToken, ParenthesizedPatternSyntaxWrapper> WithCloseParenTokenFunc2;
        private static readonly Func<PatternSyntax?, SyntaxToken, ParenthesizedPatternSyntaxWrapper> WithOpenParenTokenFunc3;
        private static readonly Func<PatternSyntax?, PatternSyntax, ParenthesizedPatternSyntaxWrapper> WithPatternFunc4;

        private readonly PatternSyntax? WrappedObject;

        static ParenthesizedPatternSyntaxWrapper()
        {
            WrappedType = LightupHelper.FindSyntaxType(WrappedTypeName);
            CloseParenTokenFunc = LightupHelper.CreateGetAccessor<PatternSyntax?, SyntaxToken>(WrappedType, nameof(CloseParenToken));
            OpenParenTokenFunc = LightupHelper.CreateGetAccessor<PatternSyntax?, SyntaxToken>(WrappedType, nameof(OpenParenToken));
            PatternFunc = LightupHelper.CreateGetAccessor<PatternSyntax?, PatternSyntax>(WrappedType, nameof(Pattern));
            AcceptFunc0 = LightupHelper.CreateVoidMethodAccessor<ParenthesizedPatternSyntaxWrapper, PatternSyntax?, CSharpSyntaxVisitor>(WrappedType, nameof(Accept));
            UpdateFunc1 = LightupHelper.CreateMethodAccessor<ParenthesizedPatternSyntaxWrapper, PatternSyntax?, SyntaxToken, PatternSyntax, SyntaxToken, ParenthesizedPatternSyntaxWrapper>(WrappedType, nameof(Update));
            WithCloseParenTokenFunc2 = LightupHelper.CreateMethodAccessor<ParenthesizedPatternSyntaxWrapper, PatternSyntax?, SyntaxToken, ParenthesizedPatternSyntaxWrapper>(WrappedType, nameof(WithCloseParenToken));
            WithOpenParenTokenFunc3 = LightupHelper.CreateMethodAccessor<ParenthesizedPatternSyntaxWrapper, PatternSyntax?, SyntaxToken, ParenthesizedPatternSyntaxWrapper>(WrappedType, nameof(WithOpenParenToken));
            WithPatternFunc4 = LightupHelper.CreateMethodAccessor<ParenthesizedPatternSyntaxWrapper, PatternSyntax?, PatternSyntax, ParenthesizedPatternSyntaxWrapper>(WrappedType, nameof(WithPattern));
        }

        private ParenthesizedPatternSyntaxWrapper(PatternSyntax? obj)
        {
            WrappedObject = obj;
        }

        public readonly SyntaxToken CloseParenToken
            => CloseParenTokenFunc(WrappedObject);

        public readonly SyntaxToken OpenParenToken
            => OpenParenTokenFunc(WrappedObject);

        public readonly PatternSyntax Pattern
            => PatternFunc(WrappedObject);

        public static implicit operator PatternSyntax?(ParenthesizedPatternSyntaxWrapper obj)
            => obj.Unwrap();

        public static bool Is(object? obj)
            => LightupHelper.Is(obj, WrappedType);

        public static ParenthesizedPatternSyntaxWrapper As(object? obj)
        {
            var obj2 = LightupHelper.As<PatternSyntax>(obj, WrappedType);
            return new ParenthesizedPatternSyntaxWrapper(obj2);
        }

        public PatternSyntax? Unwrap()
            => WrappedObject;

        public readonly void Accept(CSharpSyntaxVisitor visitor)
            => AcceptFunc0(WrappedObject, visitor);

        public readonly ParenthesizedPatternSyntaxWrapper Update(SyntaxToken openParenToken, PatternSyntax pattern, SyntaxToken closeParenToken)
            => UpdateFunc1(WrappedObject, openParenToken, pattern, closeParenToken);

        public readonly ParenthesizedPatternSyntaxWrapper WithCloseParenToken(SyntaxToken closeParenToken)
            => WithCloseParenTokenFunc2(WrappedObject, closeParenToken);

        public readonly ParenthesizedPatternSyntaxWrapper WithOpenParenToken(SyntaxToken openParenToken)
            => WithOpenParenTokenFunc3(WrappedObject, openParenToken);

        public readonly ParenthesizedPatternSyntaxWrapper WithPattern(PatternSyntax pattern)
            => WithPatternFunc4(WrappedObject, pattern);
    }
}