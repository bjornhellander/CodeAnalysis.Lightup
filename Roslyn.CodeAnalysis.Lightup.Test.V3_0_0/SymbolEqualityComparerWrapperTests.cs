namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.SymbolEqualityComparerWrapper;

[TestClass]
public class SymbolEqualityComparerWrapperTests
{
    [TestMethod]
    public virtual void TestDefault()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Default);
    }
}
