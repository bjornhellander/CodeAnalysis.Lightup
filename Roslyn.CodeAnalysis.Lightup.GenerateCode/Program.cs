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

        var sourcePath = Path.Combine(rootFolder, "Roslyn.CodeAnalysis.Lightup.CSharp");

        var testProjectNames = GetTestProjectNames(rootFolder);
        var testProjectName = testProjectNames.Last();

        var types = Reflector.GetTypes(testProjectName, rootFolder);
        Writer.Write(types, sourcePath);
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
