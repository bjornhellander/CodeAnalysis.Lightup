// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Collector;

internal class Program
{
    private static void Main()
    {
        var rootFolder = GetRepositoryRoot();
        var types = CollectTypes(rootFolder);
        WriteTypesFile(rootFolder, types);
        RemoveGeneratedFolders(rootFolder);
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

    private static Dictionary<string, BaseTypeDefinition> CollectTypes(string rootFolder)
    {
        var referenceProjectNames = GetReferenceProjectNames(rootFolder).OrderBy(x => x, new ProjectNameComparer()).ToList();
        var types = Reflector.CollectTypes(referenceProjectNames, rootFolder);
        return types;
    }

    private static FileStream WriteTypesFile(string rootFolder, Dictionary<string, BaseTypeDefinition> types)
    {
        var typesFilePath = Path.Combine(rootFolder, "src", "CodeAnalysis.Lightup.Generator", "Types.xml");
        using var stream = new FileStream(typesFilePath, FileMode.Create);
        var serializer = new XmlSerializer(typeof(List<BaseTypeDefinition>));
        var typesList = types.Values.OrderBy(x => x.FullName).ToList();
        serializer.Serialize(stream, typesList);
        return stream;
    }

    private static List<string> GetReferenceProjectNames(string rootFolder)
    {
        var testFolder = Path.Combine(rootFolder, "ref");
        var referenceProjectNames = Directory.GetDirectories(testFolder).Select(x => Path.GetFileName(x)).ToList();
        return referenceProjectNames;
    }

    private static void RemoveGeneratedFolders(string rootFolder)
    {
        var generatedFolderPaths = new List<string>()
        {
            Path.Combine(rootFolder, "test", "CodeAnalysis.Lightup.Example.Analyzers", ".generated"),
            Path.Combine(rootFolder, "test", "CodeAnalysis.Lightup.Example.CodeFixes", ".generated"),
        };
        foreach (var generatedFoldPath in generatedFolderPaths)
        {
            if (Directory.Exists(generatedFoldPath))
            {
                Directory.Delete(generatedFoldPath, true);
            }
        }
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
