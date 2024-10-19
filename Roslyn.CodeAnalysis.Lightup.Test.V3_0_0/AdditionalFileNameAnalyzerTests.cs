// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VerifyCS = Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.Verifiers.CSharpAnalyzerVerifier<
    Roslyn.CodeAnalysis.Lightup.Example.Analyzers.AdditionalFileNameAnalyzer>;

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

        if (CommonLightupStatus.CodeAnalysisVersion >= new System.Version(3, 8, 0))
        {
            var expected = VerifyCS.Diagnostic().WithNoLocation();
            test.TestState.ExpectedDiagnostics.Add(expected);
        }

        await test.RunAsync().ConfigureAwait(false);
    }
}
