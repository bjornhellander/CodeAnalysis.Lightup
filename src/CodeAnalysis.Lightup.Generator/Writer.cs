// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

// Fixed in StyleCop.Analyzes, but not yet released
#pragma warning disable SA1513 // Closing brace should be followed by blank line
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line

namespace CodeAnalysis.Lightup.Generator;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeAnalysis.Lightup.Definitions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

internal class Writer
{
    private static readonly Dictionary<AssemblyKind, string> HelperPrefixes = new()
    {
        [AssemblyKind.Common] = "Common",
        [AssemblyKind.CSharp] = "CSharp",
        [AssemblyKind.WorkspacesCommon] = "WorkspacesCommon",
        [AssemblyKind.CSharpWorkspaces] = "CSharpWorkspaces",
    };

    private static readonly Dictionary<AssemblyKind, string> ExampleTypeNames = new()
    {
        [AssemblyKind.Common] = "Microsoft.CodeAnalysis.IOperation",
        [AssemblyKind.CSharp] = "Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax",
        [AssemblyKind.WorkspacesCommon] = "Microsoft.CodeAnalysis.WorkspaceChangeKind",
        [AssemblyKind.CSharpWorkspaces] = "Microsoft.CodeAnalysis.CSharp.Formatting.CSharpFormattingOptions",
    };

    private static readonly Dictionary<ParameterMode, string> ParameterModeText = new()
    {
        [ParameterMode.None] = "",
        [ParameterMode.In] = "", // NOTE: Avoidig 'in' to make the code compatible with c# 6
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
        "Microsoft.CodeAnalysis.GeneratorFilterContext",

        // Irrelevant new types related to diagnostic suppressors
        "Microsoft.CodeAnalysis.Diagnostics.DiagnosticSuppressor",
        "Microsoft.CodeAnalysis.Diagnostics.Suppression",
        "Microsoft.CodeAnalysis.Diagnostics.SuppressionAnalysisContext",
        "Microsoft.CodeAnalysis.SuppressionDescriptor",
        "Microsoft.CodeAnalysis.Diagnostics.SuppressionInfo",

        // TODO: Investigate if these updated types should be generated
        "Microsoft.CodeAnalysis.Diagnostics.AnalyzerFileReference", // References ISourceGenerator
        "Microsoft.CodeAnalysis.Diagnostics.AnalyzerReference", // References ISourceGenerator
    ];

    internal static void Write(
        SourceProductionContext context,
        IReadOnlyList<AssemblyKind> assemblyKinds,
        List<string> typesToInclude,
        bool useNullableContext,
        bool useFoldersInFilePaths,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var nullableAnnotation = useNullableContext ? "?" : "";

        foreach (var assemblyKind in assemblyKinds)
        {
            WriterLightupHelper(context, assemblyKind, nullableAnnotation);

            if (assemblyKind == AssemblyKind.CSharp)
            {
                WriteSeparatedSyntaxListWrapper(context, nullableAnnotation);
            }

            Write(context, assemblyKind, typesToInclude, nullableAnnotation, useFoldersInFilePaths, typeDefs);
        }
    }

    private static void WriterLightupHelper(SourceProductionContext context, AssemblyKind assemblyKind, string nullableAnnotation)
    {
        var na = nullableAnnotation;

        var name = $"{HelperPrefixes[assemblyKind]}LightupHelper";

        var source = $@"
// <auto-generated/>
{(nullableAnnotation != "" ? "#nullable enable" : "")}

namespace Microsoft.CodeAnalysis.Lightup
{{
    internal class {name} : global::CodeAnalysis.Lightup.Runtime.LightupHelper
    {{
        private static readonly global::System.Reflection.Assembly Assembly = typeof(global::{ExampleTypeNames[assemblyKind]}).Assembly;

        public static global::System.Type{na} FindType(string wrappedTypeName)
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
    private static void WriteSeparatedSyntaxListWrapper(SourceProductionContext context, string nullableAnnotation)
    {
        var na = nullableAnnotation;

        // TODO: Check if the implicit conversion members can be added and implemented
        // TODO: Implement remaining members
        var source = $@"
// <auto-generated/>
#pragma warning disable CS1591
{(nullableAnnotation != "" ? "#nullable enable" : "")}

namespace Microsoft.CodeAnalysis.Lightup
{{
    public struct SeparatedSyntaxListWrapper<TNode>
        where TNode : struct
    {{
        private static readonly global::System.Type{na} WrappedType;

        private delegate int CountDelegate(object obj);
        private delegate int SeparatorCountDelegate(object obj);
        private delegate global::Microsoft.CodeAnalysis.Text.TextSpan FullSpanDelegate(object obj);
        private delegate global::Microsoft.CodeAnalysis.Text.TextSpan SpanDelegate(object obj);
        private delegate TNode IndexerDelegate(object obj, int index);
        private delegate global::Microsoft.CodeAnalysis.SyntaxToken GetSeparatorDelegate(object obj, int index);
        private delegate global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.SyntaxToken> GetSeparatorsDelegate(object obj);
        private delegate string ToStringDelegate(object obj);
        private delegate TNode FirstDelegate(object obj);
        private delegate TNode? FirstOrDefaultDelegate(object obj);
        private delegate TNode LastDelegate(object obj);
        private delegate TNode? LastOrDefaultDelegate(object obj);
        private delegate bool ContainsDelegate(object obj, TNode node);
        private delegate int IndexOfNodeDelegate(object obj, TNode node);
        private delegate int IndexOfPredicateDelegate(object obj, global::System.Func<TNode, bool> predicate);
        private delegate int LastIndexOfNodeDelegate(object obj, TNode node);
        private delegate int LastIndexOfPredicateDelegate(object obj, global::System.Func<TNode, bool> predicate);
        private delegate bool AnyDelegate(object obj);
        private delegate SyntaxNodeOrTokenList GetWithSeparatorsDelegate(object obj);
        private delegate SeparatedSyntaxListWrapper<TNode> AddDelegate(object obj, TNode node);
        private delegate SeparatedSyntaxListWrapper<TNode> AddRangeDelegate(object obj, global::System.Collections.Generic.IEnumerable<TNode> arg1);
        private delegate SeparatedSyntaxListWrapper<TNode> InsertDelegate(object obj, int index, TNode node);
        private delegate SeparatedSyntaxListWrapper<TNode> InsertRangeDelegate(object obj, int index, global::System.Collections.Generic.IEnumerable<TNode> arg1);
        private delegate SeparatedSyntaxListWrapper<TNode> RemoveAtDelegate(object obj, int index);
        private delegate SeparatedSyntaxListWrapper<TNode> RemoveDelegate(object obj, TNode node);
        private delegate SeparatedSyntaxListWrapper<TNode> ReplaceDelegate(object obj, TNode nodeInList, TNode newNode);
        private delegate SeparatedSyntaxListWrapper<TNode> ReplaceRangeDelegate(object obj, TNode nodeInList, global::System.Collections.Generic.IEnumerable<TNode> newNodes);
        private delegate SeparatedSyntaxListWrapper<TNode> ReplaceSeparatorDelegate(object obj, global::Microsoft.CodeAnalysis.SyntaxToken separatorToken, global::Microsoft.CodeAnalysis.SyntaxToken newSeparator);

        private static readonly CountDelegate CountAccessor;
        private static readonly SeparatorCountDelegate SeparatorCountAccessor;
        private static readonly FullSpanDelegate FullSpanAccessor;
        private static readonly SpanDelegate SpanAccessor;
        private static readonly IndexerDelegate IndexerAccessor;
        private static readonly GetSeparatorDelegate GetSeparatorAccessor;
        private static readonly GetSeparatorsDelegate GetSeparatorsAccessor;
        private static readonly ToStringDelegate ToStringAccessor;
        private static readonly FirstDelegate FirstAccessor;
        private static readonly FirstOrDefaultDelegate FirstOrDefaultAccessor;
        private static readonly LastDelegate LastAccessor;
        private static readonly LastOrDefaultDelegate LastOrDefaultAccessor;
        private static readonly ContainsDelegate ContainsAccessor;
        private static readonly IndexOfNodeDelegate IndexOfNodeAccessor;
        private static readonly IndexOfPredicateDelegate IndexOfPredicateAccessor;
        private static readonly LastIndexOfNodeDelegate LastIndexOfNodeAccessor;
        private static readonly LastIndexOfPredicateDelegate LastIndexOfPredicateAccessor;
        private static readonly AnyDelegate AnyAccessor;
        private static readonly GetWithSeparatorsDelegate GetWithSeparatorsAccessor;
        private static readonly AddDelegate AddAccessor;
        private static readonly AddRangeDelegate AddRangeAccessor;
        private static readonly InsertDelegate InsertAccessor;
        private static readonly InsertRangeDelegate InsertRangeAccessor;
        private static readonly RemoveAtDelegate RemoveAtAccessor;
        private static readonly RemoveDelegate RemoveAccessor;
        private static readonly ReplaceDelegate ReplaceAccessor;
        private static readonly ReplaceRangeDelegate ReplaceRangeAccessor;
        private static readonly ReplaceSeparatorDelegate ReplaceSeparatorAccessor;

        private readonly object wrappedObject;

        static SeparatedSyntaxListWrapper()
        {{
            var wrapperNodeType = typeof(TNode);
            var wrappedNodeTypeField = wrapperNodeType.GetField(""WrappedType"", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.NonPublic);
            var wrappedNodeType = (global::System.Type)wrappedNodeTypeField.GetValue(null);
            var wrappedNodeTypeName = wrappedNodeType?.Name;
            WrappedType = wrappedNodeType != null ? typeof(SeparatedSyntaxList<>).MakeGenericType(wrappedNodeType) : null;

            CountAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<CountDelegate>(WrappedType, nameof(Count));
            SeparatorCountAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<SeparatorCountDelegate>(WrappedType, nameof(SeparatorCount));
            FullSpanAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<FullSpanDelegate>(WrappedType, nameof(FullSpan));
            SpanAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceGetAccessor<SpanDelegate>(WrappedType, nameof(Span));
            IndexerAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<IndexerDelegate>(WrappedType, ""get_Item"", ""indexInt32"");
            GetSeparatorAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<GetSeparatorDelegate>(WrappedType, nameof(GetSeparator), ""indexInt32"");
            GetSeparatorsAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<GetSeparatorsDelegate>(WrappedType, nameof(GetSeparators));
            ToStringAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<ToStringDelegate>(WrappedType, nameof(ToString));
            FirstAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<FirstDelegate>(WrappedType, nameof(First));
            FirstOrDefaultAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<FirstOrDefaultDelegate>(WrappedType, nameof(FirstOrDefault));
            LastAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<LastDelegate>(WrappedType, nameof(Last));
            LastOrDefaultAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<LastOrDefaultDelegate>(WrappedType, nameof(LastOrDefault));
            ContainsAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<ContainsDelegate>(WrappedType, nameof(Contains), ""node"" + wrappedNodeTypeName);
            IndexOfNodeAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<IndexOfNodeDelegate>(WrappedType, nameof(IndexOf), ""node"" + wrappedNodeTypeName);
            IndexOfPredicateAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<IndexOfPredicateDelegate>(WrappedType, nameof(IndexOf), ""predicateFunc`2"");
            LastIndexOfNodeAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<LastIndexOfNodeDelegate>(WrappedType, nameof(LastIndexOf), ""node"" + wrappedNodeTypeName);
            LastIndexOfPredicateAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<LastIndexOfPredicateDelegate>(WrappedType, nameof(LastIndexOf), ""predicateFunc`2"");
            AnyAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AnyDelegate>(WrappedType, nameof(Any));
            GetWithSeparatorsAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<GetWithSeparatorsDelegate>(WrappedType, nameof(GetWithSeparators));
            AddAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddDelegate>(WrappedType, nameof(Add), ""node"" + wrappedNodeTypeName);
            AddRangeAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<AddRangeDelegate>(WrappedType, nameof(AddRange), ""nodesIEnumerable`1"");
            InsertAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<InsertDelegate>(WrappedType, nameof(Insert), ""indexInt32"", ""node"" + wrappedNodeTypeName);
            InsertRangeAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<InsertRangeDelegate>(WrappedType, nameof(InsertRange), ""indexInt32"", ""nodesIEnumerable`1"");
            RemoveAtAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<RemoveAtDelegate>(WrappedType, nameof(RemoveAt), ""indexInt32"");
            RemoveAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<RemoveDelegate>(WrappedType, nameof(Remove), ""node"" + wrappedNodeTypeName);
            ReplaceAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<ReplaceDelegate>(WrappedType, nameof(Replace), ""nodeInList"" + wrappedNodeTypeName, ""newNode"" + wrappedNodeTypeName);
            ReplaceRangeAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<ReplaceRangeDelegate>(WrappedType, nameof(ReplaceRange), ""nodeInList"" + wrappedNodeTypeName, ""newNodesIEnumerable`1"");
            ReplaceSeparatorAccessor = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.CreateInstanceMethodAccessor<ReplaceSeparatorDelegate>(WrappedType, nameof(ReplaceSeparator), ""separatorTokenSyntaxToken"", ""newSeparatorSyntaxToken"");
        }}

        private SeparatedSyntaxListWrapper(object obj)
        {{
            wrappedObject = obj;
        }}

        public int Count
        {{
            get {{ return CountAccessor(wrappedObject); }}
        }}

        public int SeparatorCount
        {{
            get {{ return SeparatorCountAccessor(wrappedObject); }}
        }}

        public global::Microsoft.CodeAnalysis.Text.TextSpan FullSpan
        {{
            get {{ return FullSpanAccessor(wrappedObject); }}
        }}

        public global::Microsoft.CodeAnalysis.Text.TextSpan Span
        {{
            get {{ return SpanAccessor(wrappedObject); }}
        }}

        public TNode this[int index]
        {{
             get {{ return IndexerAccessor(wrappedObject, index); }}
        }}

        //public static implicit operator SeparatedSyntaxListWrapper<SyntaxNode>(SeparatedSyntaxListWrapper<TNode> nodes)
        //{{
        //     throw new global::System.NotImplementedException();
        //}}

        //public static implicit operator SeparatedSyntaxListWrapper<TNode>(SeparatedSyntaxListWrapper<SyntaxNode> nodes)
        //{{
        //     throw new global::System.NotImplementedException();
        //}}

        public static bool Is(object{na} obj)
        {{
            return global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Is(obj, WrappedType);
        }}

        public static SeparatedSyntaxListWrapper<TNode> Wrap(object obj)
        {{
            var obj2 = global::Microsoft.CodeAnalysis.Lightup.CSharpLightupHelper.Wrap<object>(obj, WrappedType);
            return new SeparatedSyntaxListWrapper<TNode>(obj2);
        }}

        public object Unwrap()
        {{
             return wrappedObject;
        }}

        public global::Microsoft.CodeAnalysis.SyntaxToken GetSeparator(int index)
        {{
             return GetSeparatorAccessor(wrappedObject, index);
        }}

        public global::System.Collections.Generic.IEnumerable<global::Microsoft.CodeAnalysis.SyntaxToken> GetSeparators()
        {{
             return GetSeparatorsAccessor(wrappedObject);
        }}

        public override string ToString()
        {{
             return ToStringAccessor(wrappedObject);
        }}

        public string ToFullString()
        {{
             throw new global::System.NotImplementedException();
        }}

        public TNode First()
        {{
             return FirstAccessor(wrappedObject);
        }}

        public TNode? FirstOrDefault()
        {{
             return FirstOrDefaultAccessor(wrappedObject);
        }}

        public TNode Last()
        {{
             return LastAccessor(wrappedObject);
        }}

        public TNode? LastOrDefault()
        {{
             return LastOrDefaultAccessor(wrappedObject);
        }}

        public bool Contains(TNode node)
        {{
             return ContainsAccessor(wrappedObject, node);
        }}

        public int IndexOf(TNode node)
        {{
            return IndexOfNodeAccessor(wrappedObject, node);
        }}

        public int IndexOf(global::System.Func<TNode, bool> predicate)
        {{
            return IndexOfPredicateAccessor(wrappedObject, predicate);
        }}

        public int LastIndexOf(TNode node)
        {{
            return LastIndexOfNodeAccessor(wrappedObject, node);
        }}

        public int LastIndexOf(global::System.Func<TNode, bool> predicate)
        {{
            return LastIndexOfPredicateAccessor(wrappedObject, predicate);
        }}

        public bool Any()
        {{
            return AnyAccessor(wrappedObject);
        }}

        public SyntaxNodeOrTokenList GetWithSeparators()
        {{
             return GetWithSeparatorsAccessor(wrappedObject);
        }}

        public SeparatedSyntaxListWrapper<TNode> Add(TNode node)
        {{
             return AddAccessor(wrappedObject, node);
        }}

        public SeparatedSyntaxListWrapper<TNode> AddRange(global::System.Collections.Generic.IEnumerable<TNode> nodes)
        {{
             return AddRangeAccessor(wrappedObject, nodes);
        }}

        public SeparatedSyntaxListWrapper<TNode> Insert(int index, TNode node)
        {{
             return InsertAccessor(wrappedObject, index, node);
        }}

        public SeparatedSyntaxListWrapper<TNode> InsertRange(int index, global::System.Collections.Generic.IEnumerable<TNode> nodes)
        {{
             return InsertRangeAccessor(wrappedObject, index, nodes);
        }}

        public SeparatedSyntaxListWrapper<TNode> RemoveAt(int index)
        {{
             return RemoveAtAccessor(wrappedObject, index);
        }}

        public SeparatedSyntaxListWrapper<TNode> Remove(TNode node)
        {{
             return RemoveAccessor(wrappedObject, node);
        }}

        public SeparatedSyntaxListWrapper<TNode> Replace(TNode nodeInList, TNode newNode)
        {{
             return ReplaceAccessor(wrappedObject, nodeInList, newNode);
        }}

        public SeparatedSyntaxListWrapper<TNode> ReplaceRange(TNode nodeInList, global::System.Collections.Generic.IEnumerable<TNode> newNodes)
        {{
             return ReplaceRangeAccessor(wrappedObject, nodeInList, newNodes);
        }}

        public SeparatedSyntaxListWrapper<TNode> ReplaceSeparator(global::Microsoft.CodeAnalysis.SyntaxToken separatorToken, global::Microsoft.CodeAnalysis.SyntaxToken newSeparator)
        {{
             return ReplaceSeparatorAccessor(wrappedObject, separatorToken, newSeparator);
        }}
    }}
}}
";

        var targetFilePath = "SeparatedSyntaxListWrapper.g.cs";
        context.AddSource(targetFilePath, SourceText.From(source, Encoding.UTF8));
    }

    private static void Write(
        SourceProductionContext context,
        AssemblyKind assemblyKind,
        List<string> typesToInclude,
        string nullableAnnotation,
        bool useFoldersInFilePaths,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        foreach (var typeDef in typeDefs.Values)
        {
            if (typeDef.AssemblyKind != assemblyKind)
            {
                continue;
            }

            if (typesToInclude.Count > 0 && !typesToInclude.Contains(typeDef.FullName))
            {
                continue;
            }

            var targetNamespace = GetTargetNamespace(typeDef);
            var source = GenerateType(typeDef, typeDefs, targetNamespace, HelperPrefixes[assemblyKind], nullableAnnotation);

            if (source != null)
            {
                var targetFilePath = GetGeneratedFilePath(typeDef, useFoldersInFilePaths);
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
        string helperPrefix,
        string nullableAnnotation)
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
                return GenerateWrapper(structTypeDef, typeDefs, targetNamespace, helperPrefix, nullableAnnotation);
            }
            else if (structTypeDef.IsUpdated)
            {
                return GenerateExtension(structTypeDef, typeDefs, targetNamespace, helperPrefix, nullableAnnotation);
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
                    return GenerateExtension(classTypeDef, typeDefs, targetNamespace, helperPrefix, nullableAnnotation);
                }
                else
                {
                    return GenerateWrapper(classTypeDef, typeDefs, targetNamespace, helperPrefix, nullableAnnotation);
                }
            }
            else if (classTypeDef.IsUpdated)
            {
                return GenerateExtension(classTypeDef, typeDefs, targetNamespace, helperPrefix, nullableAnnotation);
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
                return GenerateWrapper(interfaceTypeDef, typeDefs, targetNamespace, helperPrefix, nullableAnnotation);
            }
            else if (interfaceTypeDef.IsUpdated)
            {
                return GenerateExtension(interfaceTypeDef, typeDefs, targetNamespace, helperPrefix, nullableAnnotation);
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
        var newValues = typeDef.Values.Where(x => x.AssemblyVersion != null).OrderBy(x => x.Value).ToList();
        var targetName = typeDef.GeneratedName;

        var sb = new StringBuilder();
        var isFirstValue = true;

        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        AppendTypeSummary(sb, typeDef);
        if (typeDef.IsFlagsEnum)
        {
            sb.AppendLine($"    [System.Flags]");
        }
        sb.AppendLine($"    public enum {targetName} : global::{typeDef.UnderlyingTypeName}");
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

        sb.AppendLine($"// <auto-generated/>");
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
            sb.AppendLine($"        public const global::{fullTypeName} {value.Name} = (global::{fullTypeName}){value.Value};");
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
        string helperPrefix,
        string nullableAnnotation)
    {
        var na = nullableAnnotation;

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

        var fullHelperName = $"Microsoft.CodeAnalysis.Lightup.{helperPrefix}LightupHelper";

        var fullBaseTypeName = GetFullBaseTypeName(typeDef, typeDefs);
        var hasBaseType = fullBaseTypeName != null && typeDef is not InterfaceTypeDefinition;
        fullBaseTypeName ??= "System.Object";

        var sb = new StringBuilder();

        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine(nullableAnnotation != "" ? $"#nullable enable" : "");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        AppendEnclosingTypesStart(sb, typeDef.EnclosingTypeFullName, typeDefs);
        AppendTypeSummary(sb, typeDef);
        sb.AppendLine($"    public partial struct {targetName}");
        sb.AppendLine($"    {{");
        sb.AppendLine($"        private const string WrappedTypeName = \"{typeDef.FullName}\";");
        sb.AppendLine();
        sb.AppendLine($"        private static readonly global::System.Type{na} WrappedType;");
        if (staticFields.Count != 0)
        {
            sb.AppendLine();
            foreach (var field in staticFields)
            {
                AppendStaticFieldDelegateDeclarations(sb, field, nullableAnnotation, typeDefs);
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                AppendInstanceConstructorDelegateDeclarations(sb, targetName, constructor, index, nullableAnnotation, typeDefs);
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                AppendStaticPropertyDelegateDeclarations(sb, property, nullableAnnotation, typeDefs);
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                AppendInstancePropertyDelegateDeclarations(sb, property, fullBaseTypeName, nullableAnnotation, typeDefs);
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                AppendStaticMethodDelegateDeclaration(sb, method, index, nullableAnnotation, typeDefs);
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                AppendInstanceMethodDelegateDeclaration(sb, method, fullBaseTypeName, index, nullableAnnotation, typeDefs);
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
        sb.AppendLine($"        private readonly global::{fullBaseTypeName} wrappedObject;");
        sb.AppendLine();
        sb.AppendLine($"        static {targetName}()");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            WrappedType = global::{fullHelperName}.FindType(WrappedTypeName);");
        if (staticFields.Count != 0)
        {
            sb.AppendLine();
            foreach (var field in staticFields)
            {
                sb.AppendLine($"            {field.Name}GetterFunc = global::{fullHelperName}.CreateStaticReadAccessor<{field.Name}GetterDelegate>(WrappedType, nameof({field.Name}));");
                Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                sb.AppendLine($"            ConstructorFunc{index} = global::{fullHelperName}.CreateInstanceConstructorAccessor<ConstructorDelegate{index}>(WrappedType{GetCreateConstructorAccessorArguments(constructor)});");
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                sb.AppendLine($"            {property.Name}GetterFunc = global::{fullHelperName}.CreateStaticGetAccessor<{property.Name}GetterDelegate>(WrappedType, nameof({property.Name}));");
                if (property.HasSetter)
                {
                    sb.AppendLine($"            {property.Name}SetterFunc = global::{fullHelperName}.CreateStaticSetAccessor<{property.Name}SetterDelegate>(WrappedType, nameof({property.Name}));");
                }
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                sb.AppendLine($"            {property.Name}GetterFunc = global::{fullHelperName}.CreateInstanceGetAccessor<{property.Name}GetterDelegate>(WrappedType, nameof({property.Name}));");
                if (property.HasSetter)
                {
                    sb.AppendLine($"            {property.Name}SetterFunc = global::{fullHelperName}.CreateInstanceSetAccessor<{property.Name}SetterDelegate>(WrappedType, nameof({property.Name}));");
                }
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                sb.AppendLine($"            {method.Name}Func{index} = global::{fullHelperName}.CreateStaticMethodAccessor<{method.Name}Delegate{index}>(WrappedType, {GetCreateMethodAccessorArguments(method)});");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                sb.AppendLine($"            {method.Name}Func{index} = global::{fullHelperName}.CreateInstanceMethodAccessor<{method.Name}Delegate{index}>(WrappedType, {GetCreateMethodAccessorArguments(method)});");
            }
        }
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        private {targetName}(global::{fullBaseTypeName} obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            wrappedObject = obj;");
        sb.AppendLine($"        }}");
        foreach (var field in staticFields)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, field);
            sb.AppendLine($"        public static {GetFieldTypeDeclText(field, nullableAnnotation, typeDefs)} {field.Name}");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            get {{ return {field.Name}GetterFunc(); }}");
            sb.AppendLine($"        }}");
            Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
        }
        foreach (var constructor in instanceConstructors)
        {
            var index = instanceConstructors.IndexOf(constructor);
            sb.AppendLine();
            AppendMemberSummary(sb, constructor);
            sb.AppendLine($"        public static {targetName} Create({GetParametersDeclText(constructor.Parameters, nullableAnnotation, typeDefs)})");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            return ConstructorFunc{index}({GetArgumentsText(constructor.Parameters, null)});");
            sb.AppendLine($"        }}");
        }
        foreach (var property in staticProperties)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, property);
            sb.AppendLine($"        public static {GetPropertyTypeDeclText(property, nullableAnnotation, typeDefs)} {property.Name}");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            get {{ return {property.Name}GetterFunc(); }}");
            if (property.HasSetter)
            {
                sb.AppendLine($"            set {{ {property.Name}SetterFunc(value); }}");
            }
            sb.AppendLine($"        }}");
        }
        foreach (var property in instanceProperties)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, property);
            sb.AppendLine($"        public {GetPropertyTypeDeclText(property, nullableAnnotation, typeDefs)} {property.Name}");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            get {{ return {property.Name}GetterFunc(wrappedObject); }}");
            if (property.HasSetter)
            {
                sb.AppendLine($"            set {{ {property.Name}SetterFunc(wrappedObject, value); }}");
            }
            sb.AppendLine($"        }}");
        }
        if (hasBaseType)
        {
            sb.AppendLine();
            sb.AppendLine($"        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>");
            sb.AppendLine($"        public static explicit operator {targetName}(global::{fullBaseTypeName} obj)");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            return Wrap(obj);");
            sb.AppendLine($"        }}");
            sb.AppendLine();
            sb.AppendLine($"        /// <summary>Returns the wrapped object.</summary>");
            sb.AppendLine($"        public static implicit operator global::{fullBaseTypeName}({targetName} obj)");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            return obj.Unwrap();");
            sb.AppendLine($"        }}");
        }
        sb.AppendLine();
        sb.AppendLine($"        /// <summary>Returns true if the specified object is compatible with this wrapper.</summary>");
        sb.AppendLine($"        public static bool Is(global::{fullBaseTypeName}{na} obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            return global::{fullHelperName}.Is(obj, WrappedType);");
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        /// <summary>Creates a wrapper object containing the specified object. If the object is not compatible with this wrapper, an exception will be thrown.</summary>");
        sb.AppendLine($"        public static {targetName} Wrap(global::{fullBaseTypeName} obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            var obj2 = global::{fullHelperName}.Wrap<global::{fullBaseTypeName}>(obj, WrappedType);");
        sb.AppendLine($"            return new {targetName}(obj2);");
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        /// <summary>Returns the wrapped object.</summary>");
        sb.AppendLine($"        public global::{fullBaseTypeName} Unwrap()");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            return wrappedObject;");
        sb.AppendLine($"        }}");
        foreach (var methodDef in staticMethods)
        {
            var index = staticMethods.IndexOf(methodDef);
            sb.AppendLine();
            AppendMemberSummary(sb, methodDef);
            sb.AppendLine($"        public static {GetMethodReturnTypeDeclText(methodDef, nullableAnnotation, typeDefs)} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, nullableAnnotation, typeDefs)})");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            {(methodDef.ReturnType != null ? "return " : "")}{methodDef.Name}Func{index}({GetArgumentsText(methodDef.Parameters, null)});");
            sb.AppendLine($"        }}");
        }
        foreach (var methodDef in instanceMethods)
        {
            var index = instanceMethods.IndexOf(methodDef);
            sb.AppendLine();
            AppendMemberSummary(sb, methodDef);
            sb.AppendLine($"        public {GetMethodReturnTypeDeclText(methodDef, nullableAnnotation, typeDefs)} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, nullableAnnotation, typeDefs)})");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            {(methodDef.ReturnType != null ? "return " : "")}{methodDef.Name}Func{index}({GetArgumentsText(methodDef.Parameters, "wrappedObject")});");
            sb.AppendLine($"        }}");
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
        string helperPrefix,
        string nullableAnnotation)
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

        var fullHelperName = $"Microsoft.CodeAnalysis.Lightup.{helperPrefix}LightupHelper";

        var fullBaseTypeName = $"{typeDef.Namespace}.{typeDef.Name}";

        var sb = new StringBuilder();

        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine(nullableAnnotation != "" ? $"#nullable enable" : "");
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
                AppendStaticFieldDelegateDeclarations(sb, field, nullableAnnotation, typeDefs);
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                AppendInstanceConstructorDelegateDeclarations(sb, typeDef.FullName, constructor, index, nullableAnnotation, typeDefs);
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                AppendStaticPropertyDelegateDeclarations(sb, property, nullableAnnotation, typeDefs);
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                AppendInstancePropertyDelegateDeclarations(sb, property, fullBaseTypeName, nullableAnnotation, typeDefs);
            }
        }
        if (instanceEvents.Count != 0)
        {
            sb.AppendLine();
            foreach (var @event in instanceEvents)
            {
                AppendInstanceEventDelegateDeclarations(sb, @event, fullBaseTypeName, typeDefs);
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                AppendStaticMethodDelegateDeclaration(sb, method, index, nullableAnnotation, typeDefs);
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                AppendInstanceMethodDelegateDeclaration(sb, method, fullBaseTypeName, index, nullableAnnotation, typeDefs);
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
        sb.AppendLine($"            var wrappedType = global::{fullHelperName}.FindType(WrappedTypeName);");
        if (staticFields.Count != 0)
        {
            sb.AppendLine();
            foreach (var field in staticFields)
            {
                sb.AppendLine($"            {field.Name}GetterFunc = global::{fullHelperName}.CreateStaticReadAccessor<{field.Name}GetterDelegate>(wrappedType, nameof({field.Name}));");
                Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
            }
        }
        if (instanceConstructors.Count != 0)
        {
            sb.AppendLine();
            foreach (var constructor in instanceConstructors)
            {
                var index = instanceConstructors.IndexOf(constructor);
                sb.AppendLine($"            ConstructorFunc{index} = global::{fullHelperName}.CreateInstanceConstructorAccessor<ConstructorDelegate{index}>(wrappedType{GetCreateConstructorAccessorArguments(constructor)});");
            }
        }
        if (staticProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in staticProperties)
            {
                sb.AppendLine($"            {property.Name}GetterFunc = global::{fullHelperName}.CreateStaticGetAccessor<{property.Name}GetterDelegate>(wrappedType, nameof({property.Name}));");
                if (property.HasSetter)
                {
                    sb.AppendLine($"            {property.Name}SetterFunc = global::{fullHelperName}.CreateStaticSetAccessor<{property.Name}SetterDelegate>(wrappedType, nameof({property.Name}));");
                }
            }
        }
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                sb.AppendLine($"            {property.Name}GetterFunc = global::{fullHelperName}.CreateInstanceGetAccessor<{property.Name}GetterDelegate>(wrappedType, nameof({property.Name}));");
                if (property.HasSetter)
                {
                    sb.AppendLine($"            {property.Name}SetterFunc = global::{fullHelperName}.CreateInstanceSetAccessor<{property.Name}SetterDelegate>(wrappedType, nameof({property.Name}));");
                }
            }
        }
        if (instanceEvents.Count != 0)
        {
            sb.AppendLine();
            foreach (var @event in instanceEvents)
            {
                sb.AppendLine($"            {@event.Name}AdderFunc = global::{fullHelperName}.CreateInstanceAddAccessor<{@event.Name}AdderDelegate>(wrappedType, \"{@event.Name}\");");
                sb.AppendLine($"            {@event.Name}RemoverFunc = global::{fullHelperName}.CreateInstanceRemoveAccessor<{@event.Name}RemoverDelegate>(wrappedType, \"{@event.Name}\");");
            }
        }
        if (staticMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in staticMethods)
            {
                var index = staticMethods.IndexOf(method);
                sb.AppendLine($"            {method.Name}Func{index} = global::{fullHelperName}.CreateStaticMethodAccessor<{method.Name}Delegate{index}>(wrappedType, {GetCreateMethodAccessorArguments(method)});");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                sb.AppendLine($"            {method.Name}Func{index} = global::{fullHelperName}.CreateInstanceMethodAccessor<{method.Name}Delegate{index}>(wrappedType, {GetCreateMethodAccessorArguments(method)});");
            }
        }
        sb.AppendLine($"        }}");
        foreach (var field in staticFields)
        {
            Assert.IsTrue(field.IsReadOnly, "Unexpected non-readonly static field");
            sb.AppendLine();
            AppendMemberSummary(sb, field);
            sb.AppendLine($"        public static {GetFieldTypeDeclText(field, nullableAnnotation, typeDefs)} {field.Name}");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            get {{ return {field.Name}GetterFunc(); }}");
            sb.AppendLine($"        }}");
        }
        foreach (var constructor in instanceConstructors)
        {
            var index = instanceConstructors.IndexOf(constructor);
            sb.AppendLine();
            AppendMemberSummary(sb, constructor);
            sb.AppendLine($"        public static global::{fullBaseTypeName} Create({GetParametersDeclText(constructor.Parameters, nullableAnnotation, typeDefs)})");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            return ConstructorFunc{index}({GetArgumentsText(constructor.Parameters, null)});");
            sb.AppendLine($"        }}");
        }
        foreach (var property in staticProperties)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, property);
            sb.AppendLine($"        public static {GetPropertyTypeDeclText(property, nullableAnnotation, typeDefs)} {property.Name}()");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            return {property.Name}GetterFunc();");
            sb.AppendLine($"        }}");
            if (property.HasSetter)
            {
                sb.AppendLine();
                AppendMemberSummary(sb, property);
                sb.AppendLine($"        public static void Set{property.Name}({GetPropertyTypeDeclText(property, nullableAnnotation, typeDefs)} _value)");
                sb.AppendLine($"        {{");
                sb.AppendLine($"            {property.Name}SetterFunc(_value);");
                sb.AppendLine($"        }}");
            }
        }
        foreach (var property in instanceProperties)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, property);
            sb.AppendLine($"        public static {GetPropertyTypeDeclText(property, nullableAnnotation, typeDefs)} {property.Name}(this global::{typeDef.Namespace}.{typeDef.Name} _obj)");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            return {property.Name}GetterFunc(_obj);");
            sb.AppendLine($"        }}");
            if (property.HasSetter)
            {
                sb.AppendLine();
                AppendMemberSummary(sb, property);
                sb.AppendLine($"        public static void Set{property.Name}(this global::{typeDef.Namespace}.{typeDef.Name} _obj, {GetPropertyTypeDeclText(property, nullableAnnotation, typeDefs)} _value)");
                sb.AppendLine($"        {{");
                sb.AppendLine($"            {property.Name}SetterFunc(_obj, _value);");
                sb.AppendLine($"        }}");
            }
        }
        foreach (var @event in instanceEvents)
        {
            sb.AppendLine();
            AppendMemberSummary(sb, @event);
            sb.AppendLine($"        public static void Add{@event.Name}(this global::{typeDef.Namespace}.{typeDef.Name} _obj, {GetEventTypeDeclText(@event, typeDefs)} _delegate)");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            {@event.Name}AdderFunc(_obj, _delegate);");
            sb.AppendLine($"        }}");
            sb.AppendLine();
            AppendMemberSummary(sb, @event);
            sb.AppendLine($"        public static void Remove{@event.Name}(this global::{typeDef.Namespace}.{typeDef.Name} _obj, {GetEventTypeDeclText(@event, typeDefs)} _delegate)");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            {@event.Name}RemoverFunc(_obj, _delegate);");
            sb.AppendLine($"        }}");
        }
        foreach (var methodDef in staticMethods)
        {
            var index = staticMethods.IndexOf(methodDef);
            sb.AppendLine();
            AppendMemberSummary(sb, methodDef);
            sb.AppendLine($"        public static {GetMethodReturnTypeDeclText(methodDef, nullableAnnotation, typeDefs)} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, nullableAnnotation, typeDefs, isExtensionMethod: methodDef.IsExtensionMethod)})");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            {(methodDef.ReturnType != null ? "return " : "")}{methodDef.Name}Func{index}({GetArgumentsText(methodDef.Parameters, null)});");
            sb.AppendLine($"        }}");
        }
        foreach (var methodDef in instanceMethods)
        {
            var index = instanceMethods.IndexOf(methodDef);
            sb.AppendLine();
            AppendMemberSummary(sb, methodDef);
            sb.AppendLine($"        public static {GetMethodReturnTypeDeclText(methodDef, nullableAnnotation, typeDefs)} {methodDef.Name}(this global::{typeDef.Namespace}.{typeDef.Name} _obj{GetParametersDeclText(methodDef.Parameters, nullableAnnotation, typeDefs, true)})");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            {(methodDef.ReturnType != null ? "return " : "")}{methodDef.Name}Func{index}({GetArgumentsText(methodDef.Parameters, "_obj")});");
            sb.AppendLine($"        }}");
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return source;
    }

    private static string? GetFullBaseTypeName(
        TypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        return typeDef switch
        {
            ClassTypeDefinition x => GetFullBaseTypeName(x, typeDefs),
            InterfaceTypeDefinition x => GetFullBaseTypeName(x, typeDefs),
            StructTypeDefinition => null,
            _ => throw new NotImplementedException(),
        };
    }

    private static string? GetFullBaseTypeName(
        ClassTypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var currTypeDef = typeDef;
        while (currTypeDef != null)
        {
            var baseTypeRef = currTypeDef.BaseClass;
            if (baseTypeRef == null)
            {
                return null;
            }

            if (baseTypeRef is not NamedTypeReference namedBaseTypeRef)
            {
                return null;
            }

            if (!typeDefs.TryGetValue(namedBaseTypeRef.FullName, out var baseTypeDef))
            {
                return namedBaseTypeRef.FullName;
            }

            if (baseTypeDef.AssemblyVersion == null)
            {
                return $"{namedBaseTypeRef.Namespace}.{namedBaseTypeRef.Name}";
            }

            currTypeDef = (ClassTypeDefinition)baseTypeDef;
        }

        Assert.Fail("Could not get base type");
        return null;
    }

    private static string? GetFullBaseTypeName(
        InterfaceTypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var baseTypeRef = typeDef.BaseInterface;
        if (baseTypeRef == null)
        {
            return null;
        }

        // TODO: Improve handling of base type to handle cases where the base type is not available in the baseline version? Add more info in reflector?
        if (IsNewType(baseTypeRef, typeDefs))
        {
            return null;
        }

        if (baseTypeRef is NamedTypeReference x)
        {
            return $"{x.Namespace}.{x.Name}";
        }

        Assert.Fail("Could not get base type");
        return null;
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
            // TODO: Enable generation of CodeStyleOptions (some members reference CodeStyleOption<> which was added in 2.0.0)
            .Where(x => typeDef.FullName != "Microsoft.CodeAnalysis.CodeStyle.CodeStyleOptions")
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
            // TODO: Enable generation of IEventAssignmentOperation (property EventReference changed type in version 2.9.0)
            .Where(x => typeDef.FullName != "Microsoft.CodeAnalysis.Operations.IEventAssignmentOperation" || x.Name != "EventReference")
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
        string nullableAnnotation,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetFieldTypeDeclText(fieldDef, nullableAnnotation, typeDefs));
        sb.AppendLine($" {fieldDef.Name}GetterDelegate();");

        Assert.IsTrue(fieldDef.IsReadOnly, "Unexpected non-readonly static field");
    }

    private static string GetFieldTypeDeclText(
        FieldDefinition fieldDef,
        string nullableAnnotation,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        AppendTypeDeclText(sb, fieldDef.Type, typeDefs);
        AppendNullableAnnotation(sb, fieldDef.Type, fieldDef.IsNullable, nullableAnnotation, typeDefs);
        var result = sb.ToString();
        return result;
    }

    private static void AppendInstanceConstructorDelegateDeclarations(
        StringBuilder sb,
        string targetName,
        ConstructorDefinition constructorDef,
        int index,
        string nullableAnnotation,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate {targetName}");
        sb.Append($" ConstructorDelegate{index}(");
        sb.Append(GetParametersDeclText(constructorDef.Parameters, nullableAnnotation, typeDefs));
        sb.AppendLine($");");
    }

    private static void AppendStaticPropertyDelegateDeclarations(
        StringBuilder sb,
        PropertyDefinition propertyDef,
        string nullableAnnotation,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetPropertyTypeDeclText(propertyDef, nullableAnnotation, typeDefs));
        sb.AppendLine($" {propertyDef.Name}GetterDelegate();");

        if (propertyDef.HasSetter)
        {
            sb.Append($"        private delegate void ");
            sb.Append($"{propertyDef.Name}SetterDelegate(");
            sb.AppendLine($"{GetPropertyTypeDeclText(propertyDef, nullableAnnotation, typeDefs)} _value);");
        }
    }

    private static void AppendInstancePropertyDelegateDeclarations(
        StringBuilder sb,
        PropertyDefinition propertyDef,
        string fullBaseTypeName,
        string nullableAnnotation,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetPropertyTypeDeclText(propertyDef, nullableAnnotation, typeDefs));
        sb.AppendLine($" {propertyDef.Name}GetterDelegate(global::{fullBaseTypeName} _obj);");

        if (propertyDef.HasSetter)
        {
            sb.Append($"        private delegate void ");
            sb.Append($"{propertyDef.Name}SetterDelegate({fullBaseTypeName} _obj, ");
            sb.AppendLine($"{GetPropertyTypeDeclText(propertyDef, nullableAnnotation, typeDefs)} _value);");
        }
    }

    private static string GetPropertyTypeDeclText(
        PropertyDefinition propertyDef,
        string nullableAnnotation,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        AppendTypeDeclText(sb, propertyDef.Type, typeDefs);
        AppendNullableAnnotation(sb, propertyDef.Type, propertyDef.IsNullable, nullableAnnotation, typeDefs);
        var result = sb.ToString();
        return result;
    }

    private static void AppendInstanceEventDelegateDeclarations(
        StringBuilder sb,
        EventDefinition propertyDef,
        string fullBaseTypeName,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate void");
        sb.AppendLine($" {propertyDef.Name}AdderDelegate(global::{fullBaseTypeName} _obj, {GetEventTypeDeclText(propertyDef, typeDefs)} _delegate);");

        sb.Append($"        private delegate void");
        sb.AppendLine($" {propertyDef.Name}RemoverDelegate(global::{fullBaseTypeName} _obj, {GetEventTypeDeclText(propertyDef, typeDefs)} _delegate);");
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
        string nullableAnnotation,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetMethodReturnTypeDeclText(methodDef, nullableAnnotation, typeDefs));
        sb.Append($" {methodDef.Name}Delegate{index}(");
        sb.Append(GetParametersDeclText(methodDef.Parameters, nullableAnnotation, typeDefs, addLeadingComma: false));
        sb.AppendLine(");");
    }

    private static void AppendInstanceMethodDelegateDeclaration(
        StringBuilder sb,
        MethodDefinition methodDef,
        string fullBaseTypeName,
        int index,
        string nullableAnnotation,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetMethodReturnTypeDeclText(methodDef, nullableAnnotation, typeDefs));
        sb.Append($" {methodDef.Name}Delegate{index}(global::{fullBaseTypeName} _obj");
        sb.Append(GetParametersDeclText(methodDef.Parameters, nullableAnnotation, typeDefs, addLeadingComma: true));
        sb.AppendLine(");");
    }

    private static string GetMethodReturnTypeDeclText(
        MethodDefinition methodDef,
        string nullableAnnotation,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        if (methodDef.ReturnType != null)
        {
            AppendTypeDeclText(sb, methodDef.ReturnType, typeDefs);
            AppendNullableAnnotation(sb, methodDef.ReturnType, methodDef.IsNullable, nullableAnnotation, typeDefs);
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
        string nullableAnnotation,
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
            sb.Append(GetParameterTypeDeclText(parameter, typeDefs, nullableAnnotation));
            sb.Append(' ');
            sb.Append(GetParameterNameText(parameter.Name));

            isExtensionMethod = false;
        }

        var result = sb.ToString();
        return result;
    }

    private static string GetParameterTypeDeclText(
        ParameterDefinition parameterDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs,
        string nullableAnnotation)
    {
        var sb = new StringBuilder();
        AppendTypeDeclText(sb, parameterDef.Type, typeDefs);
        AppendNullableAnnotation(sb, parameterDef.Type, parameterDef.IsNullable, nullableAnnotation, typeDefs);
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
        else if (name == "default")
        {
            return "@default";
        }
        else if (name == "foreach")
        {
            return "@foreach";
        }
        else if (name == "event")
        {
            return "@event";
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
                sb.Append("global::Microsoft.CodeAnalysis.Lightup.SeparatedSyntaxListWrapper");
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
            sb.Append($"global::{namedTypeRef.Namespace}");
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

    private static void AppendNullableAnnotation(StringBuilder sb, TypeReference typeRef, bool isNullable, string nullableAnnotation, IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        if (isNullable)
        {
            // NOTE: A new type is generated as a struct, so always add "?" (i.e. System.Nullable<>)
            sb.Append(IsNewType(typeRef, typeDefs) ? "?" : nullableAnnotation);
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

    private static string GetGeneratedFilePath(BaseTypeDefinition typeDef, bool useFoldersInFilePaths)
    {
        if (useFoldersInFilePaths)
        {
            var sourceNamespace = typeDef.Namespace!;
            var targetFolder = sourceNamespace.Replace("Microsoft.CodeAnalysis", "").TrimStart('.').Replace('.', Path.DirectorySeparatorChar);
            var targetFilePath = Path.Combine(targetFolder, typeDef.GeneratedFileName);
            return targetFilePath;
        }
        else
        {
            var targetFilePath = $"{typeDef.Namespace}.{typeDef.GeneratedFileName}";
            return targetFilePath;
        }
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
