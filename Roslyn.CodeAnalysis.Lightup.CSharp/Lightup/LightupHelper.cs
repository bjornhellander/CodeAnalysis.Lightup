namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class LightupHelper
    {
        private static readonly Assembly SyntaxNodeAssembly = typeof(ClassDeclarationSyntax).Assembly;

        internal static Type? FindSyntaxType(string wrappedTypeName)
        {
            return FindType(SyntaxNodeAssembly, wrappedTypeName);
        }

        internal static Type? FindType(Assembly assembly, string wrappedTypeName)
        {
            var wrappedType = assembly.GetType(wrappedTypeName);
            return wrappedType;
        }

        internal static bool Is(object? obj, Type? wrappedType)
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

        internal static TObject? As<TObject>(object? obj, Type? wrappedType)
            where TObject : class
        {
            if (!(obj is null) && obj.GetType().IsAssignableFrom(wrappedType))
            {
                return (TObject)obj;
            }
            else
            {
                return null;
            }
        }

        internal static Func<TObject, TResult> CreateGetAccessor<TObject, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var propertyInfo = wrappedType.GetProperty(memberName);
            if (propertyInfo == null)
            {
                return FallbackAccessor;
            }

            var getMethod = propertyInfo.GetAccessors().Single();

            var objParameter = Expression.Parameter(typeof(TObject), "obj");

            var instance = Expression.Convert(objParameter, wrappedType);
            var propertyValue = Expression.Property(instance, memberName);
            var possiblyWrappedValue = GetPossiblyWrappedValue<TResult>(propertyValue);
            var lambda = Expression.Lambda<Func<TObject, TResult>>(possiblyWrappedValue, objParameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node)
            {
                // TODO: InvalidOperationExcception instead?
                throw new NullReferenceException();
            }
        }

        internal static Func<TObject, T1, TResult> CreateMethodAccessor<TWrapper, TObject, T1, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var paramTypes = new[] { type1 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var wrapMethod = typeof(TWrapper).GetMethod("As");

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter);
            var wrappedReturnValue = Expression.Call(null, wrapMethod, returnValue);

            var lambda = Expression.Lambda<Func<TObject, T1, TResult>>(wrappedReturnValue, objParameter, arg1Parameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node, T1 arg1)
            {
                throw new NullReferenceException();
            }
        }

        internal static Func<TObject, T1, T2, TResult> CreateMethodAccessor<TWrapper, TObject, T1, T2, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type13 = typeof(TResult);
            var paramTypes = new[] { type1, type2 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var wrapMethod = typeof(TWrapper).GetMethod("As");

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");
            var arg2Parameter = Expression.Parameter(type2, "arg2");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter, arg2Parameter);
            var wrappedReturnValue = Expression.Call(null, wrapMethod, returnValue);

            var lambda = Expression.Lambda<Func<TObject, T1, T2, TResult>>(wrappedReturnValue, objParameter, arg1Parameter, arg2Parameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node, T1 arg1, T2 arg2)
            {
                throw new NullReferenceException();
            }
        }

        internal static Func<TObject, T1, T2, T3, TResult> CreateMethodAccessor<TWrapper, TObject, T1, T2, T3, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type13 = typeof(TResult);
            var paramTypes = new[] { type1, type2, type3 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var wrapMethod = typeof(TWrapper).GetMethod("As");

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");
            var arg2Parameter = Expression.Parameter(type2, "arg2");
            var arg3Parameter = Expression.Parameter(type3, "arg3");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter, arg2Parameter, arg3Parameter);
            var wrappedReturnValue = Expression.Call(null, wrapMethod, returnValue);

            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, TResult>>(wrappedReturnValue, objParameter, arg1Parameter, arg2Parameter, arg3Parameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node, T1 arg1, T2 arg2, T3 arg3)
            {
                throw new NullReferenceException();
            }
        }

        internal static Func<TObject, T1, T2, T3, T4, TResult> CreateMethodAccessor<TWrapper, TObject, T1, T2, T3, T4, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var type13 = typeof(TResult);
            var paramTypes = new[] { type1, type2, type3 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var wrapMethod = typeof(TWrapper).GetMethod("As");

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");
            var arg2Parameter = Expression.Parameter(type2, "arg2");
            var arg3Parameter = Expression.Parameter(type3, "arg3");
            var arg4Parameter = Expression.Parameter(type4, "arg4");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter);
            var wrappedReturnValue = Expression.Call(null, wrapMethod, returnValue);

            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, TResult>>(wrappedReturnValue, objParameter, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
                throw new NullReferenceException();
            }
        }

        internal static Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, TResult> CreateMethodAccessor<TWrapper, TObject, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var type5 = typeof(T5);
            var type6 = typeof(T6);
            var type7 = typeof(T7);
            var type8 = typeof(T8);
            var type13 = typeof(TResult);
            var paramTypes = new[] { type1, type2, type3, type4, type5, type6, type7, type8 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var wrapMethod = typeof(TWrapper).GetMethod("As");

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");
            var arg2Parameter = Expression.Parameter(type2, "arg2");
            var arg3Parameter = Expression.Parameter(type3, "arg3");
            var arg4Parameter = Expression.Parameter(type4, "arg4");
            var arg5Parameter = Expression.Parameter(type5, "arg5");
            var arg6Parameter = Expression.Parameter(type6, "arg6");
            var arg7Parameter = Expression.Parameter(type7, "arg7");
            var arg8Parameter = Expression.Parameter(type8, "arg8");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter, arg6Parameter, arg7Parameter, arg8Parameter);
            var wrappedReturnValue = Expression.Call(null, wrapMethod, returnValue);

            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, TResult>>(wrappedReturnValue, objParameter, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter, arg6Parameter, arg7Parameter, arg8Parameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            {
                throw new NullReferenceException();
            }
        }

        internal static Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> CreateMethodAccessor<TWrapper, TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var type5 = typeof(T5);
            var type6 = typeof(T6);
            var type7 = typeof(T7);
            var type8 = typeof(T8);
            var type9 = typeof(T9);
            var type13 = typeof(TResult);
            var paramTypes = new[] { type1, type2, type3, type4, type5, type6, type7, type8, type9 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var wrapMethod = typeof(TWrapper).GetMethod("As");

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");
            var arg2Parameter = Expression.Parameter(type2, "arg2");
            var arg3Parameter = Expression.Parameter(type3, "arg3");
            var arg4Parameter = Expression.Parameter(type4, "arg4");
            var arg5Parameter = Expression.Parameter(type5, "arg5");
            var arg6Parameter = Expression.Parameter(type6, "arg6");
            var arg7Parameter = Expression.Parameter(type7, "arg7");
            var arg8Parameter = Expression.Parameter(type8, "arg8");
            var arg9Parameter = Expression.Parameter(type9, "arg9");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter, arg6Parameter, arg7Parameter, arg8Parameter, arg9Parameter);
            var wrappedReturnValue = Expression.Call(null, wrapMethod, returnValue);

            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>(wrappedReturnValue, objParameter, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter, arg6Parameter, arg7Parameter, arg8Parameter, arg9Parameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            {
                throw new NullReferenceException();
            }
        }

        internal static Func<TObject, T1, T2, T3, T4, T5, TResult> CreateMethodAccessor<TWrapper, TObject, T1, T2, T3, T4, T5, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var type5 = typeof(T5);
            var type13 = typeof(TResult);
            var paramTypes = new[] { type1, type2, type3, type4, type5 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var wrapMethod = typeof(TWrapper).GetMethod("As");

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");
            var arg2Parameter = Expression.Parameter(type2, "arg2");
            var arg3Parameter = Expression.Parameter(type3, "arg3");
            var arg4Parameter = Expression.Parameter(type4, "arg4");
            var arg5Parameter = Expression.Parameter(type5, "arg5");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter);
            var wrappedReturnValue = Expression.Call(null, wrapMethod, returnValue);

            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, TResult>>(wrappedReturnValue, objParameter, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
                throw new NullReferenceException();
            }
        }

        internal static Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> CreateMethodAccessor<TWrapper, TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var type5 = typeof(T5);
            var type6 = typeof(T6);
            var type7 = typeof(T7);
            var type8 = typeof(T8);
            var type9 = typeof(T9);
            var type10 = typeof(T10);
            var type11 = typeof(T11);
            var type12 = typeof(T12);
            var type13 = typeof(TResult);
            var paramTypes = new[] { type1, type2, type3, type4, type5, type6, type7, type8, type9, type10, type11, type12 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var wrapMethod = typeof(TWrapper).GetMethod("As");

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");
            var arg2Parameter = Expression.Parameter(type2, "arg2");
            var arg3Parameter = Expression.Parameter(type3, "arg3");
            var arg4Parameter = Expression.Parameter(type4, "arg4");
            var arg5Parameter = Expression.Parameter(type5, "arg5");
            var arg6Parameter = Expression.Parameter(type6, "arg6");
            var arg7Parameter = Expression.Parameter(type7, "arg7");
            var arg8Parameter = Expression.Parameter(type8, "arg8");
            var arg9Parameter = Expression.Parameter(type9, "arg9");
            var arg10Parameter = Expression.Parameter(type10, "arg10");
            var arg11Parameter = Expression.Parameter(type11, "arg11");
            var arg12Parameter = Expression.Parameter(type12, "arg12");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter, arg6Parameter, arg7Parameter, arg8Parameter, arg9Parameter, arg10Parameter, arg11Parameter, arg12Parameter);
            var wrappedReturnValue = Expression.Call(null, wrapMethod, returnValue);

            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>(wrappedReturnValue, objParameter, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter, arg6Parameter, arg7Parameter, arg8Parameter, arg9Parameter, arg10Parameter, arg11Parameter, arg12Parameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            {
                throw new NullReferenceException();
            }
        }

        internal static Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> CreateMethodAccessor<TWrapper, TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var type5 = typeof(T5);
            var type6 = typeof(T6);
            var type7 = typeof(T7);
            var type8 = typeof(T8);
            var type9 = typeof(T9);
            var type10 = typeof(T10);
            var type11 = typeof(T11);
            var type12 = typeof(T12);
            var type13 = typeof(T13);
            var paramTypes = new[] { type1, type2, type3, type4, type5, type6, type7, type8, type9, type10, type11, type12, type13 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var wrapMethod = typeof(TWrapper).GetMethod("As");

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");
            var arg2Parameter = Expression.Parameter(type2, "arg2");
            var arg3Parameter = Expression.Parameter(type3, "arg3");
            var arg4Parameter = Expression.Parameter(type4, "arg4");
            var arg5Parameter = Expression.Parameter(type5, "arg5");
            var arg6Parameter = Expression.Parameter(type6, "arg6");
            var arg7Parameter = Expression.Parameter(type7, "arg7");
            var arg8Parameter = Expression.Parameter(type8, "arg8");
            var arg9Parameter = Expression.Parameter(type9, "arg9");
            var arg10Parameter = Expression.Parameter(type10, "arg10");
            var arg11Parameter = Expression.Parameter(type11, "arg11");
            var arg12Parameter = Expression.Parameter(type12, "arg12");
            var arg13Parameter = Expression.Parameter(type13, "arg13");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter, arg6Parameter, arg7Parameter, arg8Parameter, arg9Parameter, arg10Parameter, arg11Parameter, arg12Parameter, arg13Parameter);
            var wrappedReturnValue = Expression.Call(null, wrapMethod, returnValue);

            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>(wrappedReturnValue, objParameter, arg1Parameter, arg2Parameter, arg3Parameter, arg4Parameter, arg5Parameter, arg6Parameter, arg7Parameter, arg8Parameter, arg9Parameter, arg10Parameter, arg11Parameter, arg12Parameter, arg13Parameter);
            var func = lambda.Compile();
            return func;

            static TResult FallbackAccessor(TObject node, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            {
                throw new NullReferenceException();
            }
        }

        // NOTE: TWrapper is unused, but leaving it to make code generation more uniform
        internal static Action<TObject, T1> CreateVoidMethodAccessor<TWrapper, TObject, T1>(Type? wrappedType, string memberName)
        {
            if (wrappedType == null)
            {
                return FallbackAccessor;
            }

            var type1 = typeof(T1);
            var paramTypes = new[] { type1 };
            var method = wrappedType.GetMethod(memberName, paramTypes);
            if (method == null)
            {
                return FallbackAccessor;
            }

            var objParameter = Expression.Parameter(typeof(TObject), "obj");
            var arg1Parameter = Expression.Parameter(type1, "arg1");

            var instance = Expression.Convert(objParameter, wrappedType);
            var returnValue = Expression.Call(instance, method, arg1Parameter);

            var lambda = Expression.Lambda<Action<TObject, T1>>(returnValue, objParameter, arg1Parameter);
            var func = lambda.Compile();
            return func;

            static void FallbackAccessor(TObject node, T1 arg1)
            {
                throw new NullReferenceException();
            }
        }

        private static Expression GetPossiblyWrappedValue<TResult>(Expression nativeValue)
        {
            var resultType = typeof(TResult);
            var isWrappedType = resultType.Assembly.FullName.StartsWith("Roslyn.CodeAnalysis.Lightup");

            if (!isWrappedType)
            {
                return nativeValue;
            }

            var wrapMethod = resultType.GetMethod("As");
            var wrappedValue = Expression.Call(null, wrapMethod, nativeValue);
            return wrappedValue;
        }
    }
}
