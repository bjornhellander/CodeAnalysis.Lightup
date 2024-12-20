﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.FindSymbols.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.FindSymbols.SymbolFinder.</summary>
    public static partial class SymbolFinderEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.FindSymbols.SymbolFinder";

        private delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.INamedTypeSymbol>> FindDerivedClassesAsyncDelegate0(global::Microsoft.CodeAnalysis.INamedTypeSymbol type, global::Microsoft.CodeAnalysis.Solution solution, global::System.Boolean transitive, global::System.Collections.Immutable.IImmutableSet<global::Microsoft.CodeAnalysis.Project>? projects, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.INamedTypeSymbol>> FindDerivedInterfacesAsyncDelegate1(global::Microsoft.CodeAnalysis.INamedTypeSymbol type, global::Microsoft.CodeAnalysis.Solution solution, global::System.Boolean transitive, global::System.Collections.Immutable.IImmutableSet<global::Microsoft.CodeAnalysis.Project>? projects, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.INamedTypeSymbol>> FindImplementationsAsyncDelegate2(global::Microsoft.CodeAnalysis.INamedTypeSymbol type, global::Microsoft.CodeAnalysis.Solution solution, global::System.Boolean transitive, global::System.Collections.Immutable.IImmutableSet<global::Microsoft.CodeAnalysis.Project>? projects, global::System.Threading.CancellationToken cancellationToken);

        private static readonly FindDerivedClassesAsyncDelegate0 FindDerivedClassesAsyncFunc0;
        private static readonly FindDerivedInterfacesAsyncDelegate1 FindDerivedInterfacesAsyncFunc1;
        private static readonly FindImplementationsAsyncDelegate2 FindImplementationsAsyncFunc2;

        static SymbolFinderEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            FindDerivedClassesAsyncFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<FindDerivedClassesAsyncDelegate0>(wrappedType, "FindDerivedClassesAsync", "typeINamedTypeSymbol", "solutionSolution", "transitiveBoolean", "projectsIImmutableSet`1", "cancellationTokenCancellationToken");
            FindDerivedInterfacesAsyncFunc1 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<FindDerivedInterfacesAsyncDelegate1>(wrappedType, "FindDerivedInterfacesAsync", "typeINamedTypeSymbol", "solutionSolution", "transitiveBoolean", "projectsIImmutableSet`1", "cancellationTokenCancellationToken");
            FindImplementationsAsyncFunc2 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<FindImplementationsAsyncDelegate2>(wrappedType, "FindImplementationsAsync", "typeINamedTypeSymbol", "solutionSolution", "transitiveBoolean", "projectsIImmutableSet`1", "cancellationTokenCancellationToken");
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.INamedTypeSymbol>> FindDerivedClassesAsync(global::Microsoft.CodeAnalysis.INamedTypeSymbol type, global::Microsoft.CodeAnalysis.Solution solution, global::System.Boolean transitive, global::System.Collections.Immutable.IImmutableSet<global::Microsoft.CodeAnalysis.Project>? projects, global::System.Threading.CancellationToken cancellationToken)
        {
            return FindDerivedClassesAsyncFunc0(type, solution, transitive, projects, cancellationToken);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.INamedTypeSymbol>> FindDerivedInterfacesAsync(global::Microsoft.CodeAnalysis.INamedTypeSymbol type, global::Microsoft.CodeAnalysis.Solution solution, global::System.Boolean transitive, global::System.Collections.Immutable.IImmutableSet<global::Microsoft.CodeAnalysis.Project>? projects, global::System.Threading.CancellationToken cancellationToken)
        {
            return FindDerivedInterfacesAsyncFunc1(type, solution, transitive, projects, cancellationToken);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.INamedTypeSymbol>> FindImplementationsAsync(global::Microsoft.CodeAnalysis.INamedTypeSymbol type, global::Microsoft.CodeAnalysis.Solution solution, global::System.Boolean transitive, global::System.Collections.Immutable.IImmutableSet<global::Microsoft.CodeAnalysis.Project>? projects, global::System.Threading.CancellationToken cancellationToken)
        {
            return FindImplementationsAsyncFunc2(type, solution, transitive, projects, cancellationToken);
        }
    }
}
