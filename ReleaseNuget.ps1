<#
.SYNOPSIS
    Builds and publishes the CodeAnalysis.Lightup.Generator and/or CodeAnalysis.Lightup.Runtime NuGet packages.

.DESCRIPTION
    Builds, pushes and tags a release for the selected package(s). Select at least one of -Generator / -Runtime.
    Each package version is read from its .csproj file (PackageVersion), and its tag name is derived from it.
    Must be run from the repository root.

.PARAMETER ApiKey
    The NuGet API key to use when pushing the package(s).

.PARAMETER Generator
    Release the CodeAnalysis.Lightup.Generator package.

.PARAMETER Runtime
    Release the CodeAnalysis.Lightup.Runtime package.

.PARAMETER Force
    Skip the confirmation prompt before running the destructive "git clean -fdx" step.

.PARAMETER DryRun
    Print the commands that would be run, without executing the clean, push or tag/push steps.

.EXAMPLE
    .\ReleaseNuget.ps1 -ApiKey "oy2abc..." -Generator

.EXAMPLE
    .\ReleaseNuget.ps1 -ApiKey "oy2abc..." -Generator -Runtime
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$ApiKey,

    [switch]$Generator,

    [switch]$Runtime,

    [switch]$Force,

    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

if (-not $Generator -and -not $Runtime) {
    throw "Specify at least one of -Generator or -Runtime to select which package(s) to release."
}

# Refuse to proceed with any uncommitted changes (staged/unstaged, tracked/untracked), since a
# release should be built from committed state and git clean -fdx only removes untracked/ignored files.
$statusOutput = git status --porcelain
if ($LASTEXITCODE -ne 0) {
    throw "git status failed"
}
if ($statusOutput) {
    throw "Working tree has uncommitted changes. Commit or stash them before releasing:`n$statusOutput"
}

$allPackages = @(
    [PSCustomObject]@{
        ProjectName = "CodeAnalysis.Lightup.Generator"
        Selected    = [bool]$Generator
        TagPrefix   = "generator"
    },
    [PSCustomObject]@{
        ProjectName = "CodeAnalysis.Lightup.Runtime"
        Selected    = [bool]$Runtime
        TagPrefix   = "runtime"
    }
)

$packages = $allPackages | Where-Object { $_.Selected }

foreach ($package in $packages) {
    $projectDir = "src\$($package.ProjectName)"
    $csprojPath = "$projectDir\$($package.ProjectName).csproj"

    # Read package version from the csproj
    [xml]$csproj = Get-Content $csprojPath
    $packageVersion = $csproj.Project.PropertyGroup.PackageVersion | Where-Object { $_ } | Select-Object -First 1
    if (-not $packageVersion) {
        throw "Could not find <PackageVersion> in $csprojPath"
    }
    $packageVersion = $packageVersion.Trim()

    # NuGet normalizes the version by dropping a trailing ".0" revision, e.g. "5.9.2.0-alpha.1" -> "5.9.2-alpha.1",
    # which is both the tag naming convention used in this repo and the version used in the built .nupkg's file name.
    if ($packageVersion -match '^(?<core>\d+\.\d+\.\d+)(\.0)?(?<suffix>-.*)?$') {
        $normalizedVersion = "$($Matches.core)$($Matches.suffix)"
    }
    else {
        $normalizedVersion = $packageVersion
    }
    $package | Add-Member -NotePropertyName Tag -NotePropertyValue "$($package.TagPrefix)_v$normalizedVersion"
    $package | Add-Member -NotePropertyName NupkgPath -NotePropertyValue (Join-Path $projectDir "bin\Release\$($package.ProjectName).$normalizedVersion.nupkg")

    Write-Host "$($package.ProjectName)"
    Write-Host "  Package version : $packageVersion"
    Write-Host "  Git tag         : $($package.Tag)"
    Write-Host "  NuPkg file      : $($package.NupkgPath)"
    Write-Host ""

    # Refuse to proceed if the tag already exists
    $existingTag = git tag --list $package.Tag
    if ($existingTag) {
        throw "Tag '$($package.Tag)' already exists. Has this version already been released?"
    }
}

Write-Host "The following commands will be executed:"
Write-Host "  git clean -fdx"
Write-Host "  dotnet build -c Release"
foreach ($package in $packages) {
    Write-Host "  dotnet nuget push `"$($package.NupkgPath)`" --api-key <ApiKey>"
    Write-Host "  git tag $($package.Tag)"
    Write-Host "  git push origin $($package.Tag)"
}

if ($DryRun) {
    return
}

if (-not $Force) {
    Write-Host ""
    Write-Host "Do you want to proceed?"
    $answer = Read-Host "Type 'yes' to continue"
    if ($answer -ne "yes") {
        Write-Host "Aborted."
        return
    }
}

Write-Host ""
Write-Host "Cleaning..."
git clean -fdx
if ($LASTEXITCODE -ne 0) { throw "git clean failed" }

Write-Host "Building..."
dotnet build -c Release
if ($LASTEXITCODE -ne 0) { throw "dotnet build failed" }

foreach ($package in $packages) {
    Write-Host "[$($package.ProjectName)] Pushing nuget package..."
    dotnet nuget push $package.NupkgPath --api-key $ApiKey
    if ($LASTEXITCODE -ne 0) { throw "dotnet nuget push failed for $($package.ProjectName)" }

    Write-Host "[$($package.ProjectName)] Tagging..."
    git tag $package.Tag
    if ($LASTEXITCODE -ne 0) { throw "git tag failed for $($package.ProjectName)" }

    Write-Host "[$($package.ProjectName)] Pushing tag..."
    git push origin $package.Tag
    if ($LASTEXITCODE -ne 0) { throw "git push failed for $($package.ProjectName)" }

    Write-Host "[$($package.ProjectName)] Done!"
}
