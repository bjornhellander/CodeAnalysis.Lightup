// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.Generator.V4_0_1;

using VerifyCS = CodeAnalysis.Lightup.Test.Support.Verifiers.CSharpAnalyzerVerifier<
    CodeAnalysis.Lightup.Generator.ConfigurationAnalyzer>;

[TestClass]
public class ConfigurationAnalyzerTests
{
    private const string UseFoldersInFilePathsMessage = "The current Roslyn version does not support generating files in folders. Upgrade to at least Roslyn 4.6.0 or configure not to use folders. The latter is done by adding '\"useFoldersInFilePaths\": false' in the configuration file.";

    protected virtual bool SupportsFoldersInFilePaths => false;

    [TestMethod]
    [DataRow(null)]
    [DataRow("x.json")]
    [DataRow("CodeAnalysis.Lightup.txt")]
    [DataRow("CodeAnalysis.Lightup.jsonz")]
    [DataRow("Xyz.CodeAnalysis.Lightup.json")]
    public async Task TestNoConfigurationFile(string? fileName)
    {
        var test = CreateTest(fileName);
        test.ExpectedDiagnostics.Add(CreateDiagnostic(ConfigurationAnalyzer.NoFileDiagnosticId));
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestOkConfigurationFile()
    {
        var test = CreateTest("CodeAnalysis.Lightup.json");
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyConfigurationFile()
    {
        var test = CreateTest("CodeAnalysis.Lightup.json", content: "");
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Failed to parse file");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestConfigurationFileWithEmptyArray()
    {
        var test = CreateTest("CodeAnalysis.Lightup.json", content: "[]");
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Failed to parse file");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestNoAssembliesAttribute()
    {
        var content = $@"
{{
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")}
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Missing 'assemblies' attribute.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyAssembliesAttribute()
    {
        var content = $@"
{{
	""assemblies"": [],
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")}
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Empty 'assemblies' attribute.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyAssembliesAttributeValue()
    {
        var content = $@"
{{
	""assemblies"": [ """" ],
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")}
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Incorrect 'assemblies' attribute value: ''. Expected one of these: Microsoft.CodeAnalysis.Common, Microsoft.CodeAnalysis.CSharp, Microsoft.CodeAnalysis.Workspaces.Common, Microsoft.CodeAnalysis.CSharp.Workspaces.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestIncorrectAssembliesAttribute()
    {
        var content = $@"
{{
	""assemblies"": ""Xyz"",
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")}
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Incorrect 'assemblies' attribute. Expected an array.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestIncorrectAssembliesAttributeValue()
    {
        var content = $@"
{{
	""assemblies"": [ ""Xyz"" ],
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")}
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Incorrect 'assemblies' attribute value: 'Xyz'. Expected one of these: Microsoft.CodeAnalysis.Common, Microsoft.CodeAnalysis.CSharp, Microsoft.CodeAnalysis.Workspaces.Common, Microsoft.CodeAnalysis.CSharp.Workspaces.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestNoBaselineVersionAttribute()
    {
        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")}
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Missing 'baselineVersion' attribute.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyBaselineVersionAttribute()
    {
        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
	""baselineVersion"":  """",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")}
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Incorrect 'baselineVersion' attribute value: ''.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestIncorrectBaselineVersionAttribute()
    {
        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
	""baselineVersion"":  ""Xyz"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")}
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Incorrect 'baselineVersion' attribute value: 'Xyz'.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestMultipleBaselineVersionAttributes()
    {
        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
	""baselineVersion"":  ""3.0.0.0"",
	""baselineVersion"":  ""3.8.0.0"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")}
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Failed to parse file");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestIncorrectIncludeTypesAttribute()
    {
        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")},
    ""includeTypes"": """"
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Incorrect 'includeTypes' attribute value. Expected an array of strings.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestIncorrectIncludeTypesAttributeValue()
    {
        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")},
    ""includeTypes"": [false]
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Incorrect 'includeTypes' attribute value. Expected an array of strings.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestNoUseFoldersAttributeInFilePaths()
    {
        if (SupportsFoldersInFilePaths)
        {
            return;
        }

        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
	""baselineVersion"":  ""3.0.0.0""
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments(UseFoldersInFilePathsMessage);
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestEmptyUseFoldersInFilePathsAttribute()
    {
        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": """"
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Incorrect 'useFoldersInFilePaths' attribute value. Expected a boolean.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestIncorrectUseFoldersInFilePathsAttribute()
    {
        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": ""Xyz""
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Incorrect 'useFoldersInFilePaths' attribute value. Expected a boolean.");
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestMultipleUseFoldersInFilePathsAttributes()
    {
        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"", ""Microsoft.CodeAnalysis.CSharp"" ],
	""baselineVersion"":  ""3.0.0.0""
    ""useFoldersInFilePaths"": true,
    ""useFoldersInFilePaths"": false
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments("Failed to parse file");
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

        var content = $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"" ],
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": true
}}";

        var test = CreateTest("CodeAnalysis.Lightup.json", content);
        var diagnostic = CreateDiagnostic(ConfigurationAnalyzer.BadFileDiagnosticId).WithArguments(UseFoldersInFilePathsMessage);
        test.ExpectedDiagnostics.Add(diagnostic);
        await test.RunAsync();
    }

    private static VerifyCS.Test CreateTest(string? fileName, string? content = null)
    {
        var test = new VerifyCS.Test();
        test.TestCode = "";

        if (fileName != null)
        {
            var configFileContent = content ?? $@"
{{
	""assemblies"": [ ""Microsoft.CodeAnalysis.Common"", ""Microsoft.CodeAnalysis.CSharp"", ""Microsoft.CodeAnalysis.Workspaces.Common"", ""Microsoft.CodeAnalysis.CSharp.Workspaces"" ],
	""baselineVersion"":  ""3.0.0.0"",
    ""useFoldersInFilePaths"": {(Helpers.RoslynSupportsFoldersInGeneratedFilePaths ? "true" : "false")},
    ""includeTypes"": [ ""abc"" ]
}}";
            test.TestState.AdditionalFiles.Add((fileName, configFileContent));
        }

        return test;
    }

    private static DiagnosticResult CreateDiagnostic(string id)
    {
        var result = VerifyCS.Diagnostic(id);

        if (id == ConfigurationAnalyzer.BadFileDiagnosticId)
        {
            result = result.WithLocation("CodeAnalysis.Lightup.json", 1, 1);
        }

        return result;
    }
}
