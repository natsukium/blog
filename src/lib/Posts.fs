module Posts

open Fable.Core
open Fable.Core.JsInterop
open Node.Api

open Markdown

let postsDirectory =
    path.join (``process``.cwd (), "post/posts")

let getSortedPostsData () =
    fs.readdirSync (U2.Case1 postsDirectory)
    |> Seq.cast
    |> Seq.toArray
    |> Array.map
        (fun (fileName: string) ->
            let id = fileName.Replace(".md", "")
            let fullPath = path.join (postsDirectory, fileName)
            let mutable fileContents = toVfile?readSync fullPath
            vfileMatter fileContents |> ignore
            JS.Constructors.Object.assign ({| id = id |}, JS.JSON.parse (JS.JSON.stringify fileContents?data?matter)))
    |> Array.sortBy (fun x -> x?id)
