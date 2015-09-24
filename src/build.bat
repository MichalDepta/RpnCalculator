@echo off

rem Install FAKE package
rem .\nuget.exe install FAKE -OutputDirectory "packages" -ExcludeVersion

rem Invoke FAKE and execute build script passing all input args
.\packages\FAKE\tools\FAKE.exe build.fsx %*