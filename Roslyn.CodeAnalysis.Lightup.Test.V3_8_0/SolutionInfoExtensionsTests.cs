namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SolutionInfoExtensionsTests : V3_0_0.SolutionInfoExtensionsTests
{
    [TestMethod]
    public override void TestSignatureGivenNullObject()
    {
        _ = CallCreate();
    }
}
