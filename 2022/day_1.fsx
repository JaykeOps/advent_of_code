open System.IO;
open System

let caloryList = File.ReadAllText "./day_1_input"

caloryList.Split([|"\n\n"|], StringSplitOptions.RemoveEmptyEntries)
|> Array.map (fun elfCals -> elfCals.Split '\n' |> Array.map Int32.Parse |> Array.sum)
|> Array.max