﻿// <auto-generated/>

#nullable enable

using Microsoft.CodeAnalysis.Lightup;
using System;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    public readonly struct BaseParameterSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.BaseParameterSyntax";

        private static readonly Type? WrappedType;
        private static readonly Func<CSharpSyntaxNode?, SyntaxList<AttributeListSyntax>> AttributeListsFunc;
        private static readonly Func<CSharpSyntaxNode?, SyntaxTokenList> ModifiersFunc;
        private static readonly Func<CSharpSyntaxNode?, TypeSyntax?> TypeFunc;
        private static readonly Func<CSharpSyntaxNode?, AttributeListSyntax[], BaseParameterSyntaxWrapper> AddAttributeListsFunc0;
        private static readonly Func<CSharpSyntaxNode?, SyntaxToken[], BaseParameterSyntaxWrapper> AddModifiersFunc1;
        private static readonly Func<CSharpSyntaxNode?, SyntaxList<AttributeListSyntax>, BaseParameterSyntaxWrapper> WithAttributeListsFunc2;
        private static readonly Func<CSharpSyntaxNode?, SyntaxTokenList, BaseParameterSyntaxWrapper> WithModifiersFunc3;
        private static readonly Func<CSharpSyntaxNode?, TypeSyntax?, BaseParameterSyntaxWrapper> WithTypeFunc4;

        private readonly CSharpSyntaxNode? WrappedObject;

        static BaseParameterSyntaxWrapper()
        {
            WrappedType = LightupHelper.FindSyntaxType(WrappedTypeName);
            AttributeListsFunc = LightupHelper.CreateGetAccessor<CSharpSyntaxNode?, SyntaxList<AttributeListSyntax>>(WrappedType, nameof(AttributeLists));
            ModifiersFunc = LightupHelper.CreateGetAccessor<CSharpSyntaxNode?, SyntaxTokenList>(WrappedType, nameof(Modifiers));
            TypeFunc = LightupHelper.CreateGetAccessor<CSharpSyntaxNode?, TypeSyntax?>(WrappedType, nameof(Type));
            AddAttributeListsFunc0 = LightupHelper.CreateMethodAccessor<BaseParameterSyntaxWrapper, CSharpSyntaxNode?, AttributeListSyntax[], BaseParameterSyntaxWrapper>(WrappedType, nameof(AddAttributeLists));
            AddModifiersFunc1 = LightupHelper.CreateMethodAccessor<BaseParameterSyntaxWrapper, CSharpSyntaxNode?, SyntaxToken[], BaseParameterSyntaxWrapper>(WrappedType, nameof(AddModifiers));
            WithAttributeListsFunc2 = LightupHelper.CreateMethodAccessor<BaseParameterSyntaxWrapper, CSharpSyntaxNode?, SyntaxList<AttributeListSyntax>, BaseParameterSyntaxWrapper>(WrappedType, nameof(WithAttributeLists));
            WithModifiersFunc3 = LightupHelper.CreateMethodAccessor<BaseParameterSyntaxWrapper, CSharpSyntaxNode?, SyntaxTokenList, BaseParameterSyntaxWrapper>(WrappedType, nameof(WithModifiers));
            WithTypeFunc4 = LightupHelper.CreateMethodAccessor<BaseParameterSyntaxWrapper, CSharpSyntaxNode?, TypeSyntax?, BaseParameterSyntaxWrapper>(WrappedType, nameof(WithType));
        }

        private BaseParameterSyntaxWrapper(CSharpSyntaxNode? obj)
        {
            WrappedObject = obj;
        }

        public readonly SyntaxList<AttributeListSyntax> AttributeLists
            => AttributeListsFunc(WrappedObject);

        public readonly SyntaxTokenList Modifiers
            => ModifiersFunc(WrappedObject);

        public readonly TypeSyntax? Type
            => TypeFunc(WrappedObject);

        public static implicit operator CSharpSyntaxNode?(BaseParameterSyntaxWrapper obj)
            => obj.Unwrap();

        public static bool Is(object? obj)
            => LightupHelper.Is(obj, WrappedType);

        public static BaseParameterSyntaxWrapper As(object? obj)
        {
            var obj2 = LightupHelper.As<CSharpSyntaxNode>(obj, WrappedType);
            return new BaseParameterSyntaxWrapper(obj2);
        }

        public CSharpSyntaxNode? Unwrap()
            => WrappedObject;

        public readonly BaseParameterSyntaxWrapper AddAttributeLists(AttributeListSyntax[] items)
            => AddAttributeListsFunc0(WrappedObject, items);

        public readonly BaseParameterSyntaxWrapper AddModifiers(SyntaxToken[] items)
            => AddModifiersFunc1(WrappedObject, items);

        public readonly BaseParameterSyntaxWrapper WithAttributeLists(SyntaxList<AttributeListSyntax> attributeLists)
            => WithAttributeListsFunc2(WrappedObject, attributeLists);

        public readonly BaseParameterSyntaxWrapper WithModifiers(SyntaxTokenList modifiers)
            => WithModifiersFunc3(WrappedObject, modifiers);

        public readonly BaseParameterSyntaxWrapper WithType(TypeSyntax? type)
            => WithTypeFunc4(WrappedObject, type);
    }
}