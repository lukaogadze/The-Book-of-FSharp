let stateCapitals =
    Map [
        ("Indiana", "Indianapolis")
        ("Michigan", "Lansign")
        ("Ohio", "Columbus")
        ("Kentucky","Frankfort")
        ("Illinois", "Springfield")
    ]
    
stateCapitals.["Illinois"]
stateCapitals |> Map.containsKey "Washington"
stateCapitals |> Map.tryFind "Washington"
stateCapitals |> Map.tryFind "Indiana"

stateCapitals |> Map.tryFindKey (fun k v -> v = "Indianapolis")
stateCapitals |> Map.tryFindKey (fun k v -> v = "Olympia")