// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0;

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public abstract class EnumTestsBase<TExtension, TNative>
{
    [TestMethod]
    public void TestExtensionFieldsMatchActualType()
    {
        var enumNames = typeof(TNative).GetEnumNames();

        var fields = typeof(TExtension).GetFields();
        foreach (var field in fields)
        {
            var fieldName = field.Name;

            var fieldValue = field.GetValue(null);
            Assert.IsNotNull(fieldValue);

            Assert.IsTrue(field.IsStatic && field.IsLiteral, $"All fields should be constants ({fieldName})");
            Assert.AreEqual(typeof(TNative), field.FieldType, $"All constants should be of type {nameof(TNative)} ({fieldName})");

            if (enumNames.Contains(fieldName))
            {
                var enumValue = Enum.Parse(typeof(TNative), fieldName);
                Assert.AreEqual(enumValue, fieldValue, $"Constants should have expected value, when name is known ({fieldName})");
            }
        }
    }
}
