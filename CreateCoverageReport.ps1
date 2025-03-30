# To install the used tool: dotnet tool install -g dotnet-reportgenerator-globaltool

reportgenerator -reports:test\TestResult\**\coverage.cobertura.xml -targetdir:test\TestReport
