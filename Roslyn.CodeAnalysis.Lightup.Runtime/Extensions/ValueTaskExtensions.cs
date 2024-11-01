// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Runtime.Extensions
{
    using System;
    using System.Threading.Tasks;

    // NOTE: Created since there is no ContinueWith method in ValueTask
    internal static class ValueTaskExtensions
    {
        // NOTE: Used via reflection
        public static ValueTask<TResult> ContinueWith<TSource, TResult>(
            this ValueTask<TSource> valueTask,
            Func<TSource, TResult> continuation)
        {
            if (valueTask.IsCompletedSuccessfully)
            {
                try
                {
                    TResult continuationResult = continuation(valueTask.Result);
                    return new ValueTask<TResult>(continuationResult);
                }
                catch (Exception ex)
                {
                    return new ValueTask<TResult>(Task.FromException<TResult>(ex));
                }
            }
            else
            {
                return ContinueWithNotCompleted(valueTask, continuation);
            }
        }

        private static async ValueTask<TResult> ContinueWithNotCompleted<TSource, TResult>(
            ValueTask<TSource> valueTask,
            Func<TSource, TResult> continuation)
        {
            try
            {
                var result = await valueTask;
                return continuation(result);
            }
            catch (Exception ex)
            {
                return await new ValueTask<TResult>(Task.FromException<TResult>(ex));
            }
        }
    }
}
