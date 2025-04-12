// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

using System;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeAnalysis.Lightup.Test.V1_3_2;

[TestClass]
public class WellKnownDiagnosticTagsExTests
{
    [TestMethod]
    public virtual void TestCustomObsolete()
    {
        Assert.ThrowsException<InvalidOperationException>(() => WellKnownDiagnosticTagsEx.CustomObsolete);
    }
}
