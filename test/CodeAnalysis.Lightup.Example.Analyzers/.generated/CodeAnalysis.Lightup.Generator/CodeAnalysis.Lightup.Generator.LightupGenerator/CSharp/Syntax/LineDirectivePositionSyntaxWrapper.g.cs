﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.CSharp.Syntax.LineDirectivePositionSyntax. Added in version 4.0.0.0.</summary>
    public partial struct LineDirectivePositionSyntaxWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.LineDirectivePositionSyntax";

        private static readonly global::System.Type? WrappedType; // NOTE: Used via reflection

        private delegate global::Microsoft.CodeAnalysis.SyntaxToken CharacterGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken CloseParenTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken CommaTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken LineGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken OpenParenTokenGetterDelegate(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj);

        private delegate void AcceptDelegate0(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj, global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper UpdateDelegate1(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.SyntaxToken line, global::Microsoft.CodeAnalysis.SyntaxToken commaToken, global::Microsoft.CodeAnalysis.SyntaxToken character, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithCharacterDelegate2(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj, global::Microsoft.CodeAnalysis.SyntaxToken character);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithCloseParenTokenDelegate3(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithCommaTokenDelegate4(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj, global::Microsoft.CodeAnalysis.SyntaxToken commaToken);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithLineDelegate5(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj, global::Microsoft.CodeAnalysis.SyntaxToken line);
        private delegate global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithOpenParenTokenDelegate6(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? _obj, global::Microsoft.CodeAnalysis.SyntaxToken openParenToken);

        private static readonly CharacterGetterDelegate CharacterGetterFunc;
        private static readonly CloseParenTokenGetterDelegate CloseParenTokenGetterFunc;
        private static readonly CommaTokenGetterDelegate CommaTokenGetterFunc;
        private static readonly LineGetterDelegate LineGetterFunc;
        private static readonly OpenParenTokenGetterDelegate OpenParenTokenGetterFunc;

        private static readonly AcceptDelegate0 AcceptFunc0;
        private static readonly UpdateDelegate1 UpdateFunc1;
        private static readonly WithCharacterDelegate2 WithCharacterFunc2;
        private static readonly WithCloseParenTokenDelegate3 WithCloseParenTokenFunc3;
        private static readonly WithCommaTokenDelegate4 WithCommaTokenFunc4;
        private static readonly WithLineDelegate5 WithLineFunc5;
        private static readonly WithOpenParenTokenDelegate6 WithOpenParenTokenFunc6;

        private readonly global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? wrappedObject;

        static LineDirectivePositionSyntaxWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.FindType(WrappedTypeName);

            CharacterGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CharacterGetterDelegate>(WrappedType, nameof(Character));
            CloseParenTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CloseParenTokenGetterDelegate>(WrappedType, nameof(CloseParenToken));
            CommaTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CommaTokenGetterDelegate>(WrappedType, nameof(CommaToken));
            LineGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<LineGetterDelegate>(WrappedType, nameof(Line));
            OpenParenTokenGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<OpenParenTokenGetterDelegate>(WrappedType, nameof(OpenParenToken));

            AcceptFunc0 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AcceptDelegate0>(WrappedType, "Accept", "visitorCSharpSyntaxVisitor");
            UpdateFunc1 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<UpdateDelegate1>(WrappedType, "Update", "openParenTokenSyntaxToken", "lineSyntaxToken", "commaTokenSyntaxToken", "characterSyntaxToken", "closeParenTokenSyntaxToken");
            WithCharacterFunc2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithCharacterDelegate2>(WrappedType, "WithCharacter", "characterSyntaxToken");
            WithCloseParenTokenFunc3 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithCloseParenTokenDelegate3>(WrappedType, "WithCloseParenToken", "closeParenTokenSyntaxToken");
            WithCommaTokenFunc4 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithCommaTokenDelegate4>(WrappedType, "WithCommaToken", "commaTokenSyntaxToken");
            WithLineFunc5 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithLineDelegate5>(WrappedType, "WithLine", "lineSyntaxToken");
            WithOpenParenTokenFunc6 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<WithOpenParenTokenDelegate6>(WrappedType, "WithOpenParenToken", "openParenTokenSyntaxToken");
        }

        private LineDirectivePositionSyntaxWrapper(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken Character
        {
            get { return CharacterGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken CloseParenToken
        {
            get { return CloseParenTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken CommaToken
        {
            get { return CommaTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken Line
        {
            get { return LineGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.SyntaxToken OpenParenToken
        {
            get { return OpenParenTokenGetterFunc(wrappedObject); }
        }

        /// <summary>Returns the wrapped object.</summary>
        public static implicit operator global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode?(LineDirectivePositionSyntaxWrapper obj)
        {
            return obj.Unwrap();
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>
        public static LineDirectivePositionSyntaxWrapper As(global::System.Object? obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.As<global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode>(obj, WrappedType);
            return new LineDirectivePositionSyntaxWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode? Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public void Accept(global::Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor visitor)
        {
            AcceptFunc0(wrappedObject, visitor);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper Update(global::Microsoft.CodeAnalysis.SyntaxToken openParenToken, global::Microsoft.CodeAnalysis.SyntaxToken line, global::Microsoft.CodeAnalysis.SyntaxToken commaToken, global::Microsoft.CodeAnalysis.SyntaxToken character, global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken)
        {
            return UpdateFunc1(wrappedObject, openParenToken, line, commaToken, character, closeParenToken);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithCharacter(global::Microsoft.CodeAnalysis.SyntaxToken character)
        {
            return WithCharacterFunc2(wrappedObject, character);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithCloseParenToken(global::Microsoft.CodeAnalysis.SyntaxToken closeParenToken)
        {
            return WithCloseParenTokenFunc3(wrappedObject, closeParenToken);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithCommaToken(global::Microsoft.CodeAnalysis.SyntaxToken commaToken)
        {
            return WithCommaTokenFunc4(wrappedObject, commaToken);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithLine(global::Microsoft.CodeAnalysis.SyntaxToken line)
        {
            return WithLineFunc5(wrappedObject, line);
        }

        /// <summary>Method added in version 4.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LineDirectivePositionSyntaxWrapper WithOpenParenToken(global::Microsoft.CodeAnalysis.SyntaxToken openParenToken)
        {
            return WithOpenParenTokenFunc6(wrappedObject, openParenToken);
        }
    }
}