// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class IAssemblySymbolExtensionsTests : V3_0_0.IAssemblySymbolExtensionsTests
{
    [TestMethod]
    public override void TestGetForwardedTypesGivenNullObject()
    {
        var obj = CreateInstance();
        _ = obj.GetForwardedTypes();
    }
}
