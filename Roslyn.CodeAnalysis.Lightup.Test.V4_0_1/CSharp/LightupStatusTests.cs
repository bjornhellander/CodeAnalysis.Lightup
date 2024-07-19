namespace Roslyn.CodeAnalysis.Lightup.Test.V4_0_1.CSharp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LightupStatusTests : V3_8_0.CSharp.LightupStatusTests
{
    [TestMethod]
    public override void TestCodeAnalysisVersion()
    {
        CheckCodeAnalysisVersion(4, 0, 0, 0);
    }

    [TestMethod]
    public override void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(true, true, false, false);
    }
}
