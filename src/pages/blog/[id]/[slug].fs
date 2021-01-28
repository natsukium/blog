module BlogPost

open Fable.Core.JsInterop
open Feliz

open Markdown
open Next
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
let Post (props: {| postData: obj |}) =
    Html.div [ Head [ Html.title (Html.text (props.postData?title: string)) ]
               Html.h1 (props.postData?title: string)
               Html.p [ Html.text (sprintf "Published at %s" (props.postData?published: string)) ]
               ((mdProcessor?processSync props.postData?contents))?result ]

let main = Post

exportDefault main
