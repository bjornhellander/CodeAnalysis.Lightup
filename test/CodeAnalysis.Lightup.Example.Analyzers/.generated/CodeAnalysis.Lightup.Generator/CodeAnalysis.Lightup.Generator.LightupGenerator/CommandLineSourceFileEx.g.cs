﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.CommandLineSourceFile.</summary>
    public static partial class CommandLineSourceFileEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CommandLineSourceFile";

        private delegate Microsoft.CodeAnalysis.CommandLineSourceFile ConstructorDelegate0(global::System.String path, global::System.Boolean isScript, global::System.Boolean isInputRedirected);

        private delegate global::System.Boolean IsInputRedirectedGetterDelegate(global::Microsoft.CodeAnalysis.CommandLineSourceFile _obj);

        private static readonly ConstructorDelegate0 ConstructorFunc0;

        private static readonly IsInputRedirectedGetterDelegate IsInputRedirectedGetterFunc;

        static CommandLineSourceFileEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ConstructorFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate0>(wrappedType, "pathString", "isScriptBoolean", "isInputRedirectedBoolean");

            IsInputRedirectedGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsInputRedirectedGetterDelegate>(wrappedType, nameof(IsInputRedirected));
        }

        /// <summary>Constructor added in version 3.6.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CommandLineSourceFile Create(global::System.String path, global::System.Boolean isScript, global::System.Boolean isInputRedirected)
        {
            return ConstructorFunc0(path, isScript, isInputRedirected);
        }

        /// <summary>Property added in version 3.6.0.0.</summary>
        public static global::System.Boolean IsInputRedirected(this global::Microsoft.CodeAnalysis.CommandLineSourceFile _obj)
        {
            return IsInputRedirectedGetterFunc(_obj);
        }
    }
}