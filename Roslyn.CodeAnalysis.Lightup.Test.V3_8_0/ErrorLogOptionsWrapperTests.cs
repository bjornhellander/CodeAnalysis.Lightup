// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.ErrorLogOptionsWrapper;

[TestClass]
public class ErrorLogOptionsWrapperTests : V3_0_0.ErrorLogOptionsWrapperTests
{
    [TestMethod]
    public override void TestConstructor()
    {
        var obj = Wrapper.Create("/a/b.txt", SarifVersionEx.Sarif2);
        Assert.AreEqual("/a/b.txt", obj.Path);
        Assert.AreEqual(SarifVersionEx.Sarif2, obj.SarifVersion);
    }
}
