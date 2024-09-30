// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V4_4_0;

using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WorkspaceExtensionsTests : V4_0_1.WorkspaceExtensionsTests
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
