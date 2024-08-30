namespace Roslyn.CodeAnalysis.Lightup.Test.V4_0_1;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SyntaxTokenExtensionsTests : V3_8_0.SyntaxTokenExtensionsTests
{
    [TestMethod]
    public override void TestIsIncrementallyIdenticalTo()
    {
        var obj = CreateInstance();
        _ = obj.IsIncrementallyIdenticalTo(default);
    }
}
