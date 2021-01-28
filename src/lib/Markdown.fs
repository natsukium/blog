module Markdown

open Fable.Core.JsInterop

type Vfile =
    static member inline Matter(x: obj): unit = importDefault "vfile-matter"
    static member inline Matter(x: obj, y: obj): unit = importDefault "vfile-matter"

let toVfile: obj = importDefault "to-vfile"

let unified: unit -> obj = importDefault "unified"
let remarkParse: obj = importDefault "remark-parse"
let remarkRehype: obj = importDefault "remark-rehype"
let rehypeReact: obj = importDefault "rehype-react"

let mdProcessor: obj =
    let react = importDefault "react"

    (((unified ())?``use`` (remarkParse))?``use`` (remarkRehype))?``use`` (rehypeReact,
                                                                           {| createElement = react?createElement |})
