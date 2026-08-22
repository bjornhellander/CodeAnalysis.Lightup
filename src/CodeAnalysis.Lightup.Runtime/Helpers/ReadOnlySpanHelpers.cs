// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Runtime.Helpers
{
    using System;
    using System.Reflection;
    using CodeAnalysis.Lightup.Runtime.Extensions;

    // NOTE: System.ReadOnlySpan<T> is not referenced by this project, so the needed members are located via reflection
    internal static class ReadOnlySpanHelpers
    {
        private const string GenericReadOnlySpanTypeFullName = "System.ReadOnlySpan`1";

        public static bool IsReadOnlySpanType(Type type)
        {
            return type.IsGenericType() && type.GetGenericTypeDefinition().FullName == GenericReadOnlySpanTypeFullName;
        }

        public static ConstructorInfo GetArrayConstructor(Type readOnlySpanType, Type itemType)
        {
            var arrayType = itemType.MakeArrayType();
            var result = readOnlySpanType.GetConstructor(x => IsArrayConstructor(x, arrayType));
            return result;
        }

        private static bool IsArrayConstructor(ConstructorInfo constructor, Type arrayType)
        {
            var parameters = constructor.GetParameters();
            return parameters.Length == 1 && parameters[0].ParameterType == arrayType;
        }
    }
}
