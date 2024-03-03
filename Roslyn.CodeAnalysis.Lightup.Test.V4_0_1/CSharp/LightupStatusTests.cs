using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roslyn.CodeAnalysis.Lightup.Test.V4_0_1.CSharp;

[TestClass]
public class LightupStatusTests : V3_8_0.CSharp.LightupStatusTests
{
    [TestMethod]
    public override void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(true, true, false, false);
    }
}
