module Footer

open Feliz

open Config
open Style

[<ReactComponent>]
let Footer () =
    Html.div [ prop.className [ Style.``bg-nord5``
                                Style.``mt-auto`` ]
               prop.children [ Html.footer [ prop.className [ Style.``mx-auto``
                                                              Style.``lg:max-w-screen-lg``
                                                              Style.``text-center``
                                                              Style.``py-3`` ]
                                             prop.children [ Html.p (sprintf "© 2021 natsukium | %s" config.blogTitle) ] ] ] ]
