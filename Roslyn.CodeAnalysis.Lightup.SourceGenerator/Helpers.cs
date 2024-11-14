// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.SourceGenerator;

using System.IO;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;

internal static class Helpers
{
    private static readonly Regex SettingsFileNameRegex = new("Roslyn\\.CodeAnalysis\\.Lightup.*\\.xml");

    public static bool IsConfigurationFile(AdditionalText additionalFile)
    {
        return SettingsFileNameRegex.IsMatch(Path.GetFileName(additionalFile.Path));
    }
}
