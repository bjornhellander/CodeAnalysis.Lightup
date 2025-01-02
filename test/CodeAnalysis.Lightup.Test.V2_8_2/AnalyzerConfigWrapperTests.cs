// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_8_2;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper;

[TestClass]
public class AnalyzerConfigWrapperTests
{
    [TestMethod]
    public virtual void TestParse()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Parse("", "/a/b.txt"));
    }
}
