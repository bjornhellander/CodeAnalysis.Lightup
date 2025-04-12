// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

using System;
using System.Reflection;
using CodeAnalysis.Lightup.Runtime.Extensions;

namespace CodeAnalysis.Lightup.Runtime.Helpers
{
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
            var result = typeof(ValueTaskExtensions).GetPublicMethod("ContinueWith");
            return result;
        }
    }
}
