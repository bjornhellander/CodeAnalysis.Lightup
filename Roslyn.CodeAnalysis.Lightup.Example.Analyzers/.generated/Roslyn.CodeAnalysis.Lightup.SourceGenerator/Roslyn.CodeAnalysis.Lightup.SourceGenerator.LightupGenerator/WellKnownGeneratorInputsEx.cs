﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.WellKnownGeneratorInputs. Added in version 4.4.0.0.</summary>
    public static partial class WellKnownGeneratorInputsEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.WellKnownGeneratorInputs";

        private delegate System.String AdditionalTextsGetterDelegate();
        private delegate System.String AnalyzerConfigOptionsGetterDelegate();
        private delegate System.String CompilationGetterDelegate();
        private delegate System.String MetadataReferencesGetterDelegate();
        private delegate System.String ParseOptionsGetterDelegate();

        private static readonly AdditionalTextsGetterDelegate AdditionalTextsGetterFunc;
        private static readonly AnalyzerConfigOptionsGetterDelegate AnalyzerConfigOptionsGetterFunc;
        private static readonly CompilationGetterDelegate CompilationGetterFunc;
        private static readonly MetadataReferencesGetterDelegate MetadataReferencesGetterFunc;
        private static readonly ParseOptionsGetterDelegate ParseOptionsGetterFunc;

        static WellKnownGeneratorInputsEx()
        {
            var wrappedType = CommonLightupHelper.FindType(WrappedTypeName);

            AdditionalTextsGetterFunc = CommonLightupHelper.CreateStaticReadAccessor<AdditionalTextsGetterDelegate>(wrappedType, nameof(AdditionalTexts));
            AnalyzerConfigOptionsGetterFunc = CommonLightupHelper.CreateStaticReadAccessor<AnalyzerConfigOptionsGetterDelegate>(wrappedType, nameof(AnalyzerConfigOptions));
            CompilationGetterFunc = CommonLightupHelper.CreateStaticReadAccessor<CompilationGetterDelegate>(wrappedType, nameof(Compilation));
            MetadataReferencesGetterFunc = CommonLightupHelper.CreateStaticReadAccessor<MetadataReferencesGetterDelegate>(wrappedType, nameof(MetadataReferences));
            ParseOptionsGetterFunc = CommonLightupHelper.CreateStaticReadAccessor<ParseOptionsGetterDelegate>(wrappedType, nameof(ParseOptions));
        }

        /// <summary>Field added in version 4.4.0.0.</summary>
        public static System.String AdditionalTexts
        {
            get => AdditionalTextsGetterFunc();
        }

        /// <summary>Field added in version 4.4.0.0.</summary>
        public static System.String AnalyzerConfigOptions
        {
            get => AnalyzerConfigOptionsGetterFunc();
        }

        /// <summary>Field added in version 4.4.0.0.</summary>
        public static System.String Compilation
        {
            get => CompilationGetterFunc();
        }

        /// <summary>Field added in version 4.4.0.0.</summary>
        public static System.String MetadataReferences
        {
            get => MetadataReferencesGetterFunc();
        }

        /// <summary>Field added in version 4.4.0.0.</summary>
        public static System.String ParseOptions
        {
            get => ParseOptionsGetterFunc();
        }
    }
}