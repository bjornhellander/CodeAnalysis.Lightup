using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roslyn.CodeAnalysis.Lightup.Test.V4_4_0.CSharp;

[TestClass]
public class LightupStatusTests : V4_0_1.CSharp.LightupStatusTests
{
    [TestMethod]
    public override void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(true, true, true, false);
    }
}
