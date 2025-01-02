// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_6_1;

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public static class EnumTestsHelper
{
    public static void CheckEnum(Type extensionEnumType, Type nativeEnumType)
    {
        Assert.IsTrue(nativeEnumType.IsEnum);
        var enumNames = nativeEnumType.GetEnumNames();

        var fields = extensionEnumType.GetFields();
        foreach (var field in fields)
        {
            var fieldName = field.Name;

            var fieldValue = field.GetValue(null);
            Assert.IsNotNull(fieldValue);

            Assert.IsTrue(field.IsStatic && field.IsLiteral, $"All fields should be constants ({fieldName})");
            Assert.AreEqual(nativeEnumType, field.FieldType, $"All constants should be of type {nativeEnumType.Name} ({fieldName})");

            if (enumNames.Contains(fieldName))
            {
                var enumValue = Enum.Parse(nativeEnumType, fieldName);
                Assert.AreEqual(enumValue, fieldValue, $"Constants should have expected value, when name is known ({fieldName})");
            }
        }
    }
}
