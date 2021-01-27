module BlogPost

open Fable.Core.JsInterop
open Feliz

open Posts

let getStaticPaths () =
    promise {
        return
            {| paths = getAllPostIdsSlugs ()
               fallback = false |}
    }

let getStaticProps (``params``: {| ``params``: {| id: string; slug: string |} |}) =
    promise { return {| props = {| postData = getPostData ``params``.``params``.id |} |} }

[<ReactComponent>]
let Post (props: {| postData: obj |}) = Html.h1 (props.postData?title: string)

let main = Post

exportDefault main
