// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_0_0;

using System;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
