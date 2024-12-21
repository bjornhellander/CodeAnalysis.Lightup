// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.CollectionExpressionSyntaxWrapper;

[TestClass]
public class CollectionExpressionSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        SyntaxNode? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public virtual void TestAddElementsGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = Wrapper.Wrap(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.AddElements());
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        var wrapper = Wrapper.Wrap(obj);
        Assert.IsNull(wrapper.Unwrap());
    }
}
