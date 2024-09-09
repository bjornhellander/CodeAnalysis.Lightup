namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SolutionInfoExtensionsTests
{
    [TestMethod]
    public virtual void TestSignatureGivenNullObject()
    {
        Assert.ThrowsException<InvalidOperationException>(() => CallCreate());
    }

    protected static SolutionInfo CallCreate()
    {
        return SolutionInfoExtensions.Create(
            SolutionId.CreateNewId(),
            default,
            default,
            [],
            []);
    }
}
