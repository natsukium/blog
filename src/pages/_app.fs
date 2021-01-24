module Init

open Fable.Core.JsInterop
open Feliz

importSideEffects "../../static/styles/tailwind.css"

[<ReactComponent>]
let MyApp
    (props: {| Component: ReactElement
               pageProps: ReactElement |})
    =
    Interop.reactApi.createElement (props.Component, props.pageProps)

exportDefault MyApp
