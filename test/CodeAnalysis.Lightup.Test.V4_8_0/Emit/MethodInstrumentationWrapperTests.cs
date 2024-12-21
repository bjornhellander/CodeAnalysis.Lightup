// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_8_0.Emit;

using Microsoft.CodeAnalysis.Emit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Emit.Lightup.MethodInstrumentationWrapper;

[TestClass]
public partial class MethodInstrumentationWrapperTests
{
    [TestMethod]
    [DataRow(InstrumentationKind.None)]
    [DataRow(InstrumentationKind.TestCoverage)]
    public void TestKindsGivenCompatibleObject(InstrumentationKind kind)
    {
        var obj = CreateInstance(kind);
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(1, wrapper.Kinds.Length);
        Assert.AreEqual(kind, wrapper.Kinds[0]);
    }

    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        Assert.IsNotNull(wrapper.Unwrap());
    }

    private static MethodInstrumentation CreateInstance(InstrumentationKind kind = InstrumentationKind.TestCoverage)
    {
        var obj = new MethodInstrumentation
        {
            Kinds = [kind],
        };
        return obj;
    }
}
