﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.SyntaxNodeOrToken.</summary>
    public static partial class SyntaxNodeOrTokenEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.SyntaxNodeOrToken";

        private delegate global::System.Boolean IsIncrementallyIdenticalToDelegate0(global::Microsoft.CodeAnalysis.SyntaxNodeOrToken _obj, global::Microsoft.CodeAnalysis.SyntaxNodeOrToken other);

        private static readonly IsIncrementallyIdenticalToDelegate0 IsIncrementallyIdenticalToFunc0;

        static SyntaxNodeOrTokenEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            IsIncrementallyIdenticalToFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<IsIncrementallyIdenticalToDelegate0>(wrappedType, "IsIncrementallyIdenticalTo", "otherSyntaxNodeOrToken");
        }

        /// <summary>Method added in version 3.10.0.0.</summary>
        public static global::System.Boolean IsIncrementallyIdenticalTo(this global::Microsoft.CodeAnalysis.SyntaxNodeOrToken _obj, global::Microsoft.CodeAnalysis.SyntaxNodeOrToken other)
        {
            return IsIncrementallyIdenticalToFunc0(_obj, other);
        }
    }
}
