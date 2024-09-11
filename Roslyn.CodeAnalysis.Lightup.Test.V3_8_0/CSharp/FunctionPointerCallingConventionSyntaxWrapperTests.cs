namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0.CSharp;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FunctionPointerCallingConventionSyntaxWrapperTests : V3_0_0.CSharp.FunctionPointerCallingConventionSyntaxWrapperTests
{
    [TestMethod]
    public override void TestUnmanagedCallingConventionListGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = FunctionPointerCallingConventionSyntaxWrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.UnmanagedCallingConventionList);
    }

    [TestMethod]
    public override void TestWithUnmanagedCallingConventionListGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = FunctionPointerCallingConventionSyntaxWrapper.As(obj);
        var unmanagedCallingConventionListWrapper = FunctionPointerUnmanagedCallingConventionListSyntaxWrapper.As(null);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.WithUnmanagedCallingConventionList(unmanagedCallingConventionListWrapper));
    }

    [TestMethod]
    public void TestAsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = FunctionPointerCallingConventionSyntaxWrapper.As(obj);
        Assert.IsNotNull(wrapper.Unwrap());
    }

    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        Assert.IsTrue(FunctionPointerCallingConventionSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestUnmanagedCallingConventionListGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = FunctionPointerCallingConventionSyntaxWrapper.As(obj);
        Assert.IsNotNull(wrapper.Unwrap());
        Assert.IsNull(wrapper.UnmanagedCallingConventionList.Unwrap());
    }

    [TestMethod]
    public void TestWithUnmanagedCallingConventionListGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = FunctionPointerCallingConventionSyntaxWrapper.As(obj);
        Assert.IsNull(wrapper.UnmanagedCallingConventionList.Unwrap());
        var nativeUnmanagedCallingConventionListWrapper = SyntaxFactory.FunctionPointerUnmanagedCallingConventionList();
        var unmanagedCallingConventionListWrapper = FunctionPointerUnmanagedCallingConventionListSyntaxWrapper.As(nativeUnmanagedCallingConventionListWrapper);
        Assert.IsNotNull(wrapper.Unwrap());
        wrapper = wrapper.WithUnmanagedCallingConventionList(unmanagedCallingConventionListWrapper);
        Assert.IsNotNull(wrapper.UnmanagedCallingConventionList.Unwrap());
    }

    private static FunctionPointerCallingConventionSyntax CreateInstance()
    {
        var obj = SyntaxFactory.FunctionPointerCallingConvention(
            SyntaxFactory.Token(SyntaxKind.ManagedKeyword));
        return obj;
    }
}
