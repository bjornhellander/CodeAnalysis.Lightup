﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Classification.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Classification.ClassificationTypeNames.</summary>
    public static partial class ClassificationTypeNamesEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Classification.ClassificationTypeNames";

        private delegate System.String RecordClassNameGetterDelegate();
        private delegate System.String RecordStructNameGetterDelegate();

        private delegate System.Collections.Immutable.ImmutableArray<System.String> AllTypeNamesGetterDelegate();

        private static readonly RecordClassNameGetterDelegate RecordClassNameGetterFunc;
        private static readonly RecordStructNameGetterDelegate RecordStructNameGetterFunc;

        private static readonly AllTypeNamesGetterDelegate AllTypeNamesGetterFunc;

        static ClassificationTypeNamesEx()
        {
            var wrappedType = WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            RecordClassNameGetterFunc = WorkspacesCommonLightupHelper.CreateStaticReadAccessor<RecordClassNameGetterDelegate>(wrappedType, nameof(RecordClassName));
            RecordStructNameGetterFunc = WorkspacesCommonLightupHelper.CreateStaticReadAccessor<RecordStructNameGetterDelegate>(wrappedType, nameof(RecordStructName));

            AllTypeNamesGetterFunc = WorkspacesCommonLightupHelper.CreateStaticGetAccessor<AllTypeNamesGetterDelegate>(wrappedType, nameof(AllTypeNames));
        }

        /// <summary>Field added in version 4.0.0.0.</summary>
        public static System.String RecordClassName
        {
            get => RecordClassNameGetterFunc();
        }

        /// <summary>Field added in version 4.0.0.0.</summary>
        public static System.String RecordStructName
        {
            get => RecordStructNameGetterFunc();
        }

        /// <summary>Property added in version 4.4.0.0.</summary>
        public static System.Collections.Immutable.ImmutableArray<System.String> AllTypeNames()
            => AllTypeNamesGetterFunc();
    }
}