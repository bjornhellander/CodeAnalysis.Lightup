// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class IMethodSymbolExtensionsTests
{
    [TestMethod]
    [DataRow(NullableAnnotationEx.None)]
    [DataRow(NullableAnnotationEx.NotAnnotated)]
    [DataRow(NullableAnnotationEx.Annotated)]
    public virtual void TestTypeArgumentNullableAnnotationsGivenCompatibleObject(NullableAnnotationEx nullableAnnotation)
    {
        var obj = CreateInstance();
        Assert.ThrowsException<InvalidOperationException>(() => obj.TypeArgumentNullableAnnotations());
    }

    [TestMethod]
    [DataRow(NullableAnnotationEx.None)]
    [DataRow(NullableAnnotationEx.NotAnnotated)]
    [DataRow(NullableAnnotationEx.Annotated)]
    public virtual void TestConstructGivenCompatibleObject(NullableAnnotationEx nullableAnnotation)
    {
        var obj = CreateInstance();
        Assert.ThrowsException<InvalidOperationException>(() => obj.Construct([], [nullableAnnotation]));
    }

    private static IMethodSymbol CreateInstance()
    {
        var mock = new Mock<IMethodSymbol>();
        return mock.Object;
    }
}
