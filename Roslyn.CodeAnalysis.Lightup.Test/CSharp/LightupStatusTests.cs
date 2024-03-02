using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.CodeAnalysis.Lightup.CSharp;
using System;
using System.Reflection;

namespace Roslyn.CodeAnalysis.Lightup.Test.CSharp
{
    [TestClass]
    public class LightupStatusTests
    {
        [TestMethod]
        public void TestLanguageVersion9()
        {
            var shouldBeSupported = GetExpectedSupportedLanguage() >= LanguageVersionEx.CSharp9;
            Assert.AreEqual(shouldBeSupported, LightupStatus.SupportsCSharp9);
        }

        [TestMethod]
        public void TestLanguageVersion10()
        {
            var shouldBeSupported = GetExpectedSupportedLanguage() >= LanguageVersionEx.CSharp10;
            Assert.AreEqual(shouldBeSupported, LightupStatus.SupportsCSharp10);
        }

        [TestMethod]
        public void TestLanguageVersion11()
        {
            var shouldBeSupported = GetExpectedSupportedLanguage() >= LanguageVersionEx.CSharp11;
            Assert.AreEqual(shouldBeSupported, LightupStatus.SupportsCSharp11);
        }

        [TestMethod]
        public void TestLanguageVersion12()
        {
            var shouldBeSupported = GetExpectedSupportedLanguage() >= LanguageVersionEx.CSharp12;
            Assert.AreEqual(shouldBeSupported, LightupStatus.SupportsCSharp12);
        }

        private static LanguageVersion GetExpectedSupportedLanguage()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var assemblyNameSuffix = assemblyName[32..];
            return assemblyNameSuffix switch
            {
                "" => LanguageVersion.CSharp8,
                ".3_8_0" => LanguageVersionEx.CSharp9,
                ".4_0_1" => LanguageVersionEx.CSharp10,
                ".4_4_0" => LanguageVersionEx.CSharp11,
                ".4_8_0" => LanguageVersionEx.CSharp12,
                _ => throw new ArgumentException($"Unhandled test assembly version '{assemblyNameSuffix}'"),
            };
        }
    }
}
