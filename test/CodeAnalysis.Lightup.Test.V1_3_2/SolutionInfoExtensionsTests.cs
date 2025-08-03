// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

[TestClass]
public class SolutionInfoExtensionsTests
{
    [TestMethod]
    public virtual void TestConstructor()
    {
        Assert.ThrowsExactly<InvalidOperationException>(() => CallCreate());
    }

    protected static SolutionInfo CallCreate()
    {
        return SolutionInfoEx.Create(
            SolutionId.CreateNewId(),
            default,
            default,
            [],
            []);
    }
}
