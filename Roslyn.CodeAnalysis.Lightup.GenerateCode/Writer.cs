// TODO: Review suppression
#pragma warning disable SA1513 // Closing brace should be followed by blank line

namespace Roslyn.CodeAnalysis.Lightup.GenerateCode;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

internal class Writer
{
    private static readonly Dictionary<AssemblyKind, string> ProjectNames = new()
    {
        [AssemblyKind.Common] = "Roslyn.CodeAnalysis.Lightup.Common",
        [AssemblyKind.CSharp] = "Roslyn.CodeAnalysis.Lightup.CSharp",
        [AssemblyKind.Workspaces] = "Roslyn.CodeAnalysis.Lightup.Workspaces.Common",
        [AssemblyKind.CSharpWorkspaces] = "Roslyn.CodeAnalysis.Lightup.CSharp.Workspaces",
    };

    // TODO: Check if these types should be generated
    private static readonly HashSet<string> TypesToSkip =
    [
        "Microsoft.CodeAnalysis.AnalyzerConfigSet",
        "Microsoft.CodeAnalysis.CodeFixes.DocumentBasedFixAllProvider", // using CodeAction
        "Microsoft.CodeAnalysis.CSharp.CSharpGeneratorDriver", // No base interface
        "Microsoft.CodeAnalysis.Diagnostics.AnalyzerConfigOptions", // Parameter mode
        "Microsoft.CodeAnalysis.Diagnostics.AnalyzerConfigOptionsProvider",
        "Microsoft.CodeAnalysis.Diagnostics.DiagnosticSuppressor",
        "Microsoft.CodeAnalysis.Diagnostics.Suppression",
        "Microsoft.CodeAnalysis.Diagnostics.SuppressionAnalysisContext",
        "Microsoft.CodeAnalysis.GeneratorDriver", // Parameter mode
        "Microsoft.CodeAnalysis.GeneratorDriverRunResult",
        "Microsoft.CodeAnalysis.GeneratorDriverTimingInfo",
        "Microsoft.CodeAnalysis.GeneratorExecutionContext",
        "Microsoft.CodeAnalysis.GeneratorInitializationContext",
        "Microsoft.CodeAnalysis.GeneratorRunResult",
        "Microsoft.CodeAnalysis.GeneratorTimingInfo",
        "Microsoft.CodeAnalysis.Host.LanguageServices", // Wrong return type
        "Microsoft.CodeAnalysis.Host.SolutionServices", // Wrong return type
        "Microsoft.CodeAnalysis.IImportScope", // No base interface
        "Microsoft.CodeAnalysis.IIncrementalGenerator", // No base interface
        "Microsoft.CodeAnalysis.IncrementalGeneratorInitializationContext",
        "Microsoft.CodeAnalysis.IncrementalGeneratorRunStep", // ValueTuple
        "Microsoft.CodeAnalysis.ISourceGenerator", // No base interface
        "Microsoft.CodeAnalysis.ISupportedChangesService", // No base interface
        "Microsoft.CodeAnalysis.ISyntaxContextReceiver", // No base interface
        "Microsoft.CodeAnalysis.ISyntaxReceiver", // No base interface
        "Microsoft.CodeAnalysis.Rename.DocumentRenameOptions", // Parameter mode
        "Microsoft.CodeAnalysis.Rename.SymbolRenameOptions", // Parameter mode
        "Microsoft.CodeAnalysis.SuppressionDescriptor",
        "Microsoft.CodeAnalysis.SymbolEqualityComparer",
        "Microsoft.CodeAnalysis.SyntaxContextReceiverCreator",
        "Microsoft.CodeAnalysis.SyntaxReceiverCreator",
        "Microsoft.CodeAnalysis.SyntaxTreeOptionsProvider", // Parameter mode
    ];

    internal static void Write(IReadOnlyDictionary<string, TypeDefinition> typeDefs, string rootPath)
    {
        foreach (var assemblyKind in Enum.GetValues<AssemblyKind>())
        {
            Write(typeDefs, rootPath, assemblyKind);
        }
    }

    private static void Write(
        IReadOnlyDictionary<string, TypeDefinition> typeDefs,
        string rootPath,
        AssemblyKind assemblyKind)
    {
        var relevantTypeDefs = typeDefs.Values.Where(x => x.AssemblyKind == assemblyKind).ToList();
        foreach (var typeDef in relevantTypeDefs)
        {
            var targetNamespace = GetTargetNamespace(typeDef);
            var result = GenerateType(typeDef, typeDefs, targetNamespace);

            if (result != null)
            {
                var sourcePath = Path.Combine(rootPath, ProjectNames[assemblyKind]);
                var targetFolder = GetTargetFolder(typeDef, sourcePath);
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }

                File.WriteAllText(Path.Combine(targetFolder, result.Value.Name + ".cs"), result.Value.Source, Encoding.UTF8);
            }
        }
    }

    private static string GetTargetNamespace(TypeDefinition typeDef)
    {
        var sourceNamespace = typeDef.Namespace!;
        var targetNamespace = sourceNamespace + ".Lightup";
        return targetNamespace;
    }

    private static (string Name, string Source)? GenerateType(
        TypeDefinition typeDef,
        IReadOnlyDictionary<string, TypeDefinition> typeDefs,
        string targetNamespace)
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
            else
            {
                return GenerateUpdatedEnum(enumTypeDef, targetNamespace);
            }
        }
        else if (typeDef is StructTypeDefinition structTypeDef)
        {
            if (typeDef.AssemblyVersion == null)
            {
                // TODO: Handle updated types as well
                return null;
            }
            else
            {
                return GenerateStruct(structTypeDef, typeDefs, targetNamespace);
            }
        }
        else if (typeDef is ClassTypeDefinition classTypeDef)
        {
            if (typeDef.AssemblyVersion == null)
            {
                // TODO: Handle updated types as well
                return null;
            }
            else if (classTypeDef.IsStatic)
            {
                // TODO: Handle static classes as well
                return null;
            }
            else
            {
                return GenerateClass(classTypeDef, typeDefs, targetNamespace);
            }
        }
        else if (typeDef is InterfaceTypeDefinition interfaceTypeDef)
        {
            if (typeDef.AssemblyVersion == null)
            {
                // TODO: Handle updated types as well
                return null;
            }
            else
            {
                return GenerateInterface(interfaceTypeDef, typeDefs, targetNamespace);
            }
        }
        else
        {
            Assert.Fail("Unexpected type");
            return null;
        }
    }

    private static (string Name, string Source) GenerateNewEnum(
        EnumTypeDefinition typeDef,
        string targetNamespace)
    {
        var newValues = typeDef.Values.Where(x => x.AssemblyVersion != null).OrderBy(x => x.Value).ToList();
        var targetName = typeDef.Name + "Ex";

        var sb = new StringBuilder();
        var isFirstValue = true;

        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        sb.AppendLine($"    /// <summary>Enum added in Roslyn version {typeDef.AssemblyVersion}</summary>");
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

            sb.AppendLine($"        /// <summary>Added in Roslyn version {value.AssemblyVersion}</summary>");
            sb.AppendLine($"        {value.Name} = {value.Value},");
            isFirstValue = false;
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return (targetName, source);
    }

    private static (string Name, string Source)? GenerateUpdatedEnum(
        EnumTypeDefinition typeDef,
        string targetNamespace)
    {
        var newValues = typeDef.Values.Where(x => x.AssemblyVersion != null).OrderBy(x => x.Value).ToList();
        if (newValues.Count == 0)
        {
            return null;
        }

        var targetName = typeDef.Name + "Ex";

        var sb = new StringBuilder();
        var isFirstValue = true;

        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        sb.AppendLine($"    public class {targetName}");
        sb.AppendLine($"    {{");
        foreach (var value in newValues)
        {
            if (!isFirstValue)
            {
                sb.AppendLine();
            }

            sb.AppendLine($"        /// <summary>Added in Roslyn version {value.AssemblyVersion}</summary>");
            sb.AppendLine($"        public const {typeDef.Name} {value.Name} = ({typeDef.Name}){value.Value};");
            isFirstValue = false;
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return (targetName, source);
    }

    private static (string Name, string Source) GenerateStruct(
        StructTypeDefinition typeDef,
        IReadOnlyDictionary<string, TypeDefinition> typeDefs,
        string targetNamespace)
    {
        var targetName = typeDef.Name + "Wrapper";
        var instanceProperties = typeDef.Properties;
        var instanceMethods = typeDef.Methods;

        ////var baseTypeName = GetWrappedObjectTypeName(typeDef);
        ////Assert.IsTrue(baseTypeName != null, "Could not get base type");
        var baseTypeName = "object";

        var sb = new StringBuilder();

        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        sb.AppendLine($"using Microsoft.CodeAnalysis.Lightup;");
        sb.AppendLine($"using Microsoft.CodeAnalysis.Text;");
        sb.AppendLine($"using System;");
        sb.AppendLine($"using System.Collections.Immutable;");
        sb.AppendLine($"using System.Threading;");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        sb.AppendLine($"    /// <summary>Struct added in Roslyn version {typeDef.AssemblyVersion}</summary>");
        sb.AppendLine($"    public readonly struct {targetName}");
        sb.AppendLine($"    {{");
        sb.AppendLine($"        private const string WrappedTypeName = \"{typeDef.FullName}\";");
        sb.AppendLine();
        sb.AppendLine($"        public static readonly Type? WrappedType;");
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                var funcDeclText = GetPropertyFuncDeclText(property, baseTypeName, typeDefs);
                sb.AppendLine($"        private static readonly {funcDeclText} {property.Name}Func;");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                var funcDeclText = GetMethodFuncDeclText(method, baseTypeName, typeDefs);
                sb.AppendLine($"        private static readonly {funcDeclText} {method.Name}Func{index};");
            }
        }
        sb.AppendLine();
        sb.AppendLine($"        private readonly {baseTypeName}? wrappedObject;");
        sb.AppendLine();
        sb.AppendLine($"        static {targetName}()");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            WrappedType = LightupHelper.FindType(WrappedTypeName);");
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                sb.AppendLine($"            {property.Name}Func = LightupHelper.CreateGetAccessor<{baseTypeName}?, {GetTypeDeclText(property, typeDefs)}>(WrappedType, nameof({property.Name}));");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                var createMethod = method.ReturnType != null ? "CreateMethodAccessor" : "CreateVoidMethodAccessor";
                sb.AppendLine($"            {method.Name}Func{index} = LightupHelper.{createMethod}<{baseTypeName}?{(method.Parameters.Count > 0 ? ", " : "")}{GetParametersTypeDeclText(method.Parameters, typeDefs)}{(method.ReturnType != null ? $", {GetTypeDeclText(method.ReturnType, typeDefs)}" : "")}>(WrappedType, nameof({method.Name}));");
            }
        }
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        private {targetName}({baseTypeName}? obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            wrappedObject = obj;");
        sb.AppendLine($"        }}");
        foreach (var property in instanceProperties)
        {
            sb.AppendLine();
            sb.AppendLine($"        public readonly {GetTypeDeclText(property, typeDefs)} {property.Name}");
            sb.AppendLine($"            => {property.Name}Func(wrappedObject);");
        }
        sb.AppendLine();
        ////sb.AppendLine($"        public static implicit operator {baseTypeName}?({targetName} obj)");
        ////sb.AppendLine($"            => obj.Unwrap();");
        ////sb.AppendLine();
        sb.AppendLine($"        public static bool Is(object? obj)");
        sb.AppendLine($"            => LightupHelper.Is(obj, WrappedType);");
        sb.AppendLine();
        sb.AppendLine($"        public static {targetName} As(object? obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            var obj2 = LightupHelper.As<{baseTypeName}>(obj, WrappedType);");
        sb.AppendLine($"            return new {targetName}(obj2);");
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        public {baseTypeName}? Unwrap()");
        sb.AppendLine($"            => wrappedObject;");
        foreach (var methodDef in instanceMethods)
        {
            var index = instanceMethods.IndexOf(methodDef);
            sb.AppendLine();
            sb.AppendLine($"        public readonly {(methodDef.ReturnType != null ? GetTypeDeclText(methodDef.ReturnType, typeDefs) : "void")} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, typeDefs)})");
            sb.AppendLine($"            => {methodDef.Name}Func{index}(wrappedObject{(methodDef.Parameters.Count > 0 ? ", " : "")}{string.Join(", ", methodDef.Parameters.Select(x => x.Name))});");
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return (targetName, source);
    }

    private static (string Name, string Source) GenerateClass(
        ClassTypeDefinition typeDef,
        IReadOnlyDictionary<string, TypeDefinition> typeDefs,
        string targetNamespace)
    {
        var targetName = typeDef.Name + "Wrapper";
        var instanceProperties = GetInstanceProperties(typeDef);
        var instanceMethods = GetInstanceMethods(typeDef);

        var baseTypeName = GetBaseTypeName(typeDef, typeDefs);
        var hasBaseType = baseTypeName != null;
        baseTypeName ??= "object";

        var sb = new StringBuilder();

        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        sb.AppendLine($"using Microsoft.CodeAnalysis.Lightup;");
        sb.AppendLine($"using System;");
        sb.AppendLine($"using System.Collections.Generic;");
        sb.AppendLine($"using System.Collections.Immutable;");
        sb.AppendLine($"using System.Threading;");
        sb.AppendLine($"using System.Threading.Tasks;");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        sb.AppendLine($"    /// <summary>Class added in Roslyn version {typeDef.AssemblyVersion}</summary>");
        sb.AppendLine($"    public readonly struct {targetName}");
        sb.AppendLine($"    {{");
        sb.AppendLine($"        private const string WrappedTypeName = \"{typeDef.FullName}\";");
        sb.AppendLine();
        sb.AppendLine($"        public static readonly Type? WrappedType;");
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                var funcDeclText = GetPropertyFuncDeclText(property, baseTypeName, typeDefs);
                sb.AppendLine($"        private static readonly {funcDeclText} {property.Name}Func;");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                var funcDeclText = GetMethodFuncDeclText(method, baseTypeName, typeDefs);
                sb.AppendLine($"        private static readonly {funcDeclText} {method.Name}Func{index};");
            }
        }
        sb.AppendLine();
        sb.AppendLine($"        private readonly {baseTypeName}? wrappedObject;");
        sb.AppendLine();
        sb.AppendLine($"        static {targetName}()");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            WrappedType = LightupHelper.FindType(WrappedTypeName);");
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                sb.AppendLine($"            {property.Name}Func = LightupHelper.CreateGetAccessor<{baseTypeName}?, {GetTypeDeclText(property, typeDefs)}>(WrappedType, nameof({property.Name}));");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                var createMethod = method.ReturnType != null ? "CreateMethodAccessor" : "CreateVoidMethodAccessor";
                sb.AppendLine($"            {method.Name}Func{index} = LightupHelper.{createMethod}<{baseTypeName}?, {GetParametersTypeDeclText(method.Parameters, typeDefs)}{(method.ReturnType != null ? $", {targetName}" : "")}>(WrappedType, nameof({method.Name}));");
            }
        }
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        private {targetName}({baseTypeName}? obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            wrappedObject = obj;");
        sb.AppendLine($"        }}");
        foreach (var property in instanceProperties)
        {
            sb.AppendLine();
            sb.AppendLine($"        public readonly {GetTypeDeclText(property, typeDefs)} {property.Name}");
            sb.AppendLine($"            => {property.Name}Func(wrappedObject);");
        }
        if (hasBaseType)
        {
            sb.AppendLine();
            sb.AppendLine($"        public static implicit operator {baseTypeName}?({targetName} obj)");
            sb.AppendLine($"            => obj.Unwrap();");
        }
        sb.AppendLine();
        sb.AppendLine($"        public static bool Is(object? obj)");
        sb.AppendLine($"            => LightupHelper.Is(obj, WrappedType);");
        sb.AppendLine();
        sb.AppendLine($"        public static {targetName} As(object? obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            var obj2 = LightupHelper.As<{baseTypeName}>(obj, WrappedType);");
        sb.AppendLine($"            return new {targetName}(obj2);");
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        public {baseTypeName}? Unwrap()");
        sb.AppendLine($"            => wrappedObject;");
        foreach (var methodDef in instanceMethods)
        {
            var index = instanceMethods.IndexOf(methodDef);
            sb.AppendLine();
            sb.AppendLine($"        public readonly {(methodDef.ReturnType != null ? GetTypeDeclText(methodDef.ReturnType, typeDefs) : "void")} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, typeDefs)})");
            sb.AppendLine($"            => {methodDef.Name}Func{index}(wrappedObject, {string.Join(", ", methodDef.Parameters.Select(x => x.Name))});");
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return (targetName, source);
    }

    private static List<PropertyDefinition> GetInstanceProperties(ClassTypeDefinition typeDef)
    {
        var result = typeDef.Properties
            .Where(x => !x.IsStatic)
            .ToList();
        return result;
    }

    private static List<MethodDefinition> GetInstanceMethods(ClassTypeDefinition typeDef)
    {
        var result = typeDef.Methods
            .Where(x => !x.IsStatic)
            .ToList();
        return result;
    }

    private static (string Name, string Source) GenerateInterface(
        InterfaceTypeDefinition typeDef,
        IReadOnlyDictionary<string, TypeDefinition> typeDefs,
        string targetNamespace)
    {
        var targetName = typeDef.Name + "Wrapper";
        var instanceProperties = typeDef.Properties;
        var instanceMethods = typeDef.Methods;

        var baseTypeName = GetWrappedObjectTypeName(typeDef);
        Assert.IsTrue(baseTypeName != null, "Could not get base type");

        var sb = new StringBuilder();

        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        sb.AppendLine($"using Microsoft.CodeAnalysis.Lightup;");
        sb.AppendLine($"using System;");
        sb.AppendLine($"using System.Collections.Immutable;");
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        sb.AppendLine($"    /// <summary>Interface added in Roslyn version {typeDef.AssemblyVersion}</summary>");
        sb.AppendLine($"    public readonly struct {targetName}");
        sb.AppendLine($"    {{");
        sb.AppendLine($"        private const string WrappedTypeName = \"{typeDef.FullName}\";");
        sb.AppendLine();
        sb.AppendLine($"        public static readonly Type? WrappedType;");
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                var funcDeclText = GetPropertyFuncDeclText(property, baseTypeName, typeDefs);
                sb.AppendLine($"        private static readonly {funcDeclText} {property.Name}Func;");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                var funcDeclText = GetMethodFuncDeclText(method, baseTypeName, typeDefs);
                sb.AppendLine($"        private static readonly {funcDeclText} {method.Name}Func{index};");
            }
        }
        sb.AppendLine();
        sb.AppendLine($"        private readonly {baseTypeName}? wrappedObject;");
        sb.AppendLine();
        sb.AppendLine($"        static {targetName}()");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            WrappedType = LightupHelper.FindType(WrappedTypeName);");
        if (instanceProperties.Count != 0)
        {
            sb.AppendLine();
            foreach (var property in instanceProperties)
            {
                sb.AppendLine($"            {property.Name}Func = LightupHelper.CreateGetAccessor<{baseTypeName}?, {GetTypeDeclText(property, typeDefs)}>(WrappedType, nameof({property.Name}));");
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                var createMethod = method.ReturnType != null ? "CreateMethodAccessor" : "CreateVoidMethodAccessor";
                sb.AppendLine($"            {method.Name}Func{index} = LightupHelper.{createMethod}<{baseTypeName}?, {GetParametersTypeDeclText(method.Parameters, typeDefs)}{(method.ReturnType != null ? $", {targetName}" : "")}>(WrappedType, nameof({method.Name}));");
            }
        }
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        private {targetName}({baseTypeName}? obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            wrappedObject = obj;");
        sb.AppendLine($"        }}");
        foreach (var property in instanceProperties)
        {
            sb.AppendLine();
            sb.AppendLine($"        public readonly {GetTypeDeclText(property, typeDefs)} {property.Name}");
            sb.AppendLine($"            => {property.Name}Func(wrappedObject);");
        }
        sb.AppendLine();
        ////sb.AppendLine($"        public static implicit operator {baseTypeName}?({targetName} obj)");
        ////sb.AppendLine($"            => obj.Unwrap();");
        ////sb.AppendLine();
        sb.AppendLine($"        public static bool Is(object? obj)");
        sb.AppendLine($"            => LightupHelper.Is(obj, WrappedType);");
        sb.AppendLine();
        sb.AppendLine($"        public static {targetName} As(object? obj)");
        sb.AppendLine($"        {{");
        sb.AppendLine($"            var obj2 = LightupHelper.As<{baseTypeName}>(obj, WrappedType);");
        sb.AppendLine($"            return new {targetName}(obj2);");
        sb.AppendLine($"        }}");
        sb.AppendLine();
        sb.AppendLine($"        public {baseTypeName}? Unwrap()");
        sb.AppendLine($"            => wrappedObject;");
        foreach (var methodDef in instanceMethods)
        {
            var index = instanceMethods.IndexOf(methodDef);
            sb.AppendLine();
            sb.AppendLine($"        public readonly {(methodDef.ReturnType != null ? GetTypeDeclText(methodDef.ReturnType, typeDefs) : "void")} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, typeDefs)})");
            sb.AppendLine($"            => {methodDef.Name}Func{index}(wrappedObject, {string.Join(", ", methodDef.Parameters.Select(x => x.Name))});");
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return (targetName, source);
    }

    private static string GetPropertyFuncDeclText(PropertyDefinition propertyDef, string baseTypeName, IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();

        sb.Append($"Func<{baseTypeName}?, ");
        AppendTypeDeclText(sb, propertyDef.Type, typeDefs);
        sb.Append(propertyDef.IsNullable && !IsNewType(propertyDef.Type, typeDefs) ? "?" : "");
        sb.Append('>');

        var result = sb.ToString();
        return result;
    }

    private static string GetMethodFuncDeclText(MethodDefinition methodDef, string baseTypeName, IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();

        sb.Append(methodDef.ReturnType != null ? "Func" : "Action");
        sb.Append($"<{baseTypeName}?");

        foreach (var parameter in methodDef.Parameters)
        {
            sb.Append(", ");
            Assert.IsTrue(parameter.Mode == ParameterMode.None, "Unhandled parameter mode");
            AppendTypeDeclText(sb, parameter.Type, typeDefs);
            sb.Append(parameter.IsNullable && !IsNewType(parameter.Type, typeDefs) ? "?" : "");
        }

        if (methodDef.ReturnType != null)
        {
            sb.Append(", ");
            AppendTypeDeclText(sb, methodDef.ReturnType, typeDefs);
        }

        sb.Append('>');

        var result = sb.ToString();
        return result;
    }

    private static string GetParametersTypeDeclText(
        IEnumerable<ParameterDefinition> parameters,
        IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        foreach (var parameter in parameters)
        {
            if (sb.Length > 0)
            {
                sb.Append(", ");
            }

            Assert.IsTrue(parameter.Mode == ParameterMode.None, "Unhandled parameter mode");
            AppendTypeDeclText(sb, parameter.Type, typeDefs);
            sb.Append(parameter.IsNullable && !IsNewType(parameter.Type, typeDefs) ? "?" : "");
        }

        var result = sb.ToString();
        return result;
    }

    private static string GetParametersDeclText(
        IEnumerable<ParameterDefinition> parameters,
        IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        foreach (var parameter in parameters)
        {
            if (sb.Length > 0)
            {
                sb.Append(", ");
            }

            Assert.IsTrue(parameter.Mode == ParameterMode.None, "Unhandled parameter mode");
            sb.Append(parameter.IsParams ? "params " : "");
            AppendTypeDeclText(sb, parameter.Type, typeDefs);
            sb.Append(parameter.IsNullable && !IsNewType(parameter.Type, typeDefs) ? "?" : "");
            sb.Append(' ');
            sb.Append(parameter.Name);
        }

        var result = sb.ToString();
        return result;
    }

    private static string GetTypeDeclText(
        PropertyDefinition propertyDef,
        IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        AppendTypeDeclText(sb, propertyDef.Type, typeDefs);
        sb.Append(propertyDef.IsNullable && !IsNewType(propertyDef.Type, typeDefs) ? "?" : "");
        var result = sb.ToString();
        return result;
    }

    private static string GetTypeDeclText(TypeReference type, IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        var sb = new StringBuilder();
        AppendTypeDeclText(sb, type, typeDefs);
        var result = sb.ToString();
        return result;
    }

    private static void AppendTypeDeclText(
        StringBuilder sb,
        TypeReference typeRef,
        IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        if (typeRef is GenericTypeReference genericTypeRef)
        {
            if (IsSeparatedSyntaxList(genericTypeRef) && IsNewType(genericTypeRef.TypeArguments[0], typeDefs))
            {
                sb.Append("SeparatedSyntaxListWrapper");
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
            sb.Append($"{namedTypeRef.Name}{(isNewEnum ? "Ex" : isNew ? "Wrapper" : "")}");
        }
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

    private static string GetTargetFolder(TypeDefinition typeDef, string targetProjectPath)
    {
        var sourceNamespace = typeDef.Namespace!;
        var targetNamespace = sourceNamespace + ".Lightup";
        var targetFolder = targetNamespace.Replace("Microsoft.CodeAnalysis", "").TrimStart('.').Replace('.', Path.DirectorySeparatorChar);
        return Path.Combine(targetProjectPath, targetFolder);
    }

    private static string? GetBaseTypeName(
        ClassTypeDefinition typeDef,
        IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        if (typeDef.Name == "AnalyzerConfig")
        {
        }

        while (true)
        {
            var baseTypeRef = typeDef.BaseClass;
            switch (baseTypeRef)
            {
                case null:
                    Assert.Fail("Could not get base type");
                    return null;

                case NamedTypeReference x:
                    if (!IsNewType(x, typeDefs))
                    {
                        if (x.FullName == "System.Object")
                        {
                            return null;
                        }
                        else
                        {
                            return x.Name;
                        }
                    }
                    else
                    {
                        typeDef = (ClassTypeDefinition)typeDefs[x.FullName];
                        continue;
                    }

                default:
                    Assert.Fail("Could not get base type");
                    return null;
            }
        }
    }

    private static string? GetWrappedObjectTypeName(
        InterfaceTypeDefinition typeDef)
    {
        var types = typeDef.Interfaces.OfType<NamedTypeReference>().ToList();
        while (RemoveIndirectInterfaces(types))
        {
        }

        if (types.Count == 1)
        {
            return types[0].Name;
        }
        else
        {
            return null;
        }

        static bool RemoveIndirectInterfaces(List<NamedTypeReference> typeRefs)
        {
            for (var i = 0; i < typeRefs.Count; i++)
            {
                var currTypeRef = typeRefs[i];

                for (var j = 0; j < i; j++)
                {
                    var prevTypeRef = typeRefs[j];
                    if (prevTypeRef.IsAssignableFrom(currTypeRef))
                    {
                        typeRefs.RemoveAt(j);
                        return true;
                    }
                    else if (currTypeRef.IsAssignableFrom(prevTypeRef))
                    {
                        typeRefs.RemoveAt(i);
                        return true;
                    }
                }
            }

            return false;
        }
    }

    private static bool IsNewType(TypeReference typeRef, IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        if (typeRef is not NamedTypeReference namedTypeRef)
        {
            return false;
        }

        return typeDefs.TryGetValue(namedTypeRef.FullName!, out var typeDef) && typeDef.AssemblyVersion != null;
    }

    private static bool IsEnumType(TypeReference typeRef, IReadOnlyDictionary<string, TypeDefinition> typeDefs)
    {
        if (typeRef is not NamedTypeReference namedTypeRef)
        {
            return false;
        }

        return typeDefs.TryGetValue(namedTypeRef.FullName!, out var typeDef) && typeDef is EnumTypeDefinition;
    }
}
