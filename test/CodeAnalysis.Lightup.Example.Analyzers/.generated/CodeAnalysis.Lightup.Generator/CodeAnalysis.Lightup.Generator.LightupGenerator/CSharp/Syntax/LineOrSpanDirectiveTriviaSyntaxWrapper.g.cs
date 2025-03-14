﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.LineOrSpanDirectiveTriviaSyntax. Added in version 4.0.0.0.</summary>
    public partial struct LineOrSpanDirectiveTriviaSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.LineOrSpanDirectiveTriviaSyntax";

        private static readonly global::System.Type? WrappedType;

        private delegate global::Microsoft.CodeAnalysis.SyntaxToken FileGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken LineKeywordGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax _obj);

        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineOrSpanDirectiveTriviaSyntaxWrapper WithEndOfDirectiveTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken endOfDirectiveToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineOrSpanDirectiveTriviaSyntaxWrapper WithFileDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken file);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineOrSpanDirectiveTriviaSyntaxWrapper WithHashTokenDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken hashToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineOrSpanDirectiveTriviaSyntaxWrapper WithLineKeywordDelegate0(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax _obj, global::Microsoft.CodeAnalysis.SyntaxToken lineKeyword);

        private static readonly FileGetterDelegate FileGetterFunc;
        private static readonly LineKeywordGetterDelegate LineKeywordGetterFunc;

        private static readonly WithEndOfDirectiveTokenDelegate0 WithEndOfDirectiveTokenFunc0;
        private static readonly WithFileDelegate0 WithFileFunc0;
        private static readonly WithHashTokenDelegate0 WithHashTokenFunc0;
        private static readonly WithLineKeywordDelegate0 WithLineKeywordFunc0;

        private readonly global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax wrappedObject;

        static LineOrSpanDirectiveTriviaSyntaxWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            FileGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<FileGetterDelegate>(WrappedType, nameof(File));
            LineKeywordGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<LineKeywordGetterDelegate>(WrappedType, nameof(LineKeyword));

            WithEndOfDirectiveTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithEndOfDirectiveTokenDelegate0>(WrappedType, "WithEndOfDirectiveToken", "endOfDirectiveTokenSyntaxToken");
            WithFileFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithFileDelegate0>(WrappedType, "WithFile", "fileSyntaxToken");
            WithHashTokenFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithHashTokenDelegate0>(WrappedType, "WithHashToken", "hashTokenSyntaxToken");
            WithLineKeywordFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithLineKeywordDelegate0>(WrappedType, "WithLineKeyword", "lineKeywordSyntaxToken");
        }

        private LineOrSpanDirectiveTriviaSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken File
        {
            get { return FileGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken LineKeyword
        {
            get { return LineKeywordGetterFunc(wrappedObject); }
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static explicit operator LineOrSpanDirectiveTriviaSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax obj)
        {
            return Wrap(obj);
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax(LineOrSpanDirectiveTriviaSyntaxWrapper obj)
        {
            return obj.Unwrap();
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static LineOrSpanDirectiveTriviaSyntaxWrapper Wrap(global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Wrap<global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax>(obj, WrappedType);
            return new LineOrSpanDirectiveTriviaSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.DirectiveTriviaSyntax Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineOrSpanDirectiveTriviaSyntaxWrapper WithEndOfDirectiveToken(global::Microsoft.CodeAnalysis.SyntaxToken endOfDirectiveToken)
        {
            return WithEndOfDirectiveTokenFunc0(wrappedObject, endOfDirectiveToken);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineOrSpanDirectiveTriviaSyntaxWrapper WithFile(global::Microsoft.CodeAnalysis.SyntaxToken file)
        {
            return WithFileFunc0(wrappedObject, file);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineOrSpanDirectiveTriviaSyntaxWrapper WithHashToken(global::Microsoft.CodeAnalysis.SyntaxToken hashToken)
        {
            return WithHashTokenFunc0(wrappedObject, hashToken);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineOrSpanDirectiveTriviaSyntaxWrapper WithLineKeyword(global::Microsoft.CodeAnalysis.SyntaxToken lineKeyword)
        {
            return WithLineKeywordFunc0(wrappedObject, lineKeyword);
        }
    }
}
