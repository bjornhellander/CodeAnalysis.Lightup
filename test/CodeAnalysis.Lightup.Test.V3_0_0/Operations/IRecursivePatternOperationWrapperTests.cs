// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0.Operations;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Operations.Lightup.IRecursivePatternOperationWrapper;

[TestClass]
public class IRecursivePatternOperationWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        IOperation? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenNullObject()
    {
        IOperation? obj = null;
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public virtual void TestPropertySubpatternsGivenNullObject()
    {
        IOperation? obj = null;
        var wrapper = Wrapper.Wrap(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.PropertySubpatterns);
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        var wrapper = Wrapper.Wrap(obj);
        Assert.IsNull(wrapper.Unwrap());
    }
}
