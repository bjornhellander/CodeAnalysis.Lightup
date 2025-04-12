// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

using System.Threading.Tasks;
using CodeAnalysis.Lightup.Example.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerifyCS = CodeAnalysis.Lightup.Test.Support.Verifiers.CSharpAnalyzerVerifier<CodeAnalysis.Lightup.Example.Analyzers.AdditionalFileNameAnalyzer>;

namespace CodeAnalysis.Lightup.Test.V1_3_2;

[TestClass]
public class AdditionalFileNameAnalyzerTests
{
    [TestMethod]
    public async Task TestAdditionalFile()
    {
        var test = new VerifyCS.Test()
        {
            TestCode = "",
            TestState =
            {
                AdditionalFiles = { ("MyAdditionalFile.xml", "") },
            },
        };

        if (LightupStatus.CodeAnalysisVersion >= new System.Version(3, 8, 0))
        {
            var expected = VerifyCS.Diagnostic().WithNoLocation();
            test.TestState.ExpectedDiagnostics.Add(expected);
        }

        await test.RunAsync().ConfigureAwait(false);
    }
}
