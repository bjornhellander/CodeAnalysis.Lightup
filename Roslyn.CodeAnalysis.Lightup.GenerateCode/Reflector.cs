using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

internal class Reflector
{
    private const string CodeAnalysisAssemblyName = "Microsoft.CodeAnalysis.dll";
    private const string CodeAnalysisCSharpAssemblyName = "Microsoft.CodeAnalysis.CSharp.dll";

    public static List<Type> GetTypes(string testProjectName, string rootFolder)
    {
        var testProjectFolder = Path.Combine(rootFolder, testProjectName);

        var codeAnalysisAssemblyPaths = Directory.GetFiles(testProjectFolder, CodeAnalysisAssemblyName, SearchOption.AllDirectories);
        var codeAnalysisAssemblyPath = codeAnalysisAssemblyPaths.SingleOrDefault();
        if (codeAnalysisAssemblyPath == null)
        {
            throw new Exception($"Unable to find {CodeAnalysisAssemblyName} in {testProjectFolder}");
        }

        var codeAnalysisCSharpAssemblyPaths = Directory.GetFiles(testProjectFolder, CodeAnalysisCSharpAssemblyName, SearchOption.AllDirectories);
        var codeAnalysisCSharpAssemblyPath = codeAnalysisCSharpAssemblyPaths.SingleOrDefault();
        if (codeAnalysisCSharpAssemblyPath == null)
        {
            throw new Exception($"Unable to find {CodeAnalysisCSharpAssemblyName} in {testProjectFolder}");
        }

        var assemblyLoadContext = new AssemblyLoadContext(testProjectName, true);
        var codeAnalysisAssembly = assemblyLoadContext.LoadFromAssemblyPath(codeAnalysisAssemblyPath);
        var codeAnalysisCSharpAssembly = assemblyLoadContext.LoadFromAssemblyPath(codeAnalysisCSharpAssemblyPath);

        var result = new List<Type>();
        var types = codeAnalysisCSharpAssembly.GetTypes().Where(x => x.IsPublic).ToList();
        foreach (var type in types)
        {
            result.Add(type);
        }

        return result;
    }
}
