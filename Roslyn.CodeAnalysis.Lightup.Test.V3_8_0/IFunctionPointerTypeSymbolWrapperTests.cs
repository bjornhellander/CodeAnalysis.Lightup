namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Wrapper = Microsoft.CodeAnalysis.Lightup.IFunctionPointerTypeSymbolWrapper;

[TestClass]
public class IFunctionPointerTypeSymbolWrapperTests : V3_0_0.IFunctionPointerTypeSymbolWrapperTests
{
    [TestMethod]
    public void TestSignatureGivenCompatibleObject()
    {
        var signatureObj = Mock.Of<IMethodSymbol>();
        var mock = new Mock<IFunctionPointerTypeSymbol>();
        mock.Setup(x => x.Signature).Returns(signatureObj);
        var obj = mock.Object;

        var wrapper = Wrapper.As(obj);
        Assert.AreSame(signatureObj, wrapper.Signature);
    }

    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var mock = new Mock<IFunctionPointerTypeSymbol>();
        var obj = mock.Object;

        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenCompatibleObject()
    {
        var mock = new Mock<IFunctionPointerTypeSymbol>();
        var obj = mock.Object;

        var wrapper = Wrapper.As(obj);
        Assert.AreSame(obj, wrapper.Unwrap());
    }
}
