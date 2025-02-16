// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0.CSharp;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper<
    Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.RecordDeclarationSyntaxWrapper>;

[TestClass]
public partial class SeparatedSyntaxListWrapperTests
{
    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.Wrap(obj);
        var obj2 = wrapper.Unwrap();
        Assert.IsNotNull(obj2);
        _ = (SeparatedSyntaxList<RecordDeclarationSyntax>)obj2;
    }

    [TestMethod]
    public void TestCountGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, wrapper.Count);

        obj = obj.Add(CreateNativeItem());
        wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestFirstGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(2, wrapper.Count);

        var result = wrapper.First();
        Assert.AreEqual("a", result.Identifier.Text);
    }

    [TestMethod]
    public void TestFirstOrDefaultGivenEmptyCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, wrapper.Count);

        var result = wrapper.FirstOrDefault();
        Assert.IsNull(result);
    }

    [TestMethod]
    public void TestFirstOrDefaultGivenNonEmptyCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(2, wrapper.Count);

        var result = wrapper.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.AreEqual("a", result.Value.Identifier.Text);
    }

    [TestMethod]
    public void TestLastGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        obj = obj.Add(CreateNativeItem("a")).Add(CreateNativeItem("b"));
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(2, wrapper.Count);

        var result = wrapper.Last();
        Assert.AreEqual("b", result.Identifier.Text);
    }

    [TestMethod]
    public void TestAddGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, wrapper.Count);

        var newNativeItem = CreateNativeItem();
        var newWrappedItem = RecordDeclarationSyntaxWrapper.Wrap(newNativeItem);

        wrapper = wrapper.Add(newWrappedItem);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestAddRangeGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, wrapper.Count);

        var newNativeItem = CreateNativeItem();
        var newWrappedItem = RecordDeclarationSyntaxWrapper.Wrap(newNativeItem);

        wrapper = wrapper.AddRange([newWrappedItem]);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestInsertGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, wrapper.Count);

        var newNativeItem = CreateNativeItem();
        var newWrappedItem = RecordDeclarationSyntaxWrapper.Wrap(newNativeItem);

        wrapper = wrapper.Insert(0, newWrappedItem);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestInsertRangeGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(0, wrapper.Count);

        var newNativeItem = CreateNativeItem();
        var newWrappedItem = RecordDeclarationSyntaxWrapper.Wrap(newNativeItem);

        wrapper = wrapper.InsertRange(0, [newWrappedItem]);
        Assert.AreEqual(1, wrapper.Count);
    }

    [TestMethod]
    public void TestRemoveAtGivenCompatibleObject()
    {
        var obj = default(SeparatedSyntaxList<RecordDeclarationSyntax>);
        obj = obj.Add(CreateNativeItem("abc"));
        obj = obj.Add(CreateNativeItem("def"));
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(2, wrapper.Count);

        wrapper = wrapper.RemoveAt(0);
        Assert.AreEqual(1, wrapper.Count);
        obj = Unwrap(wrapper);
        Assert.AreEqual("def", obj[0].Identifier.Text);
    }

    private static RecordDeclarationSyntax CreateNativeItem(string identifier = "abc")
    {
        return SyntaxFactory.RecordDeclaration(
            SyntaxFactory.Token(SyntaxKind.RecordKeyword),
            identifier);
    }

    private static SeparatedSyntaxList<RecordDeclarationSyntax> Unwrap(Wrapper wrapper)
    {
        return (SeparatedSyntaxList<RecordDeclarationSyntax>)wrapper.Unwrap();
    }
}
