module App

open Fable.Core.JsInterop
open Feliz
open Zanaptak.TypedCssClasses

open Config
open Next
open Style

[<ReactComponent>]
let Card
    (props: {| href: string
               title: string
               text: string |})
    =
    Html.a [ prop.href props.href
             prop.className [ Style.card ]
             prop.children [ Html.h3 props.title
                             Html.p props.text ] ]

[<ReactComponent>]
let Home () =
    Html.div [ prop.className [ Style.container ]
               prop.children [ Head [ Html.title (Html.text config.blogTitle)
                                      Html.link [ prop.rel "icon"
                                                  prop.href "/favicon.ico" ] ]
                               Html.main [ prop.className [ Style.main ]
                                           prop.children [ Html.h1 [ prop.className [ Style.title ]
                                                                     prop.children [ Html.text "Welcom to "
                                                                                     Html.a [ prop.href
                                                                                                  "https://nextjs.org"
                                                                                              prop.text "Next.js!" ] ] ]
                                                           Html.p [ prop.className [ Style.description ]
                                                                    prop.children [ Html.text "Get started by editing  "
                                                                                    Html.code [ prop.className
                                                                                                    Style.code
                                                                                                prop.text
                                                                                                    "src/pages/index.fs" ] ] ]
                                                           Html.div [ prop.className [ Style.grid ]
                                                                      prop.children [ Card
                                                                                          {| href =
                                                                                                 "https://nextjs.org/docs"
                                                                                             title = "Documentation"
                                                                                             text =
                                                                                                 "Find in-depth information about Next.js features and API." |}
                                                                                      Card
                                                                                          {| href =
                                                                                                 "https://nextjs.org/learn"
                                                                                             title = "Learn"
                                                                                             text =
                                                                                                 "Learn about Next.js in an interactive course with quizzes!" |}
                                                                                      Card
                                                                                          {| href =
                                                                                                 "https://github.com/vercel/next.js/tree/master/examples"
                                                                                             title = "Examples"
                                                                                             text =
                                                                                                 "Discover and deploy boilerplate example Next.js projects." |}
                                                                                      Card
                                                                                          {| href =
                                                                                                 "https://vercel.com/new?utm_source=create-next-app&utm_medium=default-template&utm_campaign=create-next-app"
                                                                                             title = "Deploy"
                                                                                             text =
                                                                                                 "Instantly deploy your Next.js site to a public URL with Vercel." |} ] ] ] ]
                               Html.footer [ prop.className Style.footer
                                             prop.children [ Html.a [ prop.href
                                                                          "https://vercel.com?utm_source=vreate-next-app&utm_medium=default-template&utm_campaign=create-next-app"
                                                                      prop.target "_blank"
                                                                      prop.rel "noopener noreferrer"
                                                                      prop.children [ Html.text "Powered by "
                                                                                      Html.img [ prop.src "/vercel.svg"
                                                                                                 prop.alt "Vercel Logo"
                                                                                                 prop.className
                                                                                                     Style.logo ] ] ] ] ] ] ]

Home |> exportDefault
