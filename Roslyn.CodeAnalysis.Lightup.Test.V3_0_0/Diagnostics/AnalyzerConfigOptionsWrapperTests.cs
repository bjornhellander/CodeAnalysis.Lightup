namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.Diagnostics;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Diagnostics.Lightup.AnalyzerConfigOptionsWrapper;

[TestClass]
public class AnalyzerConfigOptionsWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        SyntaxNode? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public virtual void TestKeyComparer()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.KeyComparer);
    }

    [TestMethod]
    public void TestTryGetValueGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.TryGetValue("key", out var value));
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
