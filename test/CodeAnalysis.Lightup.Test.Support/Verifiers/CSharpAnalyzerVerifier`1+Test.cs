// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.Support.Verifiers;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

public static partial class CSharpAnalyzerVerifier<TAnalyzer>
    where TAnalyzer : DiagnosticAnalyzer, new()
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "MSTEST0004:Public types should be test classes", Justification = "Ok")]
    public class Test : CSharpAnalyzerTest<TAnalyzer, DefaultVerifier>
    {
        public Test()
        {
            // TODO: Investigate problem with testing older Roslyn versions
            var roslynVersion = typeof(SyntaxKind).Assembly.GetName().Version;
            switch (roslynVersion)
            {
                case { Major: 2, Minor: 3 }:
                    TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck;
                    break;
            }

            SolutionTransforms.Add((solution, projectId) =>
            {
                var compilationOptions = solution.GetProject(projectId).CompilationOptions;
                compilationOptions = compilationOptions.WithSpecificDiagnosticOptions(
                    compilationOptions.SpecificDiagnosticOptions.SetItems(CSharpVerifierHelper.NullableWarnings));
                solution = solution.WithProjectCompilationOptions(projectId, compilationOptions);

                return solution;
            });
        }
    }
}
