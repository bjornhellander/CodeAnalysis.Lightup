namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public abstract class EnumTestsBase<TExtension, TNative, TInt>
{
    [TestMethod]
    public void TestExtensionFieldsMatchActualType()
    {
        var enumNames = typeof(TNative).GetEnumNames();
        var enumValues = typeof(TNative).GetEnumValues().Cast<TNative>().ToArray();
        var enumIntValues = enumValues.Cast<TInt>().ToArray();

        var fields = typeof(TExtension).GetFields();
        foreach (var field in fields)
        {
            var fieldName = field.Name;

            var fieldObjValue = field.GetValue(null);
            Assert.IsNotNull(fieldObjValue);
            var fieldIntValue = (TInt)fieldObjValue;

            Assert.IsTrue(field.IsStatic && field.IsLiteral, $"All fields should be constants ({fieldName})");
            Assert.AreEqual(typeof(TNative), field.FieldType, $"All constants should be of type {nameof(TNative)} ({fieldName})");

            if (enumNames.Contains(fieldName))
            {
                var enumObjValue = Enum.Parse(typeof(TNative), fieldName);
                var enumIntValue = (TInt)enumObjValue;
                Assert.AreEqual(enumIntValue, fieldIntValue, $"Constants should have expected value, when name is known ({fieldName})");
            }
        }
    }
}
