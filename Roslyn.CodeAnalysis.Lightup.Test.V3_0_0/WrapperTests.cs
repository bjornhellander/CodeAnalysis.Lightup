namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Lightup;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WrapperTests
{
    // TODO: Add type from Workspaces.Common
    // TODO: Add type from CSharp.Workspaces
    [TestMethod]
    [DataRow(typeof(OperationKindEx))] // From the Common project
    [DataRow(typeof(SyntaxKindEx))] // From the CSharp project
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
