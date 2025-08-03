// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2.CSharp;

[TestClass]
public class BreakStatementSyntaxExtensionsTests
{
    [TestMethod]
    public virtual void TestAttributeLists()
    {
        var obj = CreateInstance();
        Assert.ThrowsExactly<InvalidOperationException>(() => obj.AttributeLists());
    }

    [TestMethod]
    public virtual void TestAddAttributeLists()
    {
        var obj = CreateInstance();
        Assert.ThrowsExactly<InvalidOperationException>(() => obj.AddAttributeLists([]));
    }

    private static BreakStatementSyntax CreateInstance()
    {
        return SyntaxFactory.BreakStatement();
    }
}
