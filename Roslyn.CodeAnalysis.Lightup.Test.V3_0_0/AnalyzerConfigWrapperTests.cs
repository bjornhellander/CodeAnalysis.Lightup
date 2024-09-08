namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper;

[TestClass]
public class AnalyzerConfigWrapperTests
{
    [TestMethod]
    public virtual void TestParse()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Parse("", "/a/b.txt"));
    }
}
