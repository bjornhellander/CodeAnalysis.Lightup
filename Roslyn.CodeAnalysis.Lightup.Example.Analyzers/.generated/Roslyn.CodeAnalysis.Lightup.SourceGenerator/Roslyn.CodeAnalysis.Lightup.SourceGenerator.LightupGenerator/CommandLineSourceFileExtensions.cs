﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.CommandLineSourceFile.</summary>
    public static partial class CommandLineSourceFileExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CommandLineSourceFile";

        private delegate CommandLineSourceFile ConstructorDelegate0(System.String path, System.Boolean isScript, System.Boolean isInputRedirected);

        private delegate System.Boolean IsInputRedirectedGetterDelegate(Microsoft.CodeAnalysis.CommandLineSourceFile? _obj);

        private static readonly ConstructorDelegate0 ConstructorFunc0;

        private static readonly IsInputRedirectedGetterDelegate IsInputRedirectedGetterFunc;

        static CommandLineSourceFileExtensions()
        {
            var wrappedType = CommonLightupHelper.FindType(WrappedTypeName);

            ConstructorFunc0 = CommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate0>(wrappedType, "pathString", "isScriptBoolean", "isInputRedirectedBoolean");

            IsInputRedirectedGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<IsInputRedirectedGetterDelegate>(wrappedType, nameof(IsInputRedirected));
        }

        /// <summary>Constructor added in version 3.8.0.0.</summary>
        public static CommandLineSourceFile Create(System.String path, System.Boolean isScript, System.Boolean isInputRedirected)
            => ConstructorFunc0(path, isScript, isInputRedirected);

        /// <summary>Property added in version 3.8.0.0.</summary>
        public static System.Boolean IsInputRedirected(this Microsoft.CodeAnalysis.CommandLineSourceFile _obj)
            => IsInputRedirectedGetterFunc(_obj);
    }
}