﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedVariableDesignationSyntax. Added in version 2.0.0.0.</summary>
    public partial struct ParenthesizedVariableDesignationSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedVariableDesignationSyntax";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.SyntaxToken CloseParenTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken OpenParenTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj);
        private delegate global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.VariableDesignationSyntaxWrapper> VariablesGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj);

        private delegate void AcceptDelegate0(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj, global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper AddVariablesDelegate1(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj, params global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.VariableDesignationSyntaxWrapper[] items);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper UpdateDelegate2(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.VariableDesignationSyntaxWrapper> variables, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper WithCloseParenTokenDelegate3(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper WithOpenParenTokenDelegate4(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper WithVariablesDelegate5(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj, global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.VariableDesignationSyntaxWrapper> variables);

        private static readonly CloseParenTokenGetterDelegate CloseParenTokenGetterFunc;
        private static readonly OpenParenTokenGetterDelegate OpenParenTokenGetterFunc;
        private static readonly VariablesGetterDelegate VariablesGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly AddVariablesDelegate1 AddVariablesFunc1;
        private static readonly UpdateDelegate2 UpdateFunc2;
        private static readonly WithCloseParenTokenDelegate3 WithCloseParenTokenFunc3;
        private static readonly WithOpenParenTokenDelegate4 WithOpenParenTokenFunc4;
        private static readonly WithVariablesDelegate5 WithVariablesFunc5;

        private readonly global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode wrappedObject;

        static ParenthesizedVariableDesignationSyntaxWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            CloseParenTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CloseParenTokenGetterDelegate>(WrappedType, nameof(CloseParenToken));
            OpenParenTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<OpenParenTokenGetterDelegate>(WrappedType, nameof(OpenParenToken));
            VariablesGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<VariablesGetterDelegate>(WrappedType, nameof(Variables));

            AcceptFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            AddVariablesFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddVariablesDelegate1>(WrappedType, "AddVariables", "itemsVariableDesignationSyntax[]");
            UpdateFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate2>(WrappedType, "Update", "openParenTokenSyntaxToken", "variablesSeparatedSyntaxList`1", "closeParenTokenSyntaxToken");
            WithCloseParenTokenFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithCloseParenTokenDelegate3>(WrappedType, "WithCloseParenToken", "closeParenTokenSyntaxToken");
            WithOpenParenTokenFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithOpenParenTokenDelegate4>(WrappedType, "WithOpenParenToken", "openParenTokenSyntaxToken");
            WithVariablesFunc5 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithVariablesDelegate5>(WrappedType, "WithVariables", "variablesSeparatedSyntaxList`1");
        }

        private ParenthesizedVariableDesignationSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken CloseParenToken
        {
            get { return CloseParenTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken OpenParenToken
        {
            get { return OpenParenTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.VariableDesignationSyntaxWrapper> Variables
        {
            get { return VariablesGetterFunc(wrappedObject); }
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static explicit operator ParenthesizedVariableDesignationSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode obj)
        {
            return Wrap(obj);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode(ParenthesizedVariableDesignationSyntaxWrapper obj)
        {
            return obj.Unwrap();
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static ParenthesizedVariableDesignationSyntaxWrapper Wrap(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Wrap<global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode>(obj, WrappedType);
            return new ParenthesizedVariableDesignationSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public void Accept(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
        {
            AcceptFunc0(wrappedObject, visitor);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper AddVariables(params global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.VariableDesignationSyntaxWrapper[] items)
        {
            return AddVariablesFunc1(wrappedObject, items);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper Update(global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.VariableDesignationSyntaxWrapper> variables, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken)
        {
            return UpdateFunc2(wrappedObject, openParenToken, variables, closeParenToken);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper WithCloseParenToken(global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken)
        {
            return WithCloseParenTokenFunc3(wrappedObject, closeParenToken);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper WithOpenParenToken(global::Microsoft.CodeAnalysis.SyntaxToken openParenToken)
        {
            return WithOpenParenTokenFunc4(wrappedObject, openParenToken);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.ParenthesizedVariableDesignationSyntaxWrapper WithVariables(global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.VariableDesignationSyntaxWrapper> variables)
        {
            return WithVariablesFunc5(wrappedObject, variables);
        }
    }
}
