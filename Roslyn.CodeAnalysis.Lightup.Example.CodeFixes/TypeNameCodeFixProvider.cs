// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Example.CodeFixes
{
    using System;
    using System.Collections.Immutable;
    using System.Composition;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeActions;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Rename;
    using Microsoft.CodeAnalysis.Rename.Lightup;
    using Roslyn.CodeAnalysis.Lightup.Example.Analyzers;
    using Roslyn.CodeAnalysis.Lightup.Example.Support;

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(TypeNameCodeFixProvider))]
    [Shared]
    public class TypeNameCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds =>
            ImmutableArray.Create(TypeNameAnalyzer.DiagnosticId);

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            // Find the type declaration identified by the diagnostic.
            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<TypeDeclarationSyntax>().First();

            // Register a code action that will invoke the fix.
            context.RegisterCodeFix(
                CodeAction.Create(
                    title: "Fix",
                    createChangedSolution: c => MakeUppercaseAsync(context.Document, declaration, c),
                    equivalenceKey: nameof(TypeNameCodeFixProvider)),
                diagnostic);
        }

        private static async Task<Solution> MakeUppercaseAsync(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            // Compute new uppercase name.
            var identifierToken = typeDecl.Identifier;
            var newName = identifierToken.Text.ToUpperInvariant();

            // Get the symbol representing the type to be renamed.
            var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
            var typeSymbol = semanticModel.GetDeclaredSymbol(typeDecl, cancellationToken);

            // Produce a new solution that has all references to that type renamed, including the declaration.
            var orgSolution = document.Project.Solution;
            var newSolution = await RenameAsync(orgSolution, typeSymbol, newName, cancellationToken).ConfigureAwait(false);

            // Return the new solution with the now-uppercase type name.
            return newSolution;
        }

        private static async Task<Solution> RenameAsync(Solution orgSolution, ITypeSymbol typeSymbol, string newName, CancellationToken cancellationToken)
        {
            Solution newSolution;
            if (CommonLightupStatus.CodeAnalysisVersion >= new Version(4, 4, 0, 0))
            {
                var options = SymbolRenameOptionsWrapper.Create(false, false, false, false);
                newSolution = await RenamerEx.RenameSymbolAsync(orgSolution, typeSymbol, options, newName, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var optionSet = orgSolution.Workspace.Options;
                newSolution = await Renamer.RenameSymbolAsync(orgSolution, typeSymbol, newName, optionSet, cancellationToken).ConfigureAwait(false);
            }

            return newSolution;
        }
    }
}
