module Next

open Fable.Core.JsInterop
open Feliz

let link: obj = importDefault "next/link"
let head: obj = importDefault "next/head"

type Link =
    static member inline link props =
        Interop.reactApi.createElement (link, createObj !!props)

    static member inline href(path: string) = Interop.mkAttr "href" path

let inline Head props =
    Interop.reactApi.createElement (head, null, props)
