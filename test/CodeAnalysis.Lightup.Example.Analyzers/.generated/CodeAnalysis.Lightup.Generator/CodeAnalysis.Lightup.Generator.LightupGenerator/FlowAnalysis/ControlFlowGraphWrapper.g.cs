﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.FlowAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.FlowAnalysis.ControlFlowGraph. Added in version 2.9.0.0.</summary>
    public partial struct ControlFlowGraphWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.FlowAnalysis.ControlFlowGraph";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.BasicBlockWrapper> BlocksGetterDelegate(global::System.Object _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IMethodSymbol> LocalFunctionsGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.IOperation OriginalOperationGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper? ParentGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowRegionWrapper RootGetterDelegate(global::System.Object _obj);

        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper CreateDelegate0(global::Microsoft.CodeAnalysis.Operations.Lightup.IAttributeOperationWrapper attribute, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper CreateDelegate1(global::Microsoft.CodeAnalysis.Operations.IBlockOperation body, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper CreateDelegate2(global::Microsoft.CodeAnalysis.Operations.Lightup.IConstructorBodyOperationWrapper constructorBody, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper CreateDelegate3(global::Microsoft.CodeAnalysis.Operations.IFieldInitializerOperation initializer, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper CreateDelegate4(global::Microsoft.CodeAnalysis.Operations.IPropertyInitializerOperation initializer, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper CreateDelegate5(global::Microsoft.CodeAnalysis.Operations.IParameterInitializerOperation initializer, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper CreateDelegate6(global::Microsoft.CodeAnalysis.Operations.Lightup.IMethodBodyOperationWrapper methodBody, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper? CreateDelegate7(global::Microsoft.CodeAnalysis.SyntaxNode node, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::System.Threading.CancellationToken cancellationToken);

        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper GetAnonymousFunctionControlFlowGraphDelegate0(global::System.Object _obj, global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.IFlowAnonymousFunctionOperationWrapper anonymousFunction, global::System.Threading.CancellationToken cancellationToken);
        private delegate global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper GetLocalFunctionControlFlowGraphDelegate1(global::System.Object _obj, global::Microsoft.CodeAnalysis.IMethodSymbol localFunction, global::System.Threading.CancellationToken cancellationToken);

        private static readonly BlocksGetterDelegate BlocksGetterFunc;
        private static readonly LocalFunctionsGetterDelegate LocalFunctionsGetterFunc;
        private static readonly OriginalOperationGetterDelegate OriginalOperationGetterFunc;
        private static readonly ParentGetterDelegate ParentGetterFunc;
        private static readonly RootGetterDelegate RootGetterFunc;

        private static readonly CreateDelegate0 CreateFunc0;
        private static readonly CreateDelegate1 CreateFunc1;
        private static readonly CreateDelegate2 CreateFunc2;
        private static readonly CreateDelegate3 CreateFunc3;
        private static readonly CreateDelegate4 CreateFunc4;
        private static readonly CreateDelegate5 CreateFunc5;
        private static readonly CreateDelegate6 CreateFunc6;
        private static readonly CreateDelegate7 CreateFunc7;

        private static readonly GetAnonymousFunctionControlFlowGraphDelegate0 GetAnonymousFunctionControlFlowGraphFunc0;
        private static readonly GetLocalFunctionControlFlowGraphDelegate1 GetLocalFunctionControlFlowGraphFunc1;

        private readonly global::System.Object wrappedObject;

        static ControlFlowGraphWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            BlocksGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<BlocksGetterDelegate>(WrappedType, nameof(Blocks));
            LocalFunctionsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<LocalFunctionsGetterDelegate>(WrappedType, nameof(LocalFunctions));
            OriginalOperationGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<OriginalOperationGetterDelegate>(WrappedType, nameof(OriginalOperation));
            ParentGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ParentGetterDelegate>(WrappedType, nameof(Parent));
            RootGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<RootGetterDelegate>(WrappedType, nameof(Root));

            CreateFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate0>(WrappedType, "Create", "attributeIAttributeOperation", "cancellationTokenCancellationToken");
            CreateFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate1>(WrappedType, "Create", "bodyIBlockOperation", "cancellationTokenCancellationToken");
            CreateFunc2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate2>(WrappedType, "Create", "constructorBodyIConstructorBodyOperation", "cancellationTokenCancellationToken");
            CreateFunc3 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate3>(WrappedType, "Create", "initializerIFieldInitializerOperation", "cancellationTokenCancellationToken");
            CreateFunc4 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate4>(WrappedType, "Create", "initializerIPropertyInitializerOperation", "cancellationTokenCancellationToken");
            CreateFunc5 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate5>(WrappedType, "Create", "initializerIParameterInitializerOperation", "cancellationTokenCancellationToken");
            CreateFunc6 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate6>(WrappedType, "Create", "methodBodyIMethodBodyOperation", "cancellationTokenCancellationToken");
            CreateFunc7 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<CreateDelegate7>(WrappedType, "Create", "nodeSyntaxNode", "semanticModelSemanticModel", "cancellationTokenCancellationToken");

            GetAnonymousFunctionControlFlowGraphFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<GetAnonymousFunctionControlFlowGraphDelegate0>(WrappedType, "GetAnonymousFunctionControlFlowGraph", "anonymousFunctionIFlowAnonymousFunctionOperation", "cancellationTokenCancellationToken");
            GetLocalFunctionControlFlowGraphFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<GetLocalFunctionControlFlowGraphDelegate1>(WrappedType, "GetLocalFunctionControlFlowGraph", "localFunctionIMethodSymbol", "cancellationTokenCancellationToken");
        }

        private ControlFlowGraphWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.BasicBlockWrapper> Blocks
        {
            get { return BlocksGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.IMethodSymbol> LocalFunctions
        {
            get { return LocalFunctionsGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::Microsoft.CodeAnalysis.IOperation OriginalOperation
        {
            get { return OriginalOperationGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 3.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper? Parent
        {
            get { return ParentGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.9.0.0.</summary>
        public global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowRegionWrapper Root
        {
            get { return RootGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ControlFlowGraphWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new ControlFlowGraphWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 4.5.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper Create(global::Microsoft.CodeAnalysis.Operations.Lightup.IAttributeOperationWrapper attribute, global::System.Threading.CancellationToken cancellationToken)
        {
            return CreateFunc0(attribute, cancellationToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper Create(global::Microsoft.CodeAnalysis.Operations.IBlockOperation body, global::System.Threading.CancellationToken cancellationToken)
        {
            return CreateFunc1(body, cancellationToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper Create(global::Microsoft.CodeAnalysis.Operations.Lightup.IConstructorBodyOperationWrapper constructorBody, global::System.Threading.CancellationToken cancellationToken)
        {
            return CreateFunc2(constructorBody, cancellationToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper Create(global::Microsoft.CodeAnalysis.Operations.IFieldInitializerOperation initializer, global::System.Threading.CancellationToken cancellationToken)
        {
            return CreateFunc3(initializer, cancellationToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper Create(global::Microsoft.CodeAnalysis.Operations.IPropertyInitializerOperation initializer, global::System.Threading.CancellationToken cancellationToken)
        {
            return CreateFunc4(initializer, cancellationToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper Create(global::Microsoft.CodeAnalysis.Operations.IParameterInitializerOperation initializer, global::System.Threading.CancellationToken cancellationToken)
        {
            return CreateFunc5(initializer, cancellationToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper Create(global::Microsoft.CodeAnalysis.Operations.Lightup.IMethodBodyOperationWrapper methodBody, global::System.Threading.CancellationToken cancellationToken)
        {
            return CreateFunc6(methodBody, cancellationToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper? Create(global::Microsoft.CodeAnalysis.SyntaxNode node, global::Microsoft.CodeAnalysis.SemanticModel semanticModel, global::System.Threading.CancellationToken cancellationToken)
        {
            return CreateFunc7(node, semanticModel, cancellationToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper GetAnonymousFunctionControlFlowGraph(global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.IFlowAnonymousFunctionOperationWrapper anonymousFunction, global::System.Threading.CancellationToken cancellationToken)
        {
            return GetAnonymousFunctionControlFlowGraphFunc0(wrappedObject, anonymousFunction, cancellationToken);
        }

        /// <summary>Method added in version 2.9.0.0.</summary>
        public global::Microsoft.CodeAnalysis.FlowAnalysis.Lightup.ControlFlowGraphWrapper GetLocalFunctionControlFlowGraph(global::Microsoft.CodeAnalysis.IMethodSymbol localFunction, global::System.Threading.CancellationToken cancellationToken)
        {
            return GetLocalFunctionControlFlowGraphFunc1(wrappedObject, localFunction, cancellationToken);
        }
    }
}