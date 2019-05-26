let lines = seq { use r = new System.IO.StreamReader("ArnoldMovies.txt")
                  while not r.EndOfStream do yield r.ReadLine() }

let s1 = seq {0..10}
let s2 = seq {0.0..10.0}
let s3 = seq {'a'..'z'}

let s4 = seq { 0..10..100 }
// let s5 = seq { 'a'..2..'z' } <- error
let s5 = seq { 99..-1..0 }

let emptySequence = Seq.empty<string>

let rand = System.Random()

let s6 = Seq.init 10 (fun x ->
                printfn "%d" x
                rand.Next(10))

Seq.isEmpty s6
s6 |> Seq.length

seq { 0..99 } |> Seq.length

let s7 = seq { for i in 1..10 do
                printfn "Evaluating %i" i
                yield i }

s7 |> Seq.length = 0


s7 |> Seq.isEmpty

seq {0..99} |> Seq.iter (printfn "%d")

seq {0..99} |> Seq.map (fun x -> x * x)

// Sorting Sequences

Seq.init 10 (fun _ -> rand.Next 100) |> Seq.sort

let movies =
    seq { use r = new System.IO.StreamReader(".\GoingToCollections\ArnoldMovies.txt")
          while not r.EndOfStream do
              let l = r.ReadLine().Split ','
              yield l.[0], int l.[1]}
    

let printSeq xs = xs |> Seq.iter (printfn "%A")
    
movies |> printSeq

movies |> Seq.sortBy snd |> printSeq

movies |> Seq.sortBy fst |> printSeq
    
    
    
// Filtering Sequences
    
movies |> Seq.filter (fun (_, year) -> year < 1985) |> printSeq    
    
seq {yield (seq {1..10} |> Seq.fold (fun s c -> s + c) 0)} |> printSeq
    
    
seq {yield seq {1..10} |> Seq.fold (+) 0} |> printSeq

seq {1..10} |> Seq.reduce (+)

seq {1..10} |> Seq.sum

seq {1.0..10.0} |> Seq.average
    
    
    
    
    