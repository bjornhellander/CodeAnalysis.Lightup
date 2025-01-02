// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_8_2.CSharp;

using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.CollectionExpressionSyntaxWrapper;

[TestClass]
public class CollectionExpressionSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        ExpressionSyntax? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenNullObject()
    {
        ExpressionSyntax? obj = null;
        Assert.ThrowsException<ArgumentNullException>(() => Wrapper.Wrap(obj!));
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = CreateIncompatibleInstance();
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenIncompatibleObject()
    {
        var obj = CreateIncompatibleInstance();
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Wrap(obj));
    }

    private static LiteralExpressionSyntax CreateIncompatibleInstance()
    {
        return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression);
    }
}
