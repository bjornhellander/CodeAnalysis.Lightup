﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.DesktopStrongNameProvider.</summary>
    public static partial class DesktopStrongNameProviderEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.DesktopStrongNameProvider";

        private delegate Microsoft.CodeAnalysis.DesktopStrongNameProvider ConstructorDelegate0(global::System.Collections.Immutable.ImmutableArray<global::System.String> keyFileSearchPaths, global::System.String? tempPath);

        private static readonly ConstructorDelegate0 ConstructorFunc0;

        static DesktopStrongNameProviderEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ConstructorFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate0>(wrappedType, "keyFileSearchPathsImmutableArray`1", "tempPathString");
        }

        /// <summary>Constructor added in version 2.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.DesktopStrongNameProvider Create(global::System.Collections.Immutable.ImmutableArray<global::System.String> keyFileSearchPaths, global::System.String? tempPath)
        {
            return ConstructorFunc0(keyFileSearchPaths, tempPath);
        }
    }
}
