// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.SourceGenerator;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Roslyn.CodeAnalysis.Lightup.Definitions;

[Generator]
public class LightupGenerator : IIncrementalGenerator
{
    private static readonly Regex SettingsFileNameRegex = new("Roslyn\\.CodeAnalysis\\.Lightup.*\\.xml");
    private static readonly Lazy<Dictionary<string, BaseTypeDefinition>> Types = new(ReadTypes);

    private static Dictionary<string, BaseTypeDefinition> ReadTypes()
    {
        var typeList = TypesReader.Read();
        var types = typeList.ToDictionary(x => x.FullName, x => x);
        return types;
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var typesFiles = context.AdditionalTextsProvider.Where(x => SettingsFileNameRegex.IsMatch(Path.GetFileName(x.Path)));
        context.RegisterSourceOutput(
            typesFiles,
            (context, value) => Execute(context, value));
    }

    private static void Execute(SourceProductionContext context, AdditionalText typesFile)
    {
        var syntaxText = typesFile.GetText(context.CancellationToken);
        if (syntaxText is null)
        {
            throw new InvalidOperationException($"Failed to read settings file {typesFile.Path}");
        }

        var doc = XDocument.Parse(syntaxText.ToString());
        var root = doc.Root;
        var assemblies = root.Elements("Assembly").Select(x => (AssemblyKind)Enum.Parse(typeof(AssemblyKind), x.Value)).ToList();
        var baselineVersion = root.Element("BaselineVersion")?.Value;

        Writer.Write(context, assemblies, Types.Value);
    }
}
