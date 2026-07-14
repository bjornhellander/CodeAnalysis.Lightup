// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Runtime.Helpers
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using CodeAnalysis.Lightup.Runtime.Extensions;

    // NOTE: System.Threading.Tasks.ValueTask<T> is not referenced by this project, so the needed members are located via reflection
    internal static class ValueTaskHelpers
    {
        private const string GenericValueTaskTypeFullName = "System.Threading.Tasks.ValueTask`1";

        private static Type? genericValueTaskTypeDefinition;

        public static bool IsValueTaskType(Type type)
        {
            if (!type.IsGenericType() || type.GetGenericTypeDefinition().FullName != GenericValueTaskTypeFullName)
            {
                return false;
            }

            genericValueTaskTypeDefinition ??= type.GetGenericTypeDefinition();

            return true;
        }

        public static MethodInfo GetAsTaskMethod(Type sourceItemType)
        {
            var valueTaskType = genericValueTaskTypeDefinition!.MakeGenericType(sourceItemType); // The type must have been initialized by now
            var result = valueTaskType.GetMethod(IsAsTaskMethod);
            return result;
        }

        private static bool IsAsTaskMethod(MethodInfo method)
        {
            if (method.Name != "AsTask")
            {
                return false;
            }

            if (method.GetParameters().Length != 0)
            {
                return false;
            }

            return true;
        }

        public static ConstructorInfo GetTaskConstructor(Type resultItemType)
        {
            var valueTaskType = genericValueTaskTypeDefinition!.MakeGenericType(resultItemType); // The type must have been initialized by now
            var result = valueTaskType.GetConstructor(x => IsTaskConstructor(x, resultItemType));
            return result;
        }

        private static bool IsTaskConstructor(ConstructorInfo constructor, Type resultItemType)
        {
            var parameters = constructor.GetParameters();
            if (parameters.Length != 1)
            {
                return false;
            }

            var expectedParameterType = typeof(Task<>).MakeGenericType(resultItemType);
            if (parameters[0].ParameterType != expectedParameterType)
            {
                return false;
            }

            return true;
        }

        public static MethodInfo GetContinueWithMethod(Type sourceItemType, Type resultItemType)
        {
            var genericMethod = typeof(TaskContinuation).GetPublicMethod(nameof(TaskContinuation.ContinueWith));
            var specializedMethod = genericMethod.MakeGenericMethod(sourceItemType, resultItemType);
            return specializedMethod;
        }

        // NOTE: Task<T>.ContinueWith is not used here, since letting the continuation access a faulted antecedent's
        // Result property causes the original exception to end up double-wrapped in AggregateException instances.
        private static class TaskContinuation
        {
            public static async Task<TResult> ContinueWith<TSource, TResult>(Task<TSource> task, Func<TSource, TResult> continuation)
            {
                var result = await task.ConfigureAwait(false);
                return continuation(result);
            }
        }
    }
}
