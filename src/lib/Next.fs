module Next

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
