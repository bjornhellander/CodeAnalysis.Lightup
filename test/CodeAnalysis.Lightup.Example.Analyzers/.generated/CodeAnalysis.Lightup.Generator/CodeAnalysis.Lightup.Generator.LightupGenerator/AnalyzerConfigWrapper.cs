﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.AnalyzerConfig. Added in version 3.8.0.0.</summary>
    public readonly partial struct AnalyzerConfigWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.AnalyzerConfig";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper ParseDelegate0(global::System.String text, global::System.String? pathToFile);
        private delegate global::Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper ParseDelegate1(global::Microsoft.CodeAnalysis.Text.SourceText text, global::System.String? pathToFile);

        private static readonly ParseDelegate0 ParseFunc0;
        private static readonly ParseDelegate1 ParseFunc1;

        private readonly global::System.Object? wrappedObject;

        static AnalyzerConfigWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ParseFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<ParseDelegate0>(WrappedType, "Parse", "textString", "pathToFileString");
            ParseFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<ParseDelegate1>(WrappedType, "Parse", "textSourceText", "pathToFileString");
        }

        private AnalyzerConfigWrapper(global::System.Object? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
            => global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static AnalyzerConfigWrapper As(global::System.Object? obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.As<global::System.Object>(obj, WrappedType);
            return new AnalyzerConfigWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object? Unwrap()
            => wrappedObject;

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper Parse(global::System.String text, global::System.String? pathToFile)
            => ParseFunc0(text, pathToFile);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper Parse(global::Microsoft.CodeAnalysis.Text.SourceText text, global::System.String? pathToFile)
            => ParseFunc1(text, pathToFile);
    }
}