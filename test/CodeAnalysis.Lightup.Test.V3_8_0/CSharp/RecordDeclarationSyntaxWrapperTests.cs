// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V3_8_0.CSharp;

using System;
using System.Reflection;
using CodeAnalysis.Lightup.Test.V2_8_2.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.RecordDeclarationSyntaxWrapper;

[TestClass]
public partial class RecordDeclarationSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenCompatibleObject()
    {
        var obj = CreateInstance();
        Assert.IsTrue(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenCompatibleObject()
    {
        var obj = CreateInstance();
        _ = Wrapper.Wrap(obj);
    }

    [TestMethod]
    public void TestCastGivenCompatibleObject()
    {
        var obj = CreateInstance();
        _ = (Wrapper)obj;
    }

    [TestMethod]
    public void TestIdentifierDefinition()
    {
        CheckPropertyType<RecordDeclarationSyntax, Wrapper>("Identifier");
    }

    [TestMethod]
    public void TestIdentifierGivenCompatibleObject()
    {
        var obj = CreateInstance();

        var wrapper1 = Wrapper.Wrap(obj);
        Assert.AreEqual(obj.Identifier, wrapper1.Identifier);

        var wrapper2 = (Wrapper)obj;
        Assert.AreEqual(obj.Identifier, wrapper2.Identifier);
    }

    [TestMethod]
    public void TestWithIdentifierGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        var newValue = SyntaxFactory.Identifier("abc");
        var wrapper2 = wrapper.WithIdentifier(newValue);
        Assert.AreEqual(newValue.Text, wrapper2.Identifier.Text);
        TypeDeclarationSyntax? obj2 = wrapper2;
        Assert.IsNotNull(obj2);
        Assert.AreEqual(obj2.Identifier, wrapper2.Identifier);
    }

    [TestMethod]
    public void TestParameterListDefinition()
    {
        CheckPropertyType<RecordDeclarationSyntax, Wrapper>("ParameterList");
    }

    [TestMethod]
    public void TestParameterListGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        Assert.AreEqual(obj.ParameterList, wrapper.ParameterList);
    }

    [TestMethod]
    public virtual void TestClassOrStructKeywordGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        Assert.ThrowsException<InvalidOperationException>(() => wrapper.ClassOrStructKeyword);
    }

    [TestMethod]
    public void TestUpdateGivenCompatibleObject()
    {
        var obj = CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        var visitor = new TestVisitor();
        wrapper.Accept(visitor);
        Assert.AreEqual(1, visitor.VisitCount);
    }

    protected virtual RecordDeclarationSyntax CreateInstance()
    {
        return SyntaxFactory.RecordDeclaration(
            new SyntaxList<AttributeListSyntax>(
                SyntaxFactory.AttributeList()),
            new SyntaxTokenList(
                SyntaxFactory.Token(SyntaxKind.IdentifierToken)),
            SyntaxFactory.Token(
                SyntaxKind.RecordKeyword),
            SyntaxFactory.Token(
                SyntaxKind.IdentifierToken),
            SyntaxFactory.TypeParameterList(),
            SyntaxFactory.ParameterList(),
            SyntaxFactory.BaseList(),
            new SyntaxList<TypeParameterConstraintClauseSyntax>(
                SyntaxFactory.TypeParameterConstraintClause(
                    "abc")),
            SyntaxFactory.Token(
                SyntaxKind.OpenBraceToken),
            new SyntaxList<MemberDeclarationSyntax>(
                SyntaxFactory.EnumMemberDeclaration(
                    "abc")),
            SyntaxFactory.Token(
                SyntaxKind.CloseBraceToken),
            SyntaxFactory.Token(
                SyntaxKind.SemicolonToken));
    }

    private static void CheckPropertyType<T1, T2>(string name)
    {
        var property1 = typeof(T1).GetProperty(name);
        Assert.IsNotNull(property1);
        var accessor1 = property1.GetGetMethod();
        Assert.IsNotNull(accessor1);
        var type1 = accessor1.ReturnType;

        var property2 = typeof(T2).GetProperty(name);
        Assert.IsNotNull(property2);
        var accessor2 = property2.GetGetMethod();
        Assert.IsNotNull(accessor2);
        var type2 = accessor2.ReturnType;

        Assert.AreEqual(type1, type2);
        Assert.AreEqual(IsMarkedAsNullable(property1), IsMarkedAsNullable(property2));
    }

    private static bool IsMarkedAsNullable(PropertyInfo p)
    {
        var nullabilityInfo = new NullabilityInfoContext().Create(p);
        return nullabilityInfo.ReadState is NullabilityState.Nullable;
    }
}
