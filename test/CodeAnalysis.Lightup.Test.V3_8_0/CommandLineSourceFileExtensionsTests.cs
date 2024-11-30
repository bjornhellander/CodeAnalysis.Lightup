// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public partial class CommandLineSourceFileExtensionsTests
{
    [TestMethod]
    public override void TestConstructor()
    {
        var obj = CallConstructor();
        Assert.AreEqual("a/b.c", obj.Path);
        Assert.AreEqual(false, obj.IsScript);
        Assert.AreEqual(true, obj.IsInputRedirected);
    }
}
