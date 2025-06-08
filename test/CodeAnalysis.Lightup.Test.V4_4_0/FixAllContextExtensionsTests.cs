// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_4_0;

[TestClass]
public partial class FixAllContextExtensionsTests
{
    [TestMethod]
    public override void TestConstructor()
    {
        var (workspace, obj) = CallConstructor();

        try
        {
            Assert.AreEqual("EquivalenceKey", obj.CodeActionEquivalenceKey);
        }
        catch (Exception)
        {
            workspace.Dispose();
            throw;
        }
    }
}
