﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.SymbolVisitor.</summary>
    public static partial class SymbolVisitorExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.SymbolVisitor";

        private delegate void VisitFunctionPointerTypeDelegate0(global::Microsoft.CodeAnalysis.SymbolVisitor? _obj, global::Microsoft.CodeAnalysis.Lightup.IFunctionPointerTypeSymbolWrapper symbol);

        private static readonly VisitFunctionPointerTypeDelegate0 VisitFunctionPointerTypeFunc0;

        static SymbolVisitorExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            VisitFunctionPointerTypeFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerTypeDelegate0>(wrappedType, "VisitFunctionPointerType", "symbolIFunctionPointerTypeSymbol");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static void VisitFunctionPointerType(this global::Microsoft.CodeAnalysis.SymbolVisitor _obj, global::Microsoft.CodeAnalysis.Lightup.IFunctionPointerTypeSymbolWrapper symbol)
            => VisitFunctionPointerTypeFunc0(_obj, symbol);
    }
}