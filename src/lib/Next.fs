module Next

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz

let link: obj = importDefault "next/link"
let head: obj = importDefault "next/head"

type Link =
    static member inline link(props: IReactProperty seq) =
        Interop.reactApi.createElement (link, createObj !!props)

    static member inline link((props: IReactProperty seq), (child: ReactElement)) =
        Interop.reactApi.createElement (link, createObj !!props, [ child ]) // Make the child behave like ReactElement

    static member inline href(path: string) = Interop.mkAttr "href" path

    static member inline passHref = Interop.mkAttr "passHref" true

    static member inline children
        (child: ReactElementType<{| href: string
                                    onClick: Browser.Types.MouseEvent -> unit |}>)
        =
        Interop.reactApi.createElement (!!child, null)

let inline Head props =
    Interop.reactApi.createElement (head, null, props)

[<ImportDefault("next/document")>]
type Document() =
    abstract member render: unit -> ReactElement
    default this.render() = jsNative

// abstract member get: unit -> string
type Doc =
    static member inline Head props =
        let head: obj = import "Head" "next/document"
        Interop.reactApi.createElement (head, null, props)

    static member inline Html props =
        let html: obj = import "Html" "next/document"
        Interop.reactApi.createElement (html, null, props)

    static member inline Main props =
        let main: obj = import "Main" "next/document"
        Interop.reactApi.createElement (main, null, props)

    static member inline NextScript props =
        let nextScript: obj = import "NextScript" "next/document"
        Interop.reactApi.createElement (nextScript, null, props)
