module Init

open Fable.Core.JsInterop
open Feliz

importSideEffects "../../static/styles/globals.css"


[<ReactComponent>]
let MyApp
    (props: {| Component: ReactElement
               pageProps: ReactElement |})
    =
    Interop.reactApi.createElement (props.Component, props.pageProps)

exportDefault MyApp
