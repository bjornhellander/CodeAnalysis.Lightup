﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Editing.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Editing.SyntaxEditor.</summary>
    public static partial class SyntaxEditorExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Editing.SyntaxEditor";

        private delegate SyntaxEditor ConstructorDelegate0(global::Microsoft.CodeAnalysis.SyntaxNode root, global::Microsoft.CodeAnalysis.Host.HostWorkspaceServices services);
        private delegate SyntaxEditor ConstructorDelegate1(global::Microsoft.CodeAnalysis.SyntaxNode root, global::Microsoft.CodeAnalysis.Host.Lightup.SolutionServicesWrapper services);

        private static readonly ConstructorDelegate0 ConstructorFunc0;
        private static readonly ConstructorDelegate1 ConstructorFunc1;

        static SyntaxEditorExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            ConstructorFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate0>(wrappedType, "rootSyntaxNode", "servicesHostWorkspaceServices");
            ConstructorFunc1 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate1>(wrappedType, "rootSyntaxNode", "servicesSolutionServices");
        }

        /// <summary>Constructor added in version 4.2.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Editing.SyntaxEditor Create(global::Microsoft.CodeAnalysis.SyntaxNode root, global::Microsoft.CodeAnalysis.Host.HostWorkspaceServices services)
        {
            return ConstructorFunc0(root, services);
        }

        /// <summary>Constructor added in version 4.4.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Editing.SyntaxEditor Create(global::Microsoft.CodeAnalysis.SyntaxNode root, global::Microsoft.CodeAnalysis.Host.Lightup.SolutionServicesWrapper services)
        {
            return ConstructorFunc1(root, services);
        }
    }
}
