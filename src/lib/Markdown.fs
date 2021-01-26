module Markdown

open Fable.Core.JsInterop

let toVfile: obj = importDefault "to-vfile"
let vfileMatter: obj -> obj = importDefault "vfile-matter"
