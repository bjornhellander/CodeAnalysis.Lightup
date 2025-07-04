﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2;

using Wrapper = Microsoft.CodeAnalysis.Lightup.ErrorLogOptionsWrapper;

[TestClass]
public class ErrorLogOptionsWrapperTests
{
    [TestMethod]
    public virtual void TestConstructor()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Create("/a/b.txt", SarifVersionEx.Sarif2));
    }
}
