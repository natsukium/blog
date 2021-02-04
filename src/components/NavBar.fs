module NavBar

open Feliz

open Config
open Next
open Style

[<ReactComponent>]
let NavBar () =
    Html.div [ prop.className Style.``bg-nord5``
               prop.children [ Html.nav [ prop.className [ Style.``mx-auto``
                                                           Style.``p-2``
                                                           Style.``lg:max-w-screen-lg`` ]
                                          prop.children [ Link.link (
                                                              [ Link.href "/"; Link.passHref ],
                                                              Html.a [ Html.span [ prop.className [ Style.``font-semibold``
                                                                                                    Style.``hover:text-nord8`` ]
                                                                                   prop.text config.blogTitle ] ]
                                                          ) ] ] ] ]
