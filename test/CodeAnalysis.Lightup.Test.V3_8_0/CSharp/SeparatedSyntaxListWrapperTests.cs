﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0.CSharp;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<
    Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.RecordDeclarationSyntaxWrapper>;

[TestClass]
public partial class SeparatedSyntaxListWrapperTests
{
    [TestMethod]
    public override void TestCountGivenNullObject()
    {
        object? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.Count);
    }

    [TestMethod]
    public override void TestAddRangeGivenNullObject()
    {
        object? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.AddRange([]));
    }

    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.As(obj);
        var obj2 = wrapper.Unwrap();
        Assert.IsNotNull(obj2);
        _ = (SeparatedSyntaxList<RecordDeclarationSyntax>)obj2;
    }

    [TestMethod]
    public void TestCountGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.As(obj);
        Assert.AreEqual(0, wrapper.Count);

        obj = obj.Add(SyntaxFactory.RecordDeclaration(
            SyntaxFactory.Token(SyntaxKind.RecordKeyword),
            "abc"));
        wrapper = Wrapper.As(obj);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestAddRangeGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.As(obj);
        Assert.AreEqual(0, wrapper.Count);

        var newNativeItem = SyntaxFactory.RecordDeclaration(
            SyntaxFactory.Token(SyntaxKind.RecordKeyword),
            "abc");
        var newWrappedItem = RecordDeclarationSyntaxWrapper.As(newNativeItem);

        wrapper = wrapper.AddRange([newWrappedItem]);
        Assert.AreEqual(1, wrapper.Count);
    }
}
