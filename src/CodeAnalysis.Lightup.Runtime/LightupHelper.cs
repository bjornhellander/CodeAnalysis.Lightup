// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading.Tasks;
    using CodeAnalysis.Lightup.Runtime.Extensions;
    using CodeAnalysis.Lightup.Runtime.Helpers;

    public class LightupHelper
    {
        public static Type? FindType(Assembly assembly, string wrappedTypeName)
        {
            var wrappedType = assembly.GetPublicType(wrappedTypeName);
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

        public static TObject? Wrap<TObject>(object? obj, Type? wrappedType)
            where TObject : class
        {
            // TODO: Check if this should be optimized
            if (!(obj is null) && wrappedType != null && wrappedType.IsAssignableFrom(obj.GetType()))
            {
                return (TObject)obj;
            }
            else
            {
                return null;
            }
        }

        public static TDelegate CreateStaticReadAccessor<TDelegate>(Type? wrappedType, string memberName)
            where TDelegate : Delegate
        {
            var returnType = GetReturnType<TDelegate>();
            var fieldInfo = wrappedType?.GetPublicField(memberName);

            var (body, parameters) = CreateReadExpression(wrappedType, fieldInfo, null, returnType);
            var lambda = Expression.Lambda<TDelegate>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static TDelegate CreateInstanceConstructorAccessor<TDelegate>(Type? wrappedType, params string[] paramTags)
            where TDelegate : Delegate
        {
            var returnType = GetReturnType<TDelegate>();
            var paramTypes = GetParamTypes<TDelegate>(skipFirst: false);
            var method = wrappedType?.GetPublicConstructor(paramTags);

            var (body, parameters) = CreateNewExpression(method, paramTypes, returnType);
            var lambda = Expression.Lambda<TDelegate>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static TDelegate CreateStaticGetAccessor<TDelegate>(Type? wrappedType, string memberName)
            where TDelegate : Delegate
        {
            var paramTypes = Array.Empty<Type>();
            var returnType = GetReturnType<TDelegate>();
            var method = wrappedType?.GetPublicPropertyGetter(memberName);

            var (body, parameters) = CreateCallExpression(wrappedType, method, null, paramTypes, returnType);
            var lambda = Expression.Lambda<TDelegate>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static TDelegate CreateInstanceGetAccessor<TDelegate>(Type? wrappedType, string memberName)
            where TDelegate : Delegate
        {
            var instanceType = GetInstanceType<TDelegate>();
            var paramTypes = Array.Empty<Type>();
            var returnType = GetReturnType<TDelegate>();
            var method = wrappedType?.GetPublicPropertyGetter(memberName);

            var (body, parameters) = CreateCallExpression(wrappedType, method, instanceType, paramTypes, returnType);
            var lambda = Expression.Lambda<TDelegate>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static TDelegate CreateInstanceSetAccessor<TDelegate>(Type? wrappedType, string memberName)
            where TDelegate : Delegate
        {
            var instanceType = GetInstanceType<TDelegate>();
            var paramTypes = GetParamTypes<TDelegate>();
            var returnType = GetReturnType<TDelegate>();
            var method = wrappedType?.GetPublicPropertySetter(memberName);

            var (body, parameters) = CreateCallExpression(wrappedType, method, instanceType, paramTypes, returnType);
            var lambda = Expression.Lambda<TDelegate>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static TDelegate CreateInstanceAddAccessor<TDelegate>(Type? wrappedType, string memberName)
            where TDelegate : Delegate
        {
            var instanceType = GetInstanceType<TDelegate>();
            var paramTypes = GetParamTypes<TDelegate>();
            var returnType = GetReturnType<TDelegate>();
            var method = wrappedType?.GetPublicEventAdder(memberName);

            var (body, parameters) = CreateCallExpression(wrappedType, method, instanceType, paramTypes, returnType);
            var lambda = Expression.Lambda<TDelegate>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static TDelegate CreateInstanceRemoveAccessor<TDelegate>(Type? wrappedType, string memberName)
            where TDelegate : Delegate
        {
            var instanceType = GetInstanceType<TDelegate>();
            var paramTypes = GetParamTypes<TDelegate>();
            var returnType = GetReturnType<TDelegate>();
            var method = wrappedType?.GetPublicEventRemover(memberName);

            var (body, parameters) = CreateCallExpression(wrappedType, method, instanceType, paramTypes, returnType);
            var lambda = Expression.Lambda<TDelegate>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static TDelegate CreateStaticMethodAccessor<TDelegate>(Type? wrappedType, string memberName, params string[] paramTags)
            where TDelegate : Delegate
        {
            var returnType = GetReturnType<TDelegate>();
            var paramTypes = GetParamTypes<TDelegate>(skipFirst: false);
            var method = wrappedType?.GetPublicMethod(memberName, paramTags);

            var (body, parameters) = CreateCallExpression(wrappedType, method, null, paramTypes, returnType);
            var lambda = Expression.Lambda<TDelegate>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        public static TDelegate CreateInstanceMethodAccessor<TDelegate>(Type? wrappedType, string memberName, params string[] paramTags)
            where TDelegate : Delegate
        {
            var instanceType = GetInstanceType<TDelegate>();
            var paramTypes = GetParamTypes<TDelegate>();
            var returnType = GetReturnType<TDelegate>();
            var method = wrappedType?.GetPublicMethod(memberName, paramTags);

            var (body, parameters) = CreateCallExpression(wrappedType, method, instanceType, paramTypes, returnType);
            var lambda = Expression.Lambda<TDelegate>(body, parameters);
            var func = lambda.Compile();
            return func;
        }

        private static Type GetInstanceType<TDelegate>()
        {
            var type = typeof(TDelegate);
            var invokeMethod = type.GetMethod("Invoke");
            return invokeMethod.GetParameters()[0].ParameterType;
        }

        private static Type[] GetParamTypes<TDelegate>(bool skipFirst = true)
        {
            var type = typeof(TDelegate);
            var invokeMethod = type.GetMethod("Invoke");
            IEnumerable<ParameterInfo> temp = invokeMethod.GetParameters();
            temp = skipFirst ? temp.Skip(1) : temp;
            return temp.Select(x => x.ParameterType).ToArray();
        }

        private static Type GetReturnType<TDelegate>()
        {
            var type = typeof(TDelegate);
            var invokeMethod = type.GetMethod("Invoke");
            return invokeMethod.ReturnType;
        }

        private static (Expression Body, ParameterExpression[] Parameters) CreateReadExpression(
            Type? wrappedType,
            FieldInfo? field,
            Type? instanceBaseType,
            Type wrapperReturnType)
        {
            _ = wrappedType;
            Debug.Assert(instanceBaseType == null, "Unexpected instance base type (only static fields so far)");

            var expressions = new List<Expression>();

            if (field == null)
            {
                var invalidOperationExceptionConstructor = typeof(InvalidOperationException).GetConstructor(Array.Empty<Type>());
                var notSupportedStatement = Expression.Throw(
                    Expression.New(
                        invalidOperationExceptionConstructor));
                expressions.Add(notSupportedStatement);

                var dummyValue = Expression.Default(wrapperReturnType);
                expressions.Add(dummyValue);
            }
            else
            {
                var returnValue = Expression.Field(null, field);
                var wrappedReturnValue = GetPossiblyWrappedValue(returnValue, wrapperReturnType);
                expressions.Add(wrappedReturnValue);
            }

            var block = Expression.Block(expressions);

            var parameters = Array.Empty<ParameterExpression>();
            return (block, parameters);
        }

        private static (Expression Body, ParameterExpression[] Parameters) CreateCallExpression(
            Type? wrappedType,
            MethodInfo? method,
            Type? instanceBaseType,
            Type[] wrapperParameterTypes,
            Type wrapperReturnType)
        {
            var instanceParameter = instanceBaseType != null ? Expression.Parameter(instanceBaseType, "instance") : null;
            var argParameters = wrapperParameterTypes.Select((x, i) => Expression.Parameter(x, $"arg{i + 1}")).ToArray();
            var allParameters = instanceParameter != null ? new[] { instanceParameter }.Concat(argParameters).ToArray() : argParameters;

            // TODO: Try to get rid of these allocations
            var variables = new List<ParameterExpression>();
            var expressions = new List<Expression>();

            if (method == null)
            {
                var invalidOperationExceptionConstructor = typeof(InvalidOperationException).GetConstructor(Array.Empty<Type>());
                var notSupportedStatement = Expression.Throw(
                    Expression.New(
                        invalidOperationExceptionConstructor));
                expressions.Add(notSupportedStatement);

                var dummyValue = Expression.Default(wrapperReturnType);
                expressions.Add(dummyValue);
            }
            else
            {
                var parameters = method.GetParameters();
                var instance = instanceParameter != null ? Expression.Convert(instanceParameter, wrappedType) : null;
                //// TODO: Try to get rid of these allocations
                var preCallExpressions = new List<Expression>();
                var postCallExpressions = new List<Expression>();
                var argValues = Enumerable.Range(0, argParameters.Length).Select(i => GetNativeArgumentValue(argParameters[i], wrapperParameterTypes[i], parameters[i], variables, preCallExpressions, postCallExpressions)).ToArray();

                expressions.AddRange(preCallExpressions);

                var nativeReturnValue = instance != null
                    ? Expression.Call(instance, method, argValues)
                    : Expression.Call(method, argValues);

                var resultVariable = wrapperReturnType != typeof(void) ? Expression.Variable(wrapperReturnType) : null;
                if (resultVariable != null)
                {
                    variables.Add(resultVariable);

                    var wrappedReturnValue = GetPossiblyWrappedValue(nativeReturnValue, wrapperReturnType);
                    expressions.Add(
                        Expression.Assign(
                            resultVariable,
                            wrappedReturnValue));
                }
                else
                {
                    expressions.Add(nativeReturnValue);
                }

                expressions.AddRange(postCallExpressions);

                if (resultVariable != null)
                {
                    expressions.Add(resultVariable);
                }
            }

            var block = Expression.Block(
                variables,
                expressions);

            return (block, allParameters);
        }

        private static Expression GetNativeArgumentValue(
            ParameterExpression input,
            Type wrapperType,
            ParameterInfo nativeParam,
            List<ParameterExpression> variables,
            List<Expression> preCallExpressions,
            List<Expression> postCallExpressions)
        {
            var nativeType = nativeParam.ParameterType;
            if (nativeType == wrapperType)
            {
                return input;
            }

            if (wrapperType.IsByRef)
            {
                if (nativeParam.IsIn)
                {
                    var wrapperElementType = wrapperType.GetElementType();
                    var nativeElementType = nativeType.GetElementType();

                    var tempNativeVar = Expression.Variable(nativeElementType);
                    variables.Add(tempNativeVar);

                    preCallExpressions.Add(
                        Expression.Assign(
                            tempNativeVar,
                            GetNativeValue(
                                input,
                                wrapperElementType,
                                nativeElementType)));

                    return tempNativeVar;
                }
                else if (nativeParam.IsOut)
                {
                    var wrapperElementType = wrapperType.GetElementType();
                    var nativeElementType = nativeType.GetElementType();

                    var tempNativeVar = Expression.Variable(nativeElementType);
                    variables.Add(tempNativeVar);

                    // TODO: If needed, use GetNativeValue instead of Convert
                    postCallExpressions.Add(
                        Expression.Assign(
                            input,
                            Expression.Convert(
                                tempNativeVar,
                                wrapperElementType)));

                    return tempNativeVar;
                }
                else
                {
                    // TODO: If needed, handle for example ref parameter
                    throw new NotImplementedException("Unhandled parameter mode");
                }
            }
            else
            {
                var result = GetNativeValue(input, wrapperType, nativeType);
                return result;
            }
        }

        private static (Expression Body, ParameterExpression[] Parameters) CreateNewExpression(
            ConstructorInfo? constructor,
            Type[] wrapperParameterTypes,
            Type wrapperReturnType)
        {
            var argParameters = wrapperParameterTypes.Select((x, i) => Expression.Parameter(x, $"arg{i + 1}")).ToArray();

            var expressions = new List<Expression>();

            if (constructor == null)
            {
                var invalidOperationExceptionConstructor = typeof(InvalidOperationException).GetConstructor(Array.Empty<Type>());
                var notSupportedStatement = Expression.Throw(
                    Expression.New(
                        invalidOperationExceptionConstructor));
                expressions.Add(notSupportedStatement);

                var dummyValue = Expression.Default(wrapperReturnType);
                expressions.Add(dummyValue);
            }
            else
            {
                var parameters = constructor.GetParameters();
                var argValues = Enumerable.Range(0, argParameters.Length).Select(i => GetNativeValue(argParameters[i], wrapperParameterTypes[i], parameters[i].ParameterType)).ToArray();
                var returnValue = Expression.New(constructor, argValues);
                var wrappedReturnValue = GetPossiblyWrappedValue(returnValue, wrapperReturnType);
                expressions.Add(wrappedReturnValue);
            }

            var block = Expression.Block(expressions);

            return (block, argParameters);
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
            else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(ImmutableArray<>))
            {
                var wrapperItemType = targetType.GetGenericArguments()[0];
                var nativeItemType = input.Type.GetGenericArguments()[0];

                var conversionLambdaParameter = Expression.Parameter(nativeItemType);
                var conversionLambda = Expression.Lambda(
                    GetPossiblyWrappedValue(conversionLambdaParameter, wrapperItemType),
                    conversionLambdaParameter);

                var selectMethod = ImmutableArrayHelpers.GetSelectMethod(nativeItemType, wrapperItemType);
                var temp = Expression.Call(selectMethod, input, conversionLambda);

                var toArrayMethod = ImmutableArrayHelpers.GetToImmutableArrayMethod(wrapperItemType);
                var result = Expression.Call(toArrayMethod, temp);

                return result;
            }
            else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var wrapperItemType = targetType.GetGenericArguments()[0];
                var nativeItemType = input.Type.GetGenericArguments()[0];

                var conversionLambdaParameter = Expression.Parameter(nativeItemType);
                var conversionLambda = Expression.Lambda(
                    GetPossiblyWrappedValue(conversionLambdaParameter, wrapperItemType),
                    conversionLambdaParameter);

                var selectMethod = EnumerableHelpers.GetSelectMethod(nativeItemType, wrapperItemType);
                var result = Expression.Call(selectMethod, input, conversionLambda);

                return result;
            }
            else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                var wrapperItemType = targetType.GetGenericArguments()[0];
                var nativeItemType = input.Type.GetGenericArguments()[0];

                var conversionLambdaParameter = Expression.Parameter(
                    typeof(Task<>).MakeGenericType(nativeItemType));
                var conversionLambda = Expression.Lambda(
                    GetPossiblyWrappedValue(
                        Expression.Property(conversionLambdaParameter, "Result"),
                        wrapperItemType),
                    conversionLambdaParameter);

                var continueWithMethod = TaskHelpers.GetContinueWithMethod(nativeItemType, wrapperItemType);
                var result = Expression.Call(input, continueWithMethod, conversionLambda);

                return result;
            }
            else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(ValueTask<>))
            {
                var wrapperItemType = targetType.GetGenericArguments()[0];
                var nativeItemType = input.Type.GetGenericArguments()[0];

                var conversionLambdaParameter = Expression.Parameter(nativeItemType);
                var conversionLambda = Expression.Lambda(
                    GetPossiblyWrappedValue(conversionLambdaParameter, wrapperItemType),
                    conversionLambdaParameter);

                var continueWithMethod = ValueTaskHelpers.GetContinueWithMethod(nativeItemType, wrapperItemType);
                var result = Expression.Call(continueWithMethod, input, conversionLambda);

                return result;
            }
            else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(IProgress<>))
            {
                var wrapperItemType = targetType.GetGenericArguments()[0];
                var nativeItemType = input.Type.GetGenericArguments()[0];

                var conversionLambdaParameter = Expression.Parameter(wrapperItemType);
                var conversionLambda = Expression.Lambda(
                    GetNativeValue(conversionLambdaParameter, wrapperItemType, nativeItemType),
                    conversionLambdaParameter);

                var progressWrapperType = typeof(ProgressWrapper<,>).MakeGenericType(wrapperItemType, nativeItemType);
                var progressWrapperConstructor = progressWrapperType.GetConstructors().Single();
                var result = Expression.New(progressWrapperConstructor, input, conversionLambda);

                return result;
            }
            else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Func<,>))
            {
                // Func<X, Y> where X or Y is a wrapper
                var wrapperArg1Type = targetType.GetGenericArguments()[0];
                var wrapperReturnType = targetType.GetGenericArguments()[1];
                var nativeArg1Type = input.Type.GetGenericArguments()[0];

                var nativeInvokeMethod = input.Type.GetMethod("Invoke");

                var wrapperArg1LambdaParameter = Expression.Parameter(wrapperArg1Type);
                var nativeLambda = Expression.Lambda(
                    targetType,
                    GetPossiblyWrappedValue(
                        Expression.Call(
                            input,
                            nativeInvokeMethod,
                            GetNativeValue(
                                wrapperArg1LambdaParameter,
                                wrapperArg1Type,
                                nativeArg1Type)),
                        wrapperReturnType),
                    wrapperArg1LambdaParameter);

                return nativeLambda;
            }
            else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // Nullable<X> where X is a wrapper
                var wrapperItemType = targetType.GetGenericArguments()[0];

                var result = Expression.Condition(
                    Expression.IsTrue(
                        Expression.Property(
                            input,
                            "HasValue")),
                    Expression.Convert(
                        GetPossiblyWrappedValue(
                            Expression.Property(
                                input,
                                "Value"),
                            wrapperItemType),
                        targetType),
                    Expression.Default(targetType));
                return result;
            }
            else
            {
                var wrapMethod = targetType.GetMethod("Wrap");
                if (wrapMethod == null)
                {
                    throw new InvalidOperationException("Could not find method 'Wrap' in wrapper");
                }

                var parameters = wrapMethod.GetParameters();
                if (parameters.Length != 1)
                {
                    throw new InvalidOperationException("Unexpected parameters in wrapper's 'Wrap' method");
                }

                if (parameters[0].ParameterType == typeof(object) && input.Type.IsValueType)
                {
                    input = Expression.Convert(input, typeof(object));
                }

                var wrappedValue = Expression.Call(null, wrapMethod, input);
                return wrappedValue;
            }
        }

        private static Expression GetNativeValue(Expression input, Type wrapperType, Type nativeType)
        {
            if (nativeType == wrapperType)
            {
                return input;
            }

            if (wrapperType.IsGenericType && wrapperType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                // IEnumerable<X> where X is a wrapper
                var wrapperItemType = wrapperType.GetGenericArguments()[0];
                var nativeItemType = nativeType.GetGenericArguments()[0];

                var conversionLambdaParameter = Expression.Parameter(wrapperItemType);
                var conversionLambda = Expression.Lambda(
                    GetNativeValue(conversionLambdaParameter, wrapperItemType, nativeItemType),
                    conversionLambdaParameter);

                var selectMethod = EnumerableHelpers.GetSelectMethod(wrapperItemType, nativeItemType);
                var result = Expression.Call(selectMethod, input, conversionLambda);

                return result;
            }
            else if (wrapperType.IsGenericType && wrapperType.GetGenericTypeDefinition() == typeof(ImmutableArray<>))
            {
                // ImmutableArray<X> where X is a wrapper
                var wrapperItemType = wrapperType.GetGenericArguments()[0];
                var nativeItemType = nativeType.GetGenericArguments()[0];

                var conversionLambdaParameter = Expression.Parameter(wrapperItemType);
                var conversionLambda = Expression.Lambda(
                    GetNativeValue(conversionLambdaParameter, wrapperItemType, nativeItemType),
                    conversionLambdaParameter);

                var selectMethod = ImmutableArrayHelpers.GetSelectMethod(wrapperItemType, nativeItemType);
                var temp = Expression.Call(selectMethod, input, conversionLambda);

                var toArrayMethod = ImmutableArrayHelpers.GetToImmutableArrayMethod(nativeItemType);
                var result = Expression.Call(toArrayMethod, temp);

                return result;
            }
            else if (wrapperType.IsArray)
            {
                // X[] where X is a wrapper
                var wrapperItemType = wrapperType.GetElementType();
                var nativeItemType = nativeType.GetElementType();

                var conversionLambdaParameter = Expression.Parameter(wrapperItemType);
                var conversionLambda = Expression.Lambda(
                    GetNativeValue(conversionLambdaParameter, wrapperItemType, nativeItemType),
                    conversionLambdaParameter);

                var selectMethod = EnumerableHelpers.GetSelectMethod(wrapperItemType, nativeItemType);
                var temp = Expression.Call(selectMethod, input, conversionLambda);

                var toArrayMethod = EnumerableHelpers.GetToArrayMethod(nativeItemType);
                var result = Expression.Call(toArrayMethod, temp);

                return result;
            }
            else if (wrapperType.IsGenericType && wrapperType.GetGenericTypeDefinition() == typeof(EventHandler<>))
            {
                // EventHandler<X> where X is a wrapper
                var wrapperArgsType = wrapperType.GetGenericArguments()[0];
                var nativeArgsType = nativeType.GetGenericArguments()[0];

                var wrapperInvokeMethod = wrapperType.GetMethod("Invoke");

                // TODO: Investigate if this makes it possible to remove a delegate from an event. I suspect it doesn't.
                var senderLambdaParameter = Expression.Parameter(typeof(object));
                var nativeArgsLambdaParameter = Expression.Parameter(nativeArgsType);
                var nativeLambda = Expression.Lambda(
                    nativeType,
                    Expression.Call(
                        input,
                        wrapperInvokeMethod,
                        senderLambdaParameter,
                        GetPossiblyWrappedValue(
                            nativeArgsLambdaParameter,
                            wrapperArgsType)),
                    senderLambdaParameter,
                    nativeArgsLambdaParameter);

                return nativeLambda;
            }
            else if (wrapperType.IsGenericType && wrapperType.GetGenericTypeDefinition() == typeof(Action<>))
            {
                // Action<X> where X is a wrapper
                var wrapperArgsType = wrapperType.GetGenericArguments()[0];
                var nativeArgsType = nativeType.GetGenericArguments()[0];

                var wrapperInvokeMethod = wrapperType.GetMethod("Invoke");

                var nativeArgsLambdaParameter = Expression.Parameter(nativeArgsType);
                var nativeLambda = Expression.Lambda(
                    nativeType,
                    Expression.Call(
                        input,
                        wrapperInvokeMethod,
                        GetPossiblyWrappedValue(
                            nativeArgsLambdaParameter,
                            wrapperArgsType)),
                    nativeArgsLambdaParameter);

                return nativeLambda;
            }
            else if (wrapperType.IsGenericType && wrapperType.GetGenericTypeDefinition() == typeof(Func<,,>))
            {
                // Func<X, Y, Z> where X, Y or Z is a wrapper
                var wrapperArg1Type = wrapperType.GetGenericArguments()[0];
                var wrapperArg2Type = wrapperType.GetGenericArguments()[1];
                var wrapperReturnType = wrapperType.GetGenericArguments()[2];
                var nativeArg1Type = nativeType.GetGenericArguments()[0];
                var nativeArg2Type = nativeType.GetGenericArguments()[1];
                var nativeReturnType = nativeType.GetGenericArguments()[2];

                var wrapperInvokeMethod = wrapperType.GetMethod("Invoke");

                var nativeArg1LambdaParameter = Expression.Parameter(nativeArg1Type);
                var nativeArg2LambdaParameter = Expression.Parameter(nativeArg2Type);
                var nativeLambda = Expression.Lambda(
                    nativeType,
                    GetNativeValue(
                        Expression.Call(
                            input,
                            wrapperInvokeMethod,
                            GetPossiblyWrappedValue(
                                nativeArg1LambdaParameter,
                                wrapperArg1Type),
                            GetPossiblyWrappedValue(
                                nativeArg2LambdaParameter,
                                wrapperArg2Type)),
                        wrapperReturnType,
                        nativeReturnType),
                    nativeArg1LambdaParameter,
                    nativeArg2LambdaParameter);

                return nativeLambda;
            }
            else if (wrapperType.IsGenericType && wrapperType.GetGenericTypeDefinition() == typeof(Func<,>))
            {
                // Func<X, Y> where X or Y is a wrapper
                var wrapperArg1Type = wrapperType.GetGenericArguments()[0];
                var wrapperReturnType = wrapperType.GetGenericArguments()[1];
                var nativeArg1Type = nativeType.GetGenericArguments()[0];
                var nativeReturnType = nativeType.GetGenericArguments()[1];

                var wrapperInvokeMethod = wrapperType.GetMethod("Invoke");

                var nativeArg1LambdaParameter = Expression.Parameter(nativeArg1Type);
                var nativeLambda = Expression.Lambda(
                    nativeType,
                    GetNativeValue(
                        Expression.Call(
                            input,
                            wrapperInvokeMethod,
                            GetPossiblyWrappedValue(
                                nativeArg1LambdaParameter,
                                wrapperArg1Type)),
                        wrapperReturnType,
                        nativeReturnType),
                    nativeArg1LambdaParameter);

                return nativeLambda;
            }
            else if (wrapperType.IsGenericType && wrapperType.GetGenericTypeDefinition() == typeof(IProgress<>))
            {
                // IProgress<X> where X is a wrapper
                var wrapperItemType = wrapperType.GetGenericArguments()[0];
                var nativeItemType = nativeType.GetGenericArguments()[0];

                var conversionLambdaParameter = Expression.Parameter(nativeItemType);
                var conversionLambda = Expression.Lambda(
                    GetPossiblyWrappedValue(conversionLambdaParameter, wrapperItemType),
                    conversionLambdaParameter);

                var progressWrapperType = typeof(ProgressWrapper<,>).MakeGenericType(nativeItemType, wrapperItemType);
                var progressWrapperConstructor = progressWrapperType.GetConstructors().Single();
                var result = Expression.New(progressWrapperConstructor, input, conversionLambda);

                return result;
            }
            else if (wrapperType.IsGenericType && wrapperType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // Nullable<X> where X is a wrapper
                var wrapperItemType = wrapperType.GetGenericArguments()[0];
                var nativeItemType = nativeType.GetGenericArguments()[0];

                var result = Expression.Condition(
                    Expression.IsTrue(
                        Expression.Property(
                            input,
                            "HasValue")),
                    Expression.Convert(
                        GetNativeValue(
                            Expression.Property(
                                input,
                                "Value"),
                            wrapperItemType,
                            nativeItemType),
                        nativeType),
                    Expression.Default(nativeType));
                return result;
            }
            else if (wrapperType.IsEnum)
            {
                Debug.Assert(nativeType.IsEnum, "Unexpected native type");
                var nativeValue = Expression.Convert(input, nativeType);
                return nativeValue;
            }
            else
            {
                // A wrapper
                var unwrapMethod = wrapperType.GetMethod("Unwrap");
                var unwrappedValue = Expression.Call(input, unwrapMethod);

                var nativeValue = Expression.Convert(unwrappedValue, nativeType);
                return nativeValue;
            }
        }
    }
}
