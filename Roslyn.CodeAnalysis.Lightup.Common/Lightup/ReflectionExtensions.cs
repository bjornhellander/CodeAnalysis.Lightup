namespace Microsoft.CodeAnalysis.Lightup
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

        public static MethodInfo? GetPublicMethod(this Type type, string name, Type[] paramTypes)
        {
            var method = type.GetMethod(name, paramTypes);
            return method;
        }
    }
}
