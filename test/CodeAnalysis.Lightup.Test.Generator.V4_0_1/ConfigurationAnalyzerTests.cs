// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.Generator.V4_0_1;

using System.Threading.Tasks;
using CodeAnalysis.Lightup.Generator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VerifyCS = CodeAnalysis.Lightup.Test.Support.Verifiers.CSharpAnalyzerVerifier<
    CodeAnalysis.Lightup.Generator.ConfigurationAnalyzer>;

[TestClass]
public class ConfigurationAnalyzerTests
{
    private const string UseFoldersInFilePathsMessage = "The current Roslyn version does not support generating files in folders. Upgrade to at least Roslyn 4.6.0 or configure not to use folders. The latter is done by adding '<UseFoldersInFilePaths>false</UseFoldersInFilePaths>' in the configuration file.";

    protected virtual bool SupportsFoldersInFilePaths => false;

    [TestMethod]
    [DataRow(null)]
    [DataRow("x.xml")]
    [DataRow("CodeAnalysis.Lightup.txt")]
    [DataRow("CodeAnalysis.Lightup.xmlz")]
    [DataRow("Xyz.CodeAnalysis.Lightup.xml")]
    public async Task TestNoConfigurationFile(string? fileName)
    {
        var test = CreateTest(fileName);
        test.ExpectedDiagnostics.Add(VerifyCS.Diagnostic(ConfigurationAnalyzer.NoFileDiagnosticId));
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestOkConfigurationFile()
    {
        var test = CreateTest("CodeAnalysis.Lightup.xml");
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyConfigurationFile()
    {
        var test = CreateTest("CodeAnalysis.Lightup.xml", content: "");
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Failed to parse file");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestNoAssembliesInConfigurationFile()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<BaselineVersion>3.0.0.0</BaselineVersion>
    <UseFoldersInFilePaths>{Helpers.RoslynSupportsFoldersInGeneratedFilePaths}</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Missing 'Assembly' element(s).");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyAssemblyInConfigurationFile()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly></Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
    <UseFoldersInFilePaths>{Helpers.RoslynSupportsFoldersInGeneratedFilePaths}</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Incorrect 'Assembly' element value: ''. Should be one of these: Common, CSharp, WorkspacesCommon, CSharpWorkspaces.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestIncorrectAssemblyInConfigurationFile()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Xyz</Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
    <UseFoldersInFilePaths>{Helpers.RoslynSupportsFoldersInGeneratedFilePaths}</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Incorrect 'Assembly' element value: 'Xyz'. Should be one of these: Common, CSharp, WorkspacesCommon, CSharpWorkspaces.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestNoBaselineVersionInConfigurationFile()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
    <UseFoldersInFilePaths>{Helpers.RoslynSupportsFoldersInGeneratedFilePaths}</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Missing 'BaselineVersion' element.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyBaselineVersionInConfigurationFile()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<BaselineVersion></BaselineVersion>
    <UseFoldersInFilePaths>{Helpers.RoslynSupportsFoldersInGeneratedFilePaths}</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Incorrect 'BaselineVersion' element value: ''.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestIncorrectBaselineVersionInConfigurationFile()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<BaselineVersion>Xyz</BaselineVersion>
    <UseFoldersInFilePaths>{Helpers.RoslynSupportsFoldersInGeneratedFilePaths}</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Incorrect 'BaselineVersion' element value: 'Xyz'.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestMultipleBaselineVersionsInConfigurationFile()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
	<BaselineVersion>3.8.0.0</BaselineVersion>
    <UseFoldersInFilePaths>{Helpers.RoslynSupportsFoldersInGeneratedFilePaths}</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Multiple 'BaselineVersion' elements.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestNoUseFoldersInFilePaths()
    {
        if (SupportsFoldersInFilePaths)
        {
            return;
        }

        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", UseFoldersInFilePathsMessage);
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyUseFoldersInFilePaths()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
    <UseFoldersInFilePaths></UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Incorrect 'UseFoldersInFilePaths' element value: ''. Should be one of these: True, False.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestIncorrectUseFoldersInFilePaths()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
    <UseFoldersInFilePaths>Xyz</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Incorrect 'UseFoldersInFilePaths' element value: 'Xyz'. Should be one of these: True, False.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestMultipleUseFoldersInFilePaths()
    {
        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
    <UseFoldersInFilePaths>True</UseFoldersInFilePaths>
    <UseFoldersInFilePaths>False</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", "Multiple 'UseFoldersInFilePaths' elements.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestUseFoldersInFilePathsTrue()
    {
        if (SupportsFoldersInFilePaths)
        {
            return;
        }

        var content = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
    <UseFoldersInFilePaths>True</UseFoldersInFilePaths>
</Settings>
";

        var test = CreateTest("CodeAnalysis.Lightup.xml", content);
        var diagnostic = VerifyCS.Diagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("CodeAnalysis.Lightup.xml", UseFoldersInFilePathsMessage);
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    private static VerifyCS.Test CreateTest(string? fileName, string? content = null)
    {
        var test = new VerifyCS.Test();
        test.TestCode = "";

        if (fileName != null)
        {
            var configFileContent = content ?? $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Settings>
	<Assembly>Common</Assembly>
	<Assembly>CSharp</Assembly>
	<Assembly>WorkspacesCommon</Assembly>
	<Assembly>CSharpWorkspaces</Assembly>
	<BaselineVersion>3.0.0.0</BaselineVersion>
    <UseFoldersInFilePaths>{Helpers.RoslynSupportsFoldersInGeneratedFilePaths}</UseFoldersInFilePaths>
</Settings>
";
            test.TestState.AdditionalFiles.Add((fileName, configFileContent));
        }

        return test;
    }
}
