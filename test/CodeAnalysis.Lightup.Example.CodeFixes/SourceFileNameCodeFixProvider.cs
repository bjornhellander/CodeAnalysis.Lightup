// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Example.CodeFixes
{
    using System;
    using System.Collections.Immutable;
    using System.Composition;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CodeAnalysis.Lightup.Example.Analyzers;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeActions;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.Rename.Lightup;

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(SourceFileNameCodeFixProvider))]
    [Shared]
    public class SourceFileNameCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds =>
            ImmutableArray.Create(SourceFileNameAnalyzer.DiagnosticId);

        public sealed override FixAllProvider? GetFixAllProvider()
        {
            return null;
        }

        public sealed override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var diagnostic = context.Diagnostics.First();

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: "Fix",
                    createChangedSolution: c => MakeUppercaseAsync(context.Document, c),
                    equivalenceKey: nameof(SourceFileNameCodeFixProvider)),
                diagnostic);
            return Task.CompletedTask;
        }

        private static async Task<Solution> MakeUppercaseAsync(Document document, CancellationToken cancellationToken)
        {
            var newName = char.ToUpper(document.Name[0]) + document.Name.Substring(1);

            var orgSolution = document.Project.Solution;
            var newSolution = await RenameAsync(orgSolution, document, newName, cancellationToken).ConfigureAwait(false);

            return newSolution;
        }

        private static async Task<Solution> RenameAsync(Solution orgSolution, Document orgDocument, string newName, CancellationToken cancellationToken)
        {
            Solution newSolution;
            if (LightupStatus.CodeAnalysisVersion >= new Version(4, 4, 0, 0))
            {
                var options = DocumentRenameOptionsWrapper.Create(false, false);
                var actionSet = await RenamerEx.RenameDocumentAsync(orgDocument, options, newName, Array.Empty<string>(), cancellationToken).ConfigureAwait(false);
                newSolution = await actionSet.UpdateSolutionAsync(orgSolution, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var newFilePath = Path.Combine(Path.GetDirectoryName(orgDocument.FilePath), newName);
                newSolution = orgSolution
                    .WithDocumentName(orgDocument.Id, newName)
                    .WithDocumentFilePath(orgDocument.Id, newFilePath);
            }

            return newSolution;
        }
    }
}
