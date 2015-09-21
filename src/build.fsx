#r "./packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.MSBuildHelper
open Fake.NUnitSequential

let solutionFile = !!"RpnCalculator.sln"
let testDlls = !!"./*Tests/*Tests.dll"

Target "Hello" (fun _ -> 
    trace "Hello from FAKE"
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
                    OutputFile = "test-results.xml"
                    ErrorLevel = DontFailBuild
                })
)

Target "Clean" (fun _ ->
    solutionFile
    |> MSBuildRelease null "Clean"
    |> ignore
)

"Clean"
=?> ("Build", hasBuildParam "Clean")

RunTargetOrDefault "Hello"