// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_0_0;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CommandLineSourceFileExtensionsTests
{
    [TestMethod]
    public virtual void TestConstructor()
    {
        Assert.ThrowsException<InvalidOperationException>(() => CallConstructor());
    }

    protected static CommandLineSourceFile CallConstructor()
    {
        return CommandLineSourceFileEx.Create(
            "a/b.c",
            false,
            true);
    }
}
