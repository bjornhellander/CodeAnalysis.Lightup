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

internal static class Helpers
{
    private static readonly Regex SettingsFileNameRegex = new("^CodeAnalysis\\.Lightup.*\\.xml$");

    public static bool IsConfigurationFile(AdditionalText additionalFile)
    {
        return SettingsFileNameRegex.IsMatch(Path.GetFileName(additionalFile.Path));
    }

    public static bool TryParseConfiguration(
        string configFileContent,
        out List<AssemblyKind> assemblies,
        out Version baselineVersion,
        out List<string> typesToInclude,
        out string errorMessage)
    {
        try
        {
            var doc = XDocument.Parse(configFileContent);
            var root = doc.Root;
            assemblies = root.Elements("Assembly").Select(x => (AssemblyKind)Enum.Parse(typeof(AssemblyKind), x.Value)).ToList();
            baselineVersion = new Version(root.Element("BaselineVersion")?.Value);
            typesToInclude = root.Elements("IncludeType").Select(x => x.Value).ToList();

            if (assemblies.Count == 0)
            {
                errorMessage = "No assemblies specified";
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
            errorMessage = "Failed to parse file";
            return false;
        }
    }
}
