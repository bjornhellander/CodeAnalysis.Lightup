namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0.CSharp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LightupStatusTests : V3_0_0.CSharp.LightupStatusTests
{
    [TestMethod]
    public override void TestCodeAnalysisVersion()
    {
        CheckCodeAnalysisVersion(3, 8, 0, 0);
    }

    [TestMethod]
    public override void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(true, false, false, false);
    }
}
