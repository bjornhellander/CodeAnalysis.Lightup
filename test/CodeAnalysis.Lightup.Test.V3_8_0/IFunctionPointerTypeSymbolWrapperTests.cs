// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0;

using Wrapper = Microsoft.CodeAnalysis.Lightup.IFunctionPointerTypeSymbolWrapper;

[TestClass]
public partial class IFunctionPointerTypeSymbolWrapperTests
{
    [TestMethod]
    public void TestSignatureGivenCompatibleObject()
    {
        var signatureObj = Mock.Of<IMethodSymbol>();
        var mock = new Mock<IFunctionPointerTypeSymbol>();
        mock.Setup(x => x.Signature).Returns(signatureObj);
        var obj = mock.Object;

        var wrapper = Wrapper.Wrap(obj);
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
    public void TestWrapGivenCompatibleObject()
    {
        var mock = new Mock<IFunctionPointerTypeSymbol>();
        var obj = mock.Object;

        var wrapper = Wrapper.Wrap(obj);
        Assert.AreSame(obj, wrapper.Unwrap());
    }
}
