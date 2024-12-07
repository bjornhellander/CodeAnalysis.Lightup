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
    private static readonly List<AssemblyKind> NoAssemblies = [];
    private static readonly List<string> NoTypes = [];

    // See https://github.com/dotnet/roslyn/pull/66438
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
        assemblies = NoAssemblies;
        baselineVersion = new Version();
        typesToInclude = NoTypes;
        useFoldersInFilePaths = false;

        try
        {
            var doc = XDocument.Parse(configFileContent);
            var root = doc.Root;

            assemblies = GetAssemblies(root);
            baselineVersion = GetBaselineVersion(root);
            typesToInclude = GetTypesToInclude(root);
            useFoldersInFilePaths = GetUseFoldersInFilePaths(root);

            errorMessage = "";
            return true;
        }
        catch (ConfigurationException e)
        {
            errorMessage = e.Message;
            return false;
        }
        catch (Exception)
        {
            errorMessage = "Failed to parse file";
            return false;
        }
    }

    private static List<AssemblyKind> GetAssemblies(XElement root)
    {
        var assemblyStrings = root.Elements("Assembly").Select(x => x.Value).ToList();

        if (assemblyStrings.Count == 0)
        {
            throw new ConfigurationException("Missing 'Assembly' element(s).");
        }

        var assemblies = new List<AssemblyKind>(assemblyStrings.Count);
        foreach (var assemblyString in assemblyStrings)
        {
            if (!Enum.TryParse<AssemblyKind>(assemblyString, out var assembly))
            {
                throw new ConfigurationException($"Incorrect 'Assembly' element value: '{assemblyString}'. Should be one of these: {string.Join(", ", Enum.GetNames(typeof(AssemblyKind)))}.");
            }

            assemblies.Add(assembly);
        }

        return assemblies;
    }

    private static Version GetBaselineVersion(XElement root)
    {
        var baselineVersionStrings = root.Elements("BaselineVersion").ToList();
        if (baselineVersionStrings.Count == 0)
        {
            throw new ConfigurationException("Missing 'BaselineVersion' element.");
        }
        else if (baselineVersionStrings.Count > 1)
        {
            throw new ConfigurationException("Multiple 'BaselineVersion' elements.");
        }

        var baselineVersionString = baselineVersionStrings[0].Value;
        if (!Version.TryParse(baselineVersionString, out var baselineVersion))
        {
            throw new ConfigurationException($"Incorrect 'BaselineVersion' element value: '{baselineVersionString}'.");
        }

        return baselineVersion;
    }

    private static List<string> GetTypesToInclude(XElement root)
    {
        return root.Elements("IncludeType").Select(x => x.Value).ToList();
    }

    private static bool GetUseFoldersInFilePaths(XElement root)
    {
        var useFoldersInFilePathsStrings = root.Elements("UseFoldersInFilePaths").ToList();
        bool useFoldersInFilePaths;
        if (useFoldersInFilePathsStrings.Count == 0)
        {
            useFoldersInFilePaths = true;
        }
        else if (useFoldersInFilePathsStrings.Count > 1)
        {
            throw new ConfigurationException("Multiple 'UseFoldersInFilePaths' elements.");
        }
        else
        {
            var useFoldersInFilePathsString = useFoldersInFilePathsStrings[0].Value;
            if (!bool.TryParse(useFoldersInFilePathsString, out useFoldersInFilePaths))
            {
                throw new ConfigurationException($"Incorrect 'UseFoldersInFilePaths' element value: '{useFoldersInFilePathsString}'. Should be one of these: True, False.");
            }
        }

        if (useFoldersInFilePaths && !RoslynSupportsFoldersInGeneratedFilePaths)
        {
            throw new ConfigurationException("The current Roslyn version does not support generating files in folders. Upgrade to at least Roslyn 4.6.0 or configure not to use folders. The latter is done by adding '<UseFoldersInFilePaths>false</UseFoldersInFilePaths>' in the configuration file.");
        }

        return useFoldersInFilePaths;
    }

    private static Version GetRoslynVersion()
    {
        return typeof(SyntaxKind).Assembly.GetName().Version;
    }
}
