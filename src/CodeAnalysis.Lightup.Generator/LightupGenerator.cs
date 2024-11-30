// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

using System;
using System.Collections.Generic;
using System.Linq;
using CodeAnalysis.Lightup.Definitions;
using Microsoft.CodeAnalysis;

[Generator]
public class LightupGenerator : IIncrementalGenerator
{
    private static readonly Lazy<Dictionary<string, BaseTypeDefinition>> Types = new(ReadTypes);

    private static Dictionary<string, BaseTypeDefinition> ReadTypes()
    {
        var typeList = TypesReader.Read();
        var types = typeList.ToDictionary(x => x.FullName, x => x);
        return types;
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<AdditionalText> configFiles = context.AdditionalTextsProvider.Where(Helpers.IsConfigurationFile);

        IncrementalValuesProvider<string> configFileContents = configFiles.Select((text, cancellationToken) => text.GetText(cancellationToken)!.ToString());

        context.RegisterSourceOutput(
            configFileContents,
            (context, value) => Execute(context, value));
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "TODO")]
    private static void Execute(SourceProductionContext context, string configFileContent)
    {
        if (Helpers.TryParseConfiguration(configFileContent, out var assemblies, out var baselineVersion, out var _))
        {
            Writer.Write(context, assemblies, Types.Value);
        }
    }
}
