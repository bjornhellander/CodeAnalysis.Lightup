﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_8_0.CSharp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public partial class LightupStatusTests
{
    [TestMethod]
    public override void TestCodeAnalysisVersion()
    {
        CheckCodeAnalysisVersion(4, 8, 0, 0);
    }

    [TestMethod]
    public override void TestLanguageVersion()
    {
        CheckSupportedLanguageVersions(true, true, true, true);
    }
}