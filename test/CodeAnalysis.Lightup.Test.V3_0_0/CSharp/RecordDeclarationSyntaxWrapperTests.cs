﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RecordDeclarationSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        SyntaxNode? obj = null;
        Assert.IsFalse(RecordDeclarationSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public virtual void TestIdentifierGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.Identifier);
    }

    [TestMethod]
    public virtual void TestWithIdentifierGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.WithIdentifier(SyntaxFactory.Token(SyntaxKind.IdentifierToken)));
    }

    [TestMethod]
    public virtual void TestParameterListGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.ParameterList);
    }

    [TestMethod]
    public virtual void TestUpdateGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        var visitor = new TestVisitor();
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.Accept(visitor));
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.IsFalse(RecordDeclarationSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.IsNull(wrapper.Unwrap());
    }
}
