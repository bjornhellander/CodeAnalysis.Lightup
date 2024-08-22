namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class LightupHelperBase
    {
        public static Type? FindType(Assembly assembly, string wrappedTypeName)
        {
            var wrappedType = assembly.GetType(wrappedTypeName);
            return wrappedType;
        }

        public static bool Is(object? obj, Type? wrappedType)
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

        public static TObject? As<TObject>(object? obj, Type? wrappedType)
            where TObject : class
        {
            if (!(obj is null) && wrappedType != null && wrappedType.IsAssignableFrom(obj.GetType()))
            {
                return (TObject)obj;
            }
            else
            {
                return null;
            }
        }

        public static Func<TObject, TResult> CreateGetAccessor<TObject, TResult>(Type? wrappedType, string memberName)
        {
            var propertyInfo = wrappedType?.GetProperty(memberName);
            var method = propertyInfo?.GetMethod;

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), Array.Empty<Type>(), typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, TResult> CreateMethodAccessor<TObject, TResult>(Type? wrappedType, string memberName)
        {
            var paramTypes = Array.Empty<Type>();
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, T1, TResult> CreateMethodAccessor<TObject, T1, TResult>(Type? wrappedType, string memberName)
        {
            var type1 = typeof(T1);
            var paramTypes = new[] { type1 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, T1, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, T1, T2, TResult> CreateMethodAccessor<TObject, T1, T2, TResult>(Type? wrappedType, string memberName)
        {
            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var paramTypes = new[] { type1, type2 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, T1, T2, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, T1, T2, T3, TResult> CreateMethodAccessor<TObject, T1, T2, T3, TResult>(Type? wrappedType, string memberName)
        {
            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var paramTypes = new[] { type1, type2, type3 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, T1, T2, T3, T4, TResult> CreateMethodAccessor<TObject, T1, T2, T3, T4, TResult>(Type? wrappedType, string memberName)
        {
            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var paramTypes = new[] { type1, type2, type3, type4 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, T1, T2, T3, T4, T5, TResult> CreateMethodAccessor<TObject, T1, T2, T3, T4, T5, TResult>(Type? wrappedType, string memberName)
        {
            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var type5 = typeof(T5);
            var paramTypes = new[] { type1, type2, type3, type4, type5 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, TResult> CreateMethodAccessor<TObject, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Type? wrappedType, string memberName)
        {
            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var type5 = typeof(T5);
            var type6 = typeof(T6);
            var type7 = typeof(T7);
            var type8 = typeof(T8);
            var paramTypes = new[] { type1, type2, type3, type4, type5, type6, type7, type8 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> CreateMethodAccessor<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Type? wrappedType, string memberName)
        {
            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var type3 = typeof(T3);
            var type4 = typeof(T4);
            var type5 = typeof(T5);
            var type6 = typeof(T6);
            var type7 = typeof(T7);
            var type8 = typeof(T8);
            var type9 = typeof(T9);
            var paramTypes = new[] { type1, type2, type3, type4, type5, type6, type7, type8, type9 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> CreateMethodAccessor<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Type? wrappedType, string memberName)
        {
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
            var paramTypes = new[] { type1, type2, type3, type4, type5, type6, type7, type8, type9, type10, type11, type12 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> CreateMethodAccessor<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Type? wrappedType, string memberName)
        {
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
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(TResult));
            var lambda = Expression.Lambda<Func<TObject, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Action<TObject, T1> CreateVoidMethodAccessor<TObject, T1>(Type? wrappedType, string memberName)
        {
            var type1 = typeof(T1);
            var paramTypes = new[] { type1 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(void));
            var lambda = Expression.Lambda<Action<TObject, T1>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static Action<TObject, T1, T2> CreateVoidMethodAccessor<TObject, T1, T2>(Type? wrappedType, string memberName)
        {
            var type1 = typeof(T1);
            var type2 = typeof(T2);
            var paramTypes = new[] { type1, type2 };
            var method = GetMethod(wrappedType, memberName, paramTypes);

            var (body, parameters) = CreateCallExpression(wrappedType, method, typeof(TObject), paramTypes, typeof(void));
            var lambda = Expression.Lambda<Action<TObject, T1, T2>>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        private static (Expression Body, ParameterExpression[] Parameters) CreateCallExpression(
            Type? wrappedType,
            MethodInfo? method,
            Type instanceBaseType,
            Type[] wrapperParameterTypes,
            Type wrapperReturnType)
        {
            var instanceParameter = Expression.Parameter(instanceBaseType, "instance");
            var argParameters = wrapperParameterTypes.Select((x, i) => Expression.Parameter(x, $"arg{i + 1}")).ToArray();
            var allParameters = new[] { instanceParameter }.Concat(argParameters).ToArray();

            var expressions = new List<Expression>();

            var nullReferenceExceptionConstructor = typeof(NullReferenceException).GetConstructor(Array.Empty<Type>());
            var nullCheckStatement = Expression.IfThen(
                Expression.Equal(
                    instanceParameter,
                    Expression.Constant(null)),
                Expression.Throw(
                    Expression.New(
                        nullReferenceExceptionConstructor)));
            expressions.Add(nullCheckStatement);

            if (method == null)
            {
                // TODO: InvalidOperationException instead?
                var notSupportedStatement = Expression.Throw(
                    Expression.New(
                        nullReferenceExceptionConstructor));
                expressions.Add(notSupportedStatement);

                var dummyValue = Expression.Default(wrapperReturnType);
                expressions.Add(dummyValue);
            }
            else
            {
                var instance = Expression.Convert(instanceParameter, wrappedType);
                var argValues = wrapperParameterTypes.Zip(argParameters, (t, p) => GetNativeValue(p, t)).ToArray();

                var returnValue = Expression.Call(instance, method, argValues);
                var wrappedReturnValue = GetPossiblyWrappedValue(returnValue, wrapperReturnType);
                expressions.Add(wrappedReturnValue);
            }

            var block = Expression.Block(expressions);

            return (block, allParameters);
        }

        private static Expression GetPossiblyWrappedValue(Expression input, Type targetType)
        {
            if (input.Type == targetType)
            {
                return input;
            }

            if (targetType.IsEnum)
            {
                var wrappedEnumValue = Expression.Convert(input, targetType);
                return wrappedEnumValue;
            }

            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(ImmutableArray<>))
            {
                var wrapperItemType = targetType.GetGenericArguments()[0];
                var nativeItemType = input.Type.GetGenericArguments()[0];

                var itemWrapMethod = wrapperItemType.GetMethod("As");
                var conversionLambdaParameter = Expression.Parameter(nativeItemType);
                var conversionLambda = Expression.Lambda(
                    Expression.Convert(
                        Expression.Call(itemWrapMethod, conversionLambdaParameter),
                        wrapperItemType),
                    conversionLambdaParameter);

                var selectMethod = GetImmutableArraySelectMethod(nativeItemType, wrapperItemType);

                var temp1 = Expression.Call(selectMethod, input, conversionLambda);

                var toArrayMethod = GetImmutableArrayToImmutableArrayMethod(wrapperItemType);

                var result = Expression.Call(toArrayMethod, temp1);

                return result;
            }

            var wrapMethod = targetType.GetMethod("As");
            if (wrapMethod == null)
            {
                throw new InvalidOperationException("Could not find method 'As' in wrapper");
            }

            var parameters = wrapMethod.GetParameters();
            if (parameters.Length != 1)
            {
                throw new InvalidOperationException("Unexpected parameters in wrapper's 'As' method");
            }

            if (parameters[0].ParameterType == typeof(object) && input.Type.IsValueType)
            {
                input = Expression.Convert(input, typeof(object));
            }

            var wrappedValue = Expression.Call(null, wrapMethod, input);
            return wrappedValue;
        }

        private static Expression GetNativeValue(Expression input, Type type)
        {
            var nativeType = GetNativeType(type)!; // Can not be null if we have gotten this far
            if (nativeType == type)
            {
                return input;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                // IEnumerable<X> where X is a wrapper
                var wrapperItemType = type.GetGenericArguments()[0];
                var nativeItemType = nativeType.GetGenericArguments()[0];

                var unwrapMethod = wrapperItemType.GetMethod("Unwrap");
                var conversionLambdaParameter = Expression.Parameter(wrapperItemType);
                var conversionLambda = Expression.Lambda(
                    Expression.Convert(
                        Expression.Call(conversionLambdaParameter, unwrapMethod),
                        nativeItemType),
                    conversionLambdaParameter);

                var selectMethod = GetEnumerableSelectMethod(wrapperItemType, nativeItemType);

                var result = Expression.Call(selectMethod, input, conversionLambda);
                return result;
            }
            else if (type.IsArray)
            {
                // X[] where X is a wrapper
                var wrapperItemType = type.GetElementType();
                var nativeItemType = nativeType.GetElementType();

                var unwrapMethod = wrapperItemType.GetMethod("Unwrap");
                var conversionLambdaParameter = Expression.Parameter(wrapperItemType);
                var conversionLambda = Expression.Lambda(
                    Expression.Convert(
                        Expression.Call(conversionLambdaParameter, unwrapMethod),
                        nativeItemType),
                    conversionLambdaParameter);

                var selectMethod = GetEnumerableSelectMethod(wrapperItemType, nativeItemType);

                var temp1 = Expression.Call(selectMethod, input, conversionLambda);

                var toArrayMethod = GetEnumerableToArrayMethod(nativeItemType);

                var result = Expression.Call(toArrayMethod, temp1);

                return result;
            }
            else
            {
                // A wrapper
                var unwrapMethod = type.GetMethod("Unwrap");
                var unwrappedValue = Expression.Call(input, unwrapMethod);

                var nativeValue = Expression.Convert(unwrappedValue, nativeType);
                return nativeValue;
            }
        }

        private static MethodInfo? GetMethod(Type? wrappedType, string name, Type[] paramTypes)
        {
            var nativeParamTypes = paramTypes.Select(GetNativeType).ToArray();
            if (nativeParamTypes.Any(x => x == null))
            {
                return null;
            }

            var result = wrappedType?.GetMethod(name, nativeParamTypes);
            return result;
        }

        private static Type? GetNativeType(Type input)
        {
            if (input.IsGenericType && input.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var elementType = input.GetGenericArguments()[0];
                var nativeElementType = GetNativeType(elementType);
                if (nativeElementType == null)
                {
                    return null;
                }

                var nativeType = typeof(IEnumerable<>).MakeGenericType(nativeElementType);
                return nativeType;
            }
            else if (input.IsArray)
            {
                var elementType = input.GetElementType();
                var nativeElementType = GetNativeType(elementType);
                if (nativeElementType == null)
                {
                    return null;
                }

                var nativeType = nativeElementType.MakeArrayType();
                return nativeType;
            }
            else
            {
                var isWrapperType = IsWrapperType(input);
                if (!isWrapperType)
                {
                    return input;
                }

                var field = input.GetField("WrappedType");
                var nativeType = (Type?)field.GetValue(null);
                return nativeType;
            }
        }

        private static bool IsWrapperType(Type type)
        {
            var result = type.Assembly.FullName.StartsWith("Roslyn.CodeAnalysis.Lightup");
            return result;
        }

        private static MethodInfo GetEnumerableSelectMethod(Type sourceItemType, Type resultItemType)
        {
            var genericMethod = GetEnumerableSelectMethod();
            var specializedMethod = genericMethod.MakeGenericMethod(sourceItemType, resultItemType);
            return specializedMethod;
        }

        private static MethodInfo GetEnumerableSelectMethod()
        {
            var result = typeof(Enumerable).GetMethods().Single(IsEnumerableSelectMethod);
            return result;
        }

        private static bool IsEnumerableSelectMethod(MethodInfo method)
        {
            if (method.Name != "Select")
            {
                return false;
            }

            var parameters = method.GetParameters();
            if (parameters.Length != 2)
            {
                return false;
            }

            var parameterType = parameters[1].ParameterType;
            if (parameterType.Name != "Func`2")
            {
                return false;
            }

            return true;
        }

        private static MethodInfo GetEnumerableToArrayMethod(Type nativeItemType)
        {
            var genericMethod = GetEnumerableToArrayMethod();
            var specializedMethod = genericMethod.MakeGenericMethod(nativeItemType);
            return specializedMethod;
        }

        private static MethodInfo GetEnumerableToArrayMethod()
        {
            var result = typeof(Enumerable).GetMethods().Single(IsEnumerableToArrayMethod);
            return result;
        }

        private static bool IsEnumerableToArrayMethod(MethodInfo method)
        {
            if (method.Name != "ToArray")
            {
                return false;
            }

            var parameters = method.GetParameters();
            if (parameters.Length != 1)
            {
                return false;
            }

            return true;
        }

        private static MethodInfo GetImmutableArraySelectMethod(Type sourceItemType, Type resultItemType)
        {
            var genericMethod = GetImmutableArraySelectMethod();
            var specializedMethod = genericMethod.MakeGenericMethod(sourceItemType, resultItemType);
            return specializedMethod;
        }

        private static MethodInfo GetImmutableArraySelectMethod()
        {
            var result = typeof(ImmutableArrayExtensions).GetMethods().Single(IsImmutableArraySelectMethod);
            return result;
        }

        private static bool IsImmutableArraySelectMethod(MethodInfo method)
        {
            if (method.Name != "Select")
            {
                return false;
            }

            return true;
        }

        private static MethodInfo GetImmutableArrayToImmutableArrayMethod(Type nativeItemType)
        {
            var genericMethod = GetImmutableArrayToImmutableArrayMethod();
            var specializedMethod = genericMethod.MakeGenericMethod(nativeItemType);
            return specializedMethod;
        }

        private static MethodInfo GetImmutableArrayToImmutableArrayMethod()
        {
            var result = typeof(ImmutableArray).GetMethods().Single(IsImmutableArrayToImmutableArrayMethod);
            return result;
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
            if (!parameterType.IsGenericType || parameterType.GetGenericTypeDefinition() != typeof(IEnumerable<>))
            {
                return false;
            }

            return true;
        }
    }
}
