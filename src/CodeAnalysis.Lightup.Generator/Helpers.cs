// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CodeAnalysis.Lightup.Definitions;
using LightJson;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

internal static class Helpers
{
    private static readonly Regex SettingsFileNameRegex = new("^CodeAnalysis\\.Lightup.*\\.json$");
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
            var root = JsonValue.Parse(configFileContent);
            if (!root.IsJsonObject)
            {
                errorMessage = "Failed to parse file";
                return false;
            }

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

    private static List<AssemblyKind> GetAssemblies(JsonObject root)
    {
        if (!root.ContainsKey("assemblies", out var assembliesToken))
        {
            throw new ConfigurationException("Missing 'assemblies' attribute.");
        }

        if (!assembliesToken.IsJsonArray)
        {
            throw new ConfigurationException("Incorrect 'assemblies' attribute. Expected an array.");
        }

        var assembliesArray = (JsonArray)assembliesToken;
        if (assembliesArray.Count == 0)
        {
            throw new ConfigurationException("Empty 'assemblies' attribute.");
        }

        var assemblies = new List<AssemblyKind>(assembliesArray.Count);
        foreach (var assemblyToken in assembliesArray)
        {
            if (assemblyToken.Type != JsonValueType.String || !Enum.TryParse<AssemblyKind>((string)assemblyToken, out var assembly))
            {
                throw new ConfigurationException($"Incorrect 'assemblies' attribute value: '{(string)assemblyToken}'. Expected one of these: {string.Join(", ", Enum.GetNames(typeof(AssemblyKind)))}.");
            }

            assemblies.Add(assembly);
        }

        return assemblies;
    }

    private static Version GetBaselineVersion(JsonObject root)
    {
        if (!root.ContainsKey("baselineVersion", out var baselineVersionToken))
        {
            throw new ConfigurationException("Missing 'baselineVersion' attribute.");
        }

        if (baselineVersionToken.Type != JsonValueType.String || !Version.TryParse((string)baselineVersionToken, out var baselineVersion))
        {
            throw new ConfigurationException($"Incorrect 'baselineVersion' attribute value: '{(string)baselineVersionToken}'.");
        }

        return baselineVersion;
    }

    private static List<string> GetTypesToInclude(JsonObject root)
    {
        if (!root.ContainsKey("includeTypes", out var includeTypesToken))
        {
            return [];
        }

        var includeTypesArray = (JsonArray)includeTypesToken;
        if (includeTypesArray == null || includeTypesArray.Any(x => x.Type != JsonValueType.String))
        {
            throw new ConfigurationException($"Incorrect 'includeTypes' attribute value. Expected an array of strings.");
        }

        var includeTypes = includeTypesArray.Select(x => (string)x!).ToList();
        return includeTypes;
    }

    private static bool GetUseFoldersInFilePaths(JsonObject root)
    {
        bool useFoldersInFilePaths;
        if (root.ContainsKey("useFoldersInFilePaths", out var useFoldersInFilePathsToken))
        {
            if (useFoldersInFilePathsToken.Type == JsonValueType.Boolean)
            {
                useFoldersInFilePaths = (bool)useFoldersInFilePathsToken;
            }
            else
            {
                throw new ConfigurationException($"Incorrect 'useFoldersInFilePaths' attribute value. Expected a boolean.");
            }
        }
        else
        {
            useFoldersInFilePaths = true;
        }

        if (useFoldersInFilePaths && !RoslynSupportsFoldersInGeneratedFilePaths)
        {
            throw new ConfigurationException("The current Roslyn version does not support generating files in folders. Upgrade to at least Roslyn 4.6.0 or configure not to use folders. The latter is done by adding '\"useFoldersInFilePaths\": false' in the configuration file.");
        }

        return useFoldersInFilePaths;
    }

    private static Version GetRoslynVersion()
    {
        return typeof(SyntaxKind).Assembly.GetName().Version;
    }
}
