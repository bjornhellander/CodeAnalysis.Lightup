// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal static class ReflectionExtensions
    {
        public static Type? GetPublicType(this Assembly assembly, string name)
        {
            var type = assembly.GetType(name);
            return type != null && type.IsPublic ? type : null;
        }

        public static FieldInfo? GetPublicField(this Type type, string name)
        {
            var field = type.GetField(name);
            return field != null && field.IsPublic ? field : null;
        }

        public static MethodInfo? GetPublicPropertyGetter(this Type type, string name)
        {
            var property = type.GetProperty(name);
            var method = property?.GetGetMethod();
            return method;
        }

        public static MethodInfo? GetPublicPropertySetter(this Type type, string name, out Type[] nativeParamTypes)
        {
            var property = type.GetProperty(name);
            var method = property?.GetSetMethod();
            //// TODO: This can be simplified
            nativeParamTypes = method?.GetParameters().Select(x => x.ParameterType).ToArray() ?? Array.Empty<Type>();
            return method;
        }

        public static MethodInfo? GetPublicMethod(this Type type, string name, string[] paramTypeNames, out Type[] paramTypes)
        {
            MethodInfo? selectedMethod = null;
            Type[]? selectedParameterTypes = null;

            foreach (var currMethod in type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                if (currMethod.Name != name)
                {
                    continue;
                }

                var currParameters = currMethod.GetParameters();
                if (currParameters.Length != paramTypeNames.Length)
                {
                    continue;
                }

                var currParameterTypes = new Type[currParameters.Length];
                for (var pi = 0; pi < currParameters.Length; pi++)
                {
                    // TODO: Comparing just the name is not good enough in theory, but might be good enough in practise
                    if (currParameters[pi].ParameterType.Name != paramTypeNames[pi])
                    {
                        currParameterTypes = null;
                        break;
                    }

                    currParameterTypes[pi] = currParameters[pi].ParameterType;
                }

                if (currParameterTypes == null)
                {
                    continue;
                }

                if (selectedMethod != null)
                {
                    throw new InvalidOperationException("Found more than one matching method");
                }

                selectedMethod = currMethod;
                selectedParameterTypes = currParameterTypes;
            }

            if (selectedMethod == null || selectedParameterTypes == null)
            {
                paramTypes = Array.Empty<Type>();
                return null;
            }

            paramTypes = selectedParameterTypes;
            return selectedMethod;
        }
    }
}
