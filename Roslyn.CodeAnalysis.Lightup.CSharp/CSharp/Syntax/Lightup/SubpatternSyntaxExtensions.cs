﻿// <auto-generated/>

#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.Lightup
{
    /// <summary>Class added in Roslyn version </summary>
    public static class SubpatternSyntaxExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CSharp.Syntax.SubpatternSyntax";

        public static readonly Type? WrappedType;

        private delegate BaseExpressionColonSyntaxWrapper ExpressionColonGetterDelegate(SubpatternSyntax? _obj);

        private delegate SubpatternSyntax UpdateDelegate0(SubpatternSyntax? _obj, BaseExpressionColonSyntaxWrapper expressionColon, PatternSyntax pattern);
        private delegate SubpatternSyntax WithExpressionColonDelegate1(SubpatternSyntax? _obj, BaseExpressionColonSyntaxWrapper expressionColon);

        private static readonly ExpressionColonGetterDelegate ExpressionColonGetterFunc;

        private static readonly UpdateDelegate0 UpdateFunc0;
        private static readonly WithExpressionColonDelegate1 WithExpressionColonFunc1;

        static SubpatternSyntaxExtensions()
        {
            WrappedType = LightupHelper.FindType(WrappedTypeName);

            ExpressionColonGetterFunc = LightupHelper.CreateInstanceGetAccessor<ExpressionColonGetterDelegate>(WrappedType, nameof(ExpressionColon));

            UpdateFunc0 = LightupHelper.CreateInstanceMethodAccessor<UpdateDelegate0>(WrappedType, nameof(Update));
            WithExpressionColonFunc1 = LightupHelper.CreateInstanceMethodAccessor<WithExpressionColonDelegate1>(WrappedType, nameof(WithExpressionColon));
        }

        /// <summary>Added in Roslyn version 4.0.0.0</summary>
        public static BaseExpressionColonSyntaxWrapper ExpressionColon(this SubpatternSyntax _obj)
            => ExpressionColonGetterFunc(_obj);

        /// <summary>Added in Roslyn version 4.0.0.0</summary>
        public static SubpatternSyntax Update(this SubpatternSyntax wrappedObject, BaseExpressionColonSyntaxWrapper expressionColon, PatternSyntax pattern)
            => UpdateFunc0(wrappedObject, expressionColon, pattern);

        /// <summary>Added in Roslyn version 4.0.0.0</summary>
        public static SubpatternSyntax WithExpressionColon(this SubpatternSyntax wrappedObject, BaseExpressionColonSyntaxWrapper expressionColon)
            => WithExpressionColonFunc1(wrappedObject, expressionColon);
    }
}