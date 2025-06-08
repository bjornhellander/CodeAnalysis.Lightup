// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.Internal;

// NOTE: These tests are just here to document the behavior of Task
[TestClass]
public class TaskTests
{
    [TestMethod]
    public void TestAntecedentThrowsExceptionBeforeFirstAwait()
    {
        Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await WillThrowInvalidOperationExeptionBeforeFirstAwait());
        Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await WillThrowInvalidOperationExeptionBeforeFirstAwait().ContinueWith(x => x.Result));
    }

    [TestMethod]
    public void TestAntecedentThrowsExceptionAfterFirstAwait()
    {
        Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await WillThrowInvalidOperationExeptionAfterFirstAwait());
        Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await WillThrowInvalidOperationExeptionAfterFirstAwait().ContinueWith(x => x.Result));
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    private static async Task<int> WillThrowInvalidOperationExeptionBeforeFirstAwait()
    {
        throw new InvalidOperationException();
    }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

    private static async Task<int> WillThrowInvalidOperationExeptionAfterFirstAwait()
    {
        await Task.Delay(0);
        throw new InvalidOperationException();
    }
}
