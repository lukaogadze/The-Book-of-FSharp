let add a b = a + b

let add2 a = fun b -> (+) a b

// Prefer This Form
let add3 a =
    let innerAdd b =
        a + b
    innerAdd

let add4 a =
    fun b -> a + b