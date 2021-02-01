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
            Html.a [ prop.className [ Style.``min-w-0``
                                      Style.``p-4``
                                      Style.``rounded-lg``
                                      Style.``shadow-sm`` ]
                     prop.href p.href
                     prop.onClick p.onClick
                     prop.ref !!ref
                     prop.children [ Html.h4 [ prop.className [ Style.``mb-4`` ]
                                               prop.text props.title ]
                                     Html.p props.description
                                     Html.p props.date ] ])
