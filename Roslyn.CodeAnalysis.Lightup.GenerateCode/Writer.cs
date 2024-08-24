// Fixed in StyleCop.Analyzes, but not yet released
#pragma warning disable SA1513 // Closing brace should be followed by blank line
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line

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

    private static readonly Dictionary<ParameterMode, string> ParameterModeText = new()
    {
        [ParameterMode.None] = "",
        [ParameterMode.Out] = "out ",
    };

    private static readonly HashSet<string> TypesToSkip =
    [
        // Irrelevant types related to source generators
        "Microsoft.CodeAnalysis.CSharp.CSharpGeneratorDriver",
        "Microsoft.CodeAnalysis.GeneratedSourceResult",
        "Microsoft.CodeAnalysis.GeneratorAttribute",
        "Microsoft.CodeAnalysis.GeneratorAttributeSyntaxContext",
        "Microsoft.CodeAnalysis.GeneratorDriver",
        "Microsoft.CodeAnalysis.GeneratorDriverOptions",
        "Microsoft.CodeAnalysis.GeneratorDriverRunResult",
        "Microsoft.CodeAnalysis.GeneratorDriverTimingInfo",
        "Microsoft.CodeAnalysis.GeneratorExecutionContext",
        "Microsoft.CodeAnalysis.GeneratorInitializationContext",
        "Microsoft.CodeAnalysis.GeneratorPostInitializationContext",
        "Microsoft.CodeAnalysis.GeneratorRunResult",
        "Microsoft.CodeAnalysis.GeneratorSyntaxContext",
        "Microsoft.CodeAnalysis.GeneratorTimingInfo",
        "Microsoft.CodeAnalysis.IIncrementalGenerator",
        "Microsoft.CodeAnalysis.IncrementalGeneratorInitializationContext",
        "Microsoft.CodeAnalysis.IncrementalGeneratorOutputKind",
        "Microsoft.CodeAnalysis.IncrementalGeneratorPostInitializationContext",
        "Microsoft.CodeAnalysis.IncrementalGeneratorRunStep",
        "Microsoft.CodeAnalysis.IncrementalStepRunReason",
        "Microsoft.CodeAnalysis.ISourceGenerator",
        "Microsoft.CodeAnalysis.ISyntaxContextReceiver",
        "Microsoft.CodeAnalysis.ISyntaxReceiver",
        "Microsoft.CodeAnalysis.SourceProductionContext",
        "Microsoft.CodeAnalysis.SyntaxContextReceiverCreator",
        "Microsoft.CodeAnalysis.SyntaxReceiverCreator",

        // Irrelevant types related to diagnostic suppressors
        "Microsoft.CodeAnalysis.Diagnostics.DiagnosticSuppressor",
        "Microsoft.CodeAnalysis.Diagnostics.Suppression",
        "Microsoft.CodeAnalysis.Diagnostics.SuppressionAnalysisContext",
        "Microsoft.CodeAnalysis.SuppressionDescriptor",
    ];

    internal static void Write(IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs, string rootPath)
    {
        foreach (var assemblyKind in Enum.GetValues<AssemblyKind>())
        {
            Write(typeDefs, rootPath, assemblyKind);
        }
    }

    private static void Write(
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs,
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

    private static string GetTargetNamespace(BaseTypeDefinition typeDef)
    {
        var sourceNamespace = typeDef.Namespace!;
        var targetNamespace = sourceNamespace + ".Lightup";
        return targetNamespace;
    }

    private static (string Name, string Source)? GenerateType(
        BaseTypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs,
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
                // TODO: Handle updated structs as well
                return null;
            }
            else
            {
                return GenerateWrapper(structTypeDef, typeDefs, targetNamespace);
            }
        }
        else if (typeDef is ClassTypeDefinition classTypeDef)
        {
            if (typeDef.AssemblyVersion == null)
            {
                // TODO: Handle updated classes as well
                return null;
            }
            else if (classTypeDef.IsStatic)
            {
                // TODO: Handle static classes as well
                return null;
            }
            else
            {
                return GenerateWrapper(classTypeDef, typeDefs, targetNamespace);
            }
        }
        else if (typeDef is InterfaceTypeDefinition interfaceTypeDef)
        {
            if (typeDef.AssemblyVersion == null)
            {
                // TODO: Handle updated interfaces as well
                return null;
            }
            else
            {
                return GenerateWrapper(interfaceTypeDef, typeDefs, targetNamespace);
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

    private static (string Name, string Source) GenerateWrapper(
        TypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs,
        string targetNamespace)
    {
        var targetName = typeDef.Name + "Wrapper";

        // TODO: Handle static members
        var instanceProperties = GetInstanceProperties(typeDef);
        var instanceIndexers = GetInstanceIndexers(typeDef);
        Assert.IsTrue(instanceIndexers.Count == 0, "Unexpected indexers");
        var instanceMethods = GetInstanceMethods(typeDef);

        var baseTypeName = GetBaseTypeName(typeDef, typeDefs);
        var hasBaseType = baseTypeName != null && typeDef is not InterfaceTypeDefinition;
        baseTypeName ??= "object";

        var sb = new StringBuilder();

        sb.AppendLine($"// <auto-generated/>");
        sb.AppendLine();
        sb.AppendLine($"#nullable enable");
        sb.AppendLine();
        AppendUsingStatements(sb, typeDef);
        sb.AppendLine();
        sb.AppendLine($"namespace {targetNamespace}");
        sb.AppendLine($"{{");
        sb.AppendLine($"    /// <summary>{GetTypeKind(typeDef)} added in Roslyn version {typeDef.AssemblyVersion}</summary>");
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
                AppendPropertyDelegateDeclarations(sb, property, baseTypeName, typeDefs);
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                AppendMethodDelegateDeclaration(sb, method, baseTypeName, index, typeDefs);
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
                sb.AppendLine($"            {property.Name}GetterFunc = LightupHelper.CreateGetAccessor<{property.Name}GetterDelegate>(WrappedType, nameof({property.Name}));");
                if (property.HasSetter)
                {
                    sb.AppendLine($"            {property.Name}SetterFunc = LightupHelper.CreateSetAccessor<{property.Name}SetterDelegate>(WrappedType, nameof({property.Name}));");
                }
            }
        }
        if (instanceMethods.Count != 0)
        {
            sb.AppendLine();
            foreach (var method in instanceMethods)
            {
                var index = instanceMethods.IndexOf(method);
                sb.AppendLine($"            {method.Name}Func{index} = LightupHelper.CreateMethodAccessor<{method.Name}Delegate{index}>(WrappedType, nameof({method.Name}));");
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
            sb.AppendLine($"        public readonly {GetMethodReturnTypeDeclText(methodDef, typeDefs)} {methodDef.Name}({GetParametersDeclText(methodDef.Parameters, typeDefs)})");
            sb.AppendLine($"            => {methodDef.Name}Func{index}({GetArgumentsText(methodDef)});");
        }
        sb.AppendLine($"    }}");
        sb.AppendLine($"}}");

        var source = sb.ToString();
        return (targetName, source);
    }

    private static string GetTypeKind(TypeDefinition typeDef)
    {
        return typeDef switch
        {
            ClassTypeDefinition => "Class",
            InterfaceTypeDefinition => "Interface",
            StructTypeDefinition => "Struct",
            _ => throw new NotImplementedException(),
        };
    }

    private static string? GetBaseTypeName(
        TypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        return typeDef switch
        {
            ClassTypeDefinition x => GetBaseTypeName(x, typeDefs),
            InterfaceTypeDefinition x => GetBaseTypeName(x),
            StructTypeDefinition => null,
            _ => throw new NotImplementedException(),
        };
    }

    private static string? GetBaseTypeName(
        ClassTypeDefinition typeDef,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
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

    private static string? GetBaseTypeName(
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

    private static List<PropertyDefinition> GetInstanceProperties(TypeDefinition typeDef)
    {
        var result = typeDef.Properties
            .Where(x => !x.IsStatic)
            .ToList();
        return result;
    }

    private static List<IndexerDefinition> GetInstanceIndexers(TypeDefinition typeDef)
    {
        var result = typeDef.Indexers
            .Where(x => !x.IsStatic)
            .ToList();
        return result;
    }

    private static List<MethodDefinition> GetInstanceMethods(TypeDefinition typeDef)
    {
        var result = typeDef.Methods
            .Where(x => !x.IsStatic)
            .ToList();
        return result;
    }

    private static void AppendUsingStatements(StringBuilder sb, BaseTypeDefinition typeDef)
    {
        sb.AppendLine($"using System;");
        sb.AppendLine($"using System.Collections.Generic;");
        sb.AppendLine($"using System.Collections.Immutable;");
        sb.AppendLine($"using System.Threading;");
        sb.AppendLine($"using System.Threading.Tasks;");

        switch (typeDef.AssemblyKind)
        {
            case AssemblyKind.Common:
                sb.AppendLine($"using Microsoft.CodeAnalysis.Lightup;");
                sb.AppendLine($"using Microsoft.CodeAnalysis.Text;");
                break;

            case AssemblyKind.CSharp:
                sb.AppendLine($"using Microsoft.CodeAnalysis.Lightup;");
                break;

            case AssemblyKind.Workspaces:
                sb.AppendLine($"using Microsoft.CodeAnalysis.CodeActions;");
                sb.AppendLine($"using Microsoft.CodeAnalysis.Host;");
                sb.AppendLine($"using Microsoft.CodeAnalysis.Lightup;");
                sb.AppendLine($"using Microsoft.CodeAnalysis.Text;");
                break;

            case AssemblyKind.CSharpWorkspaces:
                break;

            default:
                throw new NotImplementedException();
        }
    }

    private static void AppendPropertyDelegateDeclarations(
        StringBuilder sb,
        PropertyDefinition propertyDef,
        string baseTypeName,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetPropertyTypeDeclText(propertyDef, typeDefs));
        sb.AppendLine($" {propertyDef.Name}GetterDelegate({baseTypeName}? _obj);");

        if (propertyDef.HasSetter)
        {
            sb.Append($"        private delegate void ");
            sb.Append($"{propertyDef.Name}SetterDelegate({baseTypeName}? _obj, ");
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

    private static void AppendMethodDelegateDeclaration(
        StringBuilder sb,
        MethodDefinition methodDef,
        string baseTypeName,
        int index,
        IReadOnlyDictionary<string, BaseTypeDefinition> typeDefs)
    {
        sb.Append($"        private delegate ");
        sb.Append(GetMethodReturnTypeDeclText(methodDef, typeDefs));
        sb.Append($" {methodDef.Name}Delegate{index}({baseTypeName}? _obj");
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
        bool addLeadingComma = false)
    {
        var sb = new StringBuilder();
        foreach (var parameter in parameters)
        {
            sb.Append(sb.Length > 0 || addLeadingComma ? ", " : "");
            sb.Append(parameter.IsParams ? "params " : "");
            sb.Append(ParameterModeText[parameter.Mode]);
            sb.Append(GetParameterTypeDeclText(parameter, typeDefs));
            sb.Append(' ');
            sb.Append(GetParameterNameText(parameter.Name));
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
        MethodDefinition methodDef)
    {
        var sb = new StringBuilder();
        sb.Append("wrappedObject");
        foreach (var parameterDef in methodDef.Parameters)
        {
            sb.Append($", ");
            sb.Append(ParameterModeText[parameterDef.Mode]);
            sb.Append(GetParameterNameText(parameterDef.Name));
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

    private static string GetTargetFolder(BaseTypeDefinition typeDef, string targetProjectPath)
    {
        var sourceNamespace = typeDef.Namespace!;
        var targetNamespace = sourceNamespace + ".Lightup";
        var targetFolder = targetNamespace.Replace("Microsoft.CodeAnalysis", "").TrimStart('.').Replace('.', Path.DirectorySeparatorChar);
        return Path.Combine(targetProjectPath, targetFolder);
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
