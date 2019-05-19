// Non Tail Call Version
let rec factorial1 v =
    match v with | 1L -> 1L
                 | _ -> v * factorial1 (v - 1L)


// Tail Call Version
let factorial2 v =
    let rec fact c p =
        match c with | 0L -> p
                     | _ -> fact (c - 1L) (c * p)
    fact v 1L
