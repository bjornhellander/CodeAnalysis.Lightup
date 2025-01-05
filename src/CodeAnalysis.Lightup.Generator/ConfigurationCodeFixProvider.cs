// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;

internal class ConfigurationCodeFixProvider : CodeFixProvider
{
    private static readonly string DefaultConfigurationFileName = "CodeAnalysis.Lightup.json";
    private static readonly string DefaultConfigurationFileContent = @"{
  ""$schema"": ""https://raw.githubusercontent.com/bjornhellander/CodeAnalysis.Lightup/master/Configuration.schema.json"",
  ""baselineVersion"": ""1.3.2.0"",
  ""assemblies"": [ ""Common"", ""CSharp"" ]
}
";

    public sealed override ImmutableArray<string> FixableDiagnosticIds =>
        ImmutableArray.Create(ConfigurationAnalyzer.NoFileDiagnosticId);

    public override FixAllProvider? GetFixAllProvider() => null;

    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var syntaxRoot = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        if (syntaxRoot == null)
        {
            return;
        }

        foreach (var diagnostic in context.Diagnostics)
        {
            RegisterCodeFix(context, diagnostic);
        }
    }

    private static void RegisterCodeFix(CodeFixContext context, Diagnostic diagnostic)
    {
        var codeAction = CodeAction.Create(
            "Add CodeAnalysis.Lightup.Generator configuration file",
            cancellationToken => AddConfigurationFileAsync(context.Document.Project),
            equivalenceKey: nameof(ConfigurationCodeFixProvider));
        context.RegisterCodeFix(codeAction, diagnostic);
    }

    private static Task<Solution> AddConfigurationFileAsync(Project project)
    {
        project = AddAdditionalDocument(project, DefaultConfigurationFileName, DefaultConfigurationFileContent);
        return Task.FromResult(project.Solution);
    }

    private static Project AddAdditionalDocument(Project project, string name, string fileContent)
    {
        var additionalDocument = project.AdditionalDocuments.FirstOrDefault(doc => string.Equals(doc.Name, name, StringComparison.OrdinalIgnoreCase));
        if (additionalDocument == null)
        {
            project = project.AddAdditionalDocument(name, fileContent).Project;
        }

        return project;
    }
}
