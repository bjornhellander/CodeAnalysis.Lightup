﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for class Microsoft.CodeAnalysis.EmbeddedText. Added in version 2.0.0.0.</summary>
    public partial struct EmbeddedTextWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.EmbeddedText";

        private static readonly global::System.Type? WrappedType;

        private delegate global::System.Collections.Immutable.ImmutableArray<global::System.Byte> ChecksumGetterDelegate(global::System.Object _obj);
        private delegate global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm ChecksumAlgorithmGetterDelegate(global::System.Object _obj);
        private delegate global::System.String FilePathGetterDelegate(global::System.Object _obj);

        private delegate global::Microsoft.CodeAnalysis.Lightup.EmbeddedTextWrapper FromBytesDelegate0(global::System.String filePath, global::System.ArraySegment<global::System.Byte> bytes, global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm checksumAlgorithm);
        private delegate global::Microsoft.CodeAnalysis.Lightup.EmbeddedTextWrapper FromSourceDelegate1(global::System.String filePath, global::Microsoft.CodeAnalysis.Text.SourceText text);
        private delegate global::Microsoft.CodeAnalysis.Lightup.EmbeddedTextWrapper FromStreamDelegate2(global::System.String filePath, global::System.IO.Stream stream, global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm checksumAlgorithm);

        private static readonly ChecksumGetterDelegate ChecksumGetterFunc;
        private static readonly ChecksumAlgorithmGetterDelegate ChecksumAlgorithmGetterFunc;
        private static readonly FilePathGetterDelegate FilePathGetterFunc;

        private static readonly FromBytesDelegate0 FromBytesFunc0;
        private static readonly FromSourceDelegate1 FromSourceFunc1;
        private static readonly FromStreamDelegate2 FromStreamFunc2;

        private readonly global::System.Object wrappedObject;

        static EmbeddedTextWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.FindType(WrappedTypeName);

            ChecksumGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ChecksumGetterDelegate>(WrappedType, nameof(Checksum));
            ChecksumAlgorithmGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<ChecksumAlgorithmGetterDelegate>(WrappedType, nameof(ChecksumAlgorithm));
            FilePathGetterFunc = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateInstanceGetAccessor<FilePathGetterDelegate>(WrappedType, nameof(FilePath));

            FromBytesFunc0 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<FromBytesDelegate0>(WrappedType, "FromBytes", "filePathString", "bytesArraySegment`1", "checksumAlgorithmSourceHashAlgorithm");
            FromSourceFunc1 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<FromSourceDelegate1>(WrappedType, "FromSource", "filePathString", "textSourceText");
            FromStreamFunc2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.CreateStaticMethodAccessor<FromStreamDelegate2>(WrappedType, "FromStream", "filePathString", "streamStream", "checksumAlgorithmSourceHashAlgorithm");
        }

        private EmbeddedTextWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::System.Collections.Immutable.ImmutableArray<global::System.Byte> Checksum
        {
            get { return ChecksumGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm ChecksumAlgorithm
        {
            get { return ChecksumAlgorithmGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 2.0.0.0.</summary>
        public global::System.String FilePath
        {
            get { return FilePathGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static EmbeddedTextWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new EmbeddedTextWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.EmbeddedTextWrapper FromBytes(global::System.String filePath, global::System.ArraySegment<global::System.Byte> bytes, global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm checksumAlgorithm)
        {
            return FromBytesFunc0(filePath, bytes, checksumAlgorithm);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.EmbeddedTextWrapper FromSource(global::System.String filePath, global::Microsoft.CodeAnalysis.Text.SourceText text)
        {
            return FromSourceFunc1(filePath, text);
        }

        /// <summary>Method added in version 2.0.0.0.</summary>
        public static global::Microsoft.CodeAnalysis.Lightup.EmbeddedTextWrapper FromStream(global::System.String filePath, global::System.IO.Stream stream, global::Microsoft.CodeAnalysis.Text.SourceHashAlgorithm checksumAlgorithm)
        {
            return FromStreamFunc2(filePath, stream, checksumAlgorithm);
        }
    }
}
