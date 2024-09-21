// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using System.Linq;
using Microsoft.CodeAnalysis.CodeFixes.Lightup;
using Microsoft.CodeAnalysis.CSharp.Lightup;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WrapperTests
{
    // TODO: Add a type from the CSharp.Workspaces project when we generate something there
    [TestMethod]
    [DataRow(typeof(OperationKindEx))] // From the Common project
    [DataRow(typeof(SyntaxKindEx))] // From the CSharp project
    [DataRow(typeof(FixAllScopeEx))] // From the Workspaces.Common project
    public void TestStaticConstructor(Type exampleType)
    {
        var dummyObj = new object();

        var assembly = exampleType.Assembly;
        var types = assembly.GetTypes();
        foreach (var type in types.Where(IsRelevantType))
        {
            var isMethod = type.GetMethod("Is");
            isMethod?.Invoke(null, [new object()]);
        }
    }

    private static bool IsRelevantType(Type type)
    {
        if (type.IsEnum)
        {
            return false;
        }

        if (typeof(Attribute).IsAssignableFrom(type))
        {
            return false;
        }

        if (type.IsGenericType)
        {
            return false;
        }

        switch (type.Name)
        {
            case "LightupHelperBase":
                return false;

            default:
                return true;
        }
    }
}
