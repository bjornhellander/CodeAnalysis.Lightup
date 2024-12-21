// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_4_0;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Wrapper = Microsoft.CodeAnalysis.Lightup.IImportScopeWrapper;

[TestClass]
public partial class IImportScopeWrapperTests
{
    [TestMethod]
    public override void TestImportsGivenNullObject()
    {
        object? obj = null;
        var wrapper = Wrapper.Wrap(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.Imports);
    }

    [TestMethod]
    public void TestImportsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        var imports = wrapper.Imports;
        Assert.AreEqual(1, imports.Length);
    }

    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        Assert.IsNotNull(wrapper.Unwrap());
    }

    private static IImportScope CreateInstance()
    {
        var mock = new Mock<IImportScope>();
        mock.Setup(x => x.Imports).Returns([default]);
        return mock.Object;
    }
}
