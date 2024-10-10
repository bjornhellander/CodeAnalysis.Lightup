// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V4_4_0;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FixAllContextExtensionsTests : V4_0_1.FixAllContextExtensionsTests
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
