﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class IMethodSymbolExtensionsTests : V3_0_0.IMethodSymbolExtensionsTests
{
    [TestMethod]
    [DataRow(NullableAnnotationEx.None)]
    [DataRow(NullableAnnotationEx.NotAnnotated)]
    [DataRow(NullableAnnotationEx.Annotated)]
    public override void TestTypeArgumentNullableAnnotationsGivenCompatibleObject(NullableAnnotationEx nullableAnnotation)
    {
        var obj = CreateInstance(nullableAnnotation);
        var result = IMethodSymbolExtensions.TypeArgumentNullableAnnotations(obj);
        Assert.AreEqual(1, result.Length);
        Assert.AreEqual(nullableAnnotation, result[0]);
    }

    [TestMethod]
    [DataRow(NullableAnnotationEx.None)]
    [DataRow(NullableAnnotationEx.NotAnnotated)]
    [DataRow(NullableAnnotationEx.Annotated)]
    public override void TestConstructGivenCompatibleObject(NullableAnnotationEx nullableAnnotation)
    {
        var obj = CreateInstance(nullableAnnotation);
        var x = IMethodSymbolExtensions.Construct(obj, [], [nullableAnnotation]);
        Assert.IsNotNull(x);
    }

    private static IMethodSymbol CreateInstance(NullableAnnotationEx nullableAnnotation)
    {
        var returnMock = new Mock<IMethodSymbol>();

        var mock = new Mock<IMethodSymbol>(MockBehavior.Strict);
        mock.Setup(x => x.TypeArgumentNullableAnnotations).Returns([(NullableAnnotation)nullableAnnotation]);
        mock.Setup(x => x.Construct(It.IsAny<ImmutableArray<ITypeSymbol>>(), It.Is<ImmutableArray<NullableAnnotation>>(p => p.Length == 1 && p[0] == (NullableAnnotation)nullableAnnotation)))
            .Returns(returnMock.Object);
        return mock.Object;
    }
}