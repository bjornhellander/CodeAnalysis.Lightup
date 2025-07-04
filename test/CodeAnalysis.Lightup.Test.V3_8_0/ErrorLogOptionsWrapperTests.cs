﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0;

using Wrapper = Microsoft.CodeAnalysis.Lightup.ErrorLogOptionsWrapper;

[TestClass]
public partial class ErrorLogOptionsWrapperTests
{
    [TestMethod]
    public override void TestConstructor()
    {
        var obj = Wrapper.Create("/a/b.txt", SarifVersionEx.Sarif2);
        Assert.AreEqual("/a/b.txt", obj.Path);
        Assert.AreEqual(SarifVersionEx.Sarif2, obj.SarifVersion);
    }
}
