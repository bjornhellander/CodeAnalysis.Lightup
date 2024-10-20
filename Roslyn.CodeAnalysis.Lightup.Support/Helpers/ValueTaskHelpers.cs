// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Support.Helpers
{
    using System;
    using System.Reflection;
    using Roslyn.CodeAnalysis.Lightup.Support.Extensions;

    internal static class ValueTaskHelpers
    {
        public static MethodInfo GetContinueWithMethod(Type sourceItemType, Type resultItemType)
        {
            var genericMethod = GetContinueWithMethod();
            var specializedMethod = genericMethod.MakeGenericMethod(sourceItemType, resultItemType);
            return specializedMethod;
        }

        private static MethodInfo GetContinueWithMethod()
        {
            var result = typeof(ValueTaskExtensions).GetMethod("ContinueWith");
            return result;
        }
    }
}
