using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.CodeAnalysis.Lightup.CSharp;

namespace Roslyn.CodeAnalysis.Lightup.Test.CSharp
{
    [TestClass]
    public class LanguageVersionExTests : EnumTestsBase<LanguageVersionEx, LanguageVersion, int>
    {
    }
}
