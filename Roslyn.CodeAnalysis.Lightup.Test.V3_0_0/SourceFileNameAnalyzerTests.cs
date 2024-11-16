// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VerifyCS = Roslyn.CodeAnalysis.Lightup.Test.Support.Verifiers.CSharpCodeFixVerifier<
    Roslyn.CodeAnalysis.Lightup.Example.Analyzers.SourceFileNameAnalyzer,
    Roslyn.CodeAnalysis.Lightup.Example.CodeFixes.SourceFileNameCodeFixProvider>;

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
            TestBehaviors = Microsoft.CodeAnalysis.Testing.TestBehaviors.SkipSuppressionCheck,
        };

        await test.RunAsync().ConfigureAwait(false);
    }
}
