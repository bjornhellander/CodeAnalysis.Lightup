﻿namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LineSpanDirectiveTriviaSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        SyntaxNode? obj = null;
        Assert.IsFalse(LineSpanDirectiveTriviaSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = LineSpanDirectiveTriviaSyntaxWrapper.As(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public void TestEndGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = LineSpanDirectiveTriviaSyntaxWrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.End);
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.IsFalse(LineSpanDirectiveTriviaSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        var wrapper = LineSpanDirectiveTriviaSyntaxWrapper.As(obj);
        Assert.IsNull(wrapper.Unwrap());
    }
}