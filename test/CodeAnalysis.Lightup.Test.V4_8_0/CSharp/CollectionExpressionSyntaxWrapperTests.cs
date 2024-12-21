// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_8_0.CSharp;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.CollectionExpressionSyntaxWrapper;

[TestClass]
public partial class CollectionExpressionSyntaxWrapperTests
{
    [TestMethod]
    public void TestAddElementsGivenCompatibleObject()
    {
        var obj = SyntaxFactory.CollectionExpression();
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, obj.Elements.Count);

        var newItem = SyntaxFactory.ExpressionElement(
            SyntaxFactory.LiteralExpression(
                SyntaxKind.NumericLiteralExpression,
                SyntaxFactory.Literal(13)));
        var newWrappedItem = CollectionElementSyntaxWrapper.Wrap(newItem);
        Assert.IsNotNull(newWrappedItem.Unwrap());
        wrapper = wrapper.AddElements(newWrappedItem);
        obj = (CollectionExpressionSyntax?)wrapper.Unwrap();
        Assert.IsNotNull(obj);
        Assert.AreEqual(1, obj.Elements.Count);
    }
}
