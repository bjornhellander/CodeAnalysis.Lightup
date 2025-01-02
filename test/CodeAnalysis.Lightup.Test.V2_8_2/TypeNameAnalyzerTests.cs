// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_8_2;

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VerifyCS = CodeAnalysis.Lightup.Test.Support.Verifiers.CSharpCodeFixVerifier<
    CodeAnalysis.Lightup.Example.Analyzers.TypeNameAnalyzer,
    CodeAnalysis.Lightup.Example.CodeFixes.TypeNameCodeFixProvider>;

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
