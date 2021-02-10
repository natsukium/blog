module App

open Fable.Core.JsInterop
open Feliz

open Config
open Next
open Style

[<ReactComponent>]
let Home () =
    Html.div [ Head [ Html.title (Html.text config.blogTitle)
                      Html.link [ prop.rel "icon"

                                  prop.href "/favicon.ico" ]
                      Html.link [ prop.rel "stylesheet"
                                  prop.href "/static/styles/icomoon/style.css" ] ]
               Html.main [ prop.className [ Style.``h-screen``
                                            Style.flex
                                            Style.``flex-col``
                                            Style.``md:flex-row``
                                            Style.``md:justify-evenly`` ]
                           prop.children [ Html.div [ prop.className [ Style.``text-center``
                                                                       Style.``my-auto`` ]
                                                      prop.children [ Html.h1 [ prop.className [ Style.``mb-4`` ]
                                                                                prop.text "Natsukium" ]
                                                                      Html.p [ prop.className [ "" ]
                                                                               prop.text "Machine Learning Engineer" ]
                                                                      Html.p [ prop.className [ "" ]
                                                                               prop.text "(Bio|Chem)informatician" ]
                                                                      Html.div [ prop.className [ Style.``mt-4`` ]
                                                                                 prop.children [ Html.a [ prop.href
                                                                                                              "https://twitter.com/Pavane1899"
                                                                                                          prop.children [ Html.span [ Html.i [ prop.className [ "icon-twitter"
                                                                                                                                                                Style.``mx-1``
                                                                                                                                                                Style.``hover:text-nord8`` ] ] ] ] ]
                                                                                                 Html.a [ prop.href
                                                                                                              "https://github.com/natsukium"
                                                                                                          prop.children [ Html.span [ Html.i [ prop.className [ "icon-github"
                                                                                                                                                                Style.``mx-1``
                                                                                                                                                                Style.``hover:text-nord8`` ] ] ] ] ] ] ] ] ]
                                           Html.div [ prop.className [ Style.``text-center``
                                                                       Style.``my-auto`` ]
                                                      prop.children [ Html.div [ Html.h2 [ prop.className [ Style.``text-3xl``
                                                                                                            Style.``my-4``
                                                                                                            Style.``py-4`` ]
                                                                                           prop.text "About" ] ]
                                                                      Html.div [ Link.link (
                                                                                     [ Link.href "/blog"
                                                                                       Link.passHref ],

                                                                                     Html.a [ Html.h2 [ prop.className [ Style.``text-3xl``
                                                                                                                         Style.``hover:text-nord8``
                                                                                                                         Style.``my-4``
                                                                                                                         Style.``py-4`` ]
                                                                                                        prop.text "Blog" ] ]
                                                                                 ) ] ] ] ] ] ]

let main = Home

main |> exportDefault
