namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

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
