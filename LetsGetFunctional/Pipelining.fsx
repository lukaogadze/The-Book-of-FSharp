#load "Shared.fsx"

// Forward Pipelining
Shared.add 2 3 |> ignore

Shared.marchHighTemps
|> List.average
|> Shared.fahrenheitToCelsius
|> printfn "March Average (C): %.1f"

// Backward Pipelining

printfn "March Average (F): %.1f" <| List.average Shared.marchHighTemps

let addStuff a b c = a + b + c

(1,2,3) |||> addStuff

let (||||>) (a, b, c, d) e = e a b c d
let printStuff a b c d =
    printfn "%A %A %A %A" a b c d

(1, 2, 3, 4) ||||> printStuff

let addMoreStuff a b c d = a + b + c + d
(1,1,1,1) ||||> addMoreStuff
