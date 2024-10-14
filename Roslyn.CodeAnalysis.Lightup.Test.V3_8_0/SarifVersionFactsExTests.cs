// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SarifVersionFactsExTests : V3_0_0.SarifVersionFactsExTests
{
    [TestMethod]
    public override void TestTryParse()
    {
        var ok = SarifVersionFactsEx.TryParse("1", out var result);
        Assert.IsTrue(ok);
        Assert.AreEqual(SarifVersionEx.Sarif1, result);
    }
}
