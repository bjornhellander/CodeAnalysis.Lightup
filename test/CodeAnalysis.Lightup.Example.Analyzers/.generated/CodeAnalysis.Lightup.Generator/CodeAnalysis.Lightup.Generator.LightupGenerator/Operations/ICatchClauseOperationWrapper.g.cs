﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.Operations.ICatchClauseOperation. Added in version 2.6.0.0.</summary>
    public partial struct ICatchClauseOperationWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.ICatchClauseOperation";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.IOperation? ExceptionDeclarationOrExpressionGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.ITypeSymbol ExceptionTypeGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.IOperation? FilterGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::Microsoft.CodeAnalysis.Operations.Lightup.IBlockOperationWrapper HandlerGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.ILocalSymbol> LocalsGetterDelegate(global::Microsoft.CodeAnalysis.IOperation _obj);

        private static readonly ExceptionDeclarationOrExpressionGetterDelegate ExceptionDeclarationOrExpressionGetterFunc;
        private static readonly ExceptionTypeGetterDelegate ExceptionTypeGetterFunc;
        private static readonly FilterGetterDelegate FilterGetterFunc;
        private static readonly HandlerGetterDelegate HandlerGetterFunc;
        private static readonly LocalsGetterDelegate LocalsGetterFunc;

        private readonly global::Microsoft.CodeAnalysis.IOperation wrappedObject;

        static ICatchClauseOperationWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ExceptionDeclarationOrExpressionGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ExceptionDeclarationOrExpressionGetterDelegate>(WrappedType, nameof(ExceptionDeclarationOrExpression));
            ExceptionTypeGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ExceptionTypeGetterDelegate>(WrappedType, nameof(ExceptionType));
            FilterGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<FilterGetterDelegate>(WrappedType, nameof(Filter));
            HandlerGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<HandlerGetterDelegate>(WrappedType, nameof(Handler));
            LocalsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<LocalsGetterDelegate>(WrappedType, nameof(Locals));
        }

        private ICatchClauseOperationWrapper(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation? ExceptionDeclarationOrExpression
        {
            get { return ExceptionDeclarationOrExpressionGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.ITypeSymbol ExceptionType
        {
            get { return ExceptionTypeGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation? Filter
        {
            get { return FilterGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Operations.Lightup.IBlockOperationWrapper Handler
        {
            get { return HandlerGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.6.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.ILocalSymbol> Locals
        {
            get { return LocalsGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.IOperation? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ICatchClauseOperationWrapper Wrap(global::Microsoft.CodeAnalysis.IOperation obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::Microsoft.CodeAnalysis.IOperation>(obj, WrappedType);
            return new ICatchClauseOperationWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.IOperation Unwrap()
        {
            return wrappedObject;
        }
    }
}
