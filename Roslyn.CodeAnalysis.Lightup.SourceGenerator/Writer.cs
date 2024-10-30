// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

// Fixed in StyleCop.Analyzes, but not yet released
#pragma warning disable SA1513 // Closing brace should be followed by blank line
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line

namespace Roslyn.CodeAnalysis.Lightup.SourceGenerator;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.CodeAnalysis.Lightup.Definitions;

internal class Writer
{
    private static readonly Dictionary<AssemblyKind, string> HelperPrefixes = new()
    {
        [AssemblyKind.Common] = "Common",
        [AssemblyKind.CSharp] = "CSharp",
        [AssemblyKind.Workspaces] = "WorkspacesCommon",
        [AssemblyKind.CSharpWorkspaces] = "CSharpWorkspaces",
    };

    private static readonly Dictionary<AssemblyKind, string> ExampleTypeNames = new()
    {
        [AssemblyKind.Common] = "Microsoft.CodeAnalysis.IOperation",
        [AssemblyKind.CSharp] = "Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax",
        [AssemblyKind.Workspaces] = "Microsoft.CodeAnalysis.WorkspaceChangeKind",
        [AssemblyKind.CSharpWorkspaces] = "Microsoft.CodeAnalysis.CSharp.Formatting.CSharpFormattingOptions",
    };

    private static readonly Dictionary<ParameterMode, string> ParameterModeText = new()
    {
        [ParameterMode.None] = "",
        [ParameterMode.In] = "in ",
        [ParameterMode.Out] = "out ",
    };

    private static readonly HashSet<string> TypesToSkip =
    [
        // Irrelevant new types related to source generators
        "Microsoft.CodeAnalysis.CSharp.CSharpGeneratorDriver", // References ISourceGeneratorWrapper etc
        "Microsoft.CodeAnalysis.GeneratedSourceResult",
        "Microsoft.CodeAnalysis.GeneratorAttribute",
        "Microsoft.CodeAnalysis.GeneratorAttributeSyntaxContext",
        "Microsoft.CodeAnalysis.GeneratorDriver", // References GeneratorDriverRunResultWrapper etc
        "Microsoft.CodeAnalysis.GeneratorDriverOptions",
        "Microsoft.CodeAnalysis.GeneratorDriverRunResult", // References GeneratorRunResultWrapper
        "Microsoft.CodeAnalysis.GeneratorDriverTimingInfo", // References GeneratorTimingInfoWrapper
        "Microsoft.CodeAnalysis.GeneratorExecutionContext",
        "Microsoft.CodeAnalysis.GeneratorExtensions", // References ISourceGeneratorWrapper
        "Microsoft.CodeAnalysis.GeneratorInitializationContext", // Action<wrapper>
        "Microsoft.CodeAnalysis.GeneratorPostInitializationContext",
        "Microsoft.CodeAnalysis.GeneratorRunResult", // References ISourceGeneratorWrapper
        "Microsoft.CodeAnalysis.GeneratorSyntaxContext",
        "Microsoft.CodeAnalysis.GeneratorTimingInfo", // References ISourceGeneratorWrapper
        "Microsoft.CodeAnalysis.IIncrementalGenerator", // References IncrementalGeneratorInitializationContextWrapper
        "Microsoft.CodeAnalysis.IncrementalGeneratorInitializationContext", // References IncrementalValuesProvider<>
        "Microsoft.CodeAnalysis.IncrementalGeneratorOutputKind",
        "Microsoft.CodeAnalysis.IncrementalGeneratorPostInitializationContext",
        "Microsoft.CodeAnalysis.IncrementalGeneratorRunStep", // References ValueType<wrapper, ...>
        "Microsoft.CodeAnalysis.IncrementalStepRunReason",
        "Microsoft.CodeAnalysis.IncrementalValueProviderExtensions", // Only generic methods
        "Microsoft.CodeAnalysis.ISourceGenerator", // References IncrementalGeneratorInitializationContext
        "Microsoft.CodeAnalysis.ISyntaxContextReceiver",
        "Microsoft.CodeAnalysis.ISyntaxReceiver",
        "Microsoft.CodeAnalysis.SourceProductionContext",
        "Microsoft.CodeAnalysis.SyntaxContextReceiverCreator",
        "Microsoft.CodeAnalysis.SyntaxReceiverCreator",

        // Irrelevant new types related to diagnostic suppressors
        "Microsoft.CodeAnalysis.Diagnostics.DiagnosticSuppressor",
        "Microsoft.CodeAnalysis.Diagnostics.Suppression",
        "Microsoft.CodeAnalysis.Diagnostics.SuppressionAnalysisContext",
        "Microsoft.CodeAnalysis.SuppressionDescriptor",

        // TODO: Investigate if these updated types should be generated
        "Microsoft.CodeAnalysis.Diagnostics.AnalyzerFileReference", // References ISourceGenerator
        "Microsoft.CodeAnalysis.Diagnostics.AnalyzerReference", // References ISourceGenerator
    ];

    internal static void Write(
        SourceProductionContext context,
        IReadOnlyList<AssemblyKind> assemblyKinds,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        foreach (var assemblyKind in assemblyKinds)
        {
            WriterLightupHelper(context, assemblyKind);

            if (assemblyKind == AssemblyKind.CSharp)
            {
                WriteSeparatedSyntaxListWrapper(context);
            }

            Write(context, assemblyKind, typeDefs);
        }
    }

    private static void WriterLightupHelper(SourceProductionContext context, AssemblyKind assemblyKind)
    {
        var name = $"{HelperPrefixes[assemblyKind]}LightupHelper";

        var source = $@"// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

// <auto-generated/>

#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{{
    internal class {name} : Roslyn.CodeAnalysis.Lightup.Runtime.LightupHelper
    {{
        private static readonly System.Reflection.Assembly Assembly = typeof({ExampleTypeNames[assemblyKind]}).Assembly;

        public static System.Type? FindType(string wrappedTypeName)
        {{
            return FindType(Assembly, wrappedTypeName);
        }}
    }}
}}
";

        var targetFilePath = $"{name}.g.cs";
        context.AddSource(targetFilePath, SourceText.From(source, Encoding.UTF8));
    }

    // TODO: Remove suppression of CS1591 and add documentation.
    private static void WriteSeparatedSyntaxListWrapper(SourceProductionContext context)
    {
        var source = @"// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

// <auto-generated/>
#pragma warning disable CS1591

#nullable enable

namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    // TODO: Implement remaining members
    public readonly struct SeparatedSyntaxListWrapper<TNode>
    {
        private static readonly Type? WrappedType; // NOTE: Possibly used via reflection

        private delegate int CountDelegate(object? obj);
        private delegate SeparatedSyntaxListWrapper<TNode> AddRangeDelegate(object? obj, IEnumerable<TNode> arg1);

        private static readonly CountDelegate CountAccessor;
        private static readonly AddRangeDelegate AddRangeAccessor;

        private readonly object? wrappedObject;

        static SeparatedSyntaxListWrapper()
        {
            var wrapperNodeType = typeof(TNode);
            var wrappedNodeTypeField = wrapperNodeType.GetField(""WrappedType"", BindingFlags.Static | BindingFlags.NonPublic);
            var wrappedNodeType = (Type)wrappedNodeTypeField.GetValue(null);
            WrappedType = wrappedNodeType != null ? typeof(SeparatedSyntaxList<>).MakeGenericType(wrappedNodeType) : null;

            CountAccessor = CSharpLightupHelper.CreateInstanceGetAccessor<CountDelegate>(WrappedType, nameof(Count));
            AddRangeAccessor = CSharpLightupHelper.CreateInstanceMethodAccessor<AddRangeDelegate>(WrappedType, nameof(AddRange), ""nodesIEnumerable`1"");
        }

        private SeparatedSyntaxListWrapper(object? obj)
        {
            wrappedObject = obj;
        }

        public readonly int Count
            => CountAccessor(wrappedObject);

        public readonly int SeparatorCount
            => throw new NotImplementedException();

        public readonly TextSpan FullSpan
            => throw new NotImplementedException();

        public readonly TextSpan Span
            => throw new NotImplementedException();

        public readonly TNode this[int index]
            => throw new NotImplementedException();

        public static implicit operator SeparatedSyntaxListWrapper<SyntaxNode>(SeparatedSyntaxListWrapper<TNode> nodes)
            => throw new NotImplementedException();

        public static implicit operator SeparatedSyntaxListWrapper<TNode>(SeparatedSyntaxListWrapper<SyntaxNode> nodes)
            => throw new NotImplementedException();

        public static bool Is(object? obj)
        {
            if (obj != null && obj.GetType() != WrappedType)
            {
                obj = null;
            }

            return obj != null;
        }

        public static SeparatedSyntaxListWrapper<TNode> As(object? obj)
        {
            if (obj != null && obj.GetType() != WrappedType)
            {
                obj = null;
            }

            return new SeparatedSyntaxListWrapper<TNode>(obj);
        }

        public readonly object? Unwrap()
            => wrappedObject;

        public readonly SyntaxToken GetSeparator(int index)
            => throw new NotImplementedException();

        public readonly IEnumerable<SyntaxToken> GetSeparators()
            => throw new NotImplementedException();

        public readonly override string ToString()
            => throw new NotImplementedException();

        public readonly string ToFullString()
            => throw new NotImplementedException();

        public readonly TNode First()
            => throw new NotImplementedException();

        public readonly TNode FirstOrDefault()
            => throw new NotImplementedException();

        public readonly TNode Last()
            => throw new NotImplementedException();

        public TNode LastOrDefault()
            => throw new NotImplementedException();

        public readonly bool Contains(TNode node)
            => throw new NotImplementedException();

        public readonly int IndexOf(TNode node)
            => throw new NotImplementedException();

        public readonly int IndexOf(Func<TNode, bool> predicate)
            => throw new NotImplementedException();

        public readonly int LastIndexOf(TNode node)
            => throw new NotImplementedException();

        public readonly int LastIndexOf(Func<TNode, bool> predicate)
            => throw new NotImplementedException();

        public readonly bool Any()
            => throw new NotImplementedException();

        public readonly SyntaxNodeOrTokenList GetWithSeparators()
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> Add(TNode node)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> AddRange(IEnumerable<TNode> nodes)
            => AddRangeAccessor(wrappedObject, nodes);

        public readonly SeparatedSyntaxListWrapper<TNode> Insert(int index, TNode node)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> InsertRange(int index, IEnumerable<TNode> nodes)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> RemoveAt(int index)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> Remove(TNode node)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> Replace(TNode nodeInList, TNode newNode)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> ReplaceRange(TNode nodeInList, IEnumerable<TNode> newNodes)
            => throw new NotImplementedException();

        public readonly SeparatedSyntaxListWrapper<TNode> ReplaceSeparator(SyntaxToken separatorToken, SyntaxToken newSeparator)
            => throw new NotImplementedException();
    }
}
";

        var targetFilePath = "SeparatedSyntaxListWrapper.g.cs";
        context.AddSource(targetFilePath, SourceText.From(source, Encoding.UTF8));
    }

    private static void Write(
        SourceProductionContext context,
        AssemblyKind assemblyKind,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var relevantTypeDefs = typeDefs.Values.Where(x => x.AssemblyKind == assemblyKind).ToList();
        foreach (var typeDef in relevantTypeDefs)
        {
            var targetNamespace = GetTargetNamespace(typeDef);
            var source = GenerateType(typeDef, typeDefs, targetNamespace, HelperPrefixes[assemblyKind]);

            if (source != null)
            {
                var targetFolder = GetTargetFolder(typeDef);
                var targetFilePath = Path.Combine(targetFolder, typeDef.GeneratedFileName);
                context.AddSource(targetFilePath, SourceText.From(source, Encoding.UTF8));
            }
        }
    }

    private static string GetTargetNamespace(BaseTypeDefinition typeDef)
    {
        var sourceNamespace = typeDef.Namespace!;
        var targetNamespace = sourceNamespace + ".Lightup";
        return targetNamespace;
    }

    private static string? GenerateType(
        BaseTypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs,
        string targetNamespace,
        string helperPrefix)
    {
        if (TypesToSkip.Contains(typeDef.FullName))
        {
            return null;
        }

        if (typeDef is EnumTypeDefinition enumTypeDef)
        {
            if (typeDef.AssemblyVersion != null)
            {
                return GenerateNewEnum(enumTypeDef, targetNamespace);
            }
            else if (typeDef.IsUpdated)
            {
                return GenerateUpdatedEnum(enumTypeDef, typeDefs, targetNamespace);
            }
            else
            {
                return null;
            }
        }
        else if (typeDef is StructTypeDefinition structTypeDef)
        {
            if (typeDef.AssemblyVersion != null)
            {
                return GenerateWrapper(structTypeDef, typeDefs, targetNamespace, helperPrefix);
            }
            else if (structTypeDef.IsUpdated)
            {
                return GenerateExtension(structTypeDef, typeDefs, targetNamespace, helperPrefix);
            }
            else
            {
                return null;
            }
        }
        else if (typeDef is ClassTypeDefinition classTypeDef)
        {
            if (classTypeDef.AssemblyVersion != null)
            {
                if (classTypeDef.IsStatic)
                {
                    return GenerateExtension(classTypeDef, typeDefs, targetNamespace, helperPrefix);
                }
                else
                {
                    return GenerateWrapper(classTypeDef, typeDefs, targetNamespace, helperPrefix);
                }
            }
            else if (classTypeDef.IsUpdated)
            {
                return GenerateExtension(classTypeDef, typeDefs, targetNamespace, helperPrefix);
            }
            else
            {
                return null;
            }
        }
        else if (typeDef is InterfaceTypeDefinition interfaceTypeDef)
        {
            if (typeDef.AssemblyVersion != null)
            {
                return GenerateWrapper(interfaceTypeDef, typeDefs, targetNamespace, helperPrefix);
            }
            else if (interfaceTypeDef.IsUpdated)
            {
                return GenerateExtension(interfaceTypeDef, typeDefs, targetNamespace, helperPrefix);
            }
            else
            {
                return null;
            }
        }
        else
        {
            Assert.Fail("Unexpected type");
            return null;
        }
    }

    private static string GenerateNewEnum(
        EnumTypeDefinition typeDef,
        string targetNamespace)
    {
        // TODO: No need to check AssemblyVersion here, right?
        var newValues = typeDef.Values.Where(x => x.AssemblyVersion != null).OrderBy(x => x.Value).ToList();
        var targetName = typeDef.GeneratedName;

        var sb = new StringBuilder();
        var isFirstValue = true;

        AppendCopyrightComment(sb);
        sb.AppendLine();
        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        AppendTypeSummary(sb, typeDef);
        if (typeDef.IsFlagsEnum)
        {
            sb.AppendLine($"    [System.Flags]");
        }
        sb.AppendLine($"    public enum {targetName} : {typeDef.UnderlyingTypeName}");
        sb.AppendLine($"    {{");
        foreach (var value in newValues)
        {
            if (!isFirstValue)
            {
                sb.AppendLine();
            }

            AppendEnumValueSummary(sb, value);
            sb.AppendLine($"        {value.Name} = {value.Value},");
            isFirstValue = false;
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return source;
    }

    private static string GenerateUpdatedEnum(
        EnumTypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs,
        string targetNamespace)
    {
        var newValues = typeDef.Values.Where(x => x.AssemblyVersion != null).OrderBy(x => x.Value).ToList();
        Assert.IsTrue(newValues.Count > 0, "Unexpected unchanged enum");

        var fullTypeName = GetFullEnumTypeName(typeDef, typeDefs);

        var targetName = typeDef.GeneratedName;

        var sb = new StringBuilder();
        var isFirstValue = true;

        AppendCopyrightComment(sb);
        sb.AppendLine();
        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        AppendTypeSummary(sb, typeDef);
        sb.AppendLine($"    public static partial class {targetName}");
        sb.AppendLine($"    {{");
        foreach (var value in newValues)
        {
            if (!isFirstValue)
            {
                sb.AppendLine();
            }

            AppendEnumValueSummary(sb, value);
            sb.AppendLine($"        public const {fullTypeName} {value.Name} = ({fullTypeName}){value.Value};");
            isFirstValue = false;
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return source;
    }

    private static string GetFullEnumTypeName(
        EnumTypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        sb.Append(typeDef.Namespace);
        AppendEnclosingType(sb, typeDef.EnclosingTypeFullName, false, typeDefs);
        sb.Append(".");
        sb.Append(typeDef.Name);
        return sb.ToString();
    }

    private static string GenerateWrapper(
        TypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs,
        string targetNamespace,
        string helperPrefix)
    {
        var targetName = typeDef.GeneratedName;

        var instanceConstructors = GetInstanceConstructors(typeDef);
        var staticFields = GetStaticFields(typeDef);
        var instanceFields = GetInstanceFields(typeDef);
        Assert.IsTrue(instanceFields.Count == 0, "Unexpected instance fields");
        var staticEvents = GetStaticEvents(typeDef);
        Assert.IsTrue(staticEvents.Count == 0, "Unexpected static events");
        var instanceEvents = GetInstanceEvents(typeDef);
        Assert.IsTrue(instanceEvents.Count == 0, "Unexpected instance events");
        var staticProperties = GetStaticProperties(typeDef);
        var instanceProperties = GetInstanceProperties(typeDef);
        var indexers = GetIndexers(typeDef);
        Assert.IsTrue(indexers.Count == 0, "Unexpected indexers");
        var staticMethods = GetStaticMethods(typeDef);
        var instanceMethods = GetInstanceMethods(typeDef);

        var (baseTypeName, baseTypeNamespace) = GetBaseTypeName(typeDef);
        var hasBaseType = baseTypeName != null && typeDef is not InterfaceTypeDefinition;
        baseTypeName ??= "Object";
        baseTypeNamespace ??= "System";

        var sb = new StringBuilder();

        AppendCopyrightComment(sb);
        sb.AppendLine();
        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        AppendUsingStatements(sb);
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        AppendEnclosingTypesStart(sb, typeDef.EnclosingTypeFullName, typeDefs);
        AppendTypeSummary(sb, typeDef);
        sb.AppendLine($"    public readonly partial struct {targetName}");
        sb.AppendLine($"    {{");
        sb.AppendLine($"        private const string WrappedTypeName = \"{typeDef.FullName}\";");
        sb.AppendLine();
        sb.AppendLine($"        private static readonly System.Type? WrappedType; // NOTE: Used via reflection");
        if (staticFields.Count != 0)
        {
            sb.AppendLine();
            foreach (var field in staticFields)
            {
                AppendStaticFieldDelegateDeclarations(sb, field, typeDefs);
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                AppendInstanceConstructorDelegateDeclarations(sb, targetName, constructor, index, typeDefs);
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                AppendStaticPropertyDelegateDeclarations(sb, property, typeDefs);
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                AppendInstancePropertyDelegateDeclarations(sb, property, baseTypeName, baseTypeNamespace, typeDefs);
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                AppendStaticMethodDelegateDeclaration(sb, method, index, typeDefs);
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                AppendInstanceMethodDelegateDeclaration(sb, method, baseTypeName, baseTypeNamespace, index, typeDefs);
            }
        }
        if (staticFields.Count != 0)
        {
            sb.AppendLine();
            foreach (var field in staticFields)
            {
                sb.AppendLine($"        private static readonly {field.Name}GetterDelegate {field.Name}GetterFunc;");
                Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                sb.AppendLine($"        private static readonly ConstructorDelegate{index} ConstructorFunc{index};");
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                sb.AppendLine($"        private static readonly {property.Name}GetterDelegate {property.Name}GetterFunc;");
                if (property.HasSetter)
                {
                    sb.AppendLine($"        private static readonly {property.Name}SetterDelegate {property.Name}SetterFunc;");
                }
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                sb.AppendLine($"        private static readonly {property.Name}GetterDelegate {property.Name}GetterFunc;");
                if (property.HasSetter)
                {
                    sb.AppendLine($"        private static readonly {property.Name}SetterDelegate {property.Name}SetterFunc;");
                }
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                sb.AppendLine($"        private static readonly {method.Name}Delegate{index} {method.Name}Func{index};");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                sb.AppendLine($"        private static readonly {method.Name}Delegate{index} {method.Name}Func{index};");
            }
        }
        sb.AppendLine();
        sb.AppendLine($"        private readonly {baseTypeNamespace}.{baseTypeName}? wrappedObject;");
        sb.AppendLine();
        sb.AppendLine($"        static {targetName}()");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            WrappedType = {helperPrefix}LightupHelper.FindType(WrappedTypeName);");
        if (staticFields.Count != 0)
        {
            sb.AppendLine();
            foreach (var field in staticFields)
            {
                sb.AppendLine($"            {field.Name}GetterFunc = {helperPrefix}LightupHelper.CreateStaticReadAccessor<{field.Name}GetterDelegate>(WrappedType, nameof({field.Name}));");
                Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                sb.AppendLine($"            ConstructorFunc{index} = {helperPrefix}LightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate{index}>(WrappedType{GetCreateConstructorAccessorArguments(constructor)});");
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                sb.AppendLine($"            {property.Name}GetterFunc = {helperPrefix}LightupHelper.CreateStaticGetAccessor<{property.Name}GetterDelegate>(WrappedType, nameof({property.Name}));");
                if (property.HasSetter)
                {
                    sb.AppendLine($"            {property.Name}SetterFunc = {helperPrefix}LightupHelper.CreateStaticSetAccessor<{property.Name}SetterDelegate>(WrappedType, nameof({property.Name}));");
                }
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                sb.AppendLine($"            {property.Name}GetterFunc = {helperPrefix}LightupHelper.CreateInstanceGetAccessor<{property.Name}GetterDelegate>(WrappedType, nameof({property.Name}));");
                if (property.HasSetter)
                {
                    sb.AppendLine($"            {property.Name}SetterFunc = {helperPrefix}LightupHelper.CreateInstanceSetAccessor<{property.Name}SetterDelegate>(WrappedType, nameof({property.Name}));");
                }
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                sb.AppendLine($"            {method.Name}Func{index} = {helperPrefix}LightupHelper.CreateStaticMethodAccessor<{method.Name}Delegate{index}>(WrappedType, {GetCreateMethodAccessorArguments(method)});");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                sb.AppendLine($"            {method.Name}Func{index} = {helperPrefix}LightupHelper.CreateInstanceMethodAccessor<{method.Name}Delegate{index}>(WrappedType, {GetCreateMethodAccessorArguments(method)});");
            }
        }
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        private {targetName}({baseTypeNamespace}.{baseTypeName}? obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            wrappedObject = obj;");
        sb.AppendLine($"        }}");
        foreach (var field in staticFields)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, field);
            sb.AppendLine($"        public static {GetFieldTypeDeclText(field, typeDefs)} {field.Name}");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            get => {field.Name}GetterFunc();");
            sb.AppendLine($"        }}");
            Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
        }
        foreach (var constructor in instanceConstructors)
        {
            var index = instanceConstructors.IndexOf(constructor);
            sb.AppendLine();
            AppendMemberSummary(sb, constructor);
            sb.AppendLine($"        public static {targetName} Create({GetParametersDeclText(constructor.Parameters, typeDefs)})");
            sb.AppendLine($"            => ConstructorFunc{index}({GetArgumentsText(constructor.Parameters, null)});");
        }
        foreach (var property in staticProperties)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, property);
            sb.AppendLine($"        public static {GetPropertyTypeDeclText(property, typeDefs)} {property.Name}");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            get => {property.Name}GetterFunc();");
            if (property.HasSetter)
            {
                sb.AppendLine($"            set => {property.Name}SetterFunc(value);");
            }
            sb.AppendLine($"        }}");
        }
        foreach (var property in instanceProperties)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, property);
            sb.AppendLine($"        public readonly {GetPropertyTypeDeclText(property, typeDefs)} {property.Name}");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            get => {property.Name}GetterFunc(wrappedObject);");
            if (property.HasSetter)
            {
                sb.AppendLine($"            set => {property.Name}SetterFunc(wrappedObject, value);");
            }
            sb.AppendLine($"        }}");
        }
        if (hasBaseType)
        {
            sb.AppendLine();
            sb.AppendLine($"        /// <summary>Returns the wrapped object.</summary>");
            sb.AppendLine($"        public static implicit operator {baseTypeNamespace}.{baseTypeName}?({targetName} obj)");
            sb.AppendLine($"            => obj.Unwrap();");
        }
        sb.AppendLine();
        sb.AppendLine($"        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>");
        sb.AppendLine($"        public static bool Is(System.Object? obj)");
        sb.AppendLine($"            => {helperPrefix}LightupHelper.Is(obj, WrappedType);");
        sb.AppendLine();
        sb.AppendLine($"        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, null will be stored in the wrapper instead.</summary>");
        sb.AppendLine($"        public static {targetName} As(System.Object? obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            var obj2 = {helperPrefix}LightupHelper.As<{baseTypeNamespace}.{baseTypeName}>(obj, WrappedType);");
        sb.AppendLine($"            return new {targetName}(obj2);");
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        /// <summary>Returns the wrapped object.</summary>");
        sb.AppendLine($"        public {baseTypeNamespace}.{baseTypeName}? Unwrap()");
        sb.AppendLine($"            => wrappedObject;");
        foreach (var methodDef in staticMethods)
        {
            var index = staticMethods.IndexOf(methodDef);
            sb.AppendLine();
            AppendMemberSummary(sb, methodDef);
            sb.AppendLine($"        public static {GetMethodReturnTypeDeclText(methodDef, typeDefs)} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, typeDefs)})");
            sb.AppendLine($"            => {methodDef.Name}Func{index}({GetArgumentsText(methodDef.Parameters, null)});");
        }
        foreach (var methodDef in instanceMethods)
        {
            var index = instanceMethods.IndexOf(methodDef);
            sb.AppendLine();
            AppendMemberSummary(sb, methodDef);
            sb.AppendLine($"        public readonly {GetMethodReturnTypeDeclText(methodDef, typeDefs)} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, typeDefs)})");
            sb.AppendLine($"            => {methodDef.Name}Func{index}({GetArgumentsText(methodDef.Parameters, "wrappedObject")});");
        }
        sb.AppendLine($"    }}");
        AppendEnclosingTypesEnd(sb, typeDef.EnclosingTypeFullName, typeDefs);
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return source;
    }

    private static void AppendEnclosingTypesStart(
        StringBuilder sb,
        string? enclosingTypeFullName,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        if (enclosingTypeFullName != null)
        {
            var enclosingType = typeDefs[enclosingTypeFullName];
            AppendEnclosingTypesStart(sb, enclosingType.EnclosingTypeFullName, typeDefs);
            var typeKeyword = enclosingType.AssemblyVersion != null ? "struct" : "class";
            sb.AppendLine($"public partial {typeKeyword} {enclosingType.GeneratedName} {{");
        }
    }

    private static void AppendEnclosingTypesEnd(
        StringBuilder sb,
        string? enclosingTypeFullName,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        if (enclosingTypeFullName != null)
        {
            var enclosingType = typeDefs[enclosingTypeFullName];
            AppendEnclosingTypesEnd(sb, enclosingType.EnclosingTypeFullName, typeDefs);
            sb.AppendLine("}");
        }
    }

    private static string GenerateExtension(
        TypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs,
        string targetNamespace,
        string helperPrefix)
    {
        var targetName = typeDef.GeneratedName;

        var instanceConstructors = GetInstanceConstructors(typeDef);
        var staticFields = GetStaticFields(typeDef);
        var instanceFields = GetInstanceFields(typeDef);
        Assert.IsTrue(instanceFields.Count == 0, "Unexpected instance fields");
        var staticEvents = GetStaticEvents(typeDef);
        Assert.IsTrue(staticEvents.Count == 0, "Unexpected static events");
        var instanceEvents = GetInstanceEvents(typeDef);
        var staticProperties = GetStaticProperties(typeDef);
        var instanceProperties = GetInstanceProperties(typeDef);
        var indexers = GetIndexers(typeDef);
        Assert.IsTrue(indexers.Count == 0, "Unexpected indexers");
        var instanceMethods = GetInstanceMethods(typeDef);
        var staticMethods = GetStaticMethods(typeDef);

        var baseTypeName = typeDef.Name;
        var baseTypeNamespace = typeDef.Namespace;

        var sb = new StringBuilder();

        AppendCopyrightComment(sb);
        sb.AppendLine();
        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        AppendUsingStatements(sb);
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        AppendTypeSummary(sb, typeDef);
        sb.AppendLine($"    public static partial class {targetName}");
        sb.AppendLine($"    {{");
        sb.AppendLine($"        private const string WrappedTypeName = \"{typeDef.FullName}\";");
        if (staticFields.Count != 0)
        {
            sb.AppendLine();
            foreach (var field in staticFields)
            {
                AppendStaticFieldDelegateDeclarations(sb, field, typeDefs);
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                AppendInstanceConstructorDelegateDeclarations(sb, baseTypeName, constructor, index, typeDefs);
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                AppendStaticPropertyDelegateDeclarations(sb, property, typeDefs);
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                AppendInstancePropertyDelegateDeclarations(sb, property, baseTypeName, baseTypeNamespace, typeDefs);
            }
        }
        if (instanceEvents.Count != 0)
        {
            sb.AppendLine();
            foreach (var @event in instanceEvents)
            {
                AppendInstanceEventDelegateDeclarations(sb, @event, baseTypeName, baseTypeNamespace, typeDefs);
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                AppendStaticMethodDelegateDeclaration(sb, method, index, typeDefs);
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                AppendInstanceMethodDelegateDeclaration(sb, method, baseTypeName, baseTypeNamespace, index, typeDefs);
            }
        }
        if (staticFields.Count != 0)
        {
            sb.AppendLine();
            foreach (var field in staticFields)
            {
                sb.AppendLine($"        private static readonly {field.Name}GetterDelegate {field.Name}GetterFunc;");
                Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                sb.AppendLine($"        private static readonly ConstructorDelegate{index} ConstructorFunc{index};");
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                sb.AppendLine($"        private static readonly {property.Name}GetterDelegate {property.Name}GetterFunc;");
                if (property.HasSetter)
                {
                    sb.AppendLine($"        private static readonly {property.Name}SetterDelegate {property.Name}SetterFunc;");
                }
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                sb.AppendLine($"        private static readonly {property.Name}GetterDelegate {property.Name}GetterFunc;");
                if (property.HasSetter)
                {
                    sb.AppendLine($"        private static readonly {property.Name}SetterDelegate {property.Name}SetterFunc;");
                }
            }
        }
        if (instanceEvents.Count != 0)
        {
            sb.AppendLine();
            foreach (var @event in instanceEvents)
            {
                sb.AppendLine($"        private static readonly {@event.Name}AdderDelegate {@event.Name}AdderFunc;");
                sb.AppendLine($"        private static readonly {@event.Name}RemoverDelegate {@event.Name}RemoverFunc;");
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                sb.AppendLine($"        private static readonly {method.Name}Delegate{index} {method.Name}Func{index};");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                sb.AppendLine($"        private static readonly {method.Name}Delegate{index} {method.Name}Func{index};");
            }
        }
        sb.AppendLine();
        sb.AppendLine($"        static {targetName}()");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            var wrappedType = {helperPrefix}LightupHelper.FindType(WrappedTypeName);");
        if (staticFields.Count != 0)
        {
            sb.AppendLine();
            foreach (var field in staticFields)
            {
                sb.AppendLine($"            {field.Name}GetterFunc = {helperPrefix}LightupHelper.CreateStaticReadAccessor<{field.Name}GetterDelegate>(wrappedType, nameof({field.Name}));");
                Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                sb.AppendLine($"            ConstructorFunc{index} = {helperPrefix}LightupHelper.CreateInstanceConstructorAccessor<ConstructorDelegate{index}>(wrappedType{GetCreateConstructorAccessorArguments(constructor)});");
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                sb.AppendLine($"            {property.Name}GetterFunc = {helperPrefix}LightupHelper.CreateStaticGetAccessor<{property.Name}GetterDelegate>(wrappedType, nameof({property.Name}));");
                if (property.HasSetter)
                {
                    sb.AppendLine($"            {property.Name}SetterFunc = {helperPrefix}LightupHelper.CreateStaticSetAccessor<{property.Name}SetterDelegate>(wrappedType, nameof({property.Name}));");
                }
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                sb.AppendLine($"            {property.Name}GetterFunc = {helperPrefix}LightupHelper.CreateInstanceGetAccessor<{property.Name}GetterDelegate>(wrappedType, nameof({property.Name}));");
                if (property.HasSetter)
                {
                    sb.AppendLine($"            {property.Name}SetterFunc = {helperPrefix}LightupHelper.CreateInstanceSetAccessor<{property.Name}SetterDelegate>(wrappedType, nameof({property.Name}));");
                }
            }
        }
        if (instanceEvents.Count != 0)
        {
            sb.AppendLine();
            foreach (var @event in instanceEvents)
            {
                sb.AppendLine($"            {@event.Name}AdderFunc = {helperPrefix}LightupHelper.CreateInstanceAddAccessor<{@event.Name}AdderDelegate>(wrappedType, \"{@event.Name}\");");
                sb.AppendLine($"            {@event.Name}RemoverFunc = {helperPrefix}LightupHelper.CreateInstanceRemoveAccessor<{@event.Name}RemoverDelegate>(wrappedType, \"{@event.Name}\");");
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                sb.AppendLine($"            {method.Name}Func{index} = {helperPrefix}LightupHelper.CreateStaticMethodAccessor<{method.Name}Delegate{index}>(wrappedType, {GetCreateMethodAccessorArguments(method)});");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                sb.AppendLine($"            {method.Name}Func{index} = {helperPrefix}LightupHelper.CreateInstanceMethodAccessor<{method.Name}Delegate{index}>(wrappedType, {GetCreateMethodAccessorArguments(method)});");
            }
        }
        sb.AppendLine($"        }}");
        foreach (var field in staticFields)
        {
            Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
            sb.AppendLine();
            AppendMemberSummary(sb, field);
            sb.AppendLine($"        public static {GetFieldTypeDeclText(field, typeDefs)} {field.Name}");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            get => {field.Name}GetterFunc();");
            sb.AppendLine($"        }}");
        }
        foreach (var constructor in instanceConstructors)
        {
            var index = instanceConstructors.IndexOf(constructor);
            sb.AppendLine();
            AppendMemberSummary(sb, constructor);
            sb.AppendLine($"        public static {baseTypeName} Create({GetParametersDeclText(constructor.Parameters, typeDefs)})");
            sb.AppendLine($"            => ConstructorFunc{index}({GetArgumentsText(constructor.Parameters, null)});");
        }
        foreach (var property in staticProperties)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, property);
            sb.AppendLine($"        public static {GetPropertyTypeDeclText(property, typeDefs)} {property.Name}()");
            sb.AppendLine($"            => {property.Name}GetterFunc();");
            if (property.HasSetter)
            {
                sb.AppendLine();
                AppendMemberSummary(sb, property);
                sb.AppendLine($"        public static void Set{property.Name}({GetPropertyTypeDeclText(property, typeDefs)} _value)");
                sb.AppendLine($"            => {property.Name}SetterFunc(_value);");
            }
        }
        foreach (var property in instanceProperties)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, property);
            sb.AppendLine($"        public static {GetPropertyTypeDeclText(property, typeDefs)} {property.Name}(this {typeDef.Namespace}.{typeDef.Name} _obj)");
            sb.AppendLine($"            => {property.Name}GetterFunc(_obj);");
            if (property.HasSetter)
            {
                sb.AppendLine();
                AppendMemberSummary(sb, property);
                sb.AppendLine($"        public static void Set{property.Name}(this {typeDef.Namespace}.{typeDef.Name} _obj, {GetPropertyTypeDeclText(property, typeDefs)} _value)");
                sb.AppendLine($"            => {property.Name}SetterFunc(_obj, _value);");
            }
        }
        foreach (var @event in instanceEvents)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, @event);
            sb.AppendLine($"        public static void Add{@event.Name}(this {typeDef.Namespace}.{typeDef.Name} _obj, {GetEventTypeDeclText(@event, typeDefs)} _delegate)");
            sb.AppendLine($"            => {@event.Name}AdderFunc(_obj, _delegate);");
            sb.AppendLine();
            AppendMemberSummary(sb, @event);
            sb.AppendLine($"        public static void Remove{@event.Name}(this {typeDef.Namespace}.{typeDef.Name} _obj, {GetEventTypeDeclText(@event, typeDefs)} _delegate)");
            sb.AppendLine($"            => {@event.Name}RemoverFunc(_obj, _delegate);");
        }
        foreach (var methodDef in staticMethods)
        {
            var index = staticMethods.IndexOf(methodDef);
            sb.AppendLine();
            AppendMemberSummary(sb, methodDef);
            sb.AppendLine($"        public static {GetMethodReturnTypeDeclText(methodDef, typeDefs)} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, typeDefs, isExtensionMethod: methodDef.IsExtensionMethod)})");
            sb.AppendLine($"            => {methodDef.Name}Func{index}({GetArgumentsText(methodDef.Parameters, null)});");
        }
        foreach (var methodDef in instanceMethods)
        {
            var index = instanceMethods.IndexOf(methodDef);
            sb.AppendLine();
            AppendMemberSummary(sb, methodDef);
            sb.AppendLine($"        public static {GetMethodReturnTypeDeclText(methodDef, typeDefs)} {methodDef.Name}(this {typeDef.Namespace}.{typeDef.Name} _obj{GetParametersDeclText(methodDef.Parameters, typeDefs, true)})");
            sb.AppendLine($"            => {methodDef.Name}Func{index}({GetArgumentsText(methodDef.Parameters, "_obj")});");
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return source;
    }

    private static (string? Name, string? Namespace) GetBaseTypeName(TypeDefinition typeDef)
    {
        return typeDef switch
        {
            ClassTypeDefinition x => GetBaseTypeName(x),
            InterfaceTypeDefinition x => GetBaseTypeName(x),
            StructTypeDefinition => (null, null),
            _ => throw new NotImplementedException(),
        };
    }

    private static (string? Name, string? Namespace) GetBaseTypeName(
        ClassTypeDefinition typeDef)
    {
        var baseTypeRef = typeDef.BaseClass;
        if (baseTypeRef == null)
        {
            return (null, null);
        }

        if (baseTypeRef is NamedTypeReference x)
        {
            return (x.Name, x.Namespace);
        }

        Assert.Fail("Could not get base type");
        return (null, null);
    }

    private static (string? Name, string? Namespace) GetBaseTypeName(
        InterfaceTypeDefinition typeDef)
    {
        var baseTypeRef = typeDef.BaseInterface;
        if (baseTypeRef == null)
        {
            return (null, null);
        }

        if (baseTypeRef is NamedTypeReference x)
        {
            return (x.Name, x.Namespace);
        }

        Assert.Fail("Could not get base type");
        return (null, null);
    }

    private static List<ConstructorDefinition> GetInstanceConstructors(TypeDefinition typeDef)
    {
        if (typeDef is ClassTypeDefinition classTypeDef && classTypeDef.IsAbstract)
        {
            return [];
        }

        var result = typeDef.Constructors
            .Where(x => x.AssemblyVersion != null)
            .ToList();
        return result;
    }

    private static List<FieldDefinition> GetStaticFields(TypeDefinition typeDef)
    {
        var result = typeDef.Fields
            .Where(x => x.IsStatic)
            .Where(x => x.AssemblyVersion != null)
            .ToList();
        return result;
    }

    private static List<FieldDefinition> GetInstanceFields(TypeDefinition typeDef)
    {
        var result = typeDef.Fields
            .Where(x => !x.IsStatic)
            .Where(x => x.AssemblyVersion != null)
            .ToList();
        return result;
    }

    private static List<EventDefinition> GetStaticEvents(TypeDefinition typeDef)
    {
        var result = typeDef.Events
            .Where(x => x.IsStatic)
            .Where(x => x.AssemblyVersion != null)
            .ToList();
        return result;
    }

    private static List<EventDefinition> GetInstanceEvents(TypeDefinition typeDef)
    {
        var result = typeDef.Events
            .Where(x => !x.IsStatic)
            .Where(x => x.AssemblyVersion != null)
            .ToList();
        return result;
    }

    private static List<PropertyDefinition> GetStaticProperties(TypeDefinition typeDef)
    {
        var result = typeDef.Properties
            .Where(x => x.IsStatic)
            .Where(x => x.AssemblyVersion != null)
            .OrderBy(x => x.Name)
            .ToList();
        return result;
    }

    private static List<PropertyDefinition> GetInstanceProperties(TypeDefinition typeDef)
    {
        var result = typeDef.Properties
            .Where(x => !x.IsStatic)
            .Where(x => x.AssemblyVersion != null)
            .OrderBy(x => x.Name)
            .ToList();
        return result;
    }

    private static List<IndexerDefinition> GetIndexers(TypeDefinition typeDef)
    {
        var result = typeDef.Indexers
            .Where(x => x.AssemblyVersion != null)
            .ToList();
        return result;
    }

    private static List<MethodDefinition> GetStaticMethods(TypeDefinition typeDef)
    {
        var result = typeDef.Methods
            .Where(x => x.IsStatic)
            .Where(x => x.AssemblyVersion != null)
            .OrderBy(x => x.Name).ThenBy(x => x.Parameters.Count)
            .ToList();
        return result;
    }

    private static List<MethodDefinition> GetInstanceMethods(TypeDefinition typeDef)
    {
        var result = typeDef.Methods
            .Where(x => !x.IsStatic)
            .Where(x => x.AssemblyVersion != null)
            .OrderBy(x => x.Name).ThenBy(x => x.Parameters.Count)
            .ToList();
        return result;
    }

    private static void AppendCopyrightComment(StringBuilder sb)
    {
        sb.AppendLine("// Copyright © Björn Hellander 2024");
        sb.AppendLine("// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.");
    }

    private static void AppendUsingStatements(StringBuilder sb)
    {
        sb.AppendLine($"using Microsoft.CodeAnalysis.Lightup;");
    }

    private static void AppendTypeSummary(StringBuilder sb, BaseTypeDefinition typeDef)
    {
        var kind = typeDef switch
        {
            EnumTypeDefinition => "enum",
            ClassTypeDefinition => "class",
            InterfaceTypeDefinition => "interface",
            StructTypeDefinition => "struct",
            _ => throw new NotImplementedException(),
        };
        var part1 = $"Provides lightup support for {kind} {typeDef.FullName}.";
        var part2 = typeDef.AssemblyVersion != null ? $" Added in version {typeDef.AssemblyVersion}." : "";
        sb.AppendLine($"    /// <summary>{part1}{part2}</summary>");
    }

    private static void AppendEnumValueSummary(StringBuilder sb, EnumValueDefinition valueDef)
    {
        Assert.IsTrue(valueDef.AssemblyVersion != null, "Unexpected assembly version");
        sb.AppendLine($"        /// <summary>Added in version {valueDef.AssemblyVersion}.</summary>");
    }

    private static void AppendMemberSummary(StringBuilder sb, MemberDefinition memberDef)
    {
        Assert.IsTrue(memberDef.AssemblyVersion != null, "Unexpected assembly version");
        string kind = memberDef switch
        {
            FieldDefinition => "Field",
            ConstructorDefinition => "Constructor",
            PropertyDefinition => "Property",
            EventDefinition => "Event",
            MethodDefinition => "Method",
            _ => throw new NotImplementedException(),
        };
        sb.AppendLine($"        /// <summary>{kind} added in version {memberDef.AssemblyVersion}.</summary>");
    }

    private static void AppendStaticFieldDelegateDeclarations(
        StringBuilder sb,
        FieldDefinition fieldDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetFieldTypeDeclText(fieldDef, typeDefs));
        sb.AppendLine($" {fieldDef.Name}GetterDelegate();");

        Assert.IsTrue(fieldDef.IsReadOnly, "Unexpected non-readonly static field");
    }

    private static string GetFieldTypeDeclText(
        FieldDefinition fieldDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        AppendTypeDeclText(sb, fieldDef.Type, typeDefs);
        sb.Append(fieldDef.IsNullable && !IsNewType(fieldDef.Type, typeDefs) ? "?" : "");
        var result = sb.ToString();
        return result;
    }

    private static void AppendInstanceConstructorDelegateDeclarations(
        StringBuilder sb,
        string targetName,
        ConstructorDefinition constructorDef,
        int index,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate {targetName}");
        sb.Append($" ConstructorDelegate{index}(");
        sb.Append(GetParametersDeclText(constructorDef.Parameters, typeDefs));
        sb.AppendLine($");");
    }

    private static void AppendStaticPropertyDelegateDeclarations(
        StringBuilder sb,
        PropertyDefinition propertyDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetPropertyTypeDeclText(propertyDef, typeDefs));
        sb.AppendLine($" {propertyDef.Name}GetterDelegate();");

        if (propertyDef.HasSetter)
        {
            sb.Append($"        private delegate void ");
            sb.Append($"{propertyDef.Name}SetterDelegate(");
            sb.AppendLine($"{GetPropertyTypeDeclText(propertyDef, typeDefs)} _value);");
        }
    }

    private static void AppendInstancePropertyDelegateDeclarations(
        StringBuilder sb,
        PropertyDefinition propertyDef,
        string baseTypeName,
        string baseTypeNamespace,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetPropertyTypeDeclText(propertyDef, typeDefs));
        sb.AppendLine($" {propertyDef.Name}GetterDelegate({baseTypeNamespace}.{baseTypeName}? _obj);");

        if (propertyDef.HasSetter)
        {
            sb.Append($"        private delegate void ");
            sb.Append($"{propertyDef.Name}SetterDelegate({baseTypeNamespace}.{baseTypeName}? _obj, ");
            sb.AppendLine($"{GetPropertyTypeDeclText(propertyDef, typeDefs)} _value);");
        }
    }

    private static string GetPropertyTypeDeclText(
        PropertyDefinition propertyDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        AppendTypeDeclText(sb, propertyDef.Type, typeDefs);
        sb.Append(propertyDef.IsNullable && !IsNewType(propertyDef.Type, typeDefs) ? "?" : "");
        var result = sb.ToString();
        return result;
    }

    private static void AppendInstanceEventDelegateDeclarations(
        StringBuilder sb,
        EventDefinition propertyDef,
        string baseTypeName,
        string baseTypeNamespace,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate void");
        sb.AppendLine($" {propertyDef.Name}AdderDelegate({baseTypeNamespace}.{baseTypeName} _obj, {GetEventTypeDeclText(propertyDef, typeDefs)} _delegate);");

        sb.Append($"        private delegate void");
        sb.AppendLine($" {propertyDef.Name}RemoverDelegate({baseTypeNamespace}.{baseTypeName} _obj, {GetEventTypeDeclText(propertyDef, typeDefs)} _delegate);");
    }

    private static string GetEventTypeDeclText(
        EventDefinition eventDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        AppendTypeDeclText(sb, eventDef.Type, typeDefs);
        var result = sb.ToString();
        return result;
    }

    private static void AppendStaticMethodDelegateDeclaration(
        StringBuilder sb,
        MethodDefinition methodDef,
        int index,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetMethodReturnTypeDeclText(methodDef, typeDefs));
        sb.Append($" {methodDef.Name}Delegate{index}(");
        sb.Append(GetParametersDeclText(methodDef.Parameters, typeDefs, addLeadingComma: false));
        sb.AppendLine(");");
    }

    private static void AppendInstanceMethodDelegateDeclaration(
        StringBuilder sb,
        MethodDefinition methodDef,
        string baseTypeName,
        string baseTypeNamespace,
        int index,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetMethodReturnTypeDeclText(methodDef, typeDefs));
        sb.Append($" {methodDef.Name}Delegate{index}({baseTypeNamespace}.{baseTypeName}? _obj");
        sb.Append(GetParametersDeclText(methodDef.Parameters, typeDefs, addLeadingComma: true));
        sb.AppendLine(");");
    }

    private static string GetMethodReturnTypeDeclText(
        MethodDefinition methodDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        if (methodDef.ReturnType != null)
        {
            AppendTypeDeclText(sb, methodDef.ReturnType, typeDefs);
            sb.Append(methodDef.IsNullable && !IsNewType(methodDef.ReturnType, typeDefs) ? "?" : "");
        }
        else
        {
            sb.Append("void");
        }
        var result = sb.ToString();
        return result;
    }

    private static string GetParametersDeclText(
        IEnumerable<ParameterDefinition> parameters,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs,
        bool addLeadingComma = false,
        bool isExtensionMethod = false)
    {
        var sb = new StringBuilder();

        foreach (var parameter in parameters)
        {
            sb.Append(sb.Length > 0 || addLeadingComma ? ", " : "");
            sb.Append(isExtensionMethod ? "this " : "");
            sb.Append(parameter.IsParams ? "params " : "");
            sb.Append(ParameterModeText[parameter.Mode]);
            sb.Append(GetParameterTypeDeclText(parameter, typeDefs));
            sb.Append(' ');
            sb.Append(GetParameterNameText(parameter.Name));

            isExtensionMethod = false;
        }

        var result = sb.ToString();
        return result;
    }

    private static string GetParameterTypeDeclText(
        ParameterDefinition parameterDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        AppendTypeDeclText(sb, parameterDef.Type, typeDefs);
        sb.Append(parameterDef.IsNullable && !IsNewType(parameterDef.Type, typeDefs) ? "?" : "");
        var result = sb.ToString();
        return result;
    }

    private static string GetArgumentsText(
        List<ParameterDefinition> parameterDefs,
        string? instanceName)
    {
        var sb = new StringBuilder();

        var isFirst = true;
        if (instanceName != null)
        {
            sb.Append(instanceName);
            isFirst = false;
        }

        foreach (var parameterDef in parameterDefs)
        {
            sb.Append(isFirst ? "" : ", ");
            sb.Append(ParameterModeText[parameterDef.Mode]);
            sb.Append(GetParameterNameText(parameterDef.Name));

            isFirst = false;
        }
        var result = sb.ToString();
        return result;
    }

    private static string GetParameterNameText(string name)
    {
        if (name == "object")
        {
            return "@object";
        }
        else if (name == "else")
        {
            return "@else";
        }
        else if (name == "finally")
        {
            return "@finally";
        }
        else
        {
            return name;
        }
    }

    private static void AppendTypeDeclText(
        StringBuilder sb,
        TypeReference typeRef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        if (typeRef is GenericTypeReference genericTypeRef)
        {
            if (IsSeparatedSyntaxList(genericTypeRef) && IsNewType(genericTypeRef.TypeArguments[0], typeDefs))
            {
                sb.Append("Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper");
            }
            else
            {
                AppendTypeDeclText(sb, genericTypeRef.OriginalType, typeDefs);
            }

            sb.Append("<");
            for (var i = 0; i < genericTypeRef.TypeArguments.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                AppendTypeDeclText(sb, genericTypeRef.TypeArguments[i], typeDefs);
            }
            sb.Append('>');
        }
        else if (typeRef is ArrayTypeReference arrayTypeRef)
        {
            AppendTypeDeclText(sb, arrayTypeRef.ElementType, typeDefs);
            sb.Append("[]");
        }
        else if (typeRef is NamedTypeReference namedTypeRef)
        {
            var isNew = IsNewType(namedTypeRef, typeDefs);
            var isNewEnum = isNew && IsEnumType(namedTypeRef, typeDefs);
            sb.Append($"{namedTypeRef.Namespace}");
            sb.Append($"{(isNew ? ".Lightup" : "")}");
            AppendEnclosingType(sb, namedTypeRef, isNew, typeDefs);
            sb.Append($".{namedTypeRef.Name}");
            sb.Append($"{(isNewEnum ? "Ex" : isNew ? "Wrapper" : "")}");
        }
    }

    private static void AppendEnclosingType(
        StringBuilder sb,
        NamedTypeReference namedTypeRef,
        bool isNew,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        if (typeDefs.TryGetValue(namedTypeRef.FullName!, out var typeDef))
        {
            AppendEnclosingType(sb, typeDef.EnclosingTypeFullName, isNew, typeDefs);
        }
    }

    private static void AppendEnclosingType(
        StringBuilder sb,
        string? enclosingTypeFullName,
        bool isNew,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        if (enclosingTypeFullName != null)
        {
            var enclosingType = typeDefs[enclosingTypeFullName];
            AppendEnclosingType(sb, enclosingType.EnclosingTypeFullName, isNew, typeDefs);

            sb.Append(".");
            sb.Append(isNew ? enclosingType.GeneratedName : enclosingType.Name);
        }
    }

    private static string GetCreateConstructorAccessorArguments(ConstructorDefinition methodDef)
    {
        var sb = new StringBuilder();

        foreach (var parameterDef in methodDef.Parameters)
        {
            Assert.IsTrue(parameterDef.Mode == ParameterMode.None, "Unexpected parameter mode");
            sb.Append($", \"{parameterDef.Name}{parameterDef.Type.NativeName}\"");
        }

        return sb.ToString();
    }

    private static string GetCreateMethodAccessorArguments(MethodDefinition methodDef)
    {
        var sb = new StringBuilder();

        sb.Append($"\"{methodDef.Name}\"");
        foreach (var parameterDef in methodDef.Parameters)
        {
            sb.Append($", \"{parameterDef.Name}{parameterDef.Type.NativeName}{(parameterDef.Mode != ParameterMode.None ? "&" : "")}\"");
        }

        return sb.ToString();
    }

    private static bool IsSeparatedSyntaxList(GenericTypeReference genericTypeRef)
    {
        if (genericTypeRef.OriginalType is not NamedTypeReference namedTypeRef)
        {
            return false;
        }

        if (namedTypeRef.Name != "SeparatedSyntaxList")
        {
            return false;
        }

        return true;
    }

    private static string GetTargetFolder(BaseTypeDefinition typeDef)
    {
        var sourceNamespace = typeDef.Namespace!;
        var targetFolder = sourceNamespace.Replace("Microsoft.CodeAnalysis", "").TrimStart('.').Replace('.', Path.DirectorySeparatorChar);
        return targetFolder;
    }

    private static bool IsNewType(TypeReference typeRef, IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        if (typeRef is not NamedTypeReference namedTypeRef)
        {
            return false;
        }

        return typeDefs.TryGetValue(namedTypeRef.FullName!, out var typeDef) && typeDef.AssemblyVersion != null;
    }

    private static bool IsEnumType(TypeReference typeRef, IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        if (typeRef is not NamedTypeReference namedTypeRef)
        {
            return false;
        }

        return typeDefs.TryGetValue(namedTypeRef.FullName!, out var typeDef) && typeDef is EnumTypeDefinition;
    }
}
