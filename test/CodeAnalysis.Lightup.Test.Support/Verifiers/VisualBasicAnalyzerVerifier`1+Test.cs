// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.Support.Verifiers;

public static partial class VisualBasicAnalyzerVerifier<TAnalyzer>
    where TAnalyzer : DiagnosticAnalyzer, new()
{
    internal class Test : VisualBasicAnalyzerTest<TAnalyzer, DefaultVerifier>
    {
        public Test()
        {
        }
    }
}
