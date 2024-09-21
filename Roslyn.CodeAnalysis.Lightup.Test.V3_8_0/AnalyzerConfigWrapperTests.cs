// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.AnalyzerConfigWrapper;

[TestClass]
public class AnalyzerConfigWrapperTests : V3_0_0.AnalyzerConfigWrapperTests
{
    [TestMethod]
    public override void TestParse()
    {
        _ = Wrapper.Parse("", "/a/b.txt");
    }
}
