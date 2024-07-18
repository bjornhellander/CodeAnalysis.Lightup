using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

[TestClass]
public class SyntaxKindExTests : EnumTestsBase<SyntaxKindEx, SyntaxKind, ushort>
{
}
