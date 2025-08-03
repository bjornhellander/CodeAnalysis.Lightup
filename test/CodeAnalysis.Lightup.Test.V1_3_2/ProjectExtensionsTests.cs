// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

[TestClass]
public class ProjectExtensionsTests
{
    [TestMethod]
    public virtual void TestAnalyzerConfigDocuments()
    {
        using var workspace = new AdhocWorkspace();
        var project = workspace.AddProject("Project1", LanguageNames.CSharp);
        Assert.ThrowsExactly<InvalidOperationException>(() => project.AnalyzerConfigDocuments());
    }

    [TestMethod]
    public virtual async Task GetSourceGeneratedDocuments()
    {
        using var workspace = new AdhocWorkspace();
        var project = workspace.AddProject("Project1", LanguageNames.CSharp);
        await Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => await project.GetSourceGeneratedDocumentsAsync(default));
    }
}
