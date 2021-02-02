module BlogPost

open Fable.Core.JsInterop
open Feliz

open Config
open Layout
open Markdown
open Next
open Posts
open Style

let getStaticPaths () =
    promise {
        return
            {| paths = getAllPostIdsSlugs ()
               fallback = false |}
    }

let getStaticProps (``params``: {| ``params``: {| id: string; slug: string |} |}) =
    promise { return {| props = {| postData = getPostData ``params``.``params``.id |} |} }

[<ReactComponent>]
let Post (props: {| postData: obj |}) =
    Layout
        {| children =
               [ Html.div [ Head [ Html.title (
                                       Html.text (sprintf "%s | %s" (props.postData?title: string) config.blogTitle)
                                   ) ]
                            Html.h1 (props.postData?title: string)
                            Html.p [ Html.text (sprintf "Published at %s" (props.postData?published: string)) ]
                            ((mdProcessor?processSync props.postData?contents))?result ] ] |}

let main = Post

exportDefault main
