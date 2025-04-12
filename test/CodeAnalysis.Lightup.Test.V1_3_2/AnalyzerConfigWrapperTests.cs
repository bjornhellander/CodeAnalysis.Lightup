// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper = Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper;

namespace CodeAnalysis.Lightup.Test.V1_3_2;

[TestClass]
public class AnalyzerConfigWrapperTests
{
    [TestMethod]
    public virtual void TestParse()
    {
        Assert.ThrowsException<InvalidOperationException>(() => Wrapper.Parse("", "/a/b.txt"));
    }
}
