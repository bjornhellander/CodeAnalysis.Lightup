# CodeAnalysis.Lightup

## Purpose

This source generator package generates code that makes it possible to use features from a later Roslyn version without having an actual
dependency to the version supporting those features.
The consuming project would instead compile against an "oldest supported" version and use the generator to take advantage of newer features
when they are available.
The generator package has knowledge of features added after Roslyn versin 1.3.2. When the generated code runs, it uses reflection to detect
which of those features that are available in the Roslyn version used at runtime. This for example means that an analyzer can run in any
Visual Studio version starting from the first 2019 version and still analyze code the uses newer language features. Similarly for code fixes
and code refactorings, or whatever the generator is used in.

## Usage

Add a reference to this nuget package in the project(s) you want to generate lightup code in. A configuration file with a name matching
'CodeAnalysis.Lightup*.json' is needed to guide the generator, for example to let it know for which  Microsoft.CodeAnalysis.* packages
it should generate lightup code.

The generated code needs some support code to compile. That code is available in a separate NuGet package called CodeAnalysis.Lightup.Runtime.
Note that a reference to that package needs to be added manually for now.

When the consuming project is using c# 8.0 or newer, the generated code enables the nullable context in the generated files.

## Configuration

The configuration file supports these settings:
* baselineVersion - Specifies the Roslyn version that the generated code should assume is always available. Code will be generated for features added after this version.
  Note that this is the version stated in the assemblies, not the package version. They are not always the same.
* assemblies - Specifies which Roslyn parts that code should be generated for. Expressed using the NuGet package names.
* includeTypes - Specifies which types to generate code for. All available types will be generated unless this setting is specified.
* useFoldersInFilePaths - Specifies whether or not to place generated files in a folder structure. Needs to be set to false when compiling using an older Roslyn version than 4.6.0.

Example configuration file, appropriate for an analyzer project requiring Roslyn 3.0.0 (Visual Studio 2019 RTM):
```json
{
  "$schema": "https://raw.githubusercontent.com/bjornhellander/CodeAnalysis.Lightup/master/Configuration.schema.json",
  "baselineVersion": "3.0.0.0",
  "assemblies": [ "Microsoft.CodeAnalysis.Common", "Microsoft.CodeAnalysis.CSharp" ]
}
```

Example configuration file, appropriate for a code fix project related to the analyzer project above:
```json
{
  "$schema": "https://raw.githubusercontent.com/bjornhellander/CodeAnalysis.Lightup/master/Configuration.schema.json",
  "baselineVersion": "3.0.0.0",
  "assemblies": [ "Microsoft.CodeAnalysis.Workspaces.Common", "Microsoft.CodeAnalysis.CSharp.Workspaces" ]
}
```

## Alternatives

There is at least one other way of accomplishing more or less the same thing: It is possible to package multiple versions of for example an
analyzer assembly in a NuGet package and the compiler will then use the latest supported one. There are pros and cons to each strategy.
A short description of this can for example be found here: https://www.meziantou.net/roslyn-analyzers-how-to.htm#support-multiple-ver

## Analyzers

The following diagnostics are reported as guidance, if no files are being generated:
* [RoslynLightup001 - Missing configuration file](https://github.com/bjornhellander/CodeAnalysis.Lightup/blob/master/doc/RoslynLightup001.md)
* [RoslynLightup001 - Incorrect configuration file](https://github.com/bjornhellander/CodeAnalysis.Lightup/blob/master/doc/RoslynLightup002.md)

## Limitations

- Generic types are not handled.
- Generic members are not handled.
- Some types, mostly related to source generators and diagnostic suppressors, are not handled.
- SeparatedSyntaxListWrapper is incomplete.
- C# 6.0 is required in the consuming project(s).
- Roslyn versions before 1.3.2 are not supported.

## Troubleshooting

### Problems related to long file paths

If you are using Git, enable support for long file paths by running:

> git config core.longpaths true

### The generator does not generate any code

The configuration file is probably either missing or incorrect. There is an analyzer included in the
generator NuGet package to inform about problems with the configuration file.

### The generated code does not compile

The generated code needs types from the NuGet package 'CodeAnalysis.Lightup.Runtime'.
Make sure an appropriate version is referenced in the consuming projects(s).

## Credits

This work is heavily inspired by a similar source generator implemented by [Sam Harwell](https://github.com/sharwell) in [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers).
