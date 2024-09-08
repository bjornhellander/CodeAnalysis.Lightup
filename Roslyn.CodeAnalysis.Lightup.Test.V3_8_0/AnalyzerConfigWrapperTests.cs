namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper;

[TestClass]
public class AnalyzerConfigWrapperTests : V3_0_0.AnalyzerConfigWrapperTests
{
    [TestMethod]
    public override void TestParse()
    {
        _ = Wrapper.Parse("", "/a/b.txt");
    }
}
