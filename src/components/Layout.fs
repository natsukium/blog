module Layout

open Feliz

open Style

[<ReactComponent>]
let Layout (props: {| children: list<ReactElement> |}) =
    Html.div [ prop.className [ Style.container
                                Style.``mx-auto``
                                Style.``px-2`` ]
               prop.children props.children ]
