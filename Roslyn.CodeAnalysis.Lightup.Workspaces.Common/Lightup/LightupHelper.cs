namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Reflection;

    internal class LightupHelper : LightupHelperBase
    {
        private static readonly Assembly CommonAssembly = typeof(IOperation).Assembly;

        public static Type? FindType(string wrappedTypeName)
        {
            return FindType(CommonAssembly, wrappedTypeName);
        }
    }
}
