using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class Program
{
    static void Main()
    {
        var rootFolder = GetRepositoryRoot();

        var testProjectNames = GetTestProjectNames(rootFolder).OrderBy(x => x);

        var isFirst = true;
        var types = new Dictionary<string, TypeDefinition>();
        foreach (var testProjectName in testProjectNames)
        {
            Reflector.CollectTypes(testProjectName, rootFolder, types, isFirst);
            isFirst = false;
        }

        Writer.Write(types, rootFolder);
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

        throw new InvalidOperationException();
    }

    private static List<string> GetTestProjectNames(string rootFolder)
    {
        var folders = Directory.GetDirectories(rootFolder).Select(x => Path.GetFileName(x)).ToList();
        var testProjectFolders = folders.Where(x => x.StartsWith("Roslyn.CodeAnalysis.Lightup.Test") && !x.EndsWith(".Internal")).ToList();
        return testProjectFolders;
    }
}
