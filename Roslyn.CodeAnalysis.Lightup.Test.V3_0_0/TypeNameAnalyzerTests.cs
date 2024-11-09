// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VerifyCS = Roslyn.CodeAnalysis.Lightup.Test.Support.Verifiers.CSharpCodeFixVerifier<
    Roslyn.CodeAnalysis.Lightup.Example.Analyzers.TypeNameAnalyzer,
    Roslyn.CodeAnalysis.Lightup.Example.CodeFixes.TypeNameCodeFixProvider>;

[TestClass]
public class TypeNameAnalyzerTests
{
    [TestMethod]
    public async Task Test()
    {
        var test = @"
namespace ConsoleApplication1
{
    class MAIN
    {
        private TypeName x;
    }
    
    class [|TypeName|]
    {   
    }
}";

        var fixtest = @"
namespace ConsoleApplication1
{
    class MAIN
    {
        private TYPENAME x;
    }
    
    class TYPENAME
    {   
    }
}";

        await VerifyCS.VerifyCodeFixAsync(test, DiagnosticResult.EmptyDiagnosticResults, fixtest);
    }
}
