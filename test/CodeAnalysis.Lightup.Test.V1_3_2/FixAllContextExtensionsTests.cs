// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CodeFixes.Lightup;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FixAllContextExtensionsTests
{
    [TestMethod]
    public virtual void TestConstructor()
    {
        Assert.ThrowsException<InvalidOperationException>(() => CallConstructor());
    }

    protected static (Workspace Workspace, FixAllContext Context) CallConstructor()
    {
        AdhocWorkspace? workspace = null;

        try
        {
            workspace = new AdhocWorkspace();
            var project = workspace.AddProject("x", LanguageNames.CSharp);
            var sourceText = SourceText.From("class Program { static void Main() { } }");
            var document = workspace.AddDocument(project.Id, "Program.cs", sourceText);

            var context = FixAllContextEx.Create(
                document: document,
                diagnosticSpan: null,
                codeFixProvider: new MyCodeFixProvider(),
                scope: FixAllScope.Document,
                codeActionEquivalenceKey: "EquivalenceKey",
                diagnosticIds: [],
                fixAllDiagnosticProvider: new MyDiagnosticProvider(),
                cancellationToken: default);

            return (workspace, context);
        }
        catch (Exception)
        {
            workspace?.Dispose();
            throw;
        }
    }

    private class MyCodeFixProvider : CodeFixProvider
    {
        public override ImmutableArray<string> FixableDiagnosticIds => [];

        public override Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            return Task.CompletedTask;
        }
    }

    private class MyDiagnosticProvider : FixAllContext.DiagnosticProvider
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async override Task<IEnumerable<Diagnostic>> GetAllDiagnosticsAsync(Project project, CancellationToken cancellationToken)
        {
            return [];
        }

        public async override Task<IEnumerable<Diagnostic>> GetDocumentDiagnosticsAsync(Document document, CancellationToken cancellationToken)
        {
            return [];
        }

        public async override Task<IEnumerable<Diagnostic>> GetProjectDiagnosticsAsync(Project project, CancellationToken cancellationToken)
        {
            return [];
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
