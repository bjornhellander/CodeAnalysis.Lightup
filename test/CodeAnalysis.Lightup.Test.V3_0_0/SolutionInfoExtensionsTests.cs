// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SolutionInfoExtensionsTests
{
    [TestMethod]
    public virtual void TestConstructor()
    {
        Assert.ThrowsException<InvalidOperationException>(() => CallCreate());
    }

    protected static SolutionInfo CallCreate()
    {
        return SolutionInfoExtensions.Create(
            SolutionId.CreateNewId(),
            default,
            default,
            [],
            []);
    }
}
