﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_6_1;

using System;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SarifVersionFactsExTests
{
    [TestMethod]
    public virtual void TestTryParse()
    {
        Assert.ThrowsException<InvalidOperationException>(() => SarifVersionFactsEx.TryParse("1", out var _));
    }
}