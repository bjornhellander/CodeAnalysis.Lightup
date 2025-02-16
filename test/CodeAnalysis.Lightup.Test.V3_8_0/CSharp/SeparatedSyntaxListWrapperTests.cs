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

    private static RecordDeclarationSyntax CreateNativeItem()
    {
        return SyntaxFactory.RecordDeclaration(
                    SyntaxFactory.Token(SyntaxKind.RecordKeyword),
                    "abc");
    }
}
