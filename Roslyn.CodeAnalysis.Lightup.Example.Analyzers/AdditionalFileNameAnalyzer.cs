// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Example.Analyzers
{
    using System;
    using System.Collections.Immutable;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;
    using Microsoft.CodeAnalysis.Diagnostics.Lightup;

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AdditionalFileNameAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "TEST002";

        private const string Title = "Title";
        private const string MessageFormat = "Message Format";
        private const string Description = "Description.";
        private const string Category = "Naming";

        [SuppressMessage("MicrosoftCodeAnalysisReleaseTracking", "RS2008:Enable analyzer release tracking", Justification = "OK")]
        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            DiagnosticId,
            Title,
            MessageFormat,
            Category,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get { return ImmutableArray.Create(Rule); }
        }

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            if (CommonLightupStatus.CodeAnalysisVersion >= new Version(3, 8, 0))
            {
                context.RegisterAdditionalFileAction(HandleAdditionalFile);
            }
        }

        private static void HandleAdditionalFile(AdditionalFileAnalysisContextWrapper context)
        {
            var fileName = Path.GetFileName(context.AdditionalFile.Path);
            if (fileName.Any(char.IsLower))
            {
                var diagnostic = Diagnostic.Create(Rule, default);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
