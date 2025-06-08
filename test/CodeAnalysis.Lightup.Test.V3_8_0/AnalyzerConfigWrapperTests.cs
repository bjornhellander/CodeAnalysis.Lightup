// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0;

using Wrapper = Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper;

[TestClass]
public partial class AnalyzerConfigWrapperTests
{
    [TestMethod]
    public override void TestParse()
    {
        _ = Wrapper.Parse("", "/a/b.txt");
    }
}
