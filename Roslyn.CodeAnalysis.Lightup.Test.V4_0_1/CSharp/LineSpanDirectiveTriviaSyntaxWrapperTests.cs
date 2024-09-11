namespace Roslyn.CodeAnalysis.Lightup.Test.V4_0_1.CSharp;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// NOTE: The main reason for adding these tests is that this wrapper refers to other newly created syntax nodes,
// thereby requiring that the wrapper's properties etc are defined using another wrapper.
[TestClass]
public class LineSpanDirectiveTriviaSyntaxWrapperTests : V3_8_0.CSharp.LineSpanDirectiveTriviaSyntaxWrapperTests
{
    [TestMethod]
    public override void TestEndGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = LineSpanDirectiveTriviaSyntaxWrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.End);
    }

    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        Assert.IsTrue(LineSpanDirectiveTriviaSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenCompatibleObject()
    {
        var obj = CreateInstance();
        _ = LineSpanDirectiveTriviaSyntaxWrapper.As(obj);
    }

    [TestMethod]
    public void TestStartGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = LineSpanDirectiveTriviaSyntaxWrapper.As(obj);
        var startWrapper = wrapper.Start;
        Assert.AreSame(obj.Start, startWrapper.Unwrap());
    }

    [TestMethod]
    public void TestWithStartGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = LineSpanDirectiveTriviaSyntaxWrapper.As(obj);

        var newValue = SyntaxFactory.LineDirectivePosition(
            line: SyntaxFactory.Literal(123),
            character: SyntaxFactory.Literal(456));
        var wrapper2 = wrapper.WithStart(LineDirectivePositionSyntaxWrapper.As(newValue));
        Assert.AreEqual("123", wrapper2.Start.Line.Text);
    }

    private static LineSpanDirectiveTriviaSyntax CreateInstance()
    {
        return SyntaxFactory.LineSpanDirectiveTrivia(
            start: SyntaxFactory.LineDirectivePosition(
                line: SyntaxFactory.Token(SyntaxKind.NumericLiteralToken),
                character: SyntaxFactory.Token(SyntaxKind.NumericLiteralToken)),
            end: SyntaxFactory.LineDirectivePosition(
                line: SyntaxFactory.Token(SyntaxKind.NumericLiteralToken),
                character: SyntaxFactory.Token(SyntaxKind.NumericLiteralToken)),
            file: SyntaxFactory.Token(SyntaxKind.StringLiteralToken),
            isActive: true);
    }
}
