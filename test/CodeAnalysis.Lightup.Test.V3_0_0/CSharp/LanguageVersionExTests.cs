// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LanguageVersionExTests
{
    [TestMethod]
    public void TestEnum()
    {
        EnumTestsHelper.CheckEnum(typeof(LanguageVersionEx), typeof(LanguageVersion));
    }
}
