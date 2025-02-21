// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Runtime.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal static class ReflectionExtensions
    {
        public static Type? GetPublicType(this Assembly assembly, string name)
        {
            var type = assembly.GetType(name);
            return type != null && (type.GetTypeInfo().IsPublic || type.GetTypeInfo().IsNestedPublic) ? type : null;
        }

        public static bool IsValueType(this Type type)
        {
            var result = type.GetTypeInfo().IsValueType;
            return result;
        }

        public static bool IsEnum(this Type type)
        {
            var result = type.GetTypeInfo().IsEnum;
            return result;
        }

        public static bool IsGenericType(this Type type)
        {
            var result = type.GetTypeInfo().IsGenericType;
            return result;
        }

        public static bool IsAssignableFrom(this Type type, Type otherType)
        {
            var result = type.GetTypeInfo().IsAssignableFrom(otherType.GetTypeInfo());
            return result;
        }

        public static FieldInfo? GetPublicField(this Type type, string name)
        {
            var field = type.GetTypeInfo().GetDeclaredField(name);
            return field != null ? field : null;
        }

        public static ConstructorInfo? GetPublicConstructor(this Type type, string[] paramTags)
        {
            ConstructorInfo? selectedConstructor = null;

            foreach (var currConstructor in type.GetTypeInfo().DeclaredConstructors.Where(x => x.IsPublic && !x.IsStatic))
            {
                if (!HasCorrectParameters(currConstructor, paramTags))
                {
                    continue;
                }

                if (selectedConstructor != null)
                {
                    throw new InvalidOperationException("Found more than one matching method");
                }

                selectedConstructor = currConstructor;
            }

            if (selectedConstructor == null)
            {
                return null;
            }

            return selectedConstructor;
        }

        public static ConstructorInfo GetConstructor(this Type type, Func<ConstructorInfo, bool>? predicate = null)
        {
            predicate ??= _ => true;
            var constructorInfo = type.GetTypeInfo().DeclaredConstructors.Single(predicate);
            return constructorInfo;
        }

        public static MethodInfo? GetPublicPropertyGetter(this Type type, string name)
        {
            var property = type.GetTypeInfo().GetDeclaredProperty(name);
            var method = property?.GetMethod;
            return (method != null && method.IsPublic) ? method : null;
        }

        public static MethodInfo? GetPublicPropertySetter(this Type type, string name)
        {
            var property = type.GetTypeInfo().GetDeclaredProperty(name);
            var method = property?.SetMethod;
            return (method != null && method.IsPublic) ? method : null;
        }

        public static MethodInfo? GetPublicEventAdder(this Type type, string name)
        {
            var @event = type.GetTypeInfo().GetDeclaredEvent(name);
            var method = @event?.AddMethod;
            return (method != null && method.IsPublic) ? method : null;
        }

        public static MethodInfo? GetPublicEventRemover(this Type type, string name)
        {
            var @event = type.GetTypeInfo().GetDeclaredEvent(name);
            var method = @event?.RemoveMethod;
            return (method != null && method.IsPublic) ? method : null;
        }

        public static MethodInfo? GetPublicMethod(this Type type, string name, string[] paramTags)
        {
            MethodInfo? selectedMethod = null;

            foreach (var currMethod in type.GetTypeInfo().DeclaredMethods.Where(x => x.IsPublic))
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

        public static MethodInfo GetPublicMethod(this Type type, string name)
        {
            var result = type.GetTypeInfo().GetDeclaredMethod(name);
            return result;
        }

        public static MethodInfo GetMethod(this Type type, Func<MethodInfo, bool> predicate)
        {
            var result = type.GetTypeInfo().DeclaredMethods.Single(predicate);
            return result;
        }
    }
}
