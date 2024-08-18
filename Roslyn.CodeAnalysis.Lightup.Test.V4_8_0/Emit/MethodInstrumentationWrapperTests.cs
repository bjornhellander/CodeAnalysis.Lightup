namespace Roslyn.CodeAnalysis.Lightup.Test.V4_8_0.Emit;

using Microsoft.CodeAnalysis.Emit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Emit.Lightup.MethodInstrumentationWrapper;

[TestClass]
public class MethodInstrumentationWrapperTests : V4_4_0.Emit.MethodInstrumentationWrapperTests
{
    [TestMethod]
    [DataRow(InstrumentationKind.None)]
    [DataRow(InstrumentationKind.TestCoverage)]
    public void TestKindsGivenCompatibleObject(InstrumentationKind kind)
    {
        var obj = CreateInstance(kind);
        var wrapper = Wrapper.As(obj);
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
    public void TestAsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.As(obj);
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
