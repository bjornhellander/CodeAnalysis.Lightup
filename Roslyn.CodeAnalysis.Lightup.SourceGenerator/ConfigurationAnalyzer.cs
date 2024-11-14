// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.SourceGenerator;

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

// TODO: Add help urls
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class ConfigurationAnalyzer : DiagnosticAnalyzer
{
    public const string NoConfigurationFileDiagnosticId = "ROSLYNLIGHTUP001";

    private static readonly DiagnosticDescriptor NoConfigurationFilDescriptor =
        new DiagnosticDescriptor(
            id: NoConfigurationFileDiagnosticId,
            title: "Missing configuration file(s)",
            messageFormat: "The project needs at least one configuration file to be able to use the source generator",
            category: "Source Generator",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Add at least one file with name atching 'Roslyn.CodeAnalysis.Lightup*.xml', with build action 'C# analyzer additional file'.",
            helpLinkUri: "");

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
        ImmutableArray.Create(NoConfigurationFilDescriptor);

    public override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);

        context.RegisterCompilationAction(HandleCompilation);
    }

    private static void HandleCompilation(CompilationAnalysisContext context)
    {
        var additionalFiles = context.Options.AdditionalFiles;
        var configFiles = additionalFiles.Where(Helpers.IsConfigurationFile).ToArray();

        if (configFiles.Length == 0)
        {
            ReportDiagnostic(context, NoConfigurationFilDescriptor, null);
            return;
        }
    }

    private static void ReportDiagnostic(CompilationAnalysisContext context, DiagnosticDescriptor descriptor, Location? location)
    {
        var diagnostic = Diagnostic.Create(descriptor, location);
        context.ReportDiagnostic(diagnostic);
    }
}
