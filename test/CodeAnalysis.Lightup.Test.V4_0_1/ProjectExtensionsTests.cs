﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_0_1;

[TestClass]
public partial class ProjectExtensionsTests
{
    [TestMethod]
    public override async Task GetSourceGeneratedDocuments()
    {
        using var workspace = new AdhocWorkspace();
        var project = workspace.AddProject("Project1", LanguageNames.CSharp);
        var result = await ProjectEx.GetSourceGeneratedDocumentsAsync(project, default);
        Assert.AreEqual(0, result.Count());
    }
}
