// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SolutionInfoExtensionsTests : V3_0_0.SolutionInfoExtensionsTests
{
    [TestMethod]
    public override void TestConstructor()
    {
        _ = CallCreate();
    }
}
