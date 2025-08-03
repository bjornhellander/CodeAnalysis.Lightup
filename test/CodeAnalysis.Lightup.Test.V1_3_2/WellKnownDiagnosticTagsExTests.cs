// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

[TestClass]
public class WellKnownDiagnosticTagsExTests
{
    [TestMethod]
    public virtual void TestCustomObsolete()
    {
        Assert.ThrowsExactly<InvalidOperationException>(() => WellKnownDiagnosticTagsEx.CustomObsolete);
    }
}
