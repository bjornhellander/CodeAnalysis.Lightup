// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V4_0_1;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public partial class ProjectExtensionsTests
{
    [TestMethod]
    public override async Task GetSourceGeneratedDocumentsAsync()
    {
        using var workspace = new AdhocWorkspace();
        var project = workspace.AddProject("Project1", LanguageNames.CSharp);
        var result = await ProjectExtensions.GetSourceGeneratedDocumentsAsync(project, default);
        Assert.AreEqual(0, result.Count());
    }
}
