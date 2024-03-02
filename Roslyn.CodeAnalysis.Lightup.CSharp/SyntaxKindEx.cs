using Microsoft.CodeAnalysis.CSharp;

namespace Roslyn.CodeAnalysis.Lightup.CSharp
{
    public static class SyntaxKindEx
    {
        // TODO: Just added to be able to write tests. Remove when proper members are added.
        public const SyntaxKind None = (SyntaxKind)0;
        public const SyntaxKind Abcdef = (SyntaxKind)12345;
    }
}
