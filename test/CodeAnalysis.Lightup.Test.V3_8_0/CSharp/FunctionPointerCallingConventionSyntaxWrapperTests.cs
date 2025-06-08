// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0.CSharp;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerCallingConventionSyntaxWrapper;

[TestClass]
public partial class FunctionPointerCallingConventionSyntaxWrapperTests
{
    [TestMethod]
    public void TestWrapGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        Assert.IsNotNull(wrapper.Unwrap());
    }

    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestUnmanagedCallingConventionListGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        Assert.IsNotNull(wrapper.Unwrap());
        Assert.IsNull(wrapper.UnmanagedCallingConventionList);
    }

    [TestMethod]
    public void TestWithUnmanagedCallingConventionListGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        Assert.IsNull(wrapper.UnmanagedCallingConventionList);
        var nativeUnmanagedCallingConventionListWrapper = SyntaxFactory.FunctionPointerUnmanagedCallingConventionList();
        var unmanagedCallingConventionListWrapper = FunctionPointerUnmanagedCallingConventionListSyntaxWrapper.Wrap(nativeUnmanagedCallingConventionListWrapper);
        Assert.IsNotNull(wrapper.Unwrap());

        wrapper = wrapper.WithUnmanagedCallingConventionList(unmanagedCallingConventionListWrapper);
        Assert.IsNotNull(wrapper.UnmanagedCallingConventionList);
        Assert.IsNotNull(wrapper.UnmanagedCallingConventionList.Value.Unwrap());
    }

    private static FunctionPointerCallingConventionSyntax CreateInstance()
    {
        var obj = SyntaxFactory.FunctionPointerCallingConvention(
            SyntaxFactory.Token(SyntaxKind.ManagedKeyword));
        return obj;
    }
}
