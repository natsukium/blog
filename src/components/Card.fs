module Card

open Fable.Core.JsInterop
open Fable.React
open Feliz

open Style

let Card
    (props: {| title: string
               description: string
               date: string |})
    =
    ReactBindings.React.forwardRef
        (fun (p: {| onClick: Browser.Types.MouseEvent -> unit
                    href: string |}) (ref: IRefValue<Browser.Types.HTMLElement> option) ->
            Html.div [ prop.className [ Style.``bg-nord5``
                                        Style.``p-4``
                                        Style.``rounded-lg``
                                        Style.``md:max-w-screen-md``
                                        Style.``ring-1``
                                        Style.``ring-nord4``
                                        Style.``ring-opacity-5`` ]
                       prop.children [ Html.a [ prop.href p.href
                                                prop.onClick p.onClick
                                                prop.ref !!ref
                                                prop.children [ Html.div [ prop.className [ Style.``mb-4``
                                                                                            Style.``text-xl``
                                                                                            Style.``font-bold`` ]
                                                                           prop.text props.title ]
                                                                Html.p props.description
                                                                Html.p [ prop.className [ Style.``text-right`` ]
                                                                         prop.text props.date ] ] ] ] ])
