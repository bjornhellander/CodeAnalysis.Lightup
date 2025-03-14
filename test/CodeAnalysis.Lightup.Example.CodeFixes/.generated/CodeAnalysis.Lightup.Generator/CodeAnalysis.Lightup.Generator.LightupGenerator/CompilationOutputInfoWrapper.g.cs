﻿// <auto-generated/>
#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    /// <summary>Provides lightup support for struct Microsoft.CodeAnalysis.CompilationOutputInfo. Added in version 3.7.0.0.</summary>
    public partial struct CompilationOutputInfoWrapper
    {
        private const string WrappedTypeName = "Microsoft.CodeAnalysis.CompilationOutputInfo";

        private static readonly global::System.Type? WrappedType;

        private delegate global::System.String? AssemblyPathGetterDelegate(global::System.Object _obj);
        private delegate global::System.String? GeneratedFilesOutputDirectoryGetterDelegate(global::System.Object _obj);

        private delegate global::System.Boolean EqualsDelegate0(global::System.Object _obj, global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper other);
        private delegate global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper WithAssemblyPathDelegate0(global::System.Object _obj, global::System.String? path);
        private delegate global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper WithGeneratedFilesOutputDirectoryDelegate0(global::System.Object _obj, global::System.String? path);

        private static readonly AssemblyPathGetterDelegate AssemblyPathGetterFunc;
        private static readonly GeneratedFilesOutputDirectoryGetterDelegate GeneratedFilesOutputDirectoryGetterFunc;

        private static readonly EqualsDelegate0 EqualsFunc0;
        private static readonly WithAssemblyPathDelegate0 WithAssemblyPathFunc0;
        private static readonly WithGeneratedFilesOutputDirectoryDelegate0 WithGeneratedFilesOutputDirectoryFunc0;

        private readonly global::System.Object wrappedObject;

        static CompilationOutputInfoWrapper()
        {
            WrappedType = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.FindType(WrappedTypeName);

            AssemblyPathGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<AssemblyPathGetterDelegate>(WrappedType, nameof(AssemblyPath));
            GeneratedFilesOutputDirectoryGetterFunc = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceGetAccessor<GeneratedFilesOutputDirectoryGetterDelegate>(WrappedType, nameof(GeneratedFilesOutputDirectory));

            EqualsFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<EqualsDelegate0>(WrappedType, "Equals", "otherCompilationOutputInfo");
            WithAssemblyPathFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<WithAssemblyPathDelegate0>(WrappedType, "WithAssemblyPath", "pathString");
            WithGeneratedFilesOutputDirectoryFunc0 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.CreateInstanceMethodAccessor<WithGeneratedFilesOutputDirectoryDelegate0>(WrappedType, "WithGeneratedFilesOutputDirectory", "pathString");
        }

        private CompilationOutputInfoWrapper(global::System.Object obj)
        {
            wrappedObject = obj;
        }

        /// <summary>Property added in version 3.7.0.0.</summary>
        public global::System.String? AssemblyPath
        {
            get { return AssemblyPathGetterFunc(wrappedObject); }
        }

        /// <summary>Property added in version 4.13.0.0.</summary>
        public global::System.String? GeneratedFilesOutputDirectory
        {
            get { return GeneratedFilesOutputDirectoryGetterFunc(wrappedObject); }
        }

        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>
        public static bool Is(global::System.Object? obj)
        {
            return global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.Is(obj, WrappedType);
        }

        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>
        public static CompilationOutputInfoWrapper Wrap(global::System.Object obj)
        {
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.WorkspacesCommonLightupHelper.Wrap<global::System.Object>(obj, WrappedType);
            return new CompilationOutputInfoWrapper(obj2);
        }

        /// <summary>Returns the wrapped object.</summary>
        public global::System.Object Unwrap()
        {
            return wrappedObject;
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public global::System.Boolean Equals(global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper other)
        {
            return EqualsFunc0(wrappedObject, other);
        }

        /// <summary>Method added in version 3.7.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper WithAssemblyPath(global::System.String? path)
        {
            return WithAssemblyPathFunc0(wrappedObject, path);
        }

        /// <summary>Method added in version 4.13.0.0.</summary>
        public global::Microsoft.CodeAnalysis.Lightup.CompilationOutputInfoWrapper WithGeneratedFilesOutputDirectory(global::System.String? path)
        {
            return WithGeneratedFilesOutputDirectoryFunc0(wrappedObject, path);
        }
    }
}
