// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class IAssemblySymbolExtensionsTests
{
    [TestMethod]
    public virtual void TestGetForwardedTypesGivenCompatibleObject()
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
