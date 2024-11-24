// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V4_0_1;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public partial class SyntaxTokenExtensionsTests
{
    [TestMethod]
    public override void TestIsIncrementallyIdenticalTo()
    {
        var obj = CreateInstance();
        _ = obj.IsIncrementallyIdenticalTo(default);
    }
}
