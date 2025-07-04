﻿// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V1_3_2.CSharp;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "MSTEST0004:Public types should be test classes", Justification = "Needed by other test projects")]
public class TestVisitor : CSharpSyntaxVisitor
{
    private int visitCount;

    public int VisitCount => visitCount;

    public override void DefaultVisit(SyntaxNode node)
    {
        visitCount++;
        base.DefaultVisit(node);
    }
}
