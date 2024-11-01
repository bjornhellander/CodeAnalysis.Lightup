// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Runtime.Extensions
{
    using System;
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

        public static ConstructorInfo? GetPublicConstructor(this Type type, string[] paramTags)
        {
            ConstructorInfo? selectedMethod = null;

            foreach (var currConstructor in type.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                if (!HasCorrectParameters(currConstructor, paramTags))
                {
                    continue;
                }

                if (selectedMethod != null)
                {
                    throw new InvalidOperationException("Found more than one matching method");
                }

                selectedMethod = currConstructor;
            }

            if (selectedMethod == null)
            {
                return null;
            }

            return selectedMethod;
        }

        public static MethodInfo? GetPublicPropertyGetter(this Type type, string name)
        {
            var property = type.GetProperty(name);
            var method = property?.GetGetMethod();
            return method;
        }

        public static MethodInfo? GetPublicPropertySetter(this Type type, string name)
        {
            var property = type.GetProperty(name);
            var method = property?.GetSetMethod();
            return method;
        }

        public static MethodInfo? GetPublicEventAdder(this Type type, string name)
        {
            var @event = type.GetEvent(name);
            var method = @event?.GetAddMethod();
            return method;
        }

        public static MethodInfo? GetPublicEventRemover(this Type type, string name)
        {
            var @event = type.GetEvent(name);
            var method = @event?.GetRemoveMethod();
            return method;
        }

        public static MethodInfo? GetPublicMethod(this Type type, string name, string[] paramTags)
        {
            MethodInfo? selectedMethod = null;

            foreach (var currMethod in type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                if (currMethod.Name != name)
                {
                    continue;
                }

                if (!HasCorrectParameters(currMethod, paramTags))
                {
                    continue;
                }

                if (selectedMethod != null)
                {
                    throw new InvalidOperationException("Found more than one matching method");
                }

                selectedMethod = currMethod;
            }

            if (selectedMethod == null)
            {
                return null;
            }

            return selectedMethod;
        }

        private static bool HasCorrectParameters(MethodBase method, string[] paramTags)
        {
            var parameters = method.GetParameters();
            if (parameters.Length != paramTags.Length)
            {
                return false;
            }

            for (var pi = 0; pi < parameters.Length; pi++)
            {
                // TODO: Comparing just the name and type name is not good enough in theory, but might be good enough in practise
                // TODO: At the same time it is overly complicated. Simplify!
                if (paramTags[pi] != parameters[pi].Name + parameters[pi].ParameterType.Name)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
