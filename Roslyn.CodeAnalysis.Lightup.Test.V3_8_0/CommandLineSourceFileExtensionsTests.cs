// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CommandLineSourceFileExtensionsTests : V3_0_0.CommandLineSourceFileExtensionsTests
{
    [TestMethod]
    public override void TestSignatureGivenNullObject()
    {
        var obj = CallConstructor();
        Assert.AreEqual("a/b.c", obj.Path);
        Assert.AreEqual(false, obj.IsScript);
        Assert.AreEqual(true, obj.IsInputRedirected);
    }
}
