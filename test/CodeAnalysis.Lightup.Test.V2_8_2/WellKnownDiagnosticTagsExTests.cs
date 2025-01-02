// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_8_2;

using System;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WellKnownDiagnosticTagsExTests
{
    [TestMethod]
    public virtual void TestCustomObsolete()
    {
        Assert.ThrowsException<InvalidOperationException>(() => WellKnownDiagnosticTagsEx.CustomObsolete);
    }
}
