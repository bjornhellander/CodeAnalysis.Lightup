# CodeAnalysis.Lightup

## Purpose

This source generator package generates code that makes it possible to use features from a later Roslyn version without having an actual
dependency to the version supporting those features.
The consuming package would instead compile against an "oldest supported" version and use the generator to take advantage of newer features
when they are available.
The generator package has knowledge of features added after Roslyn 3.0.0. When the generated code runs, it uses reflection to detect
which of those features that are available in the Roslyn version used at runtime. This for example means that an analyzer can run in any
Visual Studio version starting from the first 2019 version and still analyze code the uses newer language features. Similarly for code fixes
and code refactorings, or whatever the generator is used in.

## Usage

Add a reference to this nuget package in the project(s) you want to generate lightup code in. A configuration file with a name matching
'CodeAnalysis.Lightup*.xml' is needed to guide the generator, for example to let it know for which  Microsoft.CodeAnalysis.* packages
it should generate lightup code.

The generated code needs some support code to compile. That code is available in a separate NuGet package called CodeAnalysis.Lightup.Runtime.
Note that a reference to that package needs to be added manually for now.

## Alternatives

There is at least one other way of accomplishing more or less the same thing: It is possible to package multiple versions of for example an
analyzer assembly in a NuGet package and the compiler will then use the latest supported one. There are pros and cons to each strategy.
A short description can for example be found here: https://www.meziantou.net/roslyn-analyzers-how-to.htm#support-multiple-ver

## Limitations

- Generic types are not handled.
- Generic members are not handled.
- Some types, mostly related to source generators and diagnostic suppressors, are not handled.
- SeparatedSyntaxListWrapper is incomplete.
- C# 8.0 is required in the target project(s).
- Version 3.0.0 of the Microsoft.CodeAnalysis packages is required in the consuming projects.

## Troubleshooting

### Problems related to long file paths

If you are using Git, enable support for long file paths by running:

> git config core.longpaths true

### The generator does not generate any code

TODO

### The generated code does not compile

TODO

## Credits

This work is heavily inspired by a similar source generator implemented by [Sam Harwell](https://github.com/sharwell) in [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers).
