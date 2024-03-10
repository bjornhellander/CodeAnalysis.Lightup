using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Roslyn.CodeAnalysis.Lightup.CSharp
{
    internal static class WrapperHelper
    {
        private static readonly Assembly syntaxNodeAssembly = typeof(ClassDeclarationSyntax).Assembly;

        internal static Type? FindSyntaxType(string wrappedTypeName)
        {
            return FindType(syntaxNodeAssembly, wrappedTypeName);
        }

        internal static Type? FindType(Assembly assembly, string wrappedTypeName)
        {
            var wrappedType = assembly.GetType(wrappedTypeName);
            return wrappedType;
        }

        internal static bool Is(SyntaxNode? obj, Type? wrappedType)
        {
            if (obj == null)
            {
                return false;
            }

            if (wrappedType is null || !wrappedType.IsAssignableFrom(obj.GetType()))
            {
                return false;
            }

            return true;
        }

        internal static SyntaxNode? As(SyntaxNode? obj, Type? wrappedType)
        {
            if (!(obj is null) && obj.GetType().IsAssignableFrom(wrappedType))
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        internal static Func<SyntaxNode?, T> CreateGetAccessor<T>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var getMethod = wrappedType.GetProperty(memberName).GetAccessors().Single();

            var objParameter = Expression.Parameter(typeof(SyntaxNode), "obj");
            var instance = Expression.Convert(objParameter, wrappedType);
            var value = Expression.Property(instance, memberName);
            var lambda = Expression.Lambda<Func<SyntaxNode?, T>>(value, objParameter);
            var func = lambda.Compile();
            return func;

            static T FallbackAccessor(SyntaxNode? node)
            {
                throw new NullReferenceException();
            }
        }

        internal static Func<SyntaxNode?, T1, T2> CreateMethodAccessor<T1, T2>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var method = wrappedType.GetMethod(memberName);
            var wrapMethod = typeof(T2).GetMethod("As");
            var objParameter = Expression.Parameter(typeof(SyntaxNode), "obj");
            var arg1Parameter = Expression.Parameter(typeof(T1), "arg1");
            var instance = Expression.Convert(objParameter, wrappedType);
            var newObj = Expression.Call(instance, method, arg1Parameter);
            var newWrapper = Expression.Call(null, wrapMethod, newObj);
            var lambda = Expression.Lambda<Func<SyntaxNode?, T1, T2>>(newWrapper, objParameter, arg1Parameter);
            var func = lambda.Compile();
            return func;

            static T2 FallbackAccessor(SyntaxNode? node, T1 arg1)
            {
                throw new NullReferenceException();
            }
        }
    }
}
