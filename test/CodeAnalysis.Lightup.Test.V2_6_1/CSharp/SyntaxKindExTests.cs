﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_6_1.CSharp;

using CodeAnalysis.Lightup.Test.V2_6_1;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SyntaxKindExTests
{
    [TestMethod]
    public void TestEnum()
    {
        EnumTestsHelper.CheckEnum(typeof(SyntaxKindEx), typeof(SyntaxKind));
    }
}
