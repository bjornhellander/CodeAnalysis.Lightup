﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.Generator.V4_0_1;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

[TestClass]
[SkipInheritanceGeneration]
public class TypesReaderTests
{
    [TestMethod]
    public void TestRead_V3_0_0_0()
    {
        var types = TypesReader.Read(new Version(3, 0, 0, 0));
        Assert.AreEqual(998, types.Count);
        Assert.AreEqual(155, types.Count(x => x.AssemblyVersion != null));

        var type1 = (TypeDefinition)types.Single(x => x.FullName == "Microsoft.CodeAnalysis.AnalyzerConfigOptionsResult");
        Assert.AreEqual(new Version(3, 1, 0, 0), type1.AssemblyVersion);
        Assert.AreEqual(3, type1.Properties.Count);
        Assert.IsTrue(type1.Properties.All(x => x.AssemblyVersion != null));
    }

    [TestMethod]
    public void TestRead_V3_8_0_0()
    {
        var version = new Version(3, 8, 0, 0);

        var types = TypesReader.Read(version);
        Assert.AreEqual(998, types.Count);
        Assert.AreEqual(87, types.Count(x => x.AssemblyVersion != null));

        var type1 = (TypeDefinition)types.Single(x => x.FullName == "Microsoft.CodeAnalysis.AnalyzerConfigOptionsResult");
        Assert.IsNull(type1.AssemblyVersion);
        Assert.AreEqual(3, type1.Properties.Count);
        Assert.IsTrue(type1.Properties.All(x => x.AssemblyVersion == null));
    }
}
