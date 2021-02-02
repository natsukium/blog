module Blog

open Fable.Core.JsInterop
open Feliz

open Card
open Config
open Layout
open Next
open Posts
open Style

let getStaticProps () =
    promise {
        let allPostsData = getSortedPostsData ()
        return {| props = {| allPostsData = allPostsData |} |}
    }

[<ReactComponent>]
let Posts (props: {| allPostsData: array<obj> |}) =
    Layout
        {| children =
               [ Html.div [ Head [ Html.title (Html.text (sprintf "Articles | %s" config.blogTitle)) ]
                            Html.h1 [ prop.className ""
                                      prop.text "Articles" ]
                            Html.ul [ prop.className ""
                                      prop.children (
                                          props.allPostsData
                                          |> Array.map
                                              (fun (data: obj) ->
                                                  Html.li [ prop.className ""
                                                            prop.key (data?id: string)
                                                            prop.children [ Link.link (
                                                                                [ Link.href (
                                                                                    sprintf
                                                                                        "/blog/%s/%s"
                                                                                        (data?id: string)
                                                                                        (data?slug: string)
                                                                                  )
                                                                                  Link.passHref ],
                                                                                Link.children (
                                                                                    Card
                                                                                        {| title = data?title
                                                                                           description =
                                                                                               data?description
                                                                                           date =
                                                                                               data?published?slice (0,
                                                                                                                     10) |}
                                                                                )
                                                                            ) ] ])
                                      ) ] ] ] |}

let main = Posts

exportDefault main
