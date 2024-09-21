namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FunctionPointerCallingConventionSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        SyntaxNode? obj = null;
        Assert.IsFalse(FunctionPointerCallingConventionSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = FunctionPointerCallingConventionSyntaxWrapper.As(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public virtual void TestUnmanagedCallingConventionListGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = FunctionPointerCallingConventionSyntaxWrapper.As(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.UnmanagedCallingConventionList);
    }

    [TestMethod]
    public virtual void TestWithUnmanagedCallingConventionListGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = FunctionPointerCallingConventionSyntaxWrapper.As(obj);
        var unmanagedCallingConventionListWrapper = FunctionPointerUnmanagedCallingConventionListSyntaxWrapper.As(null);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.WithUnmanagedCallingConventionList(unmanagedCallingConventionListWrapper));
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.IsFalse(FunctionPointerCallingConventionSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        var wrapper = FunctionPointerCallingConventionSyntaxWrapper.As(obj);
        Assert.IsNull(wrapper.Unwrap());
    }
}
