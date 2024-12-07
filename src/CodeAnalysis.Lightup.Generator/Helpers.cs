// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using CodeAnalysis.Lightup.Definitions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

internal static class Helpers
{
    private static readonly Regex SettingsFileNameRegex = new("^CodeAnalysis\\.Lightup.*\\.xml$");

    public static bool RoslynSupportsFoldersInGeneratedFilePaths { get; } = GetRoslynVersion() >= new Version(4, 6, 0, 0);

    public static bool IsConfigurationFile(AdditionalText additionalFile)
    {
        return SettingsFileNameRegex.IsMatch(Path.GetFileName(additionalFile.Path));
    }

    public static bool TryParseConfiguration(
        string configFileContent,
        out List<AssemblyKind> assemblies,
        out Version baselineVersion,
        out List<string> typesToInclude,
        out bool useFoldersInFilePaths,
        out string errorMessage)
    {
        try
        {
            var doc = XDocument.Parse(configFileContent);
            var root = doc.Root;
            assemblies = root.Elements("Assembly").Select(x => (AssemblyKind)Enum.Parse(typeof(AssemblyKind), x.Value)).ToList();
            baselineVersion = new Version(root.Element("BaselineVersion")?.Value);
            typesToInclude = root.Elements("IncludeType").Select(x => x.Value).ToList();
            useFoldersInFilePaths = (root.Element("UseFoldersInFilePaths")?.Value ?? "True") == "True";

            if (assemblies.Count == 0)
            {
                errorMessage = "No assemblies specified";
                return false;
            }

            if (useFoldersInFilePaths && !RoslynSupportsFoldersInGeneratedFilePaths)
            {
                errorMessage = "The current Roslyn version does not support generating files in folders. Upgrade to at least Roslyn 4.6.0 or configure not to use folders. The latter is done by adding '<UseFoldersInFilePaths>false</UseFoldersInFilePaths>' in the configuration file.";
                return false;
            }

            errorMessage = "";
            return true;
        }
        catch (Exception)
        {
            assemblies = [];
            baselineVersion = new Version();
            typesToInclude = [];
            useFoldersInFilePaths = false;
            errorMessage = "Failed to parse file";
            return false;
        }
    }

    private static Version GetRoslynVersion()
    {
        return typeof(SyntaxKind).Assembly.GetName().Version;
    }
}
