// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public partial class ProjectInfoExtensionsTests
{
    [TestMethod]
    public override void TestWithCompilationOutputInfo()
    {
        var obj = CreateInstance();
        var compilationOutputInfo = default(CompilationOutputInfo).WithAssemblyPath("a/b/c.dll");
        var compilationOutputInfoWrapper = CompilationOutputInfoWrapper.As(compilationOutputInfo);
        var result = obj.WithCompilationOutputInfo(compilationOutputInfoWrapper);
        Assert.AreEqual("a/b/c.dll", result.CompilationOutputInfo.AssemblyPath);
    }
}
