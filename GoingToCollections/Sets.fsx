let alphabet = seq{'A'..'Z'} |> Set.ofSeq
alphabet.Count
alphabet.Add 'Z'
alphabet.Count

let vowels = Set.empty.Add('A').Add('E').Add('I').Add('O').Add('U')

type Sample() =
    class end

let set1 = set [1..5]
let set2 = set [3..7]

Set.union set1 set2
set1 + set2

(set1, set2) ||> Set.intersect

(set1, set2) ||> Set.difference
set1 - set2

let set3 = set [1; 2; 3; 4; 5]
let set4 = set [1; 2; 3; 4; 5]

Set.isSuperset set3 set4
Set.isProperSuperset set3 set4
Set.isSubset set4 set3
Set.isProperSubset set4 set3

let set5 = set [0..5]

Set.isSuperset set5 set4
Set.isProperSuperset set5 set4
Set.isSubset set4 set5
Set.isProperSubset set4 set5

