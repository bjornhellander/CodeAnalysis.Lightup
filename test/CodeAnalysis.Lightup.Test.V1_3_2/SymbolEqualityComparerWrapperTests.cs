﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

using Wrapper = Microsoft.CodeAnalysis.Lightup.SymbolEqualityComparerWrapper;

[TestClass]
public class SymbolEqualityComparerWrapperTests
{
    [TestMethod]
    public virtual void TestDefault()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Default);
    }
}
