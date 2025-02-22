﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.CommandLineReference.</summary>
    public static partial class CommandLineReferenceEx
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CommandLineReference";

        private delegate Microsoft.CodeAnalysis.CommandLineReference ConstructorDelegate0(global::System.String reference, global::Microsoft.CodeAnalysis.MetadataReferenceProperties properties);

        private static readonly ConstructorDelegate0 ConstructorFunc0;

        static CommandLineReferenceEx()
        {
            var wrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ConstructorFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate0>(wrappedType, "referenceString", "propertiesMetadataReferenceProperties");
        }

        /// <summary>Constructor added in version 2.3.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.CommandLineReference Create(global::System.String reference, global::Microsoft.CodeAnalysis.MetadataReferenceProperties properties)
        {
            return ConstructorFunc0(reference, properties);
        }
    }
}
