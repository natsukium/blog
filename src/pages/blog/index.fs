module Blog

open Fable.Core.JsInterop
open Feliz

open Posts

let getStaticProps () =
    promise {
        let allPostsData = getSortedPostsData ()
        return {| props = {| allPostsData = allPostsData |} |}
    }

[<ReactComponent>]
let Posts (props: {| allPostsData: array<obj> |}) =
    Html.section [ prop.className ""
                   prop.children [ Html.h1 [ prop.className ""
                                             prop.text "Articles" ]
                                   Html.ul [ prop.className ""
                                             prop.children (
                                                 props.allPostsData
                                                 |> Array.map
                                                     (fun (data: obj) ->
                                                         Html.li [ prop.className ""
                                                                   prop.key (data?id: string)
                                                                   prop.children [ Html.text (data?title: string)
                                                                                   Html.br []
                                                                                   Html.text (data?description: string)
                                                                                   Html.br []
                                                                                   Html.text (
                                                                                       sprintf "tags: %s" data?tags: string
                                                                                   )
                                                                                   Html.br []
                                                                                   Html.text (data?published: string) ] ])
                                             ) ] ] ]

let main = Posts

exportDefault main
