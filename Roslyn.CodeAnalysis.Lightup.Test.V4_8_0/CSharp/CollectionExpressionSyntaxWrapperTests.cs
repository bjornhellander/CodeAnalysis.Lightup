namespace Roslyn.CodeAnalysis.Lightup.Test.V4_8_0.CSharp;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CollectionExpressionSyntaxWrapperTests : V4_4_0.CSharp.CollectionExpressionSyntaxWrapperTests
{
    [TestMethod]
    public void TestAddElementsGivenCompatibleObject()
    {
        var obj = SyntaxFactory.CollectionExpression();
        var wrapper = CollectionExpressionSyntaxWrapper.As(obj);
        Assert.AreEqual(0, obj.Elements.Count);

        var newItem = SyntaxFactory.ExpressionElement(
            SyntaxFactory.LiteralExpression(
                SyntaxKind.NumericLiteralExpression,
                SyntaxFactory.Literal(13)));
        var newWrappedItem = CollectionElementSyntaxWrapper.As(newItem);
        Assert.IsNotNull(newWrappedItem.Unwrap());
        wrapper = wrapper.AddElements([newWrappedItem]);
        obj = (CollectionExpressionSyntax?)wrapper.Unwrap();
        Assert.IsNotNull(obj);
        Assert.AreEqual(1, obj.Elements.Count);
    }
}
