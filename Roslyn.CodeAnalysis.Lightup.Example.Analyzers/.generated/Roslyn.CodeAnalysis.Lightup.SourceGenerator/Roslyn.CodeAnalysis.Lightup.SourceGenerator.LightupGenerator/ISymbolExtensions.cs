﻿// <auto-generated/>
#nullable enable

using Microsoft.CodeAnalysis.Lightup;

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for interface Microsoft.CodeAnalysis.ISymbol.</summary>
    public static partial class ISymbolExtensions
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.ISymbol";

        private delegate System.Int32 MetadataTokenGetterDelegate(Microsoft.CodeAnalysis.ISymbol? _obj);

        private delegate System.Boolean EqualsDelegate0(Microsoft.CodeAnalysis.ISymbol? _obj, Microsoft.CodeAnalysis.ISymbol? other, Microsoft.CodeAnalysis.Lightup.SymbolEqualityComparerWrapper equalityComparer);

        private static readonly MetadataTokenGetterDelegate MetadataTokenGetterFunc;

        private static readonly EqualsDelegate0 EqualsFunc0;

        static ISymbolExtensions()
        {
            var wrappedType = CommonLightupHelper.FindType(WrappedTypeName);

            MetadataTokenGetterFunc = CommonLightupHelper.CreateInstanceGetAccessor<MetadataTokenGetterDelegate>(wrappedType, nameof(MetadataToken));

            EqualsFunc0 = CommonLightupHelper.CreateInstanceMethodAccessor<EqualsDelegate0>(wrappedType, "Equals", "otherISymbol", "equalityComparerSymbolEqualityComparer");
        }

        /// <summary>Property added in version 4.0.0.0.</summary>
        public static System.Int32 MetadataToken(this Microsoft.CodeAnalysis.ISymbol _obj)
            => MetadataTokenGetterFunc(_obj);

        /// <summary>Method added in version 3.8.0.0.</summary>
        public static System.Boolean Equals(this Microsoft.CodeAnalysis.ISymbol _obj, Microsoft.CodeAnalysis.ISymbol? other, Microsoft.CodeAnalysis.Lightup.SymbolEqualityComparerWrapper equalityComparer)
            => EqualsFunc0(_obj, other, equalityComparer);
    }
}