﻿namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0.CSharp;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class BreakStatementSyntaxExtensionsTests : V3_0_0.CSharp.BreakStatementSyntaxExtensionsTests
{
    [TestMethod]
    public override void TestAttributeLists()
    {
        var obj = CreateInstance();
        _ = obj.AttributeLists();
    }

    [TestMethod]
    public override void TestAddAttributeLists()
    {
        var obj = CreateInstance();
        _ = obj.AddAttributeLists([]);
    }

    private static BreakStatementSyntax CreateInstance()
    {
        return SyntaxFactory.BreakStatement();
    }
}