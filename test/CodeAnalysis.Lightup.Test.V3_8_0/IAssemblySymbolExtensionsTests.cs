// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public partial class IAssemblySymbolExtensionsTests
{
    [TestMethod]
    public override void TestGetForwardedTypesGivenCompatibleObject()
    {
        var obj = CreateInstance();
        _ = IAssemblySymbolEx.GetForwardedTypes(obj);
    }
}
