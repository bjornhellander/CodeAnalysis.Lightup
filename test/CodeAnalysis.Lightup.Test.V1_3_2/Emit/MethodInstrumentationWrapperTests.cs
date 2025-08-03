// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2.Emit;

using Wrapper = Microsoft.CodeAnalysis.Emit.Lightup.MethodInstrumentationWrapper;

[TestClass]
public class MethodInstrumentationWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        ITypeSymbol? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenNullObject()
    {
        ITypeSymbol? obj = null;
        Assert.ThrowsExactly<ArgumentNullException>(() => Wrapper.Wrap(obj!));
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.ThrowsExactly<InvalidOperationException>(() => Wrapper.Wrap(obj));
    }
}
