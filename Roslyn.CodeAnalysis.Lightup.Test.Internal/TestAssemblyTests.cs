// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace Roslyn.CodeAnalysis.Lightup.Test.Internal;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestAssemblyTests
{
    private static readonly List<Assembly> TestAssemblies;

    static TestAssemblyTests()
    {
        var types = new[]
        {
            typeof(V3_0_0.CSharp.LightupStatusTests),
            typeof(V3_8_0.CSharp.LightupStatusTests),
            typeof(V4_0_1.CSharp.LightupStatusTests),
            typeof(V4_4_0.CSharp.LightupStatusTests),
            typeof(V4_8_0.CSharp.LightupStatusTests),
        };
        TestAssemblies = types.Select(x => x.Assembly).ToList();
    }

    [TestMethod]
    public void TestCompleteAssemblyList()
    {
        var testAssemblyNames = TestAssemblies.Select(x => x.GetName().Name).ToList();

        var testProjectNames = GetTestProjectNames();
        foreach (var testProjectName in testProjectNames)
        {
            Assert.IsTrue(testAssemblyNames.Contains(testProjectName), $"Add test project {testProjectName} to the {nameof(TestAssemblies)} field");
        }

        Assert.AreEqual(testProjectNames.Count, testAssemblyNames.Count, $"{nameof(TestAssemblies)} contains non-existing projects");
    }

    [TestMethod]
    public void TestInheritance()
    {
        var previousTestAssembly = TestAssemblies.First();
        var testTypesInPreviousAssembly = GetTestTypes(previousTestAssembly);

        foreach (var testAssembly in TestAssemblies.Skip(1))
        {
            var testTypesInCurrentAssembly = GetTestTypes(testAssembly);
            foreach (var testTypeInPreviousAssembly in testTypesInPreviousAssembly)
            {
                var condition = ContainsSubtypeOf(testTypesInCurrentAssembly, testTypeInPreviousAssembly);
                Assert.IsTrue(condition, $"Project {testAssembly.GetName().Name} does not contain a subtype of {testTypeInPreviousAssembly.Name}");
            }

            var missingTestTypes = testTypesInPreviousAssembly.Except(testTypesInCurrentAssembly).ToList();

            previousTestAssembly = testAssembly;
            testTypesInPreviousAssembly = testTypesInCurrentAssembly;
        }
    }

    private static string GetRepositoryRoot()
    {
        var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        Assert.IsNotNull(folder);

        while (!Directory.GetFiles(folder).Any(x => x.EndsWith(".sln")))
        {
            var parent = Path.GetDirectoryName(folder);
            Assert.IsNotNull(parent);
            folder = parent;
        }

        return folder;
    }

    private static List<string> GetTestProjectNames()
    {
        var rootFolder = GetRepositoryRoot();
        var folders = Directory.GetDirectories(rootFolder).Select(x => Path.GetFileName(x)).ToList();
        var testProjectFolders = folders.Where(x => x.StartsWith("Roslyn.CodeAnalysis.Lightup.Test") && !x.EndsWith(".Internal") && !x.EndsWith(".SourceGenerator")).ToList();
        return testProjectFolders;
    }

    private static List<Type> GetTestTypes(Assembly assembly)
    {
        var testTypes = assembly.GetTypes().Where(x => HasTestClassAttribute(x)).ToList();
        return testTypes;
    }

    private static bool HasTestClassAttribute(Type type)
    {
        return type.CustomAttributes.Any(a => a.AttributeType.Name.EndsWith("TestClassAttribute"));
    }

    private static bool ContainsSubtypeOf(List<Type> types, Type type)
    {
        var result = types.Any(x => type.IsAssignableFrom(x));
        return result;
    }
}
