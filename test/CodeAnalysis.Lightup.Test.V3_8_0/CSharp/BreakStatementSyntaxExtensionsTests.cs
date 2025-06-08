// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0.CSharp;

[TestClass]
public partial class BreakStatementSyntaxExtensionsTests
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
