using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Roslyn.CodeAnalysis.Lightup.Test;

[TestClass]
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
            var fieldValue = (TInt)field.GetValue(null);

            Assert.IsTrue(field.IsStatic && field.IsLiteral, $"All fields should be constants ({fieldName})");
            Assert.AreEqual(typeof(TNative), field.FieldType, $"All constants should be of type {nameof(TNative)} ({fieldName})");

            if (enumNames.Contains(fieldName))
            {
                var enumValue = (TInt)Enum.Parse(typeof(TNative), fieldName);
                Assert.AreEqual(enumValue, fieldValue, $"Constants should have expected value, when name is known ({fieldName})");
            }
            else
            {
                var fieldHasKnownValue = enumIntValues.Contains(fieldValue);
                Assert.IsFalse(fieldHasKnownValue, $"Constant should have unknown value, when name is unknown ({fieldName})");
            }
        }
    }
}
