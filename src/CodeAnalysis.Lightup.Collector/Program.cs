// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Collector;

internal class Program
{
    private static void Main()
    {
        var rootFolder = GetRepositoryRoot();
        var types = CollectTypes();
        WriteTypesFile(rootFolder, types);
        RemoveGeneratedFolders(rootFolder);
    }

    private static string GetRepositoryRoot()
    {
        var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        while (folder != null)
        {
            if (Directory.GetFiles(folder).Any(x => x.EndsWith(".slnx")))
            {
                return folder;
            }

            folder = Path.GetDirectoryName(folder);
        }

        Assert.Fail("Can't find repository root");
        return null;
    }

    private static Dictionary<string, BaseTypeDefinition> CollectTypes()
    {
        var packageRoot = GetAssemblyMetadata("NuGetPackageRoot");
        var roslynVersions = GetAssemblyMetadata("RoslynVersions")
            .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .OrderBy(GetVersionWithoutSuffix)
            .ToList();
        var types = Reflector.CollectTypes(roslynVersions, packageRoot);
        return types;
    }

    private static string GetAssemblyMetadata(string key)
    {
        var value = Assembly.GetExecutingAssembly()
            .GetCustomAttributes<AssemblyMetadataAttribute>()
            .SingleOrDefault(x => x.Key == key)?.Value;
        Assert.IsTrue(!string.IsNullOrEmpty(value), $"Could not find assembly metadata '{key}'");
        return value;
    }

    private static Version GetVersionWithoutSuffix(string packageVersion)
    {
        var index = packageVersion.IndexOf('-');
        var versionText = index >= 0 ? packageVersion[..index] : packageVersion;
        return Version.Parse(versionText);
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
}
