// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.Internal;

using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.CodeAnalysis.Lightup.SourceGenerator;

using VerifyCS = Roslyn.CodeAnalysis.Lightup.Test.Support.Verifiers.CSharpAnalyzerVerifier<
    Roslyn.CodeAnalysis.Lightup.SourceGenerator.ConfigurationAnalyzer>;

[TestClass]
public class ConfigurationAnalyzerTests
{
    [TestMethod]
    [DataRow(null)]
    [DataRow("x.xml")]
    [DataRow("Roslyn.CodeAnalysis.Lightup.txt")]
    public async Task TestNoConfigurationFile(string? fileName)
    {
        var test = CreateTest(fileName);
        test.ExpectedDiagnostics.Add(VerifyCS.Diagnostic(ConfigurationAnalyzer.NoFileDiagnosticId));
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestOkConfigurationFile()
    {
        var test = CreateTest("Roslyn.CodeAnalysis.Lightup.xml");
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyConfigurationFile()
    {
        var test = CreateTest("Roslyn.CodeAnalysis.Lightup.xml", content: "");
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Roslyn.CodeAnalysis.Lightup.xml", "Failed to parse file");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestNoAssembliesInConfigurationFile()
    {
        var content = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<BaselineVersion>3.0.0.0</BaselineVersion>
</Settings>
";

        var test = CreateTest("Roslyn.CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Roslyn.CodeAnalysis.Lightup.xml", "No assemblies specified");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    private static VerifyCS.Test CreateTest(string? fileName, string? content = null)
    {
        var test = new VerifyCS.Test();
        test.TestCode = "";

        if (fileName != null)
        {
            var configFileContent = content ?? @"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<Assembly>CSharp</Assembly>
	<Assembly>Workspaces</Assembly>
	<Assembly>CSharpWorkspaces</Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
</Settings>
";
            test.TestState.AdditionalFiles.Add((fileName, configFileContent));
        }

        return test;
    }
}
