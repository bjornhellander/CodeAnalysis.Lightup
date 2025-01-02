// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_6_1;

using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.IImportScopeWrapper;

[TestClass]
public class IImportScopeWrapperTests
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
        var obj = SyntaxFactory.ParameterList();
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Wrap(obj));
    }
}
