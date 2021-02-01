#r "./packages/Fable.Core/lib/netstandard2.0/Fable.Core.dll"
#r "./packages/Fable.Node/lib/netstandard2.0/Fable.Node.dll"


Node.Api.``module``.exports <-
    {| purge = [| "./pages/**/*.js" |]
       darkMode = false
       theme =
           {| extend =
                  {| colors =
                         {| nord0 = "var(--nord0)"
                            nord1 = "var(--nord1)"
                            nord2 = "var(--nord2)"
                            nord3 = "var(--nord3)"
                            nord4 = "var(--nord4)"
                            nord5 = "var(--nord5)"
                            nord6 = "var(--nord6)"
                            nord7 = "var(--nord7)"
                            nord8 = "var(--nord8)"
                            nord9 = "var(--nord9)"
                            nord10 = "var(--nord10)"
                            nord11 = "var(--nord11)"
                            nord12 = "var(--nord12)"
                            nord13 = "var(--nord13)"
                            nord14 = "var(--nord14)"
                            nord15 = "var(--nord15)" |} |} |}
       variants = {| extend = {|  |} |}
       plugins = [||] |}
