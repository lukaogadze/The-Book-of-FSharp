seq { 1..10 } |> Seq.toArray
seq { 1..10 } |> Array.ofSeq

let l = [1..10]
obj.ReferenceEquals(l, Seq.ofList l)

let a = [|1..10|]
obj.ReferenceEquals(a, Seq.ofArray a)

let a1 = [|1..10|]
obj.ReferenceEquals(a1, List.ofArray a)