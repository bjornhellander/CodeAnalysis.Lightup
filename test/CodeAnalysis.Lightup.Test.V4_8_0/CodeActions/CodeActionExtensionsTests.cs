﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_8_0.CodeActions;

[TestClass]
public partial class CodeActionExtensionsTests
{
    // NOTE: Intentionally skipping High, because it can magically be changed to Default
    [TestMethod]
    [DataRow(CodeActionPriorityEx.Lowest)]
    [DataRow(CodeActionPriorityEx.Low)]
    [DataRow(CodeActionPriorityEx.Default)]
    public override void TestCreateWithPriorityGivenCompatibleObject(CodeActionPriorityEx priority)
    {
        var obj = CodeActionEx.Create("title", CreateDocumentAsync, null, priority);
        Assert.AreEqual((CodeActionPriority)priority, obj.Priority);
    }
}
