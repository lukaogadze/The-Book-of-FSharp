let testNumber1 = function
    | v when v < 0 -> printfn "%d is negative" v
    | v when v > 0 -> printfn "%d is positive" v
    | _ -> printfn "zero"
    
let testNumber2 = function
    | v when v > 0 && v % 2 = 0 -> printfn "%i is positive and even" v
    | v -> printfn "%i is zero, negative, or odd" v    