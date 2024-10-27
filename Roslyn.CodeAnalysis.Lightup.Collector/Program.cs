// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Collector;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Roslyn.CodeAnalysis.Lightup.Definitions;

internal class Program
{
    private static void Main()
    {
        var rootFolder = GetRepositoryRoot();

        var testProjectNames = GetTestProjectNames(rootFolder).OrderBy(x => x).ToList();

        var types = Reflector.CollectTypes(testProjectNames, rootFolder);

        var typesFilePath = Path.Combine(rootFolder, "Roslyn.CodeAnalysis.Lightup.GenerateCode", "Types.xml");
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

    private static List<string> GetTestProjectNames(string rootFolder)
    {
        var folders = Directory.GetDirectories(rootFolder).Select(x => Path.GetFileName(x)).ToList();
        var testProjectFolders = folders.Where(x => x.StartsWith("Roslyn.CodeAnalysis.Lightup.Test") && !x.EndsWith(".Internal")).ToList();
        return testProjectFolders;
    }
}
