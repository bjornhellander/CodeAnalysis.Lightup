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
        test.ExpectedDiagnostics.Add(VerifyCS.Diagnostic(ConfigurationAnalyzer.NoConfigurationFileDiagnosticId));
        await test.RunAsync();
    }

    [TestMethod]
    public async Task TestOkConfigurationFile()
    {
        var test = CreateTest("Roslyn.CodeAnalysis.Lightup.xml");
        await test.RunAsync();
    }

    private static VerifyCS.Test CreateTest(string? fileName)
    {
        var test = new VerifyCS.Test();
        test.TestCode = "";

        if (fileName != null)
        {
            test.TestState.AdditionalFiles.Add((fileName, ""));
        }

        return test;
    }
}
