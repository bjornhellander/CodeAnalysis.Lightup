﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_0_0.CSharp;

using NativeItem = Microsoft.CodeAnalysis.CSharp.Syntax.LocalFunctionStatementSyntax;
using Wrapper = Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<
    Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LocalFunctionStatementSyntaxWrapper>;
using WrapperItem = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.LocalFunctionStatementSyntaxWrapper;

// NOTE: This test class should be executed for all non-baseline versions
[TestClass]
public partial class SeparatedSyntaxListWrapperTests
{
    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);
        var obj2 = wrapper.Unwrap();
        Assert.IsNotNull(obj2);
        _ = (SeparatedSyntaxList<NativeItem>)obj2;
    }

    [TestMethod]
    public void TestCountGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, wrapper.Count);

        obj = obj.Add(CreateNativeItem());
        wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestSeparatorCountGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, wrapper.SeparatorCount);

        obj = obj.Add(CreateNativeItem());
        wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, wrapper.SeparatorCount);

        obj = obj.Add(CreateNativeItem());
        wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(1, wrapper.SeparatorCount);
    }

    [TestMethod]
    public void TestFullSpanGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>).Add(CreateNativeItem().WithTrailingTrivia(SyntaxFactory.Space));
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual(0, wrapper.FullSpan.Start);
        Assert.AreEqual(9, wrapper.FullSpan.End);
    }

    [TestMethod]
    public void TestSpanGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>).Add(CreateNativeItem().WithTrailingTrivia(SyntaxFactory.Space));
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual(0, wrapper.Span.Start);
        Assert.AreEqual(8, wrapper.Span.End);
    }

    [TestMethod]
    public void TestIndexerGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.AddRange([CreateNativeItem("a"), CreateNativeItem("b")]);
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual("a", wrapper[0].Identifier.Text);
        Assert.AreEqual("b", wrapper[1].Identifier.Text);
    }

    [TestMethod]
    public void TestGenericGetEnumeratorGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.AddRange([CreateNativeItem("0"), CreateNativeItem("1")]);
        var wrapper = Wrapper.Wrap(obj);

        var i = 0;
        foreach (var item in wrapper)
        {
            Assert.AreEqual(i.ToString(), wrapper[i].Identifier.Text);
            i++;
        }

        Assert.AreEqual(2, i);
    }

    [TestMethod]
    public void TestNonGenericGetEnumeratorGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.AddRange([CreateNativeItem("0"), CreateNativeItem("1")]);
        var wrapper = Wrapper.Wrap(obj);

        var i = 0;
        foreach (var item in (IEnumerable)wrapper)
        {
            Assert.AreEqual(i.ToString(), wrapper[i].Identifier.Text);
            i++;
        }

        Assert.AreEqual(2, i);
    }

    [TestMethod]
    public void TestGetSeparatorGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.AddRange([CreateNativeItem("a"), CreateNativeItem("b")]);
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual(",", wrapper.GetSeparator(0).Text);
    }

    [TestMethod]
    public void TestGetSeparatorsGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.AddRange([CreateNativeItem("a"), CreateNativeItem("b")]);
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual(1, wrapper.GetSeparators().Count());
    }

    [TestMethod]
    public void TestToStringGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual("inta(),intb()", wrapper.ToString());
    }

    [TestMethod]
    public void TestToFullStringGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual("inta(),intb()", wrapper.ToFullString());
    }

    [TestMethod]
    public void TestFirstGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        var wrapper = Wrapper.Wrap(obj);

        var result = wrapper.First();
        Assert.AreEqual("a", result.Identifier.Text);
    }

    [TestMethod]
    public void TestFirstOrDefaultGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);

        var result = wrapper.FirstOrDefault();
        Assert.IsNull(result);

        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        wrapper = Wrapper.Wrap(obj);

        result = wrapper.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.AreEqual("a", result.Value.Identifier.Text);
    }

    [TestMethod]
    public void TestLastGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        var wrapper = Wrapper.Wrap(obj);

        var result = wrapper.Last();
        Assert.AreEqual("b", result.Identifier.Text);
    }

    [TestMethod]
    public void TestLastOrDefaultGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);

        var result = wrapper.LastOrDefault();
        Assert.IsNull(result);

        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        wrapper = Wrapper.Wrap(obj);

        result = wrapper.LastOrDefault();
        Assert.IsNotNull(result);
        Assert.AreEqual("b", result.Value.Identifier.Text);
    }

    [TestMethod]
    public void TestContainsGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        var wrapper = Wrapper.Wrap(obj);

        Assert.IsTrue(wrapper.Contains(wrapper.First()));
        Assert.IsFalse(wrapper.Contains(Wrap(CreateNativeItem("a"))));
    }

    [TestMethod]
    public void TestIndexOfNodeGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var nativeItem1 = CreateNativeItem("x");
        var nativeItem2 = CreateNativeItem("y");
        var nativeItem3 = CreateNativeItem("z");
        obj = obj.AddRange([nativeItem1, nativeItem2]);
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual(0, wrapper.IndexOf(wrapper.First()));
        Assert.AreEqual(1, wrapper.IndexOf(wrapper.Last()));
        Assert.AreEqual(-1, wrapper.IndexOf(WrapperItem.Wrap(nativeItem3)));
    }

    [TestMethod]
    public void TestIndexOfPredicateGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var nativeItem1 = CreateNativeItem("x");
        var nativeItem2 = CreateNativeItem("y");
        obj = obj.AddRange([nativeItem1, nativeItem2]);
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual(0, wrapper.IndexOf(x => x.Identifier.Text == "x"));
        Assert.AreEqual(1, wrapper.IndexOf(x => x.Identifier.Text == "y"));
        Assert.AreEqual(-1, wrapper.IndexOf(x => x.Identifier.Text == "z"));
        Assert.AreEqual(0, wrapper.IndexOf(x => true));
    }

    [TestMethod]
    public void TestLastIndexOfNodeGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var nativeItem1 = CreateNativeItem("x");
        var nativeItem2 = CreateNativeItem("y");
        var nativeItem3 = CreateNativeItem("z");
        obj = obj.AddRange([nativeItem1, nativeItem2]);
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual(0, wrapper.LastIndexOf(wrapper.First()));
        Assert.AreEqual(1, wrapper.LastIndexOf(wrapper.Last()));
        Assert.AreEqual(-1, wrapper.LastIndexOf(WrapperItem.Wrap(nativeItem3)));
    }

    [TestMethod]
    public void TestLastIndexOfPredicateGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var nativeItem1 = CreateNativeItem("x");
        var nativeItem2 = CreateNativeItem("y");
        obj = obj.AddRange([nativeItem1, nativeItem2]);
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual(0, wrapper.LastIndexOf(x => x.Identifier.Text == "x"));
        Assert.AreEqual(1, wrapper.LastIndexOf(x => x.Identifier.Text == "y"));
        Assert.AreEqual(-1, wrapper.LastIndexOf(x => x.Identifier.Text == "z"));
        Assert.AreEqual(1, wrapper.LastIndexOf(x => true));
    }

    [TestMethod]
    public void TestAnyGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);
        Assert.IsFalse(wrapper.Any());

        obj = obj.Add(CreateNativeItem("x"));
        wrapper = Wrapper.Wrap(obj);
        Assert.IsTrue(wrapper.Any());
    }

    [TestMethod]
    public void TestGetWithSeparatorsGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.AddRange([CreateNativeItem(), CreateNativeItem()]);
        var wrapper = Wrapper.Wrap(obj);

        Assert.AreEqual(3, wrapper.GetWithSeparators().Count);
    }

    [TestMethod]
    public void TestAddGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);

        var newNativeItem = CreateNativeItem();
        var newWrappedItem = WrapperItem.Wrap(newNativeItem);

        wrapper = wrapper.Add(newWrappedItem);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestAddRangeGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);

        var newNativeItem = CreateNativeItem();
        var newWrappedItem = WrapperItem.Wrap(newNativeItem);

        wrapper = wrapper.AddRange([newWrappedItem]);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestInsertGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);

        var newNativeItem = CreateNativeItem();
        var newWrappedItem = WrapperItem.Wrap(newNativeItem);

        wrapper = wrapper.Insert(0, newWrappedItem);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestInsertRangeGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        var wrapper = Wrapper.Wrap(obj);

        var newNativeItem = CreateNativeItem();
        var newWrappedItem = WrapperItem.Wrap(newNativeItem);

        wrapper = wrapper.InsertRange(0, [newWrappedItem]);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestRemoveAtGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.Add(CreateNativeItem("abc"));
        obj = obj.Add(CreateNativeItem("def"));
        var wrapper = Wrapper.Wrap(obj);

        wrapper = wrapper.RemoveAt(0);
        Assert.AreEqual(1, wrapper.Count);
        obj = Unwrap(wrapper);
        Assert.AreEqual("def", obj[0].Identifier.Text);
    }

    [TestMethod]
    public void TestRemoveGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.AddRange([CreateNativeItem("abc"), CreateNativeItem("def")]);
        var wrapper = Wrapper.Wrap(obj);

        wrapper = wrapper.Remove(wrapper.First());
        Assert.AreEqual(1, wrapper.Count);

        wrapper = wrapper.Remove(WrapperItem.Wrap(CreateNativeItem("xyz")));
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestReplaceGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.Add(CreateNativeItem("abc"));
        var wrapper = Wrapper.Wrap(obj);

        wrapper = wrapper.Replace(wrapper.First(), WrapperItem.Wrap(CreateNativeItem("def")));
        Assert.AreEqual(1, wrapper.Count);
        Assert.AreEqual("def", wrapper.First().Identifier.Text);
    }

    [TestMethod]
    public void TestReplaceRangeGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.Add(CreateNativeItem("a"));
        var wrapper = Wrapper.Wrap(obj);

        wrapper = wrapper.ReplaceRange(wrapper.First(), [Wrap(CreateNativeItem("b")), Wrap(CreateNativeItem("c"))]);
        Assert.AreEqual(2, wrapper.Count);
        Assert.AreEqual("b", wrapper.First().Identifier.Text);
        Assert.AreEqual("c", wrapper.Last().Identifier.Text);
    }

    [TestMethod]
    public void TestReplaceSeparatorGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<NativeItem>);
        obj = obj.AddRange([CreateNativeItem("a"), CreateNativeItem("b")]);
        var wrapper = Wrapper.Wrap(obj);
        Assert.IsTrue(wrapper.GetSeparator(0).HasTrailingTrivia);

        var newToken = SyntaxFactory.Token(SyntaxKind.CommaToken).WithoutTrivia();
        wrapper = wrapper.ReplaceSeparator(wrapper.GetSeparator(0), newToken);
        Assert.IsFalse(wrapper.GetSeparator(0).HasTrailingTrivia);
    }

    private static NativeItem CreateNativeItem(string identifier = "abc")
    {
        return SyntaxFactory.LocalFunctionStatement(
            SyntaxFactory.PredefinedType(
                SyntaxFactory.Token(SyntaxKind.IntKeyword)),
            SyntaxFactory.Identifier(identifier));
    }

    private static SeparatedSyntaxList<NativeItem> Unwrap(Wrapper obj)
    {
        return (SeparatedSyntaxList<NativeItem>)obj.Unwrap();
    }

    private static WrapperItem Wrap(NativeItem obj)
    {
        return WrapperItem.Wrap(obj);
    }
}
