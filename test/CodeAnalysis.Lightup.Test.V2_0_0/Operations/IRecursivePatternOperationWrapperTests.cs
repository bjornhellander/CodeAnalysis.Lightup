// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_0_0.Operations;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Operations.Lightup.IRecursivePatternOperationWrapper;

[TestClass]
public class IRecursivePatternOperationWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        object? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenNullObject()
    {
        object? obj = null;
        Assert.ThrowsException<ArgumentNullException>(() => Wrapper.Wrap(obj!));
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = new object();
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenIncompatibleObject()
    {
        var obj = new object();
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Wrap(obj));
    }
}
