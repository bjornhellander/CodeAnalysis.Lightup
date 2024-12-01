// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

// TODO: Add help urls
// TODO: Create Roslyn issue for desciptions not being shown. Diagnostics without location?
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
            description: "Add at least one file with name atching 'CodeAnalysis.Lightup*.xml', with build action 'C# analyzer additional file'.",
            helpLinkUri: "");

    private static readonly DiagnosticDescriptor BadFileDescriptor =
        new DiagnosticDescriptor(
            id: BadFileDiagnosticId,
            title: "Incorrect configuration file",
            messageFormat: "Incorrect configuration file {0}: {1}",
            category: "Source Generator",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "The configuration file was incorrect.",
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
            if (!Helpers.TryParseConfiguration(configFileContent, out var assemblies, out var baselineVersion, out var typesToInclude, out var errorMessage))
            {
                ReportDiagnostic(context, BadFileDescriptor, Path.GetFileName(configFile.Path), errorMessage);
                return;
            }
        }
    }

    private static void ReportDiagnostic(CompilationAnalysisContext context, DiagnosticDescriptor descriptor, params string[] parameters)
    {
        var diagnostic = Diagnostic.Create(descriptor, null, parameters);
        context.ReportDiagnostic(diagnostic);
    }
}
