﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.FlowAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.FlowAnalysis.ControlFlowGraph.</summary>
    public static partial class ControlFlowGraphExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.FlowAnalysis.ControlFlowGraph";

        private delegate Microsoft.CodeAnalysis.FlowAnalysis.ControlFlowGraph CreateDelegate0(Microsoft.CodeAnalysis.Operations.Lightup.IAttributeOperationWrapper attribute, System.Threading.CancellationToken cancellationToken);

        private static readonly CreateDelegate0 CreateFunc0;

        static ControlFlowGraphExtensions()
        {
            var wrappedType = CommonLightupHelper.FindType(WrappedTypeName);

            CreateFunc0 = CommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate0>(wrappedType, "Create", "attributeIAttributeOperation", "cancellationTokenCancellationToken");
        }

        /// <summary>Method added in version 4.8.0.0.</summary>
        public static Microsoft.CodeAnalysis.FlowAnalysis.ControlFlowGraph Create(Microsoft.CodeAnalysis.Operations.Lightup.IAttributeOperationWrapper attribute, System.Threading.CancellationToken cancellationToken)
            => CreateFunc0(attribute, cancellationToken);
    }
}