let names1 = [ "Rose"; "Martha"; "Donna"; "Amy"; "Clara" ]
let names2 = [
    "Rose"
    "Martha"
    "Donna"
    "Amy"
    "Clara"
]

let numbers = [1..11]

List.item 3 ['A'..'Z']

List.head names1
List.tail names1

let rec contains fn xs =
    if xs = [] then false
    else fn(List.head xs) || contains fn (List.tail xs)
    
[] |> contains (fun n -> n = "Rose")
names1 |> contains  (fun n -> n = "Rose")

let names3 = "Ace" :: names2

let list1 = [1;2;3]
let list2 = [4;5;6]
let list3 = list1 @ list2

List.concat [list1;list2;list3]