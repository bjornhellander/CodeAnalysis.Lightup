// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.Internal;

using System;
using System.Reflection;
using CodeAnalysis.Lightup.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// NOTE: These tests intend to cover cases that were difficult to test using the generated code
[TestClass]
public class LightupHelperTests
{
    [TestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public void TestPropertyWithNullableOfWrapper(bool setValue)
    {
        var native = new TestClass1 { Property1 = setValue ? default(TestStruct1) : null };
        var wrapper = TestClass1Wrapper.Wrap(native);
        Assert.IsNotNull(wrapper.Unwrap());

        var wrapperValue = wrapper.Property1;

        if (setValue)
        {
            Assert.IsNotNull(wrapperValue);
            var nativeValue = wrapperValue.Value.Unwrap();
            Assert.IsNotNull(nativeValue);
            Assert.IsNotNull(native.Property1);
            Assert.AreEqual(native.Property1.Value, nativeValue);
        }
        else
        {
            Assert.IsNull(wrapperValue);
        }
    }

    [TestMethod]
    [DataRow(3)]
    [DataRow(42)]
    public void TestPropertyWithFuncReturningWrapper(int value)
    {
        var native = new TestClass1 { Property2 = NativeFunc };
        var wrapper = TestClass1Wrapper.Wrap(native);
        Assert.IsNotNull(wrapper.Unwrap());

        var wrapperFunc = wrapper.Property2;

        var wrapperReturnValue = wrapperFunc(value);
        var nativeReturnValue = (TestStruct1)wrapperReturnValue.Unwrap()!;
        Assert.AreEqual(value, nativeReturnValue.Value);

        static TestStruct1 NativeFunc(int arg1)
        {
            return new TestStruct1 { Value = arg1 };
        }
    }

    [TestMethod]
    [DataRow(7)]
    [DataRow(18)]
    public void TestPropertyWithIProgressOfWrapper(int value)
    {
        var nativeProgress = new TestProgress();
        var native = new TestClass1 { Property3 = nativeProgress };
        var wrapper = TestClass1Wrapper.Wrap(native);
        Assert.IsNotNull(wrapper.Unwrap());

        var wrapperProgress = wrapper.Property3;

        var nativeValue = new TestStruct1 { Value = value };
        var wrapperValue = TestStruct1Wrapper.Wrap(nativeValue);
        wrapperProgress.Report(wrapperValue);
        Assert.AreEqual(value, nativeProgress.Value);
    }

    [TestMethod]
    [DataRow(9)]
    [DataRow(54)]
    public void TestMethodWithParameterNullableOfWrapper(int value)
    {
        var native = new TestClass1();
        var wrapper = TestClass1Wrapper.Wrap(native);
        Assert.IsNotNull(wrapper.Unwrap());

        var nativeValue = new TestStruct1?(new TestStruct1 { Value = value });
        var wrapperValue = TestStruct1Wrapper.Wrap(nativeValue);
        wrapper.Method1(wrapperValue);

        Assert.IsNotNull(native.Value1);
        Assert.AreEqual(value, native.Value1.Value.Value);
    }

    [TestMethod]
    [DataRow(7)]
    [DataRow(11)]
    public void TestMethodWithParameterIProgressOfWrapper(int value)
    {
        var native = new TestClass1();
        var wrapper = TestClass1Wrapper.Wrap(native);
        Assert.IsNotNull(wrapper.Unwrap());

        var wrapperProgress = new TestWrapperProgress();
        wrapper.Method2(value, wrapperProgress);

        Assert.AreEqual(value, wrapperProgress.Value);
    }

    [TestMethod]
    [DataRow(92)]
    [DataRow(123)]
    public void TestMethodWithParameterFunc2OfWrapper(int value)
    {
        var native = new TestClass1();
        var wrapper = TestClass1Wrapper.Wrap(native);
        Assert.IsNotNull(wrapper.Unwrap());

        var returnValue = wrapper.Method3(value, WrapperFunc);

        Assert.AreEqual(value, returnValue);

        static int WrapperFunc(TestStruct1Wrapper arg1)
        {
            return ((TestStruct1)arg1.Unwrap()!).Value;
        }
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(13)]
    public void TestMethodWithParameterFunc3OfWrapper(int value)
    {
        var native = new TestClass1();
        var wrapper = TestClass1Wrapper.Wrap(native);
        Assert.IsNotNull(wrapper.Unwrap());

        var returnValue = wrapper.Method4(value, WrapperFunc);

        Assert.AreEqual(value, returnValue);

        static int WrapperFunc(TestStruct1Wrapper arg1, int arg2)
        {
            return ((TestStruct1)arg1.Unwrap()!).Value;
        }
    }
}

#pragma warning disable IDE0251 // Make member 'readonly'
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable SA1125 // Use shorthand for nullable types
#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1516 // Elements should be separated by blank line
#pragma warning disable MSTEST0004 // Public types should be test classes

public class TestClass1
{
    public TestStruct1? Value1;

    public Nullable<TestStruct1> Property1 { get; init; }

    public Func<int, TestStruct1>? Property2 { get; init; }

    public IProgress<TestStruct1>? Property3 { get; init; }

    public void Method1(Nullable<TestStruct1> arg)
    {
        Value1 = arg;
    }

    public void Method2(int arg1, IProgress<TestStruct1> arg2)
    {
        arg2.Report(new TestStruct1 { Value = arg1 });
    }

    public int Method3(int arg1, Func<TestStruct1, int> arg2)
    {
        return arg2(new TestStruct1 { Value = arg1 });
    }

    public int Method4(int arg1, Func<TestStruct1, int, int> arg2)
    {
        return arg2(new TestStruct1 { Value = arg1 }, 0);
    }
}

public struct TestStruct1
{
    public int Value { get; set; }
}

public class TestProgress : IProgress<TestStruct1>
{
    public int Value { get; set; }

    public void Report(TestStruct1 value)
    {
        Value = value.Value;
    }
}

public class TestWrapperProgress : IProgress<TestStruct1Wrapper>
{
    public int Value { get; set; }

    public void Report(TestStruct1Wrapper value)
    {
        Value = ((TestStruct1)value.Unwrap()!).Value;
    }
}

public class TestLightupHelper : LightupHelper
{
    private static readonly Assembly ThisAssembly = typeof(TestLightupHelper).Assembly;

    public static Type? FindType(string wrappedTypeName)
    {
        return FindType(ThisAssembly, wrappedTypeName);
    }
}

public struct TestClass1Wrapper
{
    private const string WrappedTypeName = "CodeAnalysis.Lightup.Test.Internal.TestClass1";

    private static readonly Type? WrappedType; // NOTE: Used via reflection

    private delegate Nullable<TestStruct1Wrapper> Property1GetterDelegate(object obj);
    private delegate Func<int, TestStruct1Wrapper> Property2GetterDelegate(object obj);
    private delegate IProgress<TestStruct1Wrapper> Property3GetterDelegate(object obj);
    private delegate void Method1Delegate(object obj, Nullable<TestStruct1Wrapper> arg);
    private delegate void Method2Delegate(object obj, int arg1, IProgress<TestStruct1Wrapper> arg2);
    private delegate int Method3Delegate(object obj, int arg1, Func<TestStruct1Wrapper, int> arg2);
    private delegate int Method4Delegate(object obj, int arg1, Func<TestStruct1Wrapper, int, int> arg2);

    private static readonly Property1GetterDelegate Property1GetterFunc;
    private static readonly Property2GetterDelegate Property2GetterFunc;
    private static readonly Property3GetterDelegate Property3GetterFunc;
    private static readonly Method1Delegate Methods1Func;
    private static readonly Method2Delegate Methods2Func;
    private static readonly Method3Delegate Methods3Func;
    private static readonly Method4Delegate Methods4Func;

    private readonly object wrappedObject;

    static TestClass1Wrapper()
    {
        WrappedType = TestLightupHelper.FindType(WrappedTypeName);

        Property1GetterFunc = TestLightupHelper.CreateInstanceGetAccessor<Property1GetterDelegate>(WrappedType, nameof(Property1));
        Property2GetterFunc = TestLightupHelper.CreateInstanceGetAccessor<Property2GetterDelegate>(WrappedType, nameof(Property2));
        Property3GetterFunc = TestLightupHelper.CreateInstanceGetAccessor<Property3GetterDelegate>(WrappedType, nameof(Property3));
        Methods1Func = TestLightupHelper.CreateInstanceMethodAccessor<Method1Delegate>(WrappedType, "Method1", "argNullable`1");
        Methods2Func = TestLightupHelper.CreateInstanceMethodAccessor<Method2Delegate>(WrappedType, "Method2", "arg1Int32", "arg2IProgress`1");
        Methods3Func = TestLightupHelper.CreateInstanceMethodAccessor<Method3Delegate>(WrappedType, "Method3", "arg1Int32", "arg2Func`2");
        Methods4Func = TestLightupHelper.CreateInstanceMethodAccessor<Method4Delegate>(WrappedType, "Method4", "arg1Int32", "arg2Func`3");
    }

    private TestClass1Wrapper(object obj)
    {
        wrappedObject = obj;
    }

    public Nullable<TestStruct1Wrapper> Property1
        => Property1GetterFunc(wrappedObject);

    public Func<int, TestStruct1Wrapper> Property2
        => Property2GetterFunc(wrappedObject);

    public IProgress<TestStruct1Wrapper> Property3
        => Property3GetterFunc(wrappedObject);

    public static TestClass1Wrapper Wrap(object obj)
    {
        var obj2 = TestLightupHelper.Wrap<object>(obj, WrappedType);
        return new TestClass1Wrapper(obj2);
    }

    public object Unwrap()
    {
        return wrappedObject;
    }

    public void Method1(Nullable<TestStruct1Wrapper> arg)
        => Methods1Func(wrappedObject, arg);

    public void Method2(int arg1, IProgress<TestStruct1Wrapper> arg2)
        => Methods2Func(wrappedObject, arg1, arg2);

    public int Method3(int arg1, Func<TestStruct1Wrapper, int> arg2)
        => Methods3Func(wrappedObject, arg1, arg2);

    public int Method4(int arg1, Func<TestStruct1Wrapper, int, int> arg2)
        => Methods4Func(wrappedObject, arg1, arg2);
}

public struct TestStruct1Wrapper
{
    private const string WrappedTypeName = "CodeAnalysis.Lightup.Test.Internal.TestStruct1";

    private static readonly Type? WrappedType; // NOTE: Used via reflection

    private readonly object wrappedObject;

    static TestStruct1Wrapper()
    {
        WrappedType = TestLightupHelper.FindType(WrappedTypeName);
    }

    private TestStruct1Wrapper(object obj)
    {
        wrappedObject = obj;
    }

    public static TestStruct1Wrapper Wrap(object obj)
    {
        var obj2 = TestLightupHelper.Wrap<object>(obj, WrappedType);
        return new TestStruct1Wrapper(obj2);
    }

    public object Unwrap()
    {
        return wrappedObject;
    }
}
