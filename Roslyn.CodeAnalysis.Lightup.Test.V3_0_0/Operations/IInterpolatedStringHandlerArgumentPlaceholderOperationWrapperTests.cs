namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.Operations;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper;

[TestClass]
public class IInterpolatedStringHandlerArgumentPlaceholderOperationWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        IOperation? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenNullObject()
    {
        IOperation? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public void TestPlaceholderKindGivenNullObject()
    {
        IOperation? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.PlaceholderKind);
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
        var wrapper = Wrapper.As(obj);
        Assert.IsNull(wrapper.Unwrap());
    }
}
