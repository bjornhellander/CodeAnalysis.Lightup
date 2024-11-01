# Roslyn.CodeAnalysis.Lightup

## Limitations

- Generic types are not handled.
- Generic members are not handled.
- Some other types, mostly related to source generators and diagnostic suppressors, are not generated.
- SeparatedSyntaxListWrapper is incomplete.
- C# 8.0 is required in the target project(s).
- Version 3.0.0 is required of the Microsoft.CodeAnalysis packages in the target project(s).

## Troubleshooting

### Generated types are not updated properly

If any changes has been made in the generator project, including updating the Types.xml file,
Visual Studio must be restarted for the changes to take effect.

### Problems related to long file paths

Enable support for long file paths in Git by running:

```bash
git config core.longpaths true
