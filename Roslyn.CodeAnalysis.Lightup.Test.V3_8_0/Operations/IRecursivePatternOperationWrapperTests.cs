﻿namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0.Operations;

using Microsoft.CodeAnalysis.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Wrapper = Microsoft.CodeAnalysis.Operations.Lightup.IRecursivePatternOperationWrapper;

[TestClass]
public class IRecursivePatternOperationWrapperTests : V3_0_0.Operations.IRecursivePatternOperationWrapperTests
{
    [TestMethod]
    public void TestPropertySubpatternsGivenCompatibleObject()
    {
        var mock = new Mock<IRecursivePatternOperation>();
        var propertySubpatternOperationMock = new Mock<IPropertySubpatternOperation>();
        mock.Setup(x => x.PropertySubpatterns).Returns([propertySubpatternOperationMock.Object]);
        var obj = mock.Object;

        var wrapper = Wrapper.As(obj);
        var propertySubpatterns = wrapper.PropertySubpatterns;
    }

    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var mock = new Mock<IRecursivePatternOperation>();
        var obj = mock.Object;

        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenCompatibleObject()
    {
        var mock = new Mock<IRecursivePatternOperation>();
        var obj = mock.Object;

        var wrapper = Wrapper.As(obj);
        Assert.IsNotNull(wrapper.Unwrap());
    }
}