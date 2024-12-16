namespace CodeAnalysis.Lightup.Collector;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Core.Types;
using NuGet.Resolver;
using NuGet.Versioning;

internal class NuGetHelper
{
    public static async Task DownloadAsync()
    {
        var settings = Settings.LoadDefaultSettings(root: null);
        var sourceRepositoryProvider = new SourceRepositoryProvider(
            new PackageSourceProvider(settings),
            Repository.Provider.GetCoreV3());

        using (var cacheContext = new SourceCacheContext())
        {
            var repositories = sourceRepositoryProvider.GetRepositories();
            var availablePackages = new Dictionary<PackageIdentity, SourcePackageDependencyInfo>(PackageIdentityComparer.Default);
            var packageId = new PackageIdentity("Microsoft.CodeAnalysis", NuGetVersion.Parse("3.0.0"));
            await GetPackageDependencies(
                packageId,
                NuGetFramework.ParseFolder("netstandard2.0"),
                cacheContext,
                NullLogger.Instance,
                repositories,
                availablePackages);

            var resolverContext = new PackageResolverContext(
                    DependencyBehavior.Lowest,
                    [packageId.Id],
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<PackageReference>(),
                    Enumerable.Empty<PackageIdentity>(),
                    availablePackages.Values,
                    sourceRepositoryProvider.GetRepositories().Select(s => s.PackageSource),
                    NullLogger.Instance);

            var resolver = new PackageResolver();
            var packagesToInstall = resolver.Resolve(resolverContext, CancellationToken.None)
                .Select(p => availablePackages.Values.Single(x => PackageIdentityComparer.Default.Equals(x, p)));

            foreach (var packageToInstall in packagesToInstall)
            {
                Console.WriteLine(packageToInstall);
            }

            var packagePathResolver = new PackagePathResolver(Path.GetFullPath("packages"));
            var packageExtractionContext = new PackageExtractionContext(
                PackageSaveMode.Defaultv3,
                XmlDocFileSaveMode.None,
                ClientPolicyContext.GetClientPolicy(settings, NullLogger.Instance),
                NullLogger.Instance);

            var nuGetFramework = NuGetFramework.ParseFolder("netstandard2.0");
            var frameworkReducer = new FrameworkReducer();

            foreach (var packageToInstall in packagesToInstall)
            {
                var downloadResource = await packageToInstall.Source.GetResourceAsync<DownloadResource>(CancellationToken.None);
                var downloadResult = await downloadResource.GetDownloadResourceResultAsync(
                    packageToInstall,
                    new PackageDownloadContext(cacheContext),
                    SettingsUtility.GetGlobalPackagesFolder(settings),
                    NullLogger.Instance,
                    CancellationToken.None);

                await PackageExtractor.ExtractPackageAsync(
                    downloadResult.PackageSource,
                    downloadResult.PackageStream,
                    packagePathResolver,
                    packageExtractionContext,
                    CancellationToken.None);

                var libItems = downloadResult.PackageReader.GetLibItems();
                var nearest = frameworkReducer.GetNearest(nuGetFramework, libItems.Select(x => x.TargetFramework));
                Console.WriteLine(string.Join("\n", libItems
                    .Where(x => x.TargetFramework.Equals(nearest))
                    .SelectMany(x => x.Items)));

                var frameworkItems = downloadResult.PackageReader.GetFrameworkItems();
                nearest = frameworkReducer.GetNearest(nuGetFramework, frameworkItems.Select(x => x.TargetFramework));
                Console.WriteLine(string.Join("\n", frameworkItems
                    .Where(x => x.TargetFramework.Equals(nearest))
                    .SelectMany(x => x.Items)));
            }
        }
    }

    private static async Task GetPackageDependencies(
        PackageIdentity package,
        NuGetFramework framework,
        SourceCacheContext cacheContext,
        ILogger logger,
        IEnumerable<SourceRepository> repositories,
        Dictionary<PackageIdentity, SourcePackageDependencyInfo> availablePackages)
    {
        if (availablePackages.ContainsKey(package))
        {
            return;
        }

        foreach (var sourceRepository in repositories)
        {
            var dependencyInfoResource = await sourceRepository.GetResourceAsync<DependencyInfoResource>();
            var dependencyInfo = await dependencyInfoResource.ResolvePackage(
                package, framework, cacheContext, logger, CancellationToken.None);

            if (dependencyInfo == null)
            {
                continue;
            }

            availablePackages.Add(package, dependencyInfo);
            foreach (var dependency in dependencyInfo.Dependencies)
            {
                await GetPackageDependencies(
                    new PackageIdentity(dependency.Id, dependency.VersionRange.MinVersion),
                    framework,
                    cacheContext,
                    logger,
                    repositories,
                    availablePackages);
            }
        }
    }
}
