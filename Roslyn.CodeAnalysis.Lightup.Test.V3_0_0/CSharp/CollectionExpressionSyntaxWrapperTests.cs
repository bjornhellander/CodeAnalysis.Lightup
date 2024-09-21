namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CollectionExpressionSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        SyntaxNode? obj = null;
        Assert.IsFalse(CollectionExpressionSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = CollectionExpressionSyntaxWrapper.As(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public virtual void TestAddElementsGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = CollectionExpressionSyntaxWrapper.As(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.AddElements());
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.IsFalse(CollectionExpressionSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        var wrapper = CollectionExpressionSyntaxWrapper.As(obj);
        Assert.IsNull(wrapper.Unwrap());
    }
}
