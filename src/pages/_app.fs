module Init

open Fable.Core.JsInterop
open Feliz

open NavBar
open Footer
open Style

importSideEffects "../../public/static/styles/tailwind.css"

[<ReactComponent>]
let MyApp
    (props: {| Component: ReactElement
               pageProps: ReactElement |})
    =
    Html.div [ prop.className [ Style.flex
                                Style.``flex-col``
                                Style.``min-h-screen`` ]
               prop.children [ NavBar()
                               Interop.reactApi.createElement (props.Component, props.pageProps)
                               Footer() ] ]

exportDefault MyApp
