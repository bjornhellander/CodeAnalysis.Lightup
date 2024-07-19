namespace Roslyn.CodeAnalysis.Lightup.Test.V4_0_1.CSharp;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RecordDeclarationSyntaxWrapperTests : V3_8_0.CSharp.RecordDeclarationSyntaxWrapperTests
{
    [TestMethod]
    public override void TestClassOrStructGivenCompatibleInstanceKeyword()
    {
        var obj = base.CreateInstance();
        var wrapper = RecordDeclarationSyntaxWrapper.As(obj);
        var keyword = wrapper.ClassOrStructKeyword;
        Assert.AreEqual(SyntaxKind.None, keyword.Kind());

        obj = CreateInstance();
        wrapper = RecordDeclarationSyntaxWrapper.As(obj);
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
