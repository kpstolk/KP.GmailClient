language: csharp
solution: GmailApi.sln
install:
  - nuget restore GmailApi.sln
  - nuget install NUnit.Runners -Version 2.6.4 -OutputDirectory testrunner
script:
  - xbuild /p:Configuration=Release GmailApi.sln
  - mono ./testrunner/NUnit.Runners.2.6.4/tools/nunit-console.exe ./UnitTests/bin/Release/UnitTests.dll
