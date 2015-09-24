#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.MSBuildHelper
open Fake.NUnitSequential
open Fake.AssemblyInfoFile

let majorVersion = 1
let minorVersion = 0

let solutionFile = !!"RpnCalculator.sln"
let testDlls = !!"./*Tests/bin/Release/*Tests.dll"
let rpnConsoleAssemblyInfo = "./RpnConsole/Properties/AssemblyInfo.cs"

Target "Clean" (fun _ ->
    solutionFile
    |> MSBuildRelease null "Clean"
    |> ignore
)

Target "RestorePackages" (fun _ ->
    RestorePackages()
)

Target "Build" (fun _ ->
    solutionFile
    |> MSBuildRelease null "Build"
    |> ignore
)

Target "Test" (fun _ ->
    testDlls
    |> NUnit (fun defaults -> 
                {defaults with 
                    OutputFile = "TestResult.xml"
                    ErrorLevel = DontFailBuild
                })
)

Target "UpdateVersion" (fun _ ->
    let productVersion = 
        getBuildParam "BuildNumber"
        |> sprintf "%d.%d.%s" majorVersion minorVersion

    CreateCSharpAssemblyInfo rpnConsoleAssemblyInfo
        [
            Attribute.Title "RpnConsole"
            Attribute.Description "RPN Calculator Console App"
            Attribute.Version productVersion
            Attribute.FileVersion productVersion
            Attribute.Company "FDD"
            Attribute.Copyright "Copyright © FDD 2015"
        ]
)

"Clean"
=?> ("Build", hasBuildParam "Clean")

"UpdateVersion"
=?> ("Build", hasBuildParam "BuildNumber")

"RestorePackages"
==> "Build"
==> "Test"

RunTargetOrDefault "Build"