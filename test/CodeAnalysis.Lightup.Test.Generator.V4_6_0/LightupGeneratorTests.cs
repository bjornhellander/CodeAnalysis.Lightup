// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Test.Generator.V4_6_0;

[TestClass]
public partial class LightupGeneratorTests
{
    protected override bool SupportsFoldersInFilePaths => true;

    protected override string GetGeneratedFilePath(params string[] parts)
    {
        var result = string.Join("/", parts);
        return result;
    }
}
