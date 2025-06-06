﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CommandLineArguments.</summary>
    public static partial class CommandLineArgumentsEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CommandLineArguments";

        private delegate global::System.Collections.Immutable.ImmutableArray<global::System.String> AnalyzerConfigPathsGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.Boolean DisplayLangVersionsGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.Boolean DisplayVersionGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CommandLineSourceFile> EmbeddedFilesGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.Boolean EmitPdbFileGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::Microsoft.CodeAnalysis.Lightup.ErrorLogOptionsWrapper? ErrorLogOptionsGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.String? GeneratedFilesOutputDirectoryGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.String? OutputRefFilePathGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.Boolean ReportInternalsVisibleToAttributesGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.String? RuleSetPathGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.Boolean SkipAnalyzersGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);
        private delegate global::System.String? SourceLinkGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineArguments _obj);

        private delegate global::System.String GetOutputFilePathDelegate0(global::Microsoft.CodeAnalysis.CommandLineArguments _obj, global::System.String outputFileName);
        private delegate global::System.String GetPdbFilePathDelegate0(global::Microsoft.CodeAnalysis.CommandLineArguments _obj, global::System.String outputFileName);

        private static readonly AnalyzerConfigPathsGetterDelegate AnalyzerConfigPathsGetterFunc;
        private static readonly DisplayLangVersionsGetterDelegate DisplayLangVersionsGetterFunc;
        private static readonly DisplayVersionGetterDelegate DisplayVersionGetterFunc;
        private static readonly EmbeddedFilesGetterDelegate EmbeddedFilesGetterFunc;
        private static readonly EmitPdbFileGetterDelegate EmitPdbFileGetterFunc;
        private static readonly ErrorLogOptionsGetterDelegate ErrorLogOptionsGetterFunc;
        private static readonly GeneratedFilesOutputDirectoryGetterDelegate GeneratedFilesOutputDirectoryGetterFunc;
        private static readonly OutputRefFilePathGetterDelegate OutputRefFilePathGetterFunc;
        private static readonly ReportInternalsVisibleToAttributesGetterDelegate ReportInternalsVisibleToAttributesGetterFunc;
        private static readonly RuleSetPathGetterDelegate RuleSetPathGetterFunc;
        private static readonly SkipAnalyzersGetterDelegate SkipAnalyzersGetterFunc;
        private static readonly SourceLinkGetterDelegate SourceLinkGetterFunc;

        private static readonly GetOutputFilePathDelegate0 GetOutputFilePathFunc0;
        private static readonly GetPdbFilePathDelegate0 GetPdbFilePathFunc0;

        static CommandLineArgumentsEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            AnalyzerConfigPathsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<AnalyzerConfigPathsGetterDelegate>(wrappedType, nameof(AnalyzerConfigPaths));
            DisplayLangVersionsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<DisplayLangVersionsGetterDelegate>(wrappedType, nameof(DisplayLangVersions));
            DisplayVersionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<DisplayVersionGetterDelegate>(wrappedType, nameof(DisplayVersion));
            EmbeddedFilesGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<EmbeddedFilesGetterDelegate>(wrappedType, nameof(EmbeddedFiles));
            EmitPdbFileGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<EmitPdbFileGetterDelegate>(wrappedType, nameof(EmitPdbFile));
            ErrorLogOptionsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ErrorLogOptionsGetterDelegate>(wrappedType, nameof(ErrorLogOptions));
            GeneratedFilesOutputDirectoryGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<GeneratedFilesOutputDirectoryGetterDelegate>(wrappedType, nameof(GeneratedFilesOutputDirectory));
            OutputRefFilePathGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<OutputRefFilePathGetterDelegate>(wrappedType, nameof(OutputRefFilePath));
            ReportInternalsVisibleToAttributesGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ReportInternalsVisibleToAttributesGetterDelegate>(wrappedType, nameof(ReportInternalsVisibleToAttributes));
            RuleSetPathGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<RuleSetPathGetterDelegate>(wrappedType, nameof(RuleSetPath));
            SkipAnalyzersGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<SkipAnalyzersGetterDelegate>(wrappedType, nameof(SkipAnalyzers));
            SourceLinkGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<SourceLinkGetterDelegate>(wrappedType, nameof(SourceLink));

            GetOutputFilePathFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<GetOutputFilePathDelegate0>(wrappedType, "GetOutputFilePath", "outputFileNameString");
            GetPdbFilePathFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<GetPdbFilePathDelegate0>(wrappedType, "GetPdbFilePath", "outputFileNameString");
        }

        /// <summary>Property added in version 3.1.0.0.</summary>
        public static global::System.Collections.Immutable.ImmutableArray<global::System.String> AnalyzerConfigPaths(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return AnalyzerConfigPathsGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public static global::System.Boolean DisplayLangVersions(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return DisplayLangVersionsGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public static global::System.Boolean DisplayVersion(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return DisplayVersionGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public static global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.CommandLineSourceFile> EmbeddedFiles(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return EmbeddedFilesGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.2.0.0.</summary>
        public static global::System.Boolean EmitPdbFile(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return EmitPdbFileGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.4.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.ErrorLogOptionsWrapper? ErrorLogOptions(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return ErrorLogOptionsGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static global::System.String? GeneratedFilesOutputDirectory(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return GeneratedFilesOutputDirectoryGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.3.0.0.</summary>
        public static global::System.String? OutputRefFilePath(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return OutputRefFilePathGetterFunc(_obj);
        }

        /// <summary>Property added in version 4.7.0.0.</summary>
        public static global::System.Boolean ReportInternalsVisibleToAttributes(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return ReportInternalsVisibleToAttributesGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.3.0.0.</summary>
        public static global::System.String? RuleSetPath(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return RuleSetPathGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static global::System.Boolean SkipAnalyzers(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return SkipAnalyzersGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public static global::System.String? SourceLink(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj)
        {
            return SourceLinkGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::System.String GetOutputFilePath(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj, global::System.String outputFileName)
        {
            return GetOutputFilePathFunc0(_obj, outputFileName);
        }

        /// <summary>Method added in version 3.2.0.0.</summary>
        public static global::System.String GetPdbFilePath(this global::Microsoft.CodeAnalysis.CommandLineArguments _obj, global::System.String outputFileName)
        {
            return GetPdbFilePathFunc0(_obj, outputFileName);
        }
    }
}
