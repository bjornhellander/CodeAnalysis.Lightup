﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Host.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Host.HostLanguageServices.</summary>
    public static partial class HostLanguageServicesExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Host.HostLanguageServices";

        private delegate global::Microsoft.CodeAnalysis.Host.Lightup.LanguageServicesWrapper LanguageServicesGetterDelegate(global::Microsoft.CodeAnalysis.Host.HostLanguageServices? _obj);

        private static readonly LanguageServicesGetterDelegate LanguageServicesGetterFunc;

        static HostLanguageServicesExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            LanguageServicesGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<LanguageServicesGetterDelegate>(wrappedType, nameof(LanguageServices));
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Host.Lightup.LanguageServicesWrapper LanguageServices(this global::Microsoft.CodeAnalysis.Host.HostLanguageServices _obj)
            => LanguageServicesGetterFunc(_obj);
    }
}