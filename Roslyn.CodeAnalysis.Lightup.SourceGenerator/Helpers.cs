// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.SourceGenerator;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Roslyn.CodeAnalysis.Lightup.Definitions;

internal static class Helpers
{
    private static readonly Regex SettingsFileNameRegex = new("Roslyn\\.CodeAnalysis\\.Lightup.*\\.xml");

    public static bool IsConfigurationFile(AdditionalText additionalFile)
    {
        return SettingsFileNameRegex.IsMatch(Path.GetFileName(additionalFile.Path));
    }

    public static bool TryParseConfiguration(
        string configFileContent,
        out List<AssemblyKind> assemblies,
        out Version baselineVersion,
        out string errorMessage)
    {
        try
        {
            var doc = XDocument.Parse(configFileContent);
            var root = doc.Root;
            assemblies = root.Elements("Assembly").Select(x => (AssemblyKind)Enum.Parse(typeof(AssemblyKind), x.Value)).ToList();
            baselineVersion = new Version(root.Element("BaselineVersion")?.Value);
            errorMessage = "";
            return true;
        }
        catch (Exception)
        {
            assemblies = [];
            baselineVersion = new Version();
            errorMessage = "Failed to parse file";
            return false;
        }
    }
}
