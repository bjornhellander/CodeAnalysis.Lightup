// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_6_1.Operations;

using System;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Wrapper = Microsoft.CodeAnalysis.Operations.Lightup.IRecursivePatternOperationWrapper;

[TestClass]
public class IRecursivePatternOperationWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        IPatternOperation? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenNullObject()
    {
        IPatternOperation? obj = null;
        Assert.ThrowsException<ArgumentNullException>(() => Wrapper.Wrap(obj!));
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = Mock.Of<IPatternOperation>();
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenIncompatibleObject()
    {
        var obj = Mock.Of<IPatternOperation>();
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Wrap(obj));
    }
}
