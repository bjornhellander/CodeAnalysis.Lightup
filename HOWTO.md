# Create and publish nuget package

powershell .\ReleaseNuget.ps1 -Runtime -Generator -ApiKey XYZ

# Troubleshooting

Also see the troubleshooting section in README.md

## Generated types are not updated properly

If any changes has been made in the generator project, including updating the Types.xml file,
Visual Studio might need to be restarted for the changes to take effect. Seems to work without it most of the time.
