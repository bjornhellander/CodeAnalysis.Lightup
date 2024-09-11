namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.Operations;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Operations.Lightup.IFunctionPointerInvocationOperationWrapper;

[TestClass]
public class OperationExtensionsExtensionsTests
{
    [TestMethod]
    public virtual void TestGetFunctionPointerSignatureGivenNullObject()
    {
        IOperation? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.GetFunctionPointerSignature());
    }
}
