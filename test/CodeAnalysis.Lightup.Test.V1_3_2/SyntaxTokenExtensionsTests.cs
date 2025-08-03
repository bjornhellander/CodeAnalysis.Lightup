// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

[TestClass]
public class SyntaxTokenExtensionsTests
{
    [TestMethod]
    public virtual void TestIsIncrementallyIdenticalTo()
    {
        var obj = CreateInstance();
        Assert.ThrowsExactly<InvalidOperationException>(() => obj.IsIncrementallyIdenticalTo(default));
    }

    protected static SyntaxToken CreateInstance()
    {
        return default;
    }
}
