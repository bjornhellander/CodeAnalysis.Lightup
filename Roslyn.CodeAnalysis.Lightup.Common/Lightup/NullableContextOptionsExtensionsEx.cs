﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

// <auto-generated/>

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
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.CodeAnalysis.Operations.Lightup;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.NullableContextOptionsExtensions. Added in version 3.8.0.0.</summary>
    public static class NullableContextOptionsExtensionsEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.NullableContextOptionsExtensions";

        private delegate Boolean AnnotationsEnabledDelegate0(NullableContextOptionsEx context);
        private delegate Boolean WarningsEnabledDelegate1(NullableContextOptionsEx context);

        private static readonly AnnotationsEnabledDelegate0 AnnotationsEnabledFunc0;
        private static readonly WarningsEnabledDelegate1 WarningsEnabledFunc1;

        static NullableContextOptionsExtensionsEx()
        {
            var wrappedType = LightupHelper.FindType(WrappedTypeName);

            AnnotationsEnabledFunc0 = LightupHelper.CreateStaticMethodAccessor<AnnotationsEnabledDelegate0>(wrappedType, "AnnotationsEnabled", "contextNullableContextOptions");
            WarningsEnabledFunc1 = LightupHelper.CreateStaticMethodAccessor<WarningsEnabledDelegate1>(wrappedType, "WarningsEnabled", "contextNullableContextOptions");
        }

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Boolean AnnotationsEnabled(this NullableContextOptionsEx context)
            => AnnotationsEnabledFunc0(context);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static Boolean WarningsEnabled(this NullableContextOptionsEx context)
            => WarningsEnabledFunc1(context);
    }
}