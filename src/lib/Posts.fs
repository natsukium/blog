module Posts

open Fable.Core
open Fable.Core.JsInterop
open Node.Api

open Markdown

let postsDirectory =
    path.join (``process``.cwd (), "post/posts")

let parseFrontMatter (path: string) =
    let mutable fileContents: obj = toVfile?readSync path
    Vfile.Matter fileContents
    JS.JSON.parse (JS.JSON.stringify fileContents?data?matter)

let getSortedPostsData () =
    fs.readdirSync (U2.Case1 postsDirectory)
    |> Seq.cast
    |> Seq.toArray
    |> Array.map
        (fun (fileName: string) ->
            let id = fileName.Replace(".md", "")
            let fullPath = path.join (postsDirectory, fileName)
            JS.Constructors.Object.assign ({| id = id |}, parseFrontMatter fullPath))
    |> Array.sortBy (fun x -> x?id)

let getAllPostIdsSlugs () =
    getSortedPostsData ()
    |> Array.map
        (fun (matter: obj) ->
            {| ``params`` =
                   {| id = (matter?id: string)
                      slug = (matter?slug: string) |} |})

let getPostData id =
    let fullPath =
        path.join (postsDirectory, sprintf "%s.md" id)

    let mutable fileContents: obj = toVfile?readSync fullPath

    Vfile.Matter(fileContents, createObj [ "strip" ==> true ])

    let contents = string fileContents?contents

    JS.Constructors.Object.assign ({| id = id; contents = contents |}, parseFrontMatter fullPath)
