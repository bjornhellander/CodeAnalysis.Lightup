using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roslyn.CodeAnalysis.Lightup.Test.CSharp.V3_8_0
{
    [TestClass]
    public class LightupStatusTests : CSharp.LightupStatusTests
    {
        [TestMethod]
        public override void TestLanguageVersion()
        {
            CheckSupportedLanguageVersions(true, false, false, false);
        }
    }
}
