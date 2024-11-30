// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.SymbolEqualityComparerWrapper;

[TestClass]
public partial class SymbolEqualityComparerWrapperTests
{
    [TestMethod]
    public override void TestDefault()
    {
        _ = Wrapper.Default;
    }
}
