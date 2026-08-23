// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Runtime.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using CodeAnalysis.Lightup.Runtime.Extensions;

    // NOTE: System.Collections.Immutable is not referenced by this project, so the needed types are located via reflection
    internal static class ImmutableArrayHelpers
    {
        private const string GenericImmutableArrayTypeFullName = "System.Collections.Immutable.ImmutableArray`1";
        private const string ImmutableArrayTypeFullName = "System.Collections.Immutable.ImmutableArray";
        private const string ImmutableArrayExtensionsTypeFullName = "System.Linq.ImmutableArrayExtensions";

        // NOTE: The methods in the cache below are looked up via reflection once, the first time we see an ImmutableArray<>,
        // since the lookup is somewhat expensive and the result (before MakeGenericMethod specialization) is always the same.
        private static MethodCache? methodCache;

        public static bool IsImmutableArrayType(Type type)
        {
            if (!type.IsGenericType() || type.GetGenericTypeDefinition().FullName != GenericImmutableArrayTypeFullName)
            {
                return false;
            }

            methodCache ??= CreateMethodCache(type);

            return true;
        }

        public static MethodInfo GetSelectMethod(Type sourceItemType, Type resultItemType)
        {
            var genericMethod = methodCache!.SelectMethod; // The cache must have been initialized by now
            var specializedMethod = genericMethod.MakeGenericMethod(sourceItemType, resultItemType);
            return specializedMethod;
        }

        public static MethodInfo GetToImmutableArrayMethod(Type nativeItemType)
        {
            var genericMethod = methodCache!.ToImmutableArrayMethod; // The cache must have been initialized by now
            var specializedMethod = genericMethod.MakeGenericMethod(nativeItemType);
            return specializedMethod;
        }

        private static MethodCache CreateMethodCache(Type immutableArrayType)
        {
            var assembly = immutableArrayType.GetGenericTypeDefinition().GetAssembly();
            var selectMethod = GetImmutableArraySelectMethod(assembly);
            var toImmutableArrayMethod = GetImmutableArrayToImmutableArrayMethod(assembly);
            return new MethodCache(selectMethod, toImmutableArrayMethod);
        }

        private static MethodInfo GetImmutableArraySelectMethod(Assembly assembly)
        {
            var type = GetPublicType(assembly, ImmutableArrayExtensionsTypeFullName);
            var method = type.GetMethod(IsImmutableArraySelectMethod);
            return method;
        }

        private static bool IsImmutableArraySelectMethod(MethodInfo method)
        {
            if (method.Name != "Select")
            {
                return false;
            }

            return true;
        }

        private static MethodInfo GetImmutableArrayToImmutableArrayMethod(Assembly assembly)
        {
            var type = GetPublicType(assembly, ImmutableArrayTypeFullName);
            var method = type.GetMethod(IsImmutableArrayToImmutableArrayMethod);
            return method;
        }

        private static bool IsImmutableArrayToImmutableArrayMethod(MethodInfo method)
        {
            if (method.Name != "ToImmutableArray")
            {
                return false;
            }

            var parameters = method.GetParameters();
            if (parameters.Length != 1)
            {
                return false;
            }

            var parameterType = parameters[0].ParameterType;
            if (!parameterType.IsGenericType() || parameterType.GetGenericTypeDefinition() != typeof(IEnumerable<>))
            {
                return false;
            }

            return true;
        }

        private static Type GetPublicType(Assembly assembly, string typeFullName)
        {
            var type = assembly.GetPublicType(typeFullName);
            return type ?? throw new InvalidOperationException($"Could not find type '{typeFullName}'");
        }

        private sealed class MethodCache
        {
            public MethodCache(MethodInfo selectMethod, MethodInfo toImmutableArrayMethod)
            {
                SelectMethod = selectMethod;
                ToImmutableArrayMethod = toImmutableArrayMethod;
            }

            public MethodInfo SelectMethod { get; }

            public MethodInfo ToImmutableArrayMethod { get; }
        }
    }
}
