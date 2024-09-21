namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WellKnownDiagnosticTagsExtensionsTests
{
    [TestMethod]
    public virtual void TestCustomObsolete()
    {
        Assert.ThrowsException<InvalidOperationException>(() => WellKnownDiagnosticTagsExtensions.CustomObsolete);
    }
}
