namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.SymbolEqualityComparerWrapper;

[TestClass]
public class SymbolEqualityComparerWrapperTests : V3_0_0.SymbolEqualityComparerWrapperTests
{
    [TestMethod]
    public override void TestDefault()
    {
        _ = Wrapper.Default;
    }
}
