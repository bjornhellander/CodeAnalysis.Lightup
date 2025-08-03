// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2.CodeActions;

[TestClass]
public class CodeActionExtensionsTests
{
    [TestMethod]
    [DataRow(CodeActionPriorityEx.Lowest)]
    [DataRow(CodeActionPriorityEx.Low)]
    [DataRow(CodeActionPriorityEx.Default)]
    public virtual void TestCreateWithPriorityGivenCompatibleObject(CodeActionPriorityEx priority)
    {
        Assert.ThrowsExactly<InvalidOperationException>(() => CodeActionEx.Create("title", CreateDocumentAsync, null, priority));
    }

    protected static Task<Document> CreateDocumentAsync(CancellationToken ct)
    {
        throw new InvalidOperationException();
    }
}
