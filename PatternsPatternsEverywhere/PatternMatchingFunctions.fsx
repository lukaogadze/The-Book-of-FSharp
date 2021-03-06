﻿let testOption = function
    | Some(x) -> printfn "Some: %d" x
    | None -> printfn "None"

(fun x ->
    match x with
    | Some(v) -> printfn "Some: %i" v
    | None -> printfn "None") None

[Some 10; None; Some 4; None; Some 0; Some 7]
|> List.filter (function | Some _ -> true
                         | None -> false)


let numberToString1 = function
    | 0 -> "zero"
    | 1 -> "one"
    | 2 -> "two"
    | 3 -> "three"
    | n -> sprintf "%O" n

let numberToString2 = function
    | 0 -> "zero"
    | 1 -> "one"
    | 2 -> "two"
    | 3 -> "three"
    | _ -> "unknow"

let numberToString3 = function
    | 0 -> "zero"
    | 1 -> "one"
    | 2 -> "two"
    | 3 -> "three"
    | _ -> "..."

type Shape =
    | Circle of Radius : float
    | Rectangle of Width : float * Height : float
    | Triangle of Leg1 : float * Leg2 : float * Leg3 : float

let getParameter = function
    | Circle r -> 2.0 * System.Math.PI
    | Rectangle(w, h) -> 2.0 * (w + h)
    | Triangle(l1, l2, l3) -> l1 + l2 + l3

[<LiteralAttribute>]
let Zero = 0
[<LiteralAttribute>]
let One = 1
[<LiteralAttribute>]
let Two = 2
[<LiteralAttribute>]
let Three = 3

let numberToString4 = function
    | Zero -> "zero"
    | One -> "one"
    | Two -> "two"
    | Three -> "three"
    | _ -> "unknown"

let matchString1 = function
    | "" -> None
    | v -> Some(v.ToString());;

(*OR pattern*)
let matchString2 = function
    | null
    | "" -> None
    | v -> Some(v.ToString())

let point = 10, 20
let x, y = point

let locatePoint = function
    | (0, 0) as p -> sprintf "%A is at the origin" p
    | (_, 0) as p -> sprintf "%A is on the x-axis" p
    | (0, _) as p -> sprintf "%A is on the y-axis" p
    | (x, y) -> sprintf "Point (%i, %i)" x y

type Name = { First : string; Middle : string option; Last : string }

let formatName = function
    | { First = f; Middle = Some(m); Last = l } -> sprintf "%s, %s %s" l f m
    | { First = f; Middle = None; Last = l } -> sprintf "%s, %s" l f

let hasMiddleName = function
    | { Name.Middle = Some(_) } -> true
    | { Name.Middle = None } -> false

let getLength1 = function
    | null
    | [| |] -> 0
    | [| _ |] -> 1
    | [| _; _; |] -> 2
    | [| _; _; _ |] -> 3
    | a -> a |> Array.length

let getLength2 = function    
    | [ ] -> 0
    | [ _ ] -> 1
    | [ _; _; ] -> 2
    | [ _; _; _ ] -> 3
    | xs -> xs |> List.length

let getLength xs =
    let rec len acc = function
        | [] -> acc
        | _::xs -> len(acc + 1) xs
    len 0 xs

let startsWithUpperCase = function
    | (s : string) when s.Length > 0 && s.[0] = System.Char.ToUpper s.[0] -> true
    | _ -> false

type RgbColor = { R : int; G : int; B : int }
type CmykColor = { C : int; M : int; Y : int; K : int }
type HslColor = { H : int; S : int; L : int }
let detectColorSpace (cs: obj) =
    match cs with
    | :? RgbColor -> printfn "RGB"
    | :? CmykColor -> printfn "CMYK"
    | :? HslColor -> printfn "HSL"
    | _ -> failwith "Unrecognized"

let x1, y1 = (10, 20)
let point1 = 12, 20
let x2, y2 = point1

let x3, y3 as point2 = 10, 20


let locatePoint1 = function
    | (0, 0) as p -> sprintf "%A is at the origin" p
    | (x, y) & (_, 0) -> sprintf "(%i, %i) is on the x-axis" x y
    | (x, y) & (0, _) -> sprintf "(%i, %i) is on the y-axis" x y
    | (x, y) -> sprintf "Point (%i, %i)" x y

let locatePoint2 = function
    | (0, 0) as p -> sprintf "%A is at the origin" p
    | (_, 0) | (0, _) as p -> sprintf "%A is on an axis" p
    | p -> sprintf "Point %A" p

let locatePoint3 = function
    | (0, 0) as p -> sprintf "%A is at the origin" p
    | (x, y) & ((_, 0) | (0, _)) -> sprintf "(%i, %i) is on an axis" x y
    | p -> sprintf "Point %A" p

let (|Fizz|Buzz|FizzBuzz|Other|) n =
    match (n % 3, n % 5) with
    | 0, 0 -> FizzBuzz
    | 0, _ -> Fizz
    | _, 0 -> Buzz
    | _ -> Other n

let fizzBuzz = function
    | Fizz -> "Fizz"
    | Buzz -> "Buzz"
    | FizzBuzz -> "FizzBuzz"
    | Other n -> n.ToString()

seq {1..100}
|> Seq.map fizzBuzz
|> Seq.iter (printfn "%s")

let (|Fizz|_|) n = if n % 3 = 0 then Some Fizz else None
let (|Buzz|_|) n = if n % 5 = 0 then Some Buzz else None

let fizzBuzz2 = function
    | Fizz & Buzz -> "FizzBuzz"
    | Fizz -> "Fizz"
    | Buzz -> "Buzz"
    | n -> n.ToString()

let (|DivisibleBy|_|) d n = if n % d = 0 then Some DivisibleBy else None

let fizzBuzz3 = function
    | DivisibleBy 3 & DivisibleBy 5 -> "FizzBuzz"
    | DivisibleBy 3 -> "Fizz"
    | DivisibleBy 5 -> "Buzz"
    | n -> n.ToString()