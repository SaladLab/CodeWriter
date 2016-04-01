@echo off

pushd %~dp0

SET PACKAGEPATH=.\packages\_\
SET NUGET=.\tools\nuget\NuGet.exe
SET NUGETOPTIONS=-ConfigFile .\tools\nuget\NuGet.Config -OutputDirectory %PACKAGEPATH% -ExcludeVersion

IF NOT EXIST %PACKAGEPATH%FAKE (
  %NUGET% install FAKE -Version 4.23.0 %NUGETOPTIONS%
)

IF NOT EXIST %PACKAGEPATH%FAKE.BuildLib (
  %NUGET% install FAKE.BuildLib -Version 0.1.0 %NUGETOPTIONS%
)

IF NOT EXIST %PACKAGEPATH%xunit.runner.console (
  %NUGET% install xunit.runner.console -Version 2.1.0 %NUGETOPTIONS%
)

IF NOT EXIST %PACKAGEPATH%OpenCover (
  %NUGET% install OpenCover -Version 4.6.519 %NUGETOPTIONS%
)

IF NOT EXIST %PACKAGEPATH%coveralls.io (
  %NUGET% install coveralls.io -Version 1.3.4 %NUGETOPTIONS%
)

IF NOT EXIST %PACKAGEPATH%PublishCoverity (
  %NUGET% install PublishCoverity -Version 0.11.0 %NUGETOPTIONS%
)

set encoding=utf-8
packages\_\FAKE\tools\FAKE.exe build.fsx %*

popd
