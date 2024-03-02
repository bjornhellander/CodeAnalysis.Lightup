using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.CodeAnalysis.Lightup.CSharp;
using System;
using System.Linq;

namespace Roslyn.CodeAnalysis.Lightup.Test.CSharp
{
    [TestClass]
    public class SyntaxKindExTests
    {
        [TestMethod]
        public void TestExtensionFieldsMatchActualType()
        {
            var enumNames = typeof(SyntaxKind).GetEnumNames();
            var enumValues = typeof(SyntaxKind).GetEnumValues().Cast<SyntaxKind>().ToArray();
            var enumIntValues = enumValues.Cast<ushort>().ToArray();

            var fields = typeof(SyntaxKindEx).GetFields();
            foreach (var field in fields)
            {
                var fieldName = field.Name;
                var fieldValue = (ushort)field.GetValue(null);

                Assert.IsTrue(field.IsStatic && field.IsLiteral, $"All fields should be constants ({fieldName})");
                Assert.AreEqual(typeof(SyntaxKind), field.FieldType, $"All constants should be of type {nameof(SyntaxKind)} ({fieldName})");

                if (enumNames.Contains(fieldName))
                {
                    var enumValue = (ushort)Enum.Parse(typeof(SyntaxKind), fieldName);
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
}
