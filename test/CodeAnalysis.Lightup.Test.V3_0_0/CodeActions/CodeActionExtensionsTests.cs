﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0.CodeActions;

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CodeActionExtensionsTests
{
    [TestMethod]
    [DataRow(CodeActionPriorityEx.Lowest)]
    [DataRow(CodeActionPriorityEx.Low)]
    [DataRow(CodeActionPriorityEx.Default)]
    public virtual void TestCreateWithPriorityGivenCompatibleObject(CodeActionPriorityEx priority)
    {
        Assert.ThrowsException<InvalidOperationException>(() => CodeActionExtensions.Create("title", CreateDocumentAsync, null, priority));
    }

    protected static Task<Document> CreateDocumentAsync(CancellationToken ct)
    {
        throw new InvalidOperationException();
    }
}
