﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0.Operations;

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
    public virtual void TestPlaceholderKindGivenNullObject()
    {
        IOperation? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.PlaceholderKind);
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
