// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_4_0.Operations;

using Wrapper = Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper;

[TestClass]
public partial class IInterpolatedStringHandlerArgumentPlaceholderOperationWrapperTests
{
    [TestMethod]
    [DataRow(InterpolatedStringArgumentPlaceholderKind.CallsiteArgument)]
    [DataRow(InterpolatedStringArgumentPlaceholderKind.CallsiteReceiver)]
    [DataRow(InterpolatedStringArgumentPlaceholderKind.TrailingValidityArgument)]
    public void TestPlaceholderKindGivenCompatibleObject(InterpolatedStringArgumentPlaceholderKind kind)
    {
        var mock = new Mock<IInterpolatedStringHandlerArgumentPlaceholderOperation>();
        mock.Setup(x => x.PlaceholderKind).Returns(kind);
        var obj = mock.Object;

        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(kind, (InterpolatedStringArgumentPlaceholderKind)wrapper.PlaceholderKind);
    }

    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var mock = new Mock<IInterpolatedStringHandlerArgumentPlaceholderOperation>();
        var obj = mock.Object;

        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenCompatibleObject()
    {
        var mock = new Mock<IInterpolatedStringHandlerArgumentPlaceholderOperation>();
        var obj = mock.Object;

        var wrapper = Wrapper.Wrap(obj);
        Assert.AreSame(obj, wrapper.Unwrap());
    }
}
