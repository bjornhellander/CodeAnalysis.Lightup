// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

using System;
using System.Diagnostics.CodeAnalysis;

internal class Assert
{
    [DoesNotReturn]
    public static void Fail(string message)
    {
        throw new InvalidOperationException(message);
    }

    public static void IsTrue([DoesNotReturnIf(false)] bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
