// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.IFunctionPointerTypeSymbolWrapper;

[TestClass]
public class IFunctionPointerTypeSymbolWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        ITypeSymbol? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenNullObject()
    {
        ITypeSymbol? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public virtual void TestSignatureGivenNullObject()
    {
        ITypeSymbol? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.Signature);
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
