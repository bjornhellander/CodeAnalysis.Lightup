namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class IAssemblySymbolExtensionsTests : V3_0_0.IAssemblySymbolExtensionsTests
{
    [TestMethod]
    public override void TestSignatureGivenNullObject()
    {
        var obj = CreateInstance();
        _ = obj.GetForwardedTypes();
    }
}
