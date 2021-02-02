module Config

type IConfig =
    abstract member blogTitle: string

let config: IConfig =
    Fable.Core.JsInterop.importDefault "../../config.js"
