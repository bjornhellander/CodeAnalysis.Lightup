using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.CodeAnalysis.Lightup.CSharp;

namespace Roslyn.CodeAnalysis.Lightup.Test.CSharp
{
    [TestClass]
    public class LightupStatusTests
    {
        [TestMethod]
        public virtual void TestLanguageVersion()
        {
            CheckSupportedLanguageVersions(false, false, false, false);
        }

        protected void CheckSupportedLanguageVersions(bool csharp9, bool csharp10, bool csharp11, bool csharp12)
        {
            Assert.AreEqual(csharp9, LightupStatus.SupportsCSharp9);
            Assert.AreEqual(csharp10, LightupStatus.SupportsCSharp10);
            Assert.AreEqual(csharp11, LightupStatus.SupportsCSharp11);
            Assert.AreEqual(csharp12, LightupStatus.SupportsCSharp12);
        }
    }
}
