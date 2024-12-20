﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Operations.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Operations.OperationVisitor.</summary>
    public static partial class OperationVisitorExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Operations.OperationVisitor";

        private delegate void VisitAttributeDelegate0(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IAttributeOperationWrapper operation);
        private delegate void VisitBinaryPatternDelegate1(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IBinaryPatternOperationWrapper operation);
        private delegate void VisitCollectionExpressionDelegate2(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.ICollectionExpressionOperationWrapper operation);
        private delegate void VisitFunctionPointerInvocationDelegate3(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IFunctionPointerInvocationOperationWrapper operation);
        private delegate void VisitImplicitIndexerReferenceDelegate4(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IImplicitIndexerReferenceOperationWrapper operation);
        private delegate void VisitInlineArrayAccessDelegate5(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInlineArrayAccessOperationWrapper operation);
        private delegate void VisitInterpolatedStringAdditionDelegate6(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringAdditionOperationWrapper operation);
        private delegate void VisitInterpolatedStringAppendDelegate7(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringAppendOperationWrapper operation);
        private delegate void VisitInterpolatedStringHandlerArgumentPlaceholderDelegate8(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper operation);
        private delegate void VisitInterpolatedStringHandlerCreationDelegate9(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringHandlerCreationOperationWrapper operation);
        private delegate void VisitListPatternDelegate10(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IListPatternOperationWrapper operation);
        private delegate void VisitNegatedPatternDelegate11(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.INegatedPatternOperationWrapper operation);
        private delegate void VisitPropertySubpatternDelegate12(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IPropertySubpatternOperationWrapper operation);
        private delegate void VisitRecursivePatternDelegate13(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IRecursivePatternOperationWrapper operation);
        private delegate void VisitRelationalPatternDelegate14(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IRelationalPatternOperationWrapper operation);
        private delegate void VisitSlicePatternDelegate15(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.ISlicePatternOperationWrapper operation);
        private delegate void VisitSpreadDelegate16(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.ISpreadOperationWrapper operation);
        private delegate void VisitTypePatternDelegate17(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.ITypePatternOperationWrapper operation);
        private delegate void VisitUsingDeclarationDelegate18(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IUsingDeclarationOperationWrapper operation);
        private delegate void VisitUtf8StringDelegate19(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IUtf8StringOperationWrapper operation);
        private delegate void VisitWithDelegate20(global::Microsoft.CodeAnalysis.Operations.OperationVisitor? _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IWithOperationWrapper operation);

        private static readonly VisitAttributeDelegate0 VisitAttributeFunc0;
        private static readonly VisitBinaryPatternDelegate1 VisitBinaryPatternFunc1;
        private static readonly VisitCollectionExpressionDelegate2 VisitCollectionExpressionFunc2;
        private static readonly VisitFunctionPointerInvocationDelegate3 VisitFunctionPointerInvocationFunc3;
        private static readonly VisitImplicitIndexerReferenceDelegate4 VisitImplicitIndexerReferenceFunc4;
        private static readonly VisitInlineArrayAccessDelegate5 VisitInlineArrayAccessFunc5;
        private static readonly VisitInterpolatedStringAdditionDelegate6 VisitInterpolatedStringAdditionFunc6;
        private static readonly VisitInterpolatedStringAppendDelegate7 VisitInterpolatedStringAppendFunc7;
        private static readonly VisitInterpolatedStringHandlerArgumentPlaceholderDelegate8 VisitInterpolatedStringHandlerArgumentPlaceholderFunc8;
        private static readonly VisitInterpolatedStringHandlerCreationDelegate9 VisitInterpolatedStringHandlerCreationFunc9;
        private static readonly VisitListPatternDelegate10 VisitListPatternFunc10;
        private static readonly VisitNegatedPatternDelegate11 VisitNegatedPatternFunc11;
        private static readonly VisitPropertySubpatternDelegate12 VisitPropertySubpatternFunc12;
        private static readonly VisitRecursivePatternDelegate13 VisitRecursivePatternFunc13;
        private static readonly VisitRelationalPatternDelegate14 VisitRelationalPatternFunc14;
        private static readonly VisitSlicePatternDelegate15 VisitSlicePatternFunc15;
        private static readonly VisitSpreadDelegate16 VisitSpreadFunc16;
        private static readonly VisitTypePatternDelegate17 VisitTypePatternFunc17;
        private static readonly VisitUsingDeclarationDelegate18 VisitUsingDeclarationFunc18;
        private static readonly VisitUtf8StringDelegate19 VisitUtf8StringFunc19;
        private static readonly VisitWithDelegate20 VisitWithFunc20;

        static OperationVisitorExtensions()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            VisitAttributeFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitAttributeDelegate0>(wrappedType, "VisitAttribute", "operationIAttributeOperation");
            VisitBinaryPatternFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitBinaryPatternDelegate1>(wrappedType, "VisitBinaryPattern", "operationIBinaryPatternOperation");
            VisitCollectionExpressionFunc2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitCollectionExpressionDelegate2>(wrappedType, "VisitCollectionExpression", "operationICollectionExpressionOperation");
            VisitFunctionPointerInvocationFunc3 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitFunctionPointerInvocationDelegate3>(wrappedType, "VisitFunctionPointerInvocation", "operationIFunctionPointerInvocationOperation");
            VisitImplicitIndexerReferenceFunc4 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitImplicitIndexerReferenceDelegate4>(wrappedType, "VisitImplicitIndexerReference", "operationIImplicitIndexerReferenceOperation");
            VisitInlineArrayAccessFunc5 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitInlineArrayAccessDelegate5>(wrappedType, "VisitInlineArrayAccess", "operationIInlineArrayAccessOperation");
            VisitInterpolatedStringAdditionFunc6 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitInterpolatedStringAdditionDelegate6>(wrappedType, "VisitInterpolatedStringAddition", "operationIInterpolatedStringAdditionOperation");
            VisitInterpolatedStringAppendFunc7 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitInterpolatedStringAppendDelegate7>(wrappedType, "VisitInterpolatedStringAppend", "operationIInterpolatedStringAppendOperation");
            VisitInterpolatedStringHandlerArgumentPlaceholderFunc8 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitInterpolatedStringHandlerArgumentPlaceholderDelegate8>(wrappedType, "VisitInterpolatedStringHandlerArgumentPlaceholder", "operationIInterpolatedStringHandlerArgumentPlaceholderOperation");
            VisitInterpolatedStringHandlerCreationFunc9 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitInterpolatedStringHandlerCreationDelegate9>(wrappedType, "VisitInterpolatedStringHandlerCreation", "operationIInterpolatedStringHandlerCreationOperation");
            VisitListPatternFunc10 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitListPatternDelegate10>(wrappedType, "VisitListPattern", "operationIListPatternOperation");
            VisitNegatedPatternFunc11 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitNegatedPatternDelegate11>(wrappedType, "VisitNegatedPattern", "operationINegatedPatternOperation");
            VisitPropertySubpatternFunc12 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitPropertySubpatternDelegate12>(wrappedType, "VisitPropertySubpattern", "operationIPropertySubpatternOperation");
            VisitRecursivePatternFunc13 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitRecursivePatternDelegate13>(wrappedType, "VisitRecursivePattern", "operationIRecursivePatternOperation");
            VisitRelationalPatternFunc14 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitRelationalPatternDelegate14>(wrappedType, "VisitRelationalPattern", "operationIRelationalPatternOperation");
            VisitSlicePatternFunc15 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitSlicePatternDelegate15>(wrappedType, "VisitSlicePattern", "operationISlicePatternOperation");
            VisitSpreadFunc16 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitSpreadDelegate16>(wrappedType, "VisitSpread", "operationISpreadOperation");
            VisitTypePatternFunc17 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitTypePatternDelegate17>(wrappedType, "VisitTypePattern", "operationITypePatternOperation");
            VisitUsingDeclarationFunc18 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitUsingDeclarationDelegate18>(wrappedType, "VisitUsingDeclaration", "operationIUsingDeclarationOperation");
            VisitUtf8StringFunc19 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitUtf8StringDelegate19>(wrappedType, "VisitUtf8String", "operationIUtf8StringOperation");
            VisitWithFunc20 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<VisitWithDelegate20>(wrappedType, "VisitWith", "operationIWithOperation");
        }

        /// <summary>Method added in version 4.5.0.0.</summary>
        public static void VisitAttribute(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IAttributeOperationWrapper operation)
        {
            VisitAttributeFunc0(_obj, operation);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static void VisitBinaryPattern(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IBinaryPatternOperationWrapper operation)
        {
            VisitBinaryPatternFunc1(_obj, operation);
        }

        /// <summary>Method added in version 4.9.0.0.</summary>
        public static void VisitCollectionExpression(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.ICollectionExpressionOperationWrapper operation)
        {
            VisitCollectionExpressionFunc2(_obj, operation);
        }

        /// <summary>Method added in version 4.1.0.0.</summary>
        public static void VisitFunctionPointerInvocation(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IFunctionPointerInvocationOperationWrapper operation)
        {
            VisitFunctionPointerInvocationFunc3(_obj, operation);
        }

        /// <summary>Method added in version 4.1.0.0.</summary>
        public static void VisitImplicitIndexerReference(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IImplicitIndexerReferenceOperationWrapper operation)
        {
            VisitImplicitIndexerReferenceFunc4(_obj, operation);
        }

        /// <summary>Method added in version 4.7.0.0.</summary>
        public static void VisitInlineArrayAccess(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInlineArrayAccessOperationWrapper operation)
        {
            VisitInlineArrayAccessFunc5(_obj, operation);
        }

        /// <summary>Method added in version 4.1.0.0.</summary>
        public static void VisitInterpolatedStringAddition(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringAdditionOperationWrapper operation)
        {
            VisitInterpolatedStringAdditionFunc6(_obj, operation);
        }

        /// <summary>Method added in version 4.1.0.0.</summary>
        public static void VisitInterpolatedStringAppend(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringAppendOperationWrapper operation)
        {
            VisitInterpolatedStringAppendFunc7(_obj, operation);
        }

        /// <summary>Method added in version 4.1.0.0.</summary>
        public static void VisitInterpolatedStringHandlerArgumentPlaceholder(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringHandlerArgumentPlaceholderOperationWrapper operation)
        {
            VisitInterpolatedStringHandlerArgumentPlaceholderFunc8(_obj, operation);
        }

        /// <summary>Method added in version 4.1.0.0.</summary>
        public static void VisitInterpolatedStringHandlerCreation(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IInterpolatedStringHandlerCreationOperationWrapper operation)
        {
            VisitInterpolatedStringHandlerCreationFunc9(_obj, operation);
        }

        /// <summary>Method added in version 4.1.0.0.</summary>
        public static void VisitListPattern(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IListPatternOperationWrapper operation)
        {
            VisitListPatternFunc10(_obj, operation);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static void VisitNegatedPattern(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.INegatedPatternOperationWrapper operation)
        {
            VisitNegatedPatternFunc11(_obj, operation);
        }

        /// <summary>Method added in version 3.4.0.0.</summary>
        public static void VisitPropertySubpattern(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IPropertySubpatternOperationWrapper operation)
        {
            VisitPropertySubpatternFunc12(_obj, operation);
        }

        /// <summary>Method added in version 3.4.0.0.</summary>
        public static void VisitRecursivePattern(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IRecursivePatternOperationWrapper operation)
        {
            VisitRecursivePatternFunc13(_obj, operation);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static void VisitRelationalPattern(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IRelationalPatternOperationWrapper operation)
        {
            VisitRelationalPatternFunc14(_obj, operation);
        }

        /// <summary>Method added in version 4.1.0.0.</summary>
        public static void VisitSlicePattern(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.ISlicePatternOperationWrapper operation)
        {
            VisitSlicePatternFunc15(_obj, operation);
        }

        /// <summary>Method added in version 4.9.0.0.</summary>
        public static void VisitSpread(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.ISpreadOperationWrapper operation)
        {
            VisitSpreadFunc16(_obj, operation);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static void VisitTypePattern(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.ITypePatternOperationWrapper operation)
        {
            VisitTypePatternFunc17(_obj, operation);
        }

        /// <summary>Method added in version 3.4.0.0.</summary>
        public static void VisitUsingDeclaration(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IUsingDeclarationOperationWrapper operation)
        {
            VisitUsingDeclarationFunc18(_obj, operation);
        }

        /// <summary>Method added in version 4.3.0.0.</summary>
        public static void VisitUtf8String(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IUtf8StringOperationWrapper operation)
        {
            VisitUtf8StringFunc19(_obj, operation);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static void VisitWith(this global::Microsoft.CodeAnalysis.Operations.OperationVisitor _obj, global::Microsoft.CodeAnalysis.Operations.Lightup.IWithOperationWrapper operation)
        {
            VisitWithFunc20(_obj, operation);
        }
    }
}
