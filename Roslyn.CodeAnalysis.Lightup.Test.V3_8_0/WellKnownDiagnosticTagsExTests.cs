// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WellKnownDiagnosticTagsExTests : V3_0_0.WellKnownDiagnosticTagsExTests
{
    [TestMethod]
    public override void TestCustomObsolete()
    {
        _ = WellKnownDiagnosticTagsEx.CustomObsolete;
    }
}
