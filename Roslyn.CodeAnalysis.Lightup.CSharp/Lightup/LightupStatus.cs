namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Lightup;

    public class LightupStatus
    {
        static LightupStatus()
        {
            CodeAnalysisVersion = typeof(SyntaxKind).Assembly.GetName().Version;

            var supportedLanguageVersions = Enum.GetValues(typeof(LanguageVersion)).Cast<LanguageVersion>().ToList();
            SupportsCSharp9 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp9);
            SupportsCSharp10 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp10);
            SupportsCSharp11 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp11);
            SupportsCSharp12 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp12);
        }

        public static Version CodeAnalysisVersion { get; }

        public static bool SupportsCSharp9 { get; }

        public static bool SupportsCSharp10 { get; }

        public static bool SupportsCSharp11 { get; }

        public static bool SupportsCSharp12 { get; }
    }
}
