﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerUnmanagedCallingConventionSyntax. Added in version 3.8.0.0.</summary>
    public partial struct FunctionPointerUnmanagedCallingConventionSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.FunctionPointerUnmanagedCallingConventionSyntax";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.SyntaxToken NameGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj);

        private delegate void AcceptDelegate0(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj, global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerUnmanagedCallingConventionSyntaxWrapper UpdateDelegate0(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj, global::Microsoft.CodeAnalysis.SyntaxToken name);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerUnmanagedCallingConventionSyntaxWrapper WithNameDelegate0(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode _obj, global::Microsoft.CodeAnalysis.SyntaxToken name);

        private static readonly NameGetterDelegate NameGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly UpdateDelegate0 UpdateFunc0;
        private static readonly WithNameDelegate0 WithNameFunc0;

        private readonly global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode wrappedObject;

        static FunctionPointerUnmanagedCallingConventionSyntaxWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            NameGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<NameGetterDelegate>(WrappedType, nameof(Name));

            AcceptFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            UpdateFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate0>(WrappedType, "Update", "nameSyntaxToken");
            WithNameFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithNameDelegate0>(WrappedType, "WithName", "nameSyntaxToken");
        }

        private FunctionPointerUnmanagedCallingConventionSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken Name
        {
            get { return NameGetterFunc(wrappedObject); }
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static explicit operator FunctionPointerUnmanagedCallingConventionSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode obj)
        {
            return Wrap(obj);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode(FunctionPointerUnmanagedCallingConventionSyntaxWrapper obj)
        {
            return obj.Unwrap();
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static FunctionPointerUnmanagedCallingConventionSyntaxWrapper Wrap(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Wrap<global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode>(obj, WrappedType);
            return new FunctionPointerUnmanagedCallingConventionSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public void Accept(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
        {
            AcceptFunc0(wrappedObject, visitor);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerUnmanagedCallingConventionSyntaxWrapper Update(global::Microsoft.CodeAnalysis.SyntaxToken name)
        {
            return UpdateFunc0(wrappedObject, name);
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.FunctionPointerUnmanagedCallingConventionSyntaxWrapper WithName(global::Microsoft.CodeAnalysis.SyntaxToken name)
        {
            return WithNameFunc0(wrappedObject, name);
        }
    }
}
