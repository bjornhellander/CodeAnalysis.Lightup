// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

using System;
using System.Threading.Tasks;

namespace CodeAnalysis.Lightup.Runtime.Extensions
{
    public static class TaskExtensions
    {
        public static Task<TResult> FromException<TResult>(Exception ex)
        {
            var tcs = new TaskCompletionSource<TResult>();
            tcs.SetException(ex);
            return tcs.Task;
        }
    }
}
