// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Runtime
{
    using System;

    internal class ProgressWrapper<TSource, TTarget> : IProgress<TSource>
    {
        private readonly IProgress<TTarget> actual;
        private readonly Func<TSource, TTarget> convert;

        public ProgressWrapper(IProgress<TTarget> actual, Func<TSource, TTarget> convert)
        {
            this.actual = actual;
            this.convert = convert;
        }

        public void Report(TSource sourceValue)
        {
            var targetValue = convert(sourceValue);
            actual.Report(targetValue);
        }
    }
}
