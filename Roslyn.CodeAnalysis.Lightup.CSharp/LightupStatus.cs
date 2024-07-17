using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Roslyn.CodeAnalysis.Lightup.CSharp
{
    public class LightupStatus
    {
        private static readonly List<LanguageVersion> supportedLanguageVersions = Enum.GetValues(typeof(LanguageVersion)).Cast<LanguageVersion>().ToList();

        static LightupStatus()
        {
            CodeAnalysisVersion = GetCodeAnalysisVersion();
            SupportsCSharp9 = IsLanguageVersionSupported(LanguageVersionEx.CSharp9);
            SupportsCSharp10 = IsLanguageVersionSupported(LanguageVersionEx.CSharp10);
            SupportsCSharp11 = IsLanguageVersionSupported(LanguageVersionEx.CSharp11);
            SupportsCSharp12 = IsLanguageVersionSupported(LanguageVersionEx.CSharp12);
        }

        public static Version CodeAnalysisVersion { get; }

        public static bool SupportsCSharp9 { get; }

        public static bool SupportsCSharp10 { get; }

        public static bool SupportsCSharp11 { get; }

        public static bool SupportsCSharp12 { get; }

        private static Version GetCodeAnalysisVersion()
        {
            var assembly = typeof(SyntaxKind).Assembly;
            var version = assembly.GetName().Version;
            return version;
        }

        private static bool IsLanguageVersionSupported(LanguageVersion languageVersion)
        {
            var result = supportedLanguageVersions.Contains(languageVersion);
            return result;
        }
    }
}
