﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Diagnostics.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Diagnostics.AnalysisContext.</summary>
    public static partial class AnalysisContextExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Diagnostics.AnalysisContext";

        private delegate void RegisterAdditionalFileActionDelegate0(global::Microsoft.CodeAnalysis.Diagnostics.AnalysisContext? _obj, global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.Lightup.AdditionalFileAnalysisContextWrapper> action);

        private static readonly RegisterAdditionalFileActionDelegate0 RegisterAdditionalFileActionFunc0;

        static AnalysisContextExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            RegisterAdditionalFileActionFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RegisterAdditionalFileActionDelegate0>(wrappedType, "RegisterAdditionalFileAction", "actionAction`1");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void RegisterAdditionalFileAction(this global::Microsoft.CodeAnalysis.Diagnostics.AnalysisContext _obj, global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.Lightup.AdditionalFileAnalysisContextWrapper> action)
        {
            RegisterAdditionalFileActionFunc0(_obj, action);
        }
    }
}