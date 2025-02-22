﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.SymbolDisplayFormat.</summary>
    public static partial class SymbolDisplayFormatEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.SymbolDisplayFormat";

        private delegate global::Microsoft.CodeAnalysis.SymbolDisplayFormat RemoveGenericsOptionsDelegate0(global::Microsoft.CodeAnalysis.SymbolDisplayFormat _obj, global::Microsoft.CodeAnalysis.SymbolDisplayGenericsOptions options);
        private delegate global::Microsoft.CodeAnalysis.SymbolDisplayFormat RemoveLocalOptionsDelegate1(global::Microsoft.CodeAnalysis.SymbolDisplayFormat _obj, global::Microsoft.CodeAnalysis.SymbolDisplayLocalOptions options);
        private delegate global::Microsoft.CodeAnalysis.SymbolDisplayFormat RemoveMiscellaneousOptionsDelegate2(global::Microsoft.CodeAnalysis.SymbolDisplayFormat _obj, global::Microsoft.CodeAnalysis.SymbolDisplayMiscellaneousOptions options);

        private static readonly RemoveGenericsOptionsDelegate0 RemoveGenericsOptionsFunc0;
        private static readonly RemoveLocalOptionsDelegate1 RemoveLocalOptionsFunc1;
        private static readonly RemoveMiscellaneousOptionsDelegate2 RemoveMiscellaneousOptionsFunc2;

        static SymbolDisplayFormatEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            RemoveGenericsOptionsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RemoveGenericsOptionsDelegate0>(wrappedType, "RemoveGenericsOptions", "optionsSymbolDisplayGenericsOptions");
            RemoveLocalOptionsFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RemoveLocalOptionsDelegate1>(wrappedType, "RemoveLocalOptions", "optionsSymbolDisplayLocalOptions");
            RemoveMiscellaneousOptionsFunc2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RemoveMiscellaneousOptionsDelegate2>(wrappedType, "RemoveMiscellaneousOptions", "optionsSymbolDisplayMiscellaneousOptions");
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SymbolDisplayFormat RemoveGenericsOptions(this global::Microsoft.CodeAnalysis.SymbolDisplayFormat _obj, global::Microsoft.CodeAnalysis.SymbolDisplayGenericsOptions options)
        {
            return RemoveGenericsOptionsFunc0(_obj, options);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SymbolDisplayFormat RemoveLocalOptions(this global::Microsoft.CodeAnalysis.SymbolDisplayFormat _obj, global::Microsoft.CodeAnalysis.SymbolDisplayLocalOptions options)
        {
            return RemoveLocalOptionsFunc1(_obj, options);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.SymbolDisplayFormat RemoveMiscellaneousOptions(this global::Microsoft.CodeAnalysis.SymbolDisplayFormat _obj, global::Microsoft.CodeAnalysis.SymbolDisplayMiscellaneousOptions options)
        {
            return RemoveMiscellaneousOptionsFunc2(_obj, options);
        }
    }
}
