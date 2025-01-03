// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_3_2.CSharp;

using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineSpanDirectiveTriviaSyntaxWrapper;

[TestClass]
public class LineSpanDirectiveTriviaSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        DirectiveTriviaSyntax? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenNullObject()
    {
        DirectiveTriviaSyntax? obj = null;
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

    private static DefineDirectiveTriviaSyntax CreateIncompatibleInstance()
    {
        return SyntaxFactory.DefineDirectiveTrivia(
                    SyntaxFactory.Token(SyntaxKind.HashToken),
                    SyntaxFactory.Token(SyntaxKind.DefineKeyword),
                    SyntaxFactory.Token(SyntaxKind.IdentifierToken),
                    SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken),
                    true);
    }
}
