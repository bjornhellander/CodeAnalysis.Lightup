using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

[TestClass]
public class LightupStatusTests
{
    [TestMethod]
    public virtual void TestCodeAnalysisVersion()
    {
        CheckCodeAnalysisVersion(3, 0, 0, 0);
    }

    [TestMethod]
    public virtual void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(false, false, false, false);
    }

    protected static void CheckCodeAnalysisVersion(int major, int minor, int build, int revision)
    {
        var expectedVersion = new Version(major, minor, build, revision);
        Assert.AreEqual(expectedVersion, LightupStatus.CodeAnalysisVersion);
    }

    protected static void CheckSupportedLanguageVersions(bool csharp9, bool csharp10, bool csharp11, bool csharp12)
    {
        Assert.AreEqual(csharp9, LightupStatus.SupportsCSharp9);
        Assert.AreEqual(csharp10, LightupStatus.SupportsCSharp10);
        Assert.AreEqual(csharp11, LightupStatus.SupportsCSharp11);
        Assert.AreEqual(csharp12, LightupStatus.SupportsCSharp12);
    }
}
