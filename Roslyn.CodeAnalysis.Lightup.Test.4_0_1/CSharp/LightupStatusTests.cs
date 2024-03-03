using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roslyn.CodeAnalysis.Lightup.Test.CSharp.V4_0_1
{
    [TestClass]
    public class LightupStatusTests : V3_8_0.LightupStatusTests
    {
        [TestMethod]
        public override void TestLanguageVersion()
        {
            CheckSupportedLanguageVersions(true, true, false, false);
        }
    }
}
