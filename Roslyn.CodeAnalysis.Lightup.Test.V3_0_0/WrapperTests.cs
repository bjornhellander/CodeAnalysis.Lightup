// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using System.Linq;
using Microsoft.CodeAnalysis.CodeFixes.Lightup;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WrapperTests
{
    [TestMethod]
    [DataRow(typeof(OperationKindEx))] // From the Example.Analyzers project
    [DataRow(typeof(FixAllScopeEx))] // From the Example.CodeFixes project
    public void TestStaticConstructor(Type exampleType)
    {
        var dummyObj = new object();

        var assembly = exampleType.Assembly;
        var types = assembly.GetTypes();
        foreach (var type in types.Where(IsRelevantType))
        {
            // This forces the static constructor to be executed if there are any static (non-const) fields
            var fields = type.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            var field = fields.FirstOrDefault(x => !x.IsLiteral);
            _ = field?.GetValue(null);
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
