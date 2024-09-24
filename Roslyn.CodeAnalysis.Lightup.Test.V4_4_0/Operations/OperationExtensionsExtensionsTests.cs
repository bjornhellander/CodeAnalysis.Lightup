// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V4_4_0.Operations;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Operations.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Wrapper = Microsoft.CodeAnalysis.Operations.Lightup.IFunctionPointerInvocationOperationWrapper;

[TestClass]
public class OperationExtensionsExtensionsTests : V4_0_1.Operations.OperationExtensionsExtensionsTests
{
    [TestMethod]
    public override void TestGetFunctionPointerSignatureGivenNullObject()
    {
        IFunctionPointerInvocationOperation? obj = null;
        var wrapper = Wrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.GetFunctionPointerSignature());
        Assert.ThrowsException<NullReferenceException>(() => obj!.GetFunctionPointerSignature());
    }

    [TestMethod]
    public void TestGetFunctionPointerSignatureGivenCompatibleObject()
    {
        IOperation obj = CreateFunctionPointerInvocationOperation();
        var wrapper = Wrapper.As(obj);
        _ = wrapper.GetFunctionPointerSignature();
    }

    private static IFunctionPointerInvocationOperation CreateFunctionPointerInvocationOperation()
    {
        // NOTE: GetFunctionPointerSignature returns ((IFunctionPointerTypeSymbol)functionPointer.Target.Type).Signature
        var methodMock = new Mock<IMethodSymbol>();

        var typeMock = new Mock<IFunctionPointerTypeSymbol>();
        typeMock.Setup(x => x.Signature).Returns(methodMock.Object);

        var targetMock = new Mock<IOperation>();
        targetMock.Setup(x => x.Type).Returns(typeMock.Object);

        var mock = new Mock<IFunctionPointerInvocationOperation>();
        mock.Setup(x => x.Target).Returns(targetMock.Object);

        return mock.Object;
    }
}
