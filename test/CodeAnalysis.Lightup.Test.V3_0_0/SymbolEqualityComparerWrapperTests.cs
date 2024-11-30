// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
