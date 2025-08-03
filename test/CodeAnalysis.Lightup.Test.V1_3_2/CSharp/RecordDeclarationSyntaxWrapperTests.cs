// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2.CSharp;

using Wrapper = Microsoft.CodeAnalysis.CSharp.Syntax.Lightup.RecordDeclarationSyntaxWrapper;

[TestClass]
public class RecordDeclarationSyntaxWrapperTests
{
    [TestMethod]
    public void TestIsGivenNullObject()
    {
        TypeDeclarationSyntax? obj = null;
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenNullObject()
    {
        TypeDeclarationSyntax? obj = null;
        Assert.ThrowsExactly<ArgumentNullException>(() => Wrapper.Wrap(obj!));
    }

    [TestMethod]
    public void TestCastGivenNullObject()
    {
        TypeDeclarationSyntax? obj = null;
        Assert.ThrowsExactly<ArgumentNullException>(() => (Wrapper)obj!);
    }

    [TestMethod]
    public void TestIsGivenIncompatibleObject()
    {
        var obj = CreateIncompatibleInstance();
        Assert.IsFalse(Wrapper.Is(obj));
    }

    [TestMethod]
    public void TestWrapGivenIncompatibleObject()
    {
        var obj = CreateIncompatibleInstance();
        Assert.ThrowsExactly<InvalidOperationException>(() => Wrapper.Wrap(obj));
    }

    private static ClassDeclarationSyntax CreateIncompatibleInstance()
    {
        return SyntaxFactory.ClassDeclaration(SyntaxFactory.Token(SyntaxKind.IdentifierToken));
    }
}
