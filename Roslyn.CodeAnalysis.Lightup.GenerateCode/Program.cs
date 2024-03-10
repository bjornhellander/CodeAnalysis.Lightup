using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class Program
{
    private const string CodeAnalysisCSharpAssemblyName = "Microsoft.CodeAnalysis.CSharp.dll";

    static void Main()
    {
        var rootFolder = GetRepositoryRoot();

        var sourcePath = Path.Combine(rootFolder, "Roslyn.CodeAnalysis.Lightup.CSharp");

        var testProjectNames = GetTestProjectNames(rootFolder);
        var testProjectName = testProjectNames.Last();
        var testProjectFolder = Path.Combine(rootFolder, testProjectName);
        var codeAnalysisAssemblyPath = Directory.GetFiles(testProjectFolder, CodeAnalysisCSharpAssemblyName, SearchOption.AllDirectories).SingleOrDefault();
        if (codeAnalysisAssemblyPath == null)
        {
            throw new Exception($"Unable to find {CodeAnalysisCSharpAssemblyName} in {testProjectFolder}");
        }

        var assembly = Assembly.LoadFrom(codeAnalysisAssemblyPath);
        var types = assembly.GetTypes().Where(x => x.IsPublic && x.Name == "SyntaxKind").ToList();
        foreach (var type in types)
        {
            if (type.IsEnum)
            {
                GenerateEnum(type, sourcePath);
            }
        }
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

    private static void GenerateEnum(Type type, string sourcePath)
    {
        var name = type.Name + "Ex";

        var sb = new StringBuilder();

        sb.AppendLine($"using {type.Namespace};");
        sb.AppendLine();
        sb.AppendLine($"namespace Roslyn.CodeAnalysis.Lightup.CSharp");
        sb.AppendLine($"{{");
        sb.AppendLine($"    public class {name}");
        sb.AppendLine($"    {{");
        foreach (var field in type.GetFields().Where(x => x.IsStatic && x.IsPublic))
        {
            var value = Convert.ToInt32(field.GetValue(null));
            sb.AppendLine($"        public const {type.Name} {field.Name} = ({type.Name}){value};");
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        File.WriteAllText(Path.Combine(sourcePath, name + ".cs"), source);
    }
}
