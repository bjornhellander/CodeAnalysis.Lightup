// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Collector;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using CodeAnalysis.Lightup.Definitions;

internal class Program
{
    private static void Main()
    {
        var rootFolder = GetRepositoryRoot();

        var referenceProjectNames = GetReferenceProjectNames(rootFolder).OrderBy(x => x, new ProjectNameComparer()).ToList();

        var types = Reflector.CollectTypes(referenceProjectNames, rootFolder);

        var typesFilePath = Path.Combine(rootFolder, "src", "CodeAnalysis.Lightup.Generator", "Types.xml");
        using var stream = new FileStream(typesFilePath, FileMode.Create);
        var serializer = new XmlSerializer(typeof(List<BaseTypeDefinition>));
        serializer.Serialize(stream, types.Values.ToList());
    }

    private static string GetRepositoryRoot()
    {
        var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        while (folder != null)
        {
            if (Directory.GetFiles(folder).Any(x => x.EndsWith(".sln")))
            {
                return folder;
            }

            folder = Path.GetDirectoryName(folder);
        }

        Assert.Fail("Can't find repository root");
        return null;
    }

    private static List<string> GetReferenceProjectNames(string rootFolder)
    {
        var testFolder = Path.Combine(rootFolder, "ref");
        var referenceProjectNames = Directory.GetDirectories(testFolder).Select(x => Path.GetFileName(x)).ToList();
        return referenceProjectNames;
    }

    private class ProjectNameComparer : IComparer<string>
    {
        private static readonly Regex TestProjectNameRegex = new("V(\\d+)_(\\d+)_(\\d+)$");

        public int Compare(string? x, string? y)
        {
            var xVersion = GetVersion(x!);
            var yVersion = GetVersion(y!);
            return xVersion.CompareTo(yVersion);
        }

        private static Version GetVersion(string name)
        {
            var match = TestProjectNameRegex.Match(name);
            var major = int.Parse(match.Groups[1].Value);
            var minor = int.Parse(match.Groups[2].Value);
            var patch = int.Parse(match.Groups[3].Value);
            return new Version(major, minor, patch);
        }
    }
}
