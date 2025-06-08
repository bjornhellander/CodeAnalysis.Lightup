// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

using VerifyCS = CodeAnalysis.Lightup.Test.Support.Verifiers.CSharpCodeFixVerifier<
    CodeAnalysis.Lightup.Example.Analyzers.SourceFileNameAnalyzer,
    CodeAnalysis.Lightup.Example.CodeFixes.SourceFileNameCodeFixProvider>;

[TestClass]
public class SourceFileNameAnalyzerTests
{
    [TestMethod]
    public async Task TestSourceFileName()
    {
        var test = new VerifyCS.Test()
        {
            TestState =
            {
                Sources = { ("test.cs", "[| |]") },
            },
            FixedState =
            {
                Sources = { ("Test.cs", " ") },
            },
        };
        test.TestBehaviors |= TestBehaviors.SkipSuppressionCheck;

        await test.RunAsync().ConfigureAwait(false);
    }
}
