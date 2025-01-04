// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_3_2;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Wrapper = Microsoft.CodeAnalysis.Lightup.IFunctionPointerTypeSymbolWrapper;

[TestClass]
public class IFunctionPointerTypeSymbolWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        ITypeSymbol? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenNullObject()
    {
        ITypeSymbol? obj = null;
        Assert.ThrowsException<ArgumentNullException>(() => Wrapper.Wrap(obj!));
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = Mock.Of<ITypeSymbol>();
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenIncompatibleObject()
    {
        var obj = Mock.Of<ITypeSymbol>();
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Wrap(obj));
    }
}
