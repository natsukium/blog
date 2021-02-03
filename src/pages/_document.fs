module Document

open Feliz

open Next
open Style

type MyDocument() =
    inherit Document()

    override this.render() =
        Doc.Html [ Doc.Head []
                   Html.body [ prop.className [ Style.``bg-nord6``
                                                Style.``text-nord0`` ]
                               prop.children [ Doc.Main []
                                               Doc.NextScript [] ] ] ]

// exportDefault MyDocument  // cannot export class without instantiation
