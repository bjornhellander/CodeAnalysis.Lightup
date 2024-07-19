namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.Verifiers;

using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using Microsoft.CodeAnalysis.VisualBasic.Testing;

public static partial class VisualBasicCodeRefactoringVerifier<TCodeRefactoring>
    where TCodeRefactoring : CodeRefactoringProvider, new()
{
    public class Test : VisualBasicCodeRefactoringTest<TCodeRefactoring, MSTestVerifier>
    {
    }
}
