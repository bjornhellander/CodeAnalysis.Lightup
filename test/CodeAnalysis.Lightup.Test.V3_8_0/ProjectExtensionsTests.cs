// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0;

[TestClass]
public partial class ProjectExtensionsTests
{
    [TestMethod]
    public override void TestAnalyzerConfigDocuments()
    {
        using var workspace = new AdhocWorkspace();
        var project = workspace.AddProject("Project1", LanguageNames.CSharp);
        var result = project.AnalyzerConfigDocuments();
        Assert.AreEqual(0, result.Count());
    }
}
