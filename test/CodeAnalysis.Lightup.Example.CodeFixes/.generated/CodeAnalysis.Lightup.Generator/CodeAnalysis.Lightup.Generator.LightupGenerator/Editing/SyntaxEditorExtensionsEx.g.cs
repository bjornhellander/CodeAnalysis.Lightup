﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Editing.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Editing.SyntaxEditorExtensions.</summary>
    public static partial class SyntaxEditorExtensionsEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Editing.SyntaxEditorExtensions";

        private delegate void InsertParameterDelegate0(global::Microsoft.CodeAnalysis.Editing.SyntaxEditor? editor, global::Microsoft.CodeAnalysis.SyntaxNode? declaration, global::System.Int32 index, global::Microsoft.CodeAnalysis.SyntaxNode? parameter);

        private static readonly InsertParameterDelegate0 InsertParameterFunc0;

        static SyntaxEditorExtensionsEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            InsertParameterFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<InsertParameterDelegate0>(wrappedType, "InsertParameter", "editorSyntaxEditor", "declarationSyntaxNode", "indexInt32", "parameterSyntaxNode");
        }

        /// <summary>Method added in version 2.6.0.0.</summary>
        public static void InsertParameter(this global::Microsoft.CodeAnalysis.Editing.SyntaxEditor? editor, global::Microsoft.CodeAnalysis.SyntaxNode? declaration, global::System.Int32 index, global::Microsoft.CodeAnalysis.SyntaxNode? parameter)
        {
            InsertParameterFunc0(editor, declaration, index, parameter);
        }
    }
}