﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Diagnostics.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Diagnostics.SymbolStartAnalysisContext. Added in version 3.0.0.0.</summary>
    public partial struct SymbolStartAnalysisContextWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Diagnostics.SymbolStartAnalysisContext";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::System.Threading.CancellationToken CancellationTokenGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.Compilation CompilationGetterDelegate(global::System.Object _obj);
        private delegate global::System.Nullable<global::Microsoft.CodeAnalysis.Text.TextSpan> FilterSpanGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxTree? FilterTreeGetterDelegate(global::System.Object _obj);
        private delegate global::System.Boolean IsGeneratedCodeGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.Diagnostics.AnalyzerOptions OptionsGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.ISymbol SymbolGetterDelegate(global::System.Object _obj);

        private delegate void RegisterCodeBlockActionDelegate0(global::System.Object _obj, global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.CodeBlockAnalysisContext> action);
        private delegate void RegisterOperationActionDelegate1(global::System.Object _obj, global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.OperationAnalysisContext> action, params global::Microsoft.CodeAnalysis.OperationKind[] operationKinds);
        private delegate void RegisterOperationActionDelegate2(global::System.Object _obj, global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.OperationAnalysisContext> action, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.OperationKind> operationKinds);
        private delegate void RegisterOperationBlockActionDelegate3(global::System.Object _obj, global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockAnalysisContext> action);
        private delegate void RegisterOperationBlockStartActionDelegate4(global::System.Object _obj, global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext> action);
        private delegate void RegisterSymbolEndActionDelegate5(global::System.Object _obj, global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.SymbolAnalysisContext> action);

        private static readonly CancellationTokenGetterDelegate CancellationTokenGetterFunc;
        private static readonly CompilationGetterDelegate CompilationGetterFunc;
        private static readonly FilterSpanGetterDelegate FilterSpanGetterFunc;
        private static readonly FilterTreeGetterDelegate FilterTreeGetterFunc;
        private static readonly IsGeneratedCodeGetterDelegate IsGeneratedCodeGetterFunc;
        private static readonly OptionsGetterDelegate OptionsGetterFunc;
        private static readonly SymbolGetterDelegate SymbolGetterFunc;

        private static readonly RegisterCodeBlockActionDelegate0 RegisterCodeBlockActionFunc0;
        private static readonly RegisterOperationActionDelegate1 RegisterOperationActionFunc1;
        private static readonly RegisterOperationActionDelegate2 RegisterOperationActionFunc2;
        private static readonly RegisterOperationBlockActionDelegate3 RegisterOperationBlockActionFunc3;
        private static readonly RegisterOperationBlockStartActionDelegate4 RegisterOperationBlockStartActionFunc4;
        private static readonly RegisterSymbolEndActionDelegate5 RegisterSymbolEndActionFunc5;

        private readonly global::System.Object wrappedObject;

        static SymbolStartAnalysisContextWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            CancellationTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<CancellationTokenGetterDelegate>(WrappedType, nameof(CancellationToken));
            CompilationGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<CompilationGetterDelegate>(WrappedType, nameof(Compilation));
            FilterSpanGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<FilterSpanGetterDelegate>(WrappedType, nameof(FilterSpan));
            FilterTreeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<FilterTreeGetterDelegate>(WrappedType, nameof(FilterTree));
            IsGeneratedCodeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<IsGeneratedCodeGetterDelegate>(WrappedType, nameof(IsGeneratedCode));
            OptionsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<OptionsGetterDelegate>(WrappedType, nameof(Options));
            SymbolGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<SymbolGetterDelegate>(WrappedType, nameof(Symbol));

            RegisterCodeBlockActionFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RegisterCodeBlockActionDelegate0>(WrappedType, "RegisterCodeBlockAction", "actionAction`1");
            RegisterOperationActionFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RegisterOperationActionDelegate1>(WrappedType, "RegisterOperationAction", "actionAction`1", "operationKindsOperationKind[]");
            RegisterOperationActionFunc2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RegisterOperationActionDelegate2>(WrappedType, "RegisterOperationAction", "actionAction`1", "operationKindsImmutableArray`1");
            RegisterOperationBlockActionFunc3 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RegisterOperationBlockActionDelegate3>(WrappedType, "RegisterOperationBlockAction", "actionAction`1");
            RegisterOperationBlockStartActionFunc4 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RegisterOperationBlockStartActionDelegate4>(WrappedType, "RegisterOperationBlockStartAction", "actionAction`1");
            RegisterSymbolEndActionFunc5 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<RegisterSymbolEndActionDelegate5>(WrappedType, "RegisterSymbolEndAction", "actionAction`1");
        }

        private SymbolStartAnalysisContextWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::System.Threading.CancellationToken CancellationToken
        {
            get { return CancellationTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Compilation Compilation
        {
            get { return CompilationGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.7.0.0.</summary>
        public global::System.Nullable<global::Microsoft.CodeAnalysis.Text.TextSpan> FilterSpan
        {
            get { return FilterSpanGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.7.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxTree? FilterTree
        {
            get { return FilterTreeGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public global::System.Boolean IsGeneratedCode
        {
            get { return IsGeneratedCodeGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Diagnostics.AnalyzerOptions Options
        {
            get { return OptionsGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.ISymbol Symbol
        {
            get { return SymbolGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static SymbolStartAnalysisContextWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new SymbolStartAnalysisContextWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public void RegisterCodeBlockAction(global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.CodeBlockAnalysisContext> action)
        {
            RegisterCodeBlockActionFunc0(wrappedObject, action);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public void RegisterOperationAction(global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.OperationAnalysisContext> action, params global::Microsoft.CodeAnalysis.OperationKind[] operationKinds)
        {
            RegisterOperationActionFunc1(wrappedObject, action, operationKinds);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public void RegisterOperationAction(global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.OperationAnalysisContext> action, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.OperationKind> operationKinds)
        {
            RegisterOperationActionFunc2(wrappedObject, action, operationKinds);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public void RegisterOperationBlockAction(global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockAnalysisContext> action)
        {
            RegisterOperationBlockActionFunc3(wrappedObject, action);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public void RegisterOperationBlockStartAction(global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.OperationBlockStartAnalysisContext> action)
        {
            RegisterOperationBlockStartActionFunc4(wrappedObject, action);
        }

        /// <summary>Method added in version 3.0.0.0.</summary>
        public void RegisterSymbolEndAction(global::System.Action<global::Microsoft.CodeAnalysis.Diagnostics.SymbolAnalysisContext> action)
        {
            RegisterSymbolEndActionFunc5(wrappedObject, action);
        }
    }
}