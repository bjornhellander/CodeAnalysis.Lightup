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
    public const string NoFileDiagnosticId = "ROSLYNLIGHTUP001";
    public const string BadFileDiagnosticId = "ROSLYNLIGHTUP002";

    private static readonly DiagnosticDescriptor NoFileDescriptor =
        new DiagnosticDescriptor(
            id: NoFileDiagnosticId,
            title: "Missing configuration file(s)",
            messageFormat: "The project needs at least one configuration file to be able to use the source generator",
            category: "Source Generator",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Add at least one file with name atching 'Roslyn.CodeAnalysis.Lightup*.xml', with build action 'C# analyzer additional file'.",
            helpLinkUri: "");

    private static readonly DiagnosticDescriptor BadFileDescriptor =
        new DiagnosticDescriptor(
            id: BadFileDiagnosticId,
            title: "Incorrect configuration file",
            messageFormat: "Incorrect configuration file {0}",
            category: "Source Generator",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "The configuration file could not be parsed correctly.",
            helpLinkUri: "");

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
        ImmutableArray.Create(
            NoFileDescriptor,
            BadFileDescriptor);

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
            ReportDiagnostic(context, NoFileDescriptor);
            return;
        }

        foreach (var configFile in configFiles)
        {
            var configFileContent = configFile.GetText()!.ToString();
            if (!Helpers.TryParseConfiguration(configFileContent, out var assemblies, out var baselineVersion, out var errorMessage))
            {
                ReportDiagnostic(context, BadFileDescriptor, errorMessage);
                return;
            }
        }
    }

    private static void ReportDiagnostic(CompilationAnalysisContext context, DiagnosticDescriptor descriptor, string? parameter = null)
    {
        var diagnostic = parameter != null ? Diagnostic.Create(descriptor, null, parameter) : Diagnostic.Create(descriptor, null);
        context.ReportDiagnostic(diagnostic);
    }
}
