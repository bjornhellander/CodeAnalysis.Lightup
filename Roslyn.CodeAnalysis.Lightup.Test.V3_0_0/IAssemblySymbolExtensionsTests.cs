﻿namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class IAssemblySymbolExtensionsTests
{
    [TestMethod]
    public virtual void TestSignatureGivenNullObject()
    {
        var obj = CreateInstance();
        Assert.ThrowsException<InvalidOperationException>(() => obj.GetForwardedTypes());
    }

    protected static IAssemblySymbol CreateInstance()
    {
        var mock = new Mock<IAssemblySymbol>();
        return mock.Object;
    }
}