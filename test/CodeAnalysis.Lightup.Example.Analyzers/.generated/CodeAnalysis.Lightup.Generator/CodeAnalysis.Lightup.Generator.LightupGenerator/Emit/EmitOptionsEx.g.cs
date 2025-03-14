﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Emit.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.Emit.EmitOptions.</summary>
    public static partial class EmitOptionsEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.Emit.EmitOptions";

        private delegate Microsoft.CodeAnalysis.Emit.EmitOptions ConstructorDelegate0(global::System.Boolean metadataOnly, global::Microsoft.CodeAnalysis.Emit.DebugInformationFormat debugInformationFormat, global::System.String pdbFilePath, global::System.String outputNameOverride, global::System.Int32 fileAlignment, global::System.UInt64 baseAddress, global::System.Boolean highEntropyVirtualAddressSpace, global::Microsoft.CodeAnalysis.SubsystemVersion subsystemVersion, global::System.String runtimeMetadataVersion, global::System.Boolean tolerateErrors, global::System.Boolean includePrivateMembers, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> instrumentationKinds);
        private delegate Microsoft.CodeAnalysis.Emit.EmitOptions ConstructorDelegate1(global::System.Boolean metadataOnly, global::Microsoft.CodeAnalysis.Emit.DebugInformationFormat debugInformationFormat, global::System.String? pdbFilePath, global::System.String? outputNameOverride, global::System.Int32 fileAlignment, global::System.UInt64 baseAddress, global::System.Boolean highEntropyVirtualAddressSpace, global::Microsoft.CodeAnalysis.SubsystemVersion subsystemVersion, global::System.String? runtimeMetadataVersion, global::System.Boolean tolerateErrors, global::System.Boolean includePrivateMembers, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> instrumentationKinds, global::System.Nullable<global::System.Security.Cryptography.HashAlgorithmName> pdbChecksumAlgorithm);
        private delegate Microsoft.CodeAnalysis.Emit.EmitOptions ConstructorDelegate2(global::System.Boolean metadataOnly, global::Microsoft.CodeAnalysis.Emit.DebugInformationFormat debugInformationFormat, global::System.String? pdbFilePath, global::System.String? outputNameOverride, global::System.Int32 fileAlignment, global::System.UInt64 baseAddress, global::System.Boolean highEntropyVirtualAddressSpace, global::Microsoft.CodeAnalysis.SubsystemVersion subsystemVersion, global::System.String? runtimeMetadataVersion, global::System.Boolean tolerateErrors, global::System.Boolean includePrivateMembers, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> instrumentationKinds, global::System.Nullable<global::System.Security.Cryptography.HashAlgorithmName> pdbChecksumAlgorithm, global::System.Text.Encoding? defaultSourceFileEncoding, global::System.Text.Encoding? fallbackSourceFileEncoding);

        private delegate global::System.Text.Encoding? DefaultSourceFileEncodingGetterDelegate(global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj);
        private delegate global::System.Text.Encoding? FallbackSourceFileEncodingGetterDelegate(global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj);
        private delegate global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> InstrumentationKindsGetterDelegate(global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj);
        private delegate global::System.Security.Cryptography.HashAlgorithmName PdbChecksumAlgorithmGetterDelegate(global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj);

        private delegate global::Microsoft.CodeAnalysis.Emit.EmitOptions WithDefaultSourceFileEncodingDelegate0(global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj, global::System.Text.Encoding? defaultSourceFileEncoding);
        private delegate global::Microsoft.CodeAnalysis.Emit.EmitOptions WithFallbackSourceFileEncodingDelegate0(global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj, global::System.Text.Encoding? fallbackSourceFileEncoding);
        private delegate global::Microsoft.CodeAnalysis.Emit.EmitOptions WithInstrumentationKindsDelegate0(global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> instrumentationKinds);
        private delegate global::Microsoft.CodeAnalysis.Emit.EmitOptions WithPdbChecksumAlgorithmDelegate0(global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj, global::System.Security.Cryptography.HashAlgorithmName name);

        private static readonly ConstructorDelegate0 ConstructorFunc0;
        private static readonly ConstructorDelegate1 ConstructorFunc1;
        private static readonly ConstructorDelegate2 ConstructorFunc2;

        private static readonly DefaultSourceFileEncodingGetterDelegate DefaultSourceFileEncodingGetterFunc;
        private static readonly FallbackSourceFileEncodingGetterDelegate FallbackSourceFileEncodingGetterFunc;
        private static readonly InstrumentationKindsGetterDelegate InstrumentationKindsGetterFunc;
        private static readonly PdbChecksumAlgorithmGetterDelegate PdbChecksumAlgorithmGetterFunc;

        private static readonly WithDefaultSourceFileEncodingDelegate0 WithDefaultSourceFileEncodingFunc0;
        private static readonly WithFallbackSourceFileEncodingDelegate0 WithFallbackSourceFileEncodingFunc0;
        private static readonly WithInstrumentationKindsDelegate0 WithInstrumentationKindsFunc0;
        private static readonly WithPdbChecksumAlgorithmDelegate0 WithPdbChecksumAlgorithmFunc0;

        static EmitOptionsEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ConstructorFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate0>(wrappedType, "metadataOnlyBoolean", "debugInformationFormatDebugInformationFormat", "pdbFilePathString", "outputNameOverrideString", "fileAlignmentInt32", "baseAddressUInt64", "highEntropyVirtualAddressSpaceBoolean", "subsystemVersionSubsystemVersion", "runtimeMetadataVersionString", "tolerateErrorsBoolean", "includePrivateMembersBoolean", "instrumentationKindsImmutableArray`1");
            ConstructorFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate1>(wrappedType, "metadataOnlyBoolean", "debugInformationFormatDebugInformationFormat", "pdbFilePathString", "outputNameOverrideString", "fileAlignmentInt32", "baseAddressUInt64", "highEntropyVirtualAddressSpaceBoolean", "subsystemVersionSubsystemVersion", "runtimeMetadataVersionString", "tolerateErrorsBoolean", "includePrivateMembersBoolean", "instrumentationKindsImmutableArray`1", "pdbChecksumAlgorithmNullable`1");
            ConstructorFunc2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate2>(wrappedType, "metadataOnlyBoolean", "debugInformationFormatDebugInformationFormat", "pdbFilePathString", "outputNameOverrideString", "fileAlignmentInt32", "baseAddressUInt64", "highEntropyVirtualAddressSpaceBoolean", "subsystemVersionSubsystemVersion", "runtimeMetadataVersionString", "tolerateErrorsBoolean", "includePrivateMembersBoolean", "instrumentationKindsImmutableArray`1", "pdbChecksumAlgorithmNullable`1", "defaultSourceFileEncodingEncoding", "fallbackSourceFileEncodingEncoding");

            DefaultSourceFileEncodingGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<DefaultSourceFileEncodingGetterDelegate>(wrappedType, nameof(DefaultSourceFileEncoding));
            FallbackSourceFileEncodingGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<FallbackSourceFileEncodingGetterDelegate>(wrappedType, nameof(FallbackSourceFileEncoding));
            InstrumentationKindsGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<InstrumentationKindsGetterDelegate>(wrappedType, nameof(InstrumentationKinds));
            PdbChecksumAlgorithmGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<PdbChecksumAlgorithmGetterDelegate>(wrappedType, nameof(PdbChecksumAlgorithm));

            WithDefaultSourceFileEncodingFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<WithDefaultSourceFileEncodingDelegate0>(wrappedType, "WithDefaultSourceFileEncoding", "defaultSourceFileEncodingEncoding");
            WithFallbackSourceFileEncodingFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<WithFallbackSourceFileEncodingDelegate0>(wrappedType, "WithFallbackSourceFileEncoding", "fallbackSourceFileEncodingEncoding");
            WithInstrumentationKindsFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<WithInstrumentationKindsDelegate0>(wrappedType, "WithInstrumentationKinds", "instrumentationKindsImmutableArray`1");
            WithPdbChecksumAlgorithmFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceMethodAccessor<WithPdbChecksumAlgorithmDelegate0>(wrappedType, "WithPdbChecksumAlgorithm", "nameHashAlgorithmName");
        }

        /// <summary>Constructor added in version 2.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Emit.EmitOptions Create(global::System.Boolean metadataOnly, global::Microsoft.CodeAnalysis.Emit.DebugInformationFormat debugInformationFormat, global::System.String pdbFilePath, global::System.String outputNameOverride, global::System.Int32 fileAlignment, global::System.UInt64 baseAddress, global::System.Boolean highEntropyVirtualAddressSpace, global::Microsoft.CodeAnalysis.SubsystemVersion subsystemVersion, global::System.String runtimeMetadataVersion, global::System.Boolean tolerateErrors, global::System.Boolean includePrivateMembers, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> instrumentationKinds)
        {
            return ConstructorFunc0(metadataOnly, debugInformationFormat, pdbFilePath, outputNameOverride, fileAlignment, baseAddress, highEntropyVirtualAddressSpace, subsystemVersion, runtimeMetadataVersion, tolerateErrors, includePrivateMembers, instrumentationKinds);
        }

        /// <summary>Constructor added in version 2.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Emit.EmitOptions Create(global::System.Boolean metadataOnly, global::Microsoft.CodeAnalysis.Emit.DebugInformationFormat debugInformationFormat, global::System.String? pdbFilePath, global::System.String? outputNameOverride, global::System.Int32 fileAlignment, global::System.UInt64 baseAddress, global::System.Boolean highEntropyVirtualAddressSpace, global::Microsoft.CodeAnalysis.SubsystemVersion subsystemVersion, global::System.String? runtimeMetadataVersion, global::System.Boolean tolerateErrors, global::System.Boolean includePrivateMembers, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> instrumentationKinds, global::System.Nullable<global::System.Security.Cryptography.HashAlgorithmName> pdbChecksumAlgorithm)
        {
            return ConstructorFunc1(metadataOnly, debugInformationFormat, pdbFilePath, outputNameOverride, fileAlignment, baseAddress, highEntropyVirtualAddressSpace, subsystemVersion, runtimeMetadataVersion, tolerateErrors, includePrivateMembers, instrumentationKinds, pdbChecksumAlgorithm);
        }

        /// <summary>Constructor added in version 3.7.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Emit.EmitOptions Create(global::System.Boolean metadataOnly, global::Microsoft.CodeAnalysis.Emit.DebugInformationFormat debugInformationFormat, global::System.String? pdbFilePath, global::System.String? outputNameOverride, global::System.Int32 fileAlignment, global::System.UInt64 baseAddress, global::System.Boolean highEntropyVirtualAddressSpace, global::Microsoft.CodeAnalysis.SubsystemVersion subsystemVersion, global::System.String? runtimeMetadataVersion, global::System.Boolean tolerateErrors, global::System.Boolean includePrivateMembers, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> instrumentationKinds, global::System.Nullable<global::System.Security.Cryptography.HashAlgorithmName> pdbChecksumAlgorithm, global::System.Text.Encoding? defaultSourceFileEncoding, global::System.Text.Encoding? fallbackSourceFileEncoding)
        {
            return ConstructorFunc2(metadataOnly, debugInformationFormat, pdbFilePath, outputNameOverride, fileAlignment, baseAddress, highEntropyVirtualAddressSpace, subsystemVersion, runtimeMetadataVersion, tolerateErrors, includePrivateMembers, instrumentationKinds, pdbChecksumAlgorithm, defaultSourceFileEncoding, fallbackSourceFileEncoding);
        }

        /// <summary>Property added in version 3.7.0.0.</summary>
        public static global::System.Text.Encoding? DefaultSourceFileEncoding(this global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj)
        {
            return DefaultSourceFileEncodingGetterFunc(_obj);
        }

        /// <summary>Property added in version 3.7.0.0.</summary>
        public static global::System.Text.Encoding? FallbackSourceFileEncoding(this global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj)
        {
            return FallbackSourceFileEncodingGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public static global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> InstrumentationKinds(this global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj)
        {
            return InstrumentationKindsGetterFunc(_obj);
        }

        /// <summary>Property added in version 2.8.0.0.</summary>
        public static global::System.Security.Cryptography.HashAlgorithmName PdbChecksumAlgorithm(this global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj)
        {
            return PdbChecksumAlgorithmGetterFunc(_obj);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Emit.EmitOptions WithDefaultSourceFileEncoding(this global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj, global::System.Text.Encoding? defaultSourceFileEncoding)
        {
            return WithDefaultSourceFileEncodingFunc0(_obj, defaultSourceFileEncoding);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Emit.EmitOptions WithFallbackSourceFileEncoding(this global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj, global::System.Text.Encoding? fallbackSourceFileEncoding)
        {
            return WithFallbackSourceFileEncodingFunc0(_obj, fallbackSourceFileEncoding);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Emit.EmitOptions WithInstrumentationKinds(this global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj, global::System.Collections.Immutable.ImmutableArray<global::Microsoft.CodeAnalysis.Emit.Lightup.InstrumentationKindEx> instrumentationKinds)
        {
            return WithInstrumentationKindsFunc0(_obj, instrumentationKinds);
        }

        /// <summary>Method added in version 2.8.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Emit.EmitOptions WithPdbChecksumAlgorithm(this global::Microsoft.CodeAnalysis.Emit.EmitOptions _obj, global::System.Security.Cryptography.HashAlgorithmName name)
        {
            return WithPdbChecksumAlgorithmFunc0(_obj, name);
        }
    }
}
