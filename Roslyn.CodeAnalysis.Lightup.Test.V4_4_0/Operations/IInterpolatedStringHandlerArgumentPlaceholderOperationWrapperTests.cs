namespace Roslyn.CodeAnalysis.Lightup.Test.V4_4_0.Operations;

using Microsoft.CodeAnalysis.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Wrapper = Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper;

[TestClass]
public class IInterpolatedStringHandlerArgumentPlaceholderOperationWrapperTests : V4_0_1.Operations.IInterpolatedStringHandlerArgumentPlaceholderOperationWrapperTests
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

        var wrapper = Wrapper.As(obj);
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
    public void TestAsGivenCompatibleObject()
    {
        var mock = new Mock<IInterpolatedStringHandlerArgumentPlaceholderOperation>();
        var obj = mock.Object;

        var wrapper = Wrapper.As(obj);
        Assert.AreSame(obj, wrapper.Unwrap());
    }
}
