﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_6_1.CSharp;

using System;
using CodeAnalysis.Lightup.Example.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LightupStatusTests
{
    [TestMethod]
    public virtual void TestCodeAnalysisVersion()
    {
        CheckCodeAnalysisVersion(2, 6, 0, 0);
    }

    [TestMethod]
    public virtual void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions();
    }

    protected static void CheckCodeAnalysisVersion(int major, int minor, int build, int revision)
    {
        var expectedVersion = new Version(major, minor, build, revision);
        Assert.AreEqual(expectedVersion, LightupStatus.CodeAnalysisVersion);
    }

    protected static void CheckSupportedLanguageVersions(
        bool csharp7_3 = false,
        bool csharp8 = false,
        bool csharp9 = false,
        bool csharp10 = false,
        bool csharp11 = false,
        bool csharp12 = false,
        bool csharp13 = false)
    {
        Assert.AreEqual(csharp7_3, LightupStatus.SupportsCSharp7_3);
        Assert.AreEqual(csharp8, LightupStatus.SupportsCSharp8);
        Assert.AreEqual(csharp9, LightupStatus.SupportsCSharp9);
        Assert.AreEqual(csharp10, LightupStatus.SupportsCSharp10);
        Assert.AreEqual(csharp11, LightupStatus.SupportsCSharp11);
        Assert.AreEqual(csharp12, LightupStatus.SupportsCSharp12);
        Assert.AreEqual(csharp13, LightupStatus.SupportsCSharp13);
    }
}