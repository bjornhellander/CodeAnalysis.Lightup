// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0.Diagnostics;

using Wrapper = Microsoft.CodeAnalysis.Diagnostics.Lightup.AnalyzerConfigOptionsWrapper;

[TestClass]
public partial class AnalyzerConfigOptionsWrapperTests
{
    [TestMethod]
    public override void TestKeyComparer()
    {
        _ = Wrapper.KeyComparer;
    }

    [TestMethod]
    [DataRow("existing key", true, "a value")]
    [DataRow("non-existing key", false, null)]
    public void TestTryGetValueGivenCompatibleObject(string key, bool expectedResult, string? expectedValue)
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);

        var result = wrapper.TryGetValue(key, out var value);
        Assert.AreEqual(expectedResult, result);
        Assert.AreEqual(expectedValue, value);
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

    private static AnalyzerConfigOptions CreateInstance()
    {
        var mock = new Mock<AnalyzerConfigOptions>();

        string? value1 = null;
        mock.Setup(x => x.TryGetValue(It.IsAny<string>(), out value1)).Returns(false);

        var value2 = "a value";
        mock.Setup(x => x.TryGetValue("existing key", out value2)).Returns(true);

        return mock.Object;
    }
}
