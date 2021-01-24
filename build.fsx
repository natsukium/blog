#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Target
nuget Fake.JavaScript.Yarn //"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators
open Fake.JavaScript

Target.initEnvironment ()

let dotnet cmd workDir =
    let result =
        DotNet.exec (DotNet.Options.withWorkingDirectory workDir) cmd ""

    if result.ExitCode <> 0 then
        failwithf "'dotnet %s' failed" cmd

let currentDir =
    System.IO.Directory.GetCurrentDirectory()

Target.create
    "Clean"
    (fun _ ->
        !! "src/**/bin"
        ++ "src/**/obj"
        ++ "build"
        ++ "pages"
        ++ "out"
        |> Shell.cleanDirs)

Target.create "Build" (fun _ -> !! "src/*.*proj" |> Seq.iter (DotNet.build id))

Target.create
    "Transpile"
    (fun _ ->
        let cmd = "fable src -o build"

        let currentDir =
            System.IO.Directory.GetCurrentDirectory()

        dotnet cmd currentDir)

let resolve () =
    !! "pages/**/*.js"
    |> Shell.regexReplaceInFilesWithEncoding
        @"import { (?<obj>(\w+,?\s?)+) } from ""(?<relpath>(\.\.\/)+)"
        @"import { ${obj} } from ""${relpath}build/"
        System.Text.Encoding.UTF8

    !! "pages/**/*.js"
    |> Shell.regexReplaceInFilesWithEncoding
        @"import ""\.\.\/(?<relpath>(\.\.\/)*[\w/]+\.css)"
        @"import ""${relpath}"
        System.Text.Encoding.UTF8

Target.create "Resolve" (fun _ -> resolve ())

let copy () =
    Directory.create "build/pages"
    Shell.copyDir "pages" "build/pages" (fun _ -> true)

Target.create "Copy" (fun _ -> copy ())

Target.create "BuildJS" (fun _ -> Yarn.exec "next build" (fun w -> { w with WorkingDirectory = currentDir }))

Target.create "Export" (fun _ -> Yarn.exec "next export" (fun w -> { w with WorkingDirectory = currentDir }))

Target.create "Serve" (fun _ -> Yarn.exec "dlx serve -s out" (fun w -> { w with WorkingDirectory = currentDir }))

Target.create
    "Dev"
    (fun _ ->
        let projectFile = Path.getFullName "./src/App.fsproj"

        let currentDir =
            System.IO.Directory.GetCurrentDirectory()

        let cmd =
            sprintf "watch --project %s fable -o ../build" projectFile

        let dotnet cmd workDir =
            let result =
                DotNet.exec (DotNet.Options.withWorkingDirectory workDir) cmd ""

            if result.ExitCode <> 0 then
                failwithf "'dotnet %s' failed" cmd

        let yarnDev =
            lazy (Yarn.exec "dev" (fun w -> { w with WorkingDirectory = currentDir }))

        let watch =
            lazy
                (use watcher =
                    !! "build/**/*.js"
                    |> ChangeWatcher.run
                        (fun changes ->
                            Directory.create "build/pages"
                            Shell.copyDir "pages" "build/pages" (fun _ -> true)

                            printfn "%A" changes

                            !! "pages/**/*.js"
                            |> Shell.regexReplaceInFilesWithEncoding
                                @"import { (?<obj>(\w+,?\s?)+) } from ""(?<relpath>(\.\.\/)+)"
                                @"import { ${obj} } from ""${relpath}build/"
                                System.Text.Encoding.UTF8

                            !! "pages/**/*.js"
                            |> Shell.regexReplaceInFilesWithEncoding
                                @"import ""\.\.\/(?<relpath>(\.\.\/)*[\w/]+\.css)"
                                @"import ""${relpath}"
                                System.Text.Encoding.UTF8)

                 System.Console.ReadLine() |> ignore

                 watcher.Dispose())

        // if there is not `pages_app.js` at the start, the dev server does not detect it
        dotnet "fable src -o build" currentDir
        copy ()
        resolve ()

        [ async { dotnet cmd currentDir }
          async { yarnDev.Force() }
          async { watch.Force() } ]
        |> Async.Parallel
        |> Async.RunSynchronously
        |> ignore)

Target.create "All" ignore

"Clean" ==> "Build"

"Clean" ==> "Dev"

"Clean"
==> "Transpile"
==> "Copy"
==> "Resolve"
==> "BuildJS"
==> "Export"
==> "All"

Target.runOrDefault "All"
