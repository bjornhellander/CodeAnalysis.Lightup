// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

using System;
using System.Threading.Tasks;
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

    [TestMethod]
    public virtual async Task GetSourceGeneratedDocumentsAsync()
    {
        using var workspace = new AdhocWorkspace();
        var project = workspace.AddProject("Project1", LanguageNames.CSharp);
        await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await project.GetSourceGeneratedDocumentsAsync(default));
    }
}
