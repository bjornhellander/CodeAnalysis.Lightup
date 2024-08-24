namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Reflection;

    internal class LightupHelper : LightupHelperBase
    {
        private static readonly Assembly WorkspacesCommonAssembly = typeof(WorkspaceChangeKind).Assembly;

        public static Type? FindType(string wrappedTypeName)
        {
            return FindType(WorkspacesCommonAssembly, wrappedTypeName);
        }
    }
}
