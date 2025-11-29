# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**CodeAnalysis.Lightup** is a sophisticated source generator that enables using newer Roslyn (Microsoft.CodeAnalysis) features without direct dependencies on newer versions. It compiles against an "oldest supported" Roslyn version (e.g., 1.3.2) and uses reflection at runtime to detect newer features, generating wrapper/extension code accordingly. This allows analyzers, code fixes, and refactorings to work across multiple Visual Studio versions.

Key insight: The project elegantly solves the problem of forward-compatible Roslyn usage by separating compile-time (baseline version) from runtime (detection + safe access).

## Quick Commands

### Building & Development

```bash
# Restore and build (all configurations)
dotnet build

# Build specific configuration
dotnet build -c Release
dotnet build -c Debug

# Run all tests with code coverage
dotnet test

# Run specific test project
dotnet test test/CodeAnalysis.Lightup.Test.V5_0_0

# Run Collector (updates Types.xml with Roslyn metadata)
dotnet run -c Release --project src/CodeAnalysis.Lightup.Collector

# Clean and rebuild (recommended before publishing)
git clean -fdx
dotnet build -c Release
```

### Testing

```bash
# Run all tests
dotnet test

# Run tests in parallel (faster)
dotnet test /p:NoWarn=DoNotParallelize

# Run with verbose output
dotnet test -v detailed

# Run specific test by name
dotnet test --filter "FullyQualifiedName~SomeTestName"

# Run specific test project only
dotnet test test/CodeAnalysis.Lightup.Test.Internal
```

### Analyzer & Code Quality

```bash
# Run code analyzers (NetAnalyzers, StyleCop)
dotnet build /p:EnforceCodeStyleInBuild=true

# Code style check for CI
dotnet build /p:EnforceCodeStyleInBuild=true /p:TreatWarningsAsErrors=true
```

### Publishing (from HOWTO.md)

```bash
# Before publishing, update version numbers in *.csproj files
git clean -fdx
dotnet build -c Release
dotnet nuget push <generated-.nupkg-file> --api-key <YOUR_NUGET_API_KEY>
git tag <version-tag>
git push origin <version-tag>
```

### Setup for Long Paths (Windows)

```bash
# Required before cloning if using Git on Windows
git config core.longpaths true
```

## Architecture & Key Components

### Four Core Projects

1. **CodeAnalysis.Lightup.Generator** (NuGet package, v5.0.0.0)
   - Type: Incremental Source Generator (IIncrementalGenerator)
   - Target: netstandard2.0
   - Location: `src/CodeAnalysis.Lightup.Generator/`
   - Main files: `LightupGenerator.cs` (orchestrator), `Writer.cs` (~89KB code generator), `TypesReader.cs`
   - Embedded resource: `Types.xml` (12.9MB) - metadata for all Roslyn versions and types
   - Reads config files: `CodeAnalysis.Lightup*.json` (specify baseline version and Roslyn assemblies)
   - Output: Generates `*.g.cs` files with wrapper/extension classes

2. **CodeAnalysis.Lightup.Runtime** (NuGet package, v1.2.0.0)
   - Type: Support library (zero Roslyn dependencies)
   - Targets: netstandard1.1, netstandard2.0 (maximum compatibility)
   - Location: `src/CodeAnalysis.Lightup.Runtime/`
   - Main files: `LightupHelper.cs` (~41KB reflection utilities), `Helpers/` subdirectory
   - Purpose: Provides reflection utilities for safely accessing runtime features
   - Used by: All generated code at runtime

3. **CodeAnalysis.Lightup.Collector** (CLI tool, net10.0)
   - Location: `src/CodeAnalysis.Lightup.Collector/`
   - Purpose: Reflects on reference projects to generate/update Types.xml
   - Process: Scans `ref/CodeAnalysis.Lightup.Reference.V*/` projects for each Roslyn version
   - Run: `dotnet run -c Release --project src/CodeAnalysis.Lightup.Collector`
   - Output: Updates `src/CodeAnalysis.Lightup.Generator/Types.xml`

4. **CodeAnalysis.Lightup.Definitions** (Shared models)
   - Location: `src/CodeAnalysis.Lightup.Definitions/`
   - Contains: Type definition models (ClassTypeDefinition, InterfaceTypeDefinition, etc.)
   - Used by: Collector and Generator for metadata representation

### Generation Pipeline

```
Configuration Files (CodeAnalysis.Lightup*.json)
    ↓ [LightupGenerator - parses config]
Types.xml (metadata for all Roslyn versions)
    ↓ [TypesReader - deserializes XML]
Type Definitions (in-memory model)
    ↓ [Generator analyzes + matches with consuming project's baseline version]
Version-Specific Type Mapping
    ↓ [Writer - code generation logic]
Generated *.g.cs files (wrapper classes, extension classes)
    ↓ [Runtime uses LightupHelper for safe reflection]
Type access at runtime across Roslyn versions
```

### Key Generation Rules

- **Enums**: New values → generate `EnumNameEx` extension class
- **Structs**: New members → `StructNameEx` (if new) OR `StructNameWrapper` (if existed in baseline)
- **Classes**: Static → `ClassNameEx` extension, Instance → `ClassNameWrapper` wrapper
- **Interfaces**: New members → `InterfaceNameEx` OR `InterfaceNameWrapper`

### Type Metadata System

- **Types.xml** (~12.9MB): Stores complete API metadata for 20+ Roslyn versions
- **Baseline Version**: Specified per-project in configuration file (e.g., "1.3.2.0", "3.0.0.0", "4.0.0.0")
- **Generation Scope**: Only types/members added AFTER baseline version are generated
- **Reference Projects**: `ref/` directory contains 20+ projects (V1_3_2 through V5_0_0) used by Collector

## Test Structure

- **Version-Specific Tests**: 18 projects testing each Roslyn version (V1_3_2 → V5_0_0)
- **Generator Tests**: 2 projects (`Test.Generator.V4_0_1`, `Test.Generator.V4_6_0`) testing code generation
- **Example Projects**: 3 demonstrating analyzer/code-fix/CSharp6 usage
- **Internal Tests**: `Test.Internal` (LightupHelper), `Test.Support` (shared utilities)
- **Configuration**: `TestConfiguration.cs` (DoNotParallelize), `runsettings.xml` (coverage settings)
- **Coverage Exclusion**: Generated files under `.generated/` are excluded

## CI/CD Pipeline (GitHub Actions)

File: `.github/workflows/dotnet.yml`

**Trigger**: Pushes/PRs to master, Matrix: Debug + Release

**Key Steps**:
1. Checkout + Setup .NET 10
2. `dotnet restore` → `dotnet build`
3. **Run Collector**: `dotnet run -c Release --project src/CodeAnalysis.Lightup.Collector`
4. Verify no generated files changed: `git diff --quiet HEAD`
5. `dotnet test` with XPlat Code Coverage
6. Upload coverage to Codecov

**Critical Validation**: Ensures Collector output (Types.xml) is consistent

## Project Dependencies

**Minimal & Strategic**:
- Generator: Uses `MarcosLopezC.LightJson` for fast JSON parsing
- Runtime: Zero Roslyn dependency, uses `System.Collections.Immutable` (1.2.0), `System.Threading.Tasks.Extensions` (4.3.0)
- Tests: MSTest 4.0.2, Moq 4.20.72, Coverlet for coverage
- Analyzers: Microsoft.CodeAnalysis.NetAnalyzers (10.0.100), NewStyleCop.Analyzers (1.2.1)

## Configuration Files

### CodeAnalysis.Lightup*.json (Consumed by Generator)

```json
{
  "$schema": "https://raw.githubusercontent.com/bjornhellander/CodeAnalysis.Lightup/master/Configuration.schema.json",
  "baselineVersion": "3.0.0.0",
  "assemblies": [ "Microsoft.CodeAnalysis.Common", "Microsoft.CodeAnalysis.CSharp" ],
  "includeTypes": ["SyntaxKind", "SyntaxNode"],
  "useFoldersInFilePaths": true
}
```

- **baselineVersion**: Assembly version (not package version) to treat as always available
- **assemblies**: Which Roslyn packages to generate for
- **includeTypes** (optional): Filter generated types
- **useFoldersInFilePaths** (optional): Set to false for Roslyn < 4.6.0

### Directory.Build.props

Shared MSBuild settings:
- Nullable reference types: enabled
- Code style enforcement enabled
- Binding redirect generation
- Documentation generation
- Analyzer packages included

### stylecop.json & .editorconfig

StyleCop and code formatting rules. Enforced in CI via `EnforceCodeStyleInBuild=true`.

## Common Development Tasks

### When Types.xml Needs Updating

1. Add/update reference project in `ref/` (Roslyn version support)
2. Run Collector: `dotnet run -c Release --project src/CodeAnalysis.Lightup.Collector`
3. Commit updated `Types.xml`
4. Rebuild to regenerate consumer projects

*Note: After changing Generator or Types.xml, VS may need restart for incremental generator to update.*

### Adding Support for New Roslyn Version

1. Create reference project in `ref/CodeAnalysis.Lightup.Reference.V{version}/` with target Roslyn package
2. Update Collector project list (manually or auto-detect)
3. Run Collector to reflect on new version
4. Create test project `test/CodeAnalysis.Lightup.Test.V{version}/`
5. Update GitHub Actions matrix (if needed)

### Fixing Generated Code Issues

- Issues are typically in `Writer.cs` (orchestrates code generation)
- Generated files: Excluded from source control, regenerated on build
- Look at `*.g.cs` files in `obj/` directories to debug generation

### Publishing a Release

1. Update version numbers in all `*.csproj` files (Generator: major.minor match Roslyn, Runtime: independent)
2. `git clean -fdx && dotnet build -c Release`
3. `dotnet nuget push <.nupkg> --api-key <KEY>`
4. `git tag <version>`
5. `git push origin <version>`

See `HOWTO.md` for detailed publishing guide.

## Key Limitations & Design Constraints

- **No Generic Types**: Generic types and generic members not supported
- **No Source Generators/Suppressors**: Some types not handled
- **C# 6.0 Minimum**: Consuming projects must support C# 6.0+
- **Roslyn 1.3.2+**: Earlier versions not supported
- **Long Path Support**: Windows requires `git config core.longpaths true`

## Diagnostics (Built-in Analyzer)

- **RoslynLightup001**: Missing configuration file → See `doc/RoslynLightup001.md`
- **RoslynLightup002**: Incorrect configuration file → See `doc/RoslynLightup002.md`

## Important Files to Know

| Path | Purpose |
|------|---------|
| `src/CodeAnalysis.Lightup.Generator/LightupGenerator.cs` | Main generator orchestrator |
| `src/CodeAnalysis.Lightup.Generator/Writer.cs` | Code generation engine (~89KB) |
| `src/CodeAnalysis.Lightup.Generator/Types.xml` | Embedded Roslyn metadata (12.9MB) |
| `src/CodeAnalysis.Lightup.Runtime/LightupHelper.cs` | Runtime reflection utilities (~41KB) |
| `src/CodeAnalysis.Lightup.Collector/Program.cs` | CLI tool for updating Types.xml |
| `Configuration.schema.json` | JSON schema for config validation |
| `test/CodeAnalysis.Lightup.Test.V*/` | Version-specific tests |
| `.github/workflows/dotnet.yml` | CI/CD pipeline |

## Recent Changes & Maintenance

- Recently upgraded to .NET 10 SDK
- MSTest upgraded to 4.0.2
- Microsoft.CodeAnalysis.NetAnalyzers at 10.0.100
- Generator/Runtime versions maintained independently (current: v5.0.0.0 / v1.2.0.0)
- Active feature branch workflow (feature/* → master via PR)
