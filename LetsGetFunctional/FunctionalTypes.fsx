// Tuples
let point1 = 10.0, 10.0
let point2: float * float = (10.0, 10.0)

let bigTuple = (1,2,3,4,5)

let _, _, x, _, _ = bigTuple
printfn "%d" x

let slope (x1, y1) (x2, y2) = (y1 - y2) / (x1 - x2)

(1, 2) = (1, 2)
(2, 1) = (1, 2)
let ex = System.FieldAccessException()
(1, ex) = (1, ex)

let r, v = System.Int32.TryParse "10"

// Records
type rgbColor1 = { R : byte; G : byte; B : byte }
type rgbColor2 =
    { R: byte;
      G: byte;
      B: byte; }

let red: rgbColor1 = {R = 255uy; G = 0uy; B = 0uy}