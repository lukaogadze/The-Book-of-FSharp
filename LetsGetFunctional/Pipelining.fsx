let add a =
    let innerAdd b =
        a + b
    innerAdd

// Forward Pipelining
add 2 3 |> ignore

let fahrenheitToCelsius degreeesF = (degreeesF - 30.0) * (5.0 / 9.0)

let marchHighTemps = [ 33.0; 30.0; 33.0; 38.0; 36.0; 31.0; 35.0;
                       42.0; 53.0; 65.0; 59.0; 42.0; 31.0; 41.0;
                       49.0; 45.0; 37.0; 42.0; 40.0; 32.0; 33.0;
                       42.0; 48.0; 36.0; 34.0; 38.0; 41.0; 46.0;
                       54.0; 57.0; 59.0 ]

marchHighTemps
|> List.average
|> fahrenheitToCelsius
|> printfn "March Average (C): %.1f"

// Backward Pipelining

printfn "March Average (F): %.1f" <| List.average marchHighTemps

let addStuff a b c = a + b + c

(1,2,3) |||> addStuff

let (||||>) (a, b, c, d) e = e a b c d
let printStuff a b c d =
    printfn "%A %A %A %A" a b c d

(1, 2, 3, 4) ||||> printStuff

let addMoreStuff a b c d = a + b + c + d
(1,1,1,1) ||||> addMoreStuff
