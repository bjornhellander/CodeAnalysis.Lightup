﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CodeRefactorings.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CodeRefactorings.CodeRefactoringProvider.</summary>
    public static partial class CodeRefactoringProviderExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CodeRefactorings.CodeRefactoringProvider";

        private delegate Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionRequestPriorityEx RequestPriorityGetterDelegate(Microsoft.CodeAnalysis.CodeRefactorings.CodeRefactoringProvider? _obj);

        private static readonly RequestPriorityGetterDelegate RequestPriorityGetterFunc;

        static CodeRefactoringProviderExtensions()
        {
            var wrappedType = WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            RequestPriorityGetterFunc = WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<RequestPriorityGetterDelegate>(wrappedType, nameof(RequestPriority));
        }

        /// <summary>Property added in version 4.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.CodeActions.Lightup.CodeActionRequestPriorityEx RequestPriority(this Microsoft.CodeAnalysis.CodeRefactorings.CodeRefactoringProvider _obj)
            => RequestPriorityGetterFunc(_obj);
    }
}