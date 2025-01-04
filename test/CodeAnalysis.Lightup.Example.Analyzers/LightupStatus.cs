// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Example.Analyzers
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Lightup;

    public class LightupStatus
    {
        static LightupStatus()
        {
            CodeAnalysisVersion = typeof(OperationKind).Assembly.GetName().Version;

            var supportedLanguageVersions = Enum.GetValues(typeof(LanguageVersion)).Cast<LanguageVersion>().ToList();
            SupportsCSharp7_2 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp7_2);
            SupportsCSharp7_3 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp7_3);
            SupportsCSharp8 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp8);
            SupportsCSharp9 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp9);
            SupportsCSharp10 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp10);
            SupportsCSharp11 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp11);
            SupportsCSharp12 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp12);
            SupportsCSharp13 = supportedLanguageVersions.Contains(LanguageVersionEx.CSharp13);
        }

        public static Version CodeAnalysisVersion { get; }

        public static bool SupportsCSharp7_2 { get; }

        public static bool SupportsCSharp7_3 { get; }

        public static bool SupportsCSharp8 { get; }

        public static bool SupportsCSharp9 { get; }

        public static bool SupportsCSharp10 { get; }

        public static bool SupportsCSharp11 { get; }

        public static bool SupportsCSharp12 { get; }

        public static bool SupportsCSharp13 { get; }
    }
}
