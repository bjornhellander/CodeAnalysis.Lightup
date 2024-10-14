// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ProjectExtensionsTests
{
    [TestMethod]
    public virtual void TestAnalyzerConfigDocuments()
    {
        using var workspace = new AdhocWorkspace();
        var project = workspace.AddProject("Project1", LanguageNames.CSharp);
        Assert.ThrowsException<InvalidOperationException>(() => project.AnalyzerConfigDocuments());
    }
}
