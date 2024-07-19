namespace Roslyn.CodeAnalysis.Lightup.Test.V4_4_0.CSharp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LightupStatusTests : V4_0_1.CSharp.LightupStatusTests
{
    [TestMethod]
    public override void TestCodeAnalysisVersion()
    {
        CheckCodeAnalysisVersion(4, 4, 0, 0);
    }

    [TestMethod]
    public override void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(true, true, true, false);
    }
}
