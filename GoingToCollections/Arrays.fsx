open System

let names1 = [| "Rose"; "Martha"; "Donna"; "Amy"; "Clara" |]
let names2 = [|
    "Rose"
    "Martha"
    "Donna"
    "Amy"
    "Clara"
    |]

let lines = [| use r = new System.IO.StreamReader(".\GoingToCollections\ArnoldMovies.txt")
               while not r.EndOfStream do yield r.ReadLine() |]

let emptyArray: int array = [||]

let stringArray1 = Array.zeroCreate<string> 5
let stringArray2 = Array.init 5 (fun _ -> "")

lines.[3]

Array.set lines 1 "Batman & Robin"
Array.get lines 1 |> printfn "%s"

lines.[1..3]

let arr1 = [|1..10|]
let arr2 = arr1 |> Array.copy
arr1 = arr2

let arr3 = arr1.Clone() :?> int array
System.Object.ReferenceEquals(arr1, arr3)
arr1 = arr3

let r = System.Random()
let ints = Array.init 5 (fun _ -> r.Next(-100, 100));;

ints |> Array.sortInPlace
ints

let movies = [| ("The Terminator", "1984")
                ("Predator", "1987")
                ("Commando", "1985")
                ("Total Recall", "1990")
                ("Conan the Destroyer", "1984") |]

movies |> Array.sortInPlaceBy (fun (_, year) -> year)

movies |> Array.sortInPlaceWith (fun (_, y1) (_, y2) -> if y1 < y2 then -1
                                                        elif y1 > y2 then 1
                                                        else 0)

let movies2D = array2D [| [| "The Terminator"; "1984" |]
                          [| "Predator"; "1987" |]
                          [| "Commando"; "1985" |]
                          [| "The Running Man"; "1987" |]
                          [| "True Lies"; "1994" |]
                          [| "Last Action Hero"; "1993" |]
                          [| "Total Recall"; "1990" |]
                          [| "Conan the Barbarian"; "1982" |]
                          [| "Conan the Destroyer"; "1984" |]
                          [| "Hercules in New York"; "1969" |] |]

movies2D.[2,1]
movies2D.[0..,0..0]
movies2D.[0..,1..1]

// Jagged Arrays

let movies3 = [| [| "The Terminator"; "1984"; "James Cameron" |]
                 [| "Predator"; "1987"; "John McTiernan" |]
                 [| "Commando"; "1985" |] |];;

movies3.[1].[2]