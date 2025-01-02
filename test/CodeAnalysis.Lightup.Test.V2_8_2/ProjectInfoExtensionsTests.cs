// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.V2_8_2;

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Lightup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ProjectInfoExtensionsTests
{
    [TestMethod]
    public virtual void TestWithCompilationOutputInfo()
    {
        var obj = CreateInstance();
        var compilationOutputInfo = default(CompilationOutputInfoWrapper);
        Assert.ThrowsException<InvalidOperationException>(() => obj.WithCompilationOutputInfo(compilationOutputInfo));
    }

    protected static ProjectInfo CreateInstance()
    {
        var obj = ProjectInfo.Create(
            id: ProjectId.CreateNewId(),
            version: default,
            name: "name",
            assemblyName: "assemblyName",
            language: LanguageNames.CSharp,
            filePath: "a/b.csproj",
            outputFilePath: "a/b.dll",
            compilationOptions: default,
            parseOptions: default,
            documents: default,
            projectReferences: default,
            metadataReferences: default,
            analyzerReferences: default,
            additionalDocuments: default,
            isSubmission: default,
            hostObjectType: default);
        return obj;
    }
}
