// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class BreakStatementSyntaxExtensionsTests
{
    [TestMethod]
    public virtual void TestAttributeLists()
    {
        var obj = CreateInstance();
        Assert.ThrowsException<InvalidOperationException>(() => obj.AttributeLists());
    }

    [TestMethod]
    public virtual void TestAddAttributeLists()
    {
        var obj = CreateInstance();
        Assert.ThrowsException<InvalidOperationException>(() => obj.AddAttributeLists([]));
    }

    private static BreakStatementSyntax CreateInstance()
    {
        return SyntaxFactory.BreakStatement();
    }
}
