// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0;

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
    public void TestAsGivenNullObject()
    {
        object? obj = null;
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public virtual void TestImportsGivenNullObject()
    {
        object? obj = null;
        var wrapper = Wrapper.Wrap(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.Imports);
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
