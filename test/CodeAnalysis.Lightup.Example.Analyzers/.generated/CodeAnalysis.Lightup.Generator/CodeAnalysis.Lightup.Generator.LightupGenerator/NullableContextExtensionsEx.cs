﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.NullableContextExtensions. Added in version 3.8.0.0.</summary>
    public static partial class NullableContextExtensionsEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.NullableContextExtensions";

        private delegate global::System.Boolean AnnotationsEnabledDelegate0(global::Microsoft.CodeAnalysis.Lightup.NullableContextEx context);
        private delegate global::System.Boolean AnnotationsInheritedDelegate1(global::Microsoft.CodeAnalysis.Lightup.NullableContextEx context);
        private delegate global::System.Boolean WarningsEnabledDelegate2(global::Microsoft.CodeAnalysis.Lightup.NullableContextEx context);
        private delegate global::System.Boolean WarningsInheritedDelegate3(global::Microsoft.CodeAnalysis.Lightup.NullableContextEx context);

        private static readonly AnnotationsEnabledDelegate0 AnnotationsEnabledFunc0;
        private static readonly AnnotationsInheritedDelegate1 AnnotationsInheritedFunc1;
        private static readonly WarningsEnabledDelegate2 WarningsEnabledFunc2;
        private static readonly WarningsInheritedDelegate3 WarningsInheritedFunc3;

        static NullableContextExtensionsEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            AnnotationsEnabledFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<AnnotationsEnabledDelegate0>(wrappedType, "AnnotationsEnabled", "contextNullableContext");
            AnnotationsInheritedFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<AnnotationsInheritedDelegate1>(wrappedType, "AnnotationsInherited", "contextNullableContext");
            WarningsEnabledFunc2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<WarningsEnabledDelegate2>(wrappedType, "WarningsEnabled", "contextNullableContext");
            WarningsInheritedFunc3 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<WarningsInheritedDelegate3>(wrappedType, "WarningsInherited", "contextNullableContext");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::System.Boolean AnnotationsEnabled(this global::Microsoft.CodeAnalysis.Lightup.NullableContextEx context)
            => AnnotationsEnabledFunc0(context);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::System.Boolean AnnotationsInherited(this global::Microsoft.CodeAnalysis.Lightup.NullableContextEx context)
            => AnnotationsInheritedFunc1(context);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::System.Boolean WarningsEnabled(this global::Microsoft.CodeAnalysis.Lightup.NullableContextEx context)
            => WarningsEnabledFunc2(context);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static global::System.Boolean WarningsInherited(this global::Microsoft.CodeAnalysis.Lightup.NullableContextEx context)
            => WarningsInheritedFunc3(context);
    }
}