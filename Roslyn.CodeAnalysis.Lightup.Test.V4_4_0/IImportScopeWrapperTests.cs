﻿namespace Roslyn.CodeAnalysis.Lightup.Test.V4_4_0;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Wrapper = Microsoft.CodeAnalysis.Lightup.IImportScopeWrapper;

[TestClass]
public class IImportScopeWrapperTests : V4_0_1.IImportScopeWrapperTests
{
    [TestMethod]
    public void TestImportsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.As(obj);
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
    public void TestAsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.As(obj);
        Assert.IsNotNull(wrapper.Unwrap());
    }

    private static IImportScope CreateInstance()
    {
        var mock = new Mock<IImportScope>();
        mock.Setup(x => x.Imports).Returns([default]);
        return mock.Object;
    }
}