## RoslynLightup001 - Missing configuration file

## Cause

The project needs at least one configuration file to be able to use the source generator.

## How to fix violations

To fix a violation of this rule, add at least one file with name matching 'CodeAnalysis.Lightup*.json', with build action 'C# analyzer additional file'.
