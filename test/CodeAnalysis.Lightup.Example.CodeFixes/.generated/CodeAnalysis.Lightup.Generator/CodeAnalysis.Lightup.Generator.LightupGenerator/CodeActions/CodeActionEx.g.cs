﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CodeActions.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CodeActions.CodeAction.</summary>
    public static partial class CodeActionEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CodeActions.CodeAction";

        private delegate global::System.Boolean IsInlinableGetterDelegate(global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CodeActions.CodeAction> NestedActionsGetterDelegate(global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj);
        private delegate global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx PriorityGetterDelegate(global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::System.String> TagsGetterDelegate(global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj);

        private delegate global::Microsoft.CodeAnalysis.CodeActions.CodeAction CreateDelegate0(global::System.String title, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CodeActions.CodeAction> nestedActions, global::System.Boolean isInlinable);
        private delegate global::Microsoft.CodeAnalysis.CodeActions.CodeAction CreateDelegate1(global::System.String title, global::System.Func<global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Document>> createChangedDocument, global::System.String? equivalenceKey, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority);
        private delegate global::Microsoft.CodeAnalysis.CodeActions.CodeAction CreateDelegate2(global::System.String title, global::System.Func<global::System.IProgress<global::Microsoft.CodeAnalysis.Lightup.CodeAnalysisProgressWrapper>, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Document>> createChangedDocument, global::System.String? equivalenceKey, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority);
        private delegate global::Microsoft.CodeAnalysis.CodeActions.CodeAction CreateDelegate3(global::System.String title, global::System.Func<global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Solution>> createChangedSolution, global::System.String? equivalenceKey, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority);
        private delegate global::Microsoft.CodeAnalysis.CodeActions.CodeAction CreateDelegate4(global::System.String title, global::System.Func<global::System.IProgress<global::Microsoft.CodeAnalysis.Lightup.CodeAnalysisProgressWrapper>, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Solution>> createChangedSolution, global::System.String? equivalenceKey, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority);
        private delegate global::Microsoft.CodeAnalysis.CodeActions.CodeAction CreateDelegate5(global::System.String title, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CodeActions.CodeAction> nestedActions, global::System.Boolean isInlinable, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority);

        private delegate global::System.Threading.Tasks.Task<global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CodeActions.CodeActionOperation>> GetOperationsAsyncDelegate0(global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj, global::Microsoft.CodeAnalysis.Solution originalSolution, global::System.IProgress<global::Microsoft.CodeAnalysis.Lightup.CodeAnalysisProgressWrapper> progress, global::System.Threading.CancellationToken cancellationToken);

        private static readonly IsInlinableGetterDelegate IsInlinableGetterFunc;
        private static readonly NestedActionsGetterDelegate NestedActionsGetterFunc;
        private static readonly PriorityGetterDelegate PriorityGetterFunc;
        private static readonly TagsGetterDelegate TagsGetterFunc;

        private static readonly CreateDelegate0 CreateFunc0;
        private static readonly CreateDelegate1 CreateFunc1;
        private static readonly CreateDelegate2 CreateFunc2;
        private static readonly CreateDelegate3 CreateFunc3;
        private static readonly CreateDelegate4 CreateFunc4;
        private static readonly CreateDelegate5 CreateFunc5;

        private static readonly GetOperationsAsyncDelegate0 GetOperationsAsyncFunc0;

        static CodeActionEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            IsInlinableGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<IsInlinableGetterDelegate>(wrappedType, nameof(IsInlinable));
            NestedActionsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<NestedActionsGetterDelegate>(wrappedType, nameof(NestedActions));
            PriorityGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<PriorityGetterDelegate>(wrappedType, nameof(Priority));
            TagsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<TagsGetterDelegate>(wrappedType, nameof(Tags));

            CreateFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate0>(wrappedType, "Create", "titleString", "nestedActionsImmutableArray`1", "isInlinableBoolean");
            CreateFunc1 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate1>(wrappedType, "Create", "titleString", "createChangedDocumentFunc`2", "equivalenceKeyString", "priorityCodeActionPriority");
            CreateFunc2 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate2>(wrappedType, "Create", "titleString", "createChangedDocumentFunc`3", "equivalenceKeyString", "priorityCodeActionPriority");
            CreateFunc3 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate3>(wrappedType, "Create", "titleString", "createChangedSolutionFunc`2", "equivalenceKeyString", "priorityCodeActionPriority");
            CreateFunc4 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate4>(wrappedType, "Create", "titleString", "createChangedSolutionFunc`3", "equivalenceKeyString", "priorityCodeActionPriority");
            CreateFunc5 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate5>(wrappedType, "Create", "titleString", "nestedActionsImmutableArray`1", "isInlinableBoolean", "priorityCodeActionPriority");

            GetOperationsAsyncFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<GetOperationsAsyncDelegate0>(wrappedType, "GetOperationsAsync", "originalSolutionSolution", "progressIProgress`1", "cancellationTokenCancellationToken");
        }

        /// <summary>Property added in version 4.9.0.0.</summary>
        public static global::System.Boolean IsInlinable(this global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj)
        {
            return IsInlinableGetterFunc(_obj);
        }

        /// <summary>Property added in version 4.9.0.0.</summary>
        public static global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CodeActions.CodeAction> NestedActions(this global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj)
        {
            return NestedActionsGetterFunc(_obj);
        }

        /// <summary>Property added in version 4.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx Priority(this global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj)
        {
            return PriorityGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public static global::System.Collections.Immutable.ImmutableArray<global::System.String> Tags(this global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj)
        {
            return TagsGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.3.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CodeActions.CodeAction Create(global::System.String title, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CodeActions.CodeAction> nestedActions, global::System.Boolean isInlinable)
        {
            return CreateFunc0(title, nestedActions, isInlinable);
        }

        /// <summary>Method added in version 4.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CodeActions.CodeAction Create(global::System.String title, global::System.Func<global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Document>> createChangedDocument, global::System.String? equivalenceKey, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority)
        {
            return CreateFunc1(title, createChangedDocument, equivalenceKey, priority);
        }

        /// <summary>Method added in version 4.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CodeActions.CodeAction Create(global::System.String title, global::System.Func<global::System.IProgress<global::Microsoft.CodeAnalysis.Lightup.CodeAnalysisProgressWrapper>, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Document>> createChangedDocument, global::System.String? equivalenceKey, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority)
        {
            return CreateFunc2(title, createChangedDocument, equivalenceKey, priority);
        }

        /// <summary>Method added in version 4.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CodeActions.CodeAction Create(global::System.String title, global::System.Func<global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Solution>> createChangedSolution, global::System.String? equivalenceKey, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority)
        {
            return CreateFunc3(title, createChangedSolution, equivalenceKey, priority);
        }

        /// <summary>Method added in version 4.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CodeActions.CodeAction Create(global::System.String title, global::System.Func<global::System.IProgress<global::Microsoft.CodeAnalysis.Lightup.CodeAnalysisProgressWrapper>, global::System.Threading.CancellationToken, global::System.Threading.Tasks.Task<global::Microsoft.CodeAnalysis.Solution>> createChangedSolution, global::System.String? equivalenceKey, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority)
        {
            return CreateFunc4(title, createChangedSolution, equivalenceKey, priority);
        }

        /// <summary>Method added in version 4.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CodeActions.CodeAction Create(global::System.String title, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CodeActions.CodeAction> nestedActions, global::System.Boolean isInlinable, global::Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionPriorityEx priority)
        {
            return CreateFunc5(title, nestedActions, isInlinable, priority);
        }

        /// <summary>Method added in version 4.9.0.0.</summary>
        public static global::System.Threading.Tasks.Task<global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CodeActions.CodeActionOperation>> GetOperationsAsync(this global::Microsoft.CodeAnalysis.CodeActions.CodeAction _obj, global::Microsoft.CodeAnalysis.Solution originalSolution, global::System.IProgress<global::Microsoft.CodeAnalysis.Lightup.CodeAnalysisProgressWrapper> progress, global::System.Threading.CancellationToken cancellationToken)
        {
            return GetOperationsAsyncFunc0(_obj, originalSolution, progress, cancellationToken);
        }
    }
}
