using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.CodeAnalysis.Lightup.CSharp.Syntax;
using System;

namespace Roslyn.CodeAnalysis.Lightup.Test.V3_0_0.CSharp;

[TestClass]
public class RecordDeclarationSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        SyntaxNode? obj = null;
        Assert.IsFalse(RecordDeclarationSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.AreEqual(obj, wrapper.Unwrap());
    }

    [TestMethod]
    public void TestIdentifierGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.Identifier);
    }

    [TestMethod]
    public void TestWithIdentifierGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.WithIdentifier(SyntaxFactory.Token(SyntaxKind.IdentifierToken)));
    }

    [TestMethod]
    public void TestParameterListGivenNullObject()
    {
        SyntaxNode? obj = null;
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.ThrowsException<NullReferenceException>(() => wrapper.ParameterList);
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        Assert.IsFalse(RecordDeclarationSyntaxWrapper.Is(obj));
    }

    [TestMethod]
    public void TestAsGivenIncompatibleObject()
    {
        var obj = SyntaxFactory.ParameterList();
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        Assert.IsNull(wrapper.Unwrap());
    }
}
