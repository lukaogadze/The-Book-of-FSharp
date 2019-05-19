#load "shared.fsx";

let averageInCelsius = List.average >> Shared.fahrenheitToCelsius

printfn "March average (C): %.1f" <| averageInCelsius Shared.marchHighTemps

let delay = System.TimeSpan.FromSeconds >> System.Threading.Thread.Sleep
delay 5.0