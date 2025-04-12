// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeAnalysis.Lightup.Test.V1_3_2.CSharp;

[TestClass]
public class SyntaxKindExTests
{
    [TestMethod]
    public void TestEnum()
    {
        EnumTestsHelper.CheckEnum(typeof(SyntaxKindEx), typeof(SyntaxKind));
    }
}
