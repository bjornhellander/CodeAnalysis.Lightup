// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2.CSharp;

[TestClass]
public class LightupStatusTests
{
    [TestMethod]
    public virtual void TestCodeAnalysisVersion()
    {
        CheckCodeAnalysisVersion(1, 3, 1, 0);
    }

    [TestMethod]
    public virtual void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(6);
    }

    protected static void CheckCodeAnalysisVersion(int major, int minor, int build, int revision)
    {
        var expectedVersion = new Version(major, minor, build, revision);
        Assert.AreEqual(expectedVersion, LightupStatus.CodeAnalysisVersion);
    }

    protected static void CheckSupportedLanguageVersions(decimal version)
    {
        Assert.AreEqual(version >= 7, LightupStatus.SupportsCSharp7);
        Assert.AreEqual(version >= 7.1M, LightupStatus.SupportsCSharp7_1);
        Assert.AreEqual(version >= 7.2M, LightupStatus.SupportsCSharp7_2);
        Assert.AreEqual(version >= 7.3M, LightupStatus.SupportsCSharp7_3);
        Assert.AreEqual(version >= 8, LightupStatus.SupportsCSharp8);
        Assert.AreEqual(version >= 9, LightupStatus.SupportsCSharp9);
        Assert.AreEqual(version >= 10, LightupStatus.SupportsCSharp10);
        Assert.AreEqual(version >= 11, LightupStatus.SupportsCSharp11);
        Assert.AreEqual(version >= 12, LightupStatus.SupportsCSharp12);
        Assert.AreEqual(version >= 13, LightupStatus.SupportsCSharp13);
    }
}
