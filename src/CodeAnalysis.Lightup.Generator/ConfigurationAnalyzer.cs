// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

// TODO: Create Roslyn issue for descriptions not being shown. Diagnostics without location?
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class ConfigurationAnalyzer : DiagnosticAnalyzer
{
    public const string NoFileDiagnosticId = "RoslynLightup001";
    public const string BadFileDiagnosticId = "RoslynLightup002";

    private static readonly DiagnosticDescriptor NoFileDescriptor =
        new DiagnosticDescriptor(
            id: NoFileDiagnosticId,
            title: "Missing configuration file",
            messageFormat: "The project needs at least one configuration file to be able to use the source generator",
            category: "Source Generator",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Add at least one file with name matching 'CodeAnalysis.Lightup*.json', with build action 'C# analyzer additional file'.",
            helpLinkUri: "https://github.com/bjornhellander/CodeAnalysis.Lightup/blob/master/doc/RoslynLightup001.md");

    private static readonly DiagnosticDescriptor BadFileDescriptor =
        new DiagnosticDescriptor(
            id: BadFileDiagnosticId,
            title: "Incorrect configuration file",
            messageFormat: "Incorrect configuration file {0}: {1}",
            category: "Source Generator",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Correct the configuration file.",
            helpLinkUri: "https://github.com/bjornhellander/CodeAnalysis.Lightup/blob/master/doc/RoslynLightup002.md");

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
            ReportDiagnostic(context, NoFileDescriptor, null);
            return;
        }

        foreach (var configFile in configFiles)
        {
            var configFileContent = configFile.GetText()!.ToString();
            if (!Helpers.TryParseConfiguration(configFileContent, out var assemblies, out var baselineVersion, out var typesToInclude, out var useFoldersInFilePaths, out var errorMessage))
            {
                var location = Location.Create(configFile.Path, new TextSpan(0, 0), new LinePositionSpan(new LinePosition(0, 0), new LinePosition(0, 0)));
                ReportDiagnostic(context, BadFileDescriptor, location, Path.GetFileName(configFile.Path), errorMessage);
                return;
            }
        }
    }

    private static void ReportDiagnostic(CompilationAnalysisContext context, DiagnosticDescriptor descriptor, Location? location, params string[] parameters)
    {
        var diagnostic = Diagnostic.Create(descriptor, location, parameters);
        context.ReportDiagnostic(diagnostic);
    }
}
