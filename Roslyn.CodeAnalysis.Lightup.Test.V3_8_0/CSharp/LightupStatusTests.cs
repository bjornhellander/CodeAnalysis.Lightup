using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0.CSharp;

[TestClass]
public class LightupStatusTests : V3_0_0.CSharp.LightupStatusTests
{
    [TestMethod]
    public override void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(true, false, false, false);
    }
}
