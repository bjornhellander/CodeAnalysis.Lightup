// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Runtime.Helpers
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using CodeAnalysis.Lightup.Runtime.Extensions;

    internal static class TaskHelpers
    {
        public static MethodInfo GetContinueWithMethod(Type sourceItemType, Type resultItemType)
        {
            var genericMethod = GetTaskContinueWithMethod(sourceItemType);
            var specializedMethod = genericMethod.MakeGenericMethod(resultItemType);
            return specializedMethod;
        }

        private static MethodInfo GetTaskContinueWithMethod(Type sourceItemType)
        {
            var result = typeof(Task<>).MakeGenericType(sourceItemType).GetMethod(x => IsTaskContinueWithMethod(x, sourceItemType));
            return result;
        }

        private static bool IsTaskContinueWithMethod(MethodInfo method, Type sourceItemType)
        {
            if (method.Name != "ContinueWith")
            {
                return false;
            }

            if (!method.ContainsGenericParameters)
            {
                return false;
            }

            var genericArguments = method.GetGenericArguments();
            if (genericArguments.Length != 1)
            {
                return false;
            }

            var parameters = method.GetParameters();
            if (parameters.Length != 1)
            {
                return false;
            }

            var expectedParameterType = typeof(Func<,>).MakeGenericType(
                typeof(Task<>).MakeGenericType(sourceItemType),
                genericArguments[0]);
            if (parameters[0].ParameterType != expectedParameterType)
            {
                return false;
            }

            return true;
        }
    }
}
