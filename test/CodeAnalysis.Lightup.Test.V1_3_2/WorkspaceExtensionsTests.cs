// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

[TestClass]
public class WorkspaceExtensionsTests
{
    [TestMethod]
    public virtual void TestAddTextDocumentClosedGivenCompatibleObject()
    {
        using var obj = CreateInstance();
        Assert.ThrowsExactly<InvalidOperationException>(() => obj.AddTextDocumentClosed(HandleTextDocumentClosed));
    }

    [TestMethod]
    public virtual void TestRemoveTextDocumentClosedGivenCompatibleObject()
    {
        using var obj = CreateInstance();
        Assert.ThrowsExactly<InvalidOperationException>(() => obj.RemoveTextDocumentClosed(HandleTextDocumentClosed));
    }

    protected static Workspace CreateInstance()
    {
        return new AdhocWorkspace();
    }

    protected static void HandleTextDocumentClosed(object? sender, TextDocumentEventArgsWrapper e)
    {
    }
}
