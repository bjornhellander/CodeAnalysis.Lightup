// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Runtime.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Reflection;

    internal static class ImmutableArrayHelpers
    {
        public static MethodInfo GetSelectMethod(Type sourceItemType, Type resultItemType)
        {
            var genericMethod = GetImmutableArraySelectMethod();
            var specializedMethod = genericMethod.MakeGenericMethod(sourceItemType, resultItemType);
            return specializedMethod;
        }

        private static MethodInfo GetImmutableArraySelectMethod()
        {
            var result = typeof(ImmutableArrayExtensions).GetMethods().Single(IsImmutableArraySelectMethod);
            return result;
        }

        private static bool IsImmutableArraySelectMethod(MethodInfo method)
        {
            if (method.Name != "Select")
            {
                return false;
            }

            return true;
        }

        public static MethodInfo GetToImmutableArrayMethod(Type nativeItemType)
        {
            var genericMethod = GetImmutableArrayToImmutableArrayMethod();
            var specializedMethod = genericMethod.MakeGenericMethod(nativeItemType);
            return specializedMethod;
        }

        private static MethodInfo GetImmutableArrayToImmutableArrayMethod()
        {
            var result = typeof(ImmutableArray).GetMethods().Single(IsImmutableArrayToImmutableArrayMethod);
            return result;
        }

        private static bool IsImmutableArrayToImmutableArrayMethod(MethodInfo method)
        {
            if (method.Name != "ToImmutableArray")
            {
                return false;
            }

            var parameters = method.GetParameters();
            if (parameters.Length != 1)
            {
                return false;
            }

            var parameterType = parameters[0].ParameterType;
            if (!parameterType.IsGenericType || parameterType.GetGenericTypeDefinition() != typeof(IEnumerable<>))
            {
                return false;
            }

            return true;
        }
    }
}
