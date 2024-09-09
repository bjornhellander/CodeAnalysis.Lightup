namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WellKnownDiagnosticTagsExtensionsTests : V3_0_0.WellKnownDiagnosticTagsExtensionsTests
{
    [TestMethod]
    public override void TestCustomObsolete()
    {
        _ = WellKnownDiagnosticTagsExtensions.CustomObsolete;
    }
}
