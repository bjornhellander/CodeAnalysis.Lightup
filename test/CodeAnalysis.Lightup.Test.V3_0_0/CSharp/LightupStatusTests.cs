﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

using System;
using CodeAnalysis.Lightup.Example.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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