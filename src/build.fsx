#r "./packages/FAKE/tools/FakeLib.dll"

open Fake

let allProjects = !! "./*/*.csproj"
let nonTestProjects = !! "./*/*.csproj"
                        -- "./*/*Test*.csproj"

Target "Build" (fun () ->
    allProjects
    |> Seq.iter trace
)

Target "Test" (fun () ->
    nonTestProjects
    |> Seq.iter trace
)

"Build" ==> "Test"

RunTarget()