using System;
using System.Diagnostics.CodeAnalysis;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class Assert
{
    [DoesNotReturn]
    public static void Fail(string v)
    {
        throw new InvalidOperationException();
    }

    public static void IsTrue([DoesNotReturnIf(false)] bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
