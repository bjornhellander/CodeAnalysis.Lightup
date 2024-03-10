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
        var types = assembly.GetTypes().Where(x => x.IsPublic).ToList();
        foreach (var type in types)
        {
            var targetName = type.Name + "Ex";
            var targetNamespace = GetTargetNamespace(type);

            var source = GenerateType(type, targetName, targetNamespace);

            if (source != null)
            {
                var targetFolder = GetTargetFolder(type, sourcePath);
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }
                File.WriteAllText(Path.Combine(targetFolder, targetName + ".cs"), source);
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

    private static string? GenerateType(Type type, string targetName, string targetNamespace)
    {
        if (type.IsEnum)
        {
            return GenerateEnum(type, targetName, targetNamespace);
        }

        return null;
    }

    private static string GenerateEnum(Type type, string targetName, string targetNamespace)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"using {type.Namespace};");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        sb.AppendLine($"    public class {targetName}");
        sb.AppendLine($"    {{");
        foreach (var field in type.GetFields().Where(x => x.IsStatic && x.IsPublic))
        {
            var value = Convert.ToInt32(field.GetValue(null));
            sb.AppendLine($"        public const {type.Name} {field.Name} = ({type.Name}){value};");
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var result = sb.ToString();
        return result;
    }

    private static string GetTargetNamespace(Type type)
    {
        var sourceNamespace = type.Namespace!;
        var targetNamespace = sourceNamespace.Replace("Microsoft.CodeAnalysis.CSharp", "Roslyn.CodeAnalysis.Lightup.CSharp");
        return targetNamespace;
    }

    private static string GetTargetFolder(Type type, string targetProjectPath)
    {
        var sourceNamespace = type.Namespace!;
        var targetFolder = sourceNamespace.Replace("Microsoft.CodeAnalysis.CSharp", "").TrimStart('.').Replace('.', Path.DirectorySeparatorChar);
        return Path.Combine(targetProjectPath, targetFolder);
    }
}
