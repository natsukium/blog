module Init

open Fable.Core.JsInterop
open Feliz

open NavBar

importSideEffects "../../public/static/styles/tailwind.css"

[<ReactComponent>]
let MyApp
    (props: {| Component: ReactElement
               pageProps: ReactElement |})
    =
    Html.div [ NavBar()
               Interop.reactApi.createElement (props.Component, props.pageProps) ]

exportDefault MyApp
