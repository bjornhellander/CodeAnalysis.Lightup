// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.SourceGenerator;

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.CodeAnalysis.Lightup.Definitions;
using Roslyn.CodeAnalysis.Lightup.SourceGenerator;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

[TestClass]
public class TypesReaderTests
{
    // NOTE: Add mainly to make developing TypesReader easier. Doesn't really test much.
    [TestMethod]
    public void TestRead()
    {
        var types = TypesReader.Read();
        Assert.AreEqual(877, types.Count);

        var type1 = (TypeDefinition)types.Single(x => x.FullName == "Microsoft.CodeAnalysis.AnalyzerConfigOptionsResult");
        Assert.AreEqual(3, type1.Properties.Count);
        Assert.IsTrue(type1.Properties.All(x => x.AssemblyVersion != null));
    }
}
