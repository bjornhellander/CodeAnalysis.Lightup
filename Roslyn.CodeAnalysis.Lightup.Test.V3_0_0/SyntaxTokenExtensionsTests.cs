namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SyntaxTokenExtensionsTests
{
    [TestMethod]
    public virtual void TestIsIncrementallyIdenticalTo()
    {
        var obj = CreateInstance();
        Assert.ThrowsException<InvalidOperationException>(() => obj.IsIncrementallyIdenticalTo(default));
    }

    protected static SyntaxToken CreateInstance()
    {
        return default;
    }
}
