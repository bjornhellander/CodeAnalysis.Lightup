// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_4_0;

[TestClass]
public partial class WorkspaceExtensionsTests
{
    [TestMethod]
    public override void TestAddTextDocumentClosedGivenCompatibleObject()
    {
        using var obj = CreateInstance();
        obj.AddTextDocumentClosed(HandleTextDocumentClosed);
    }

    [TestMethod]
    public override void TestRemoveTextDocumentClosedGivenCompatibleObject()
    {
        using var obj = CreateInstance();
        obj.RemoveTextDocumentClosed(HandleTextDocumentClosed);
    }
}
