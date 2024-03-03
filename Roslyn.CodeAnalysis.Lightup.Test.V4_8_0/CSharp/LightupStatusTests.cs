using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roslyn.CodeAnalysis.Lightup.Test.CSharp.V4_8_0;

[TestClass]
public class LightupStatusTests : V4_4_0.LightupStatusTests
{
    [TestMethod]
    public override void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(true, true, true, true);
    }
}
