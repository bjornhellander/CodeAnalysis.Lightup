// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerCallingConventionSyntaxWrapper;

[TestClass]
public class FunctionPointerCallingConventionSyntaxWrapperTests
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
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public virtual void TestUnmanagedCallingConventionListGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = Wrapper.Wrap(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.UnmanagedCallingConventionList);
    }

    [TestMethod]
    public virtual void TestWithUnmanagedCallingConventionListGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = Wrapper.Wrap(obj);
        var unmanagedCallingConventionListWrapper = FunctionPointerUnmanagedCallingConventionListSyntaxWrapper.Wrap(null);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.WithUnmanagedCallingConventionList(unmanagedCallingConventionListWrapper));
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
