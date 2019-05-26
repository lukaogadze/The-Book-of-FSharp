let lazyOperation = lazy(printfn "evaluating lazy expression"
                         System.Threading.Thread.Sleep 3000
                         42)


#time
lazyOperation.Force() |> printfn "Result: %d"
#time

#time
lazyOperation.Force() |> printfn "Result: %d"
#time

