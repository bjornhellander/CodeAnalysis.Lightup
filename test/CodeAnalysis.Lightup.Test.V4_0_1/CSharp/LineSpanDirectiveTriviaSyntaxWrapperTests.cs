// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_0_1.CSharp;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineSpanDirectiveTriviaSyntaxWrapper;

// NOTE: The main reason for adding these tests is that this wrapper refers to other newly created syntax nodes,
// thereby requiring that the wrapper's properties etc are defined using another wrapper.
[TestClass]
public partial class LineSpanDirectiveTriviaSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenCompatibleObject()
    {
        var obj = CreateInstance();
        _ = Wrapper.Wrap(obj);
    }

    [TestMethod]
    public void TestStartGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        var startWrapper = wrapper.Start;
        Assert.AreSame(obj.Start, startWrapper.Unwrap());
    }

    [TestMethod]
    public void TestWithStartGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);

        var newValue = SyntaxFactory.LineDirectivePosition(
            line: SyntaxFactory.Literal(123),
            character: SyntaxFactory.Literal(456));
        var wrapper2 = wrapper.WithStart(LineDirectivePositionSyntaxWrapper.Wrap(newValue));
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
