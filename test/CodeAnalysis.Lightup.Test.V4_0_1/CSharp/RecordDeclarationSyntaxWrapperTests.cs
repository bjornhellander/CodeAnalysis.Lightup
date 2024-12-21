// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V4_0_1.CSharp;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.RecordDeclarationSyntaxWrapper;

[TestClass]
public partial class RecordDeclarationSyntaxWrapperTests
{
    [TestMethod]
    public override void TestClassOrStructKeywordGivenCompatibleObject()
    {
        var obj = base.CreateInstance();
        var wrapper = Wrapper.Wrap(obj);
        var keyword = wrapper.ClassOrStructKeyword;
        Assert.AreEqual(SyntaxKind.None, keyword.Kind());

        obj = CreateInstance();
        wrapper = Wrapper.Wrap(obj);
        keyword = wrapper.ClassOrStructKeyword;
        Assert.AreEqual(SyntaxKind.ClassKeyword, keyword.Kind());
    }

    protected override RecordDeclarationSyntax CreateInstance()
    {
        return SyntaxFactory.RecordDeclaration(
            SyntaxKind.RecordDeclaration,
            new SyntaxList<AttributeListSyntax>(
                SyntaxFactory.AttributeList()),
            new SyntaxTokenList(
                SyntaxFactory.Token(SyntaxKind.IdentifierToken)),
            SyntaxFactory.Token(
                SyntaxKind.RecordKeyword),
            SyntaxFactory.Token(
                SyntaxKind.ClassKeyword),
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
}
