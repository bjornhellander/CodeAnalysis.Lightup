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
