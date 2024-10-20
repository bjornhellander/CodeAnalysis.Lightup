// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Support.Helpers
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal static class EnumerableHelpers
    {
        public static MethodInfo GetSelectMethod(Type sourceItemType, Type resultItemType)
        {
            var genericMethod = GetEnumerableSelectMethod();
            var specializedMethod = genericMethod.MakeGenericMethod(sourceItemType, resultItemType);
            return specializedMethod;
        }

        private static MethodInfo GetEnumerableSelectMethod()
        {
            var result = typeof(Enumerable).GetMethods().Single(IsEnumerableSelectMethod);
            return result;
        }

        private static bool IsEnumerableSelectMethod(MethodInfo method)
        {
            if (method.Name != "Select")
            {
                return false;
            }

            var parameters = method.GetParameters();
            if (parameters.Length != 2)
            {
                return false;
            }

            var parameterType = parameters[1].ParameterType;
            if (parameterType.Name != "Func`2")
            {
                return false;
            }

            return true;
        }

        public static MethodInfo GetToArrayMethod(Type nativeItemType)
        {
            var genericMethod = GetEnumerableToArrayMethod();
            var specializedMethod = genericMethod.MakeGenericMethod(nativeItemType);
            return specializedMethod;
        }

        private static MethodInfo GetEnumerableToArrayMethod()
        {
            var result = typeof(Enumerable).GetMethods().Single(IsEnumerableToArrayMethod);
            return result;
        }

        private static bool IsEnumerableToArrayMethod(MethodInfo method)
        {
            if (method.Name != "ToArray")
            {
                return false;
            }

            var parameters = method.GetParameters();
            if (parameters.Length != 1)
            {
                return false;
            }

            return true;
        }
    }
}
