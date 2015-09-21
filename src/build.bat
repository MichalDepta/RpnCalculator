@echo off
rem .\nuget.exe install FAKE -OutputDirectory "packages" -ExcludeVersion
.\packages\FAKE\tools\FAKE.exe build.fsx %*