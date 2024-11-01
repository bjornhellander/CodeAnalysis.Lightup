# Roslyn.CodeAnalysis.Lightup

## Troubleshooting

### Generated types are not updated properly

If any changes has been made in the generator project, including updating the Types.xml file,
Visual Studio must be restarted for the changes to take effect.

### Problems related to long file paths

Enable support for long file paths in Git by running:

```bash
git config core.longpaths true
