@echo off

pushd %~dp0

tools\nuget\NuGet.exe update -self
tools\nuget\NuGet.exe install FAKE -ConfigFile tools\nuget\Nuget.Config -OutputDirectory packages -ExcludeVersion -Version 4.22.6
tools\nuget\NuGet.exe install xunit.runner.console -ConfigFile tools\nuget\Nuget.Config -OutputDirectory packages\FAKE -ExcludeVersion -Version 2.1.0
tools\nuget\NuGet.exe install OpenCover -ConfigFile tools\nuget\Nuget.Config -OutputDirectory packages -ExcludeVersion -Version 4.6.519
tools\nuget\NuGet.exe install coveralls.io -ConfigFile tools\nuget\Nuget.Config -OutputDirectory packages -ExcludeVersion -Version 1.3.4

set encoding=utf-8
packages\FAKE\tools\FAKE.exe build.fsx %*

popd
