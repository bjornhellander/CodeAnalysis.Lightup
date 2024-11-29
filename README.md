# CodeAnalysis.Lightup

## Limitations

- Generic types are not handled.
- Generic members are not handled.
- Some types, mostly related to source generators and diagnostic suppressors, are not handled.
- SeparatedSyntaxListWrapper is incomplete.
- C# 8.0 is required in the target project(s).
- Version 3.0.0 of the Microsoft.CodeAnalysis packages is required in the target project(s).

## Troubleshooting

### Problems related to long file paths

Enable support for long file paths in Git by running:

```bash
git config core.longpaths true
