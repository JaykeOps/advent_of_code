open System.IO

let alphabet = Array.append [|'a'..'z'|] [|'A'.. 'Z'|] 

let fstHalf str = (str: string)[0.. str.Length / 2 - 1] 
let sndHalf str = (str: string)[str.Length / 2..]

let parseCompartments rs =
    let fst = rs |> fstHalf |> Seq.toList |> List.distinct
    let snd = rs |> sndHalf |> Seq.toList |> List.distinct
    (fst, snd)

let scoreRucksack (fst, snd) = fst |> List.map (fun ch -> if snd |> List.contains ch then (alphabet |> Seq.findIndex (fun ch2 -> ch2 = ch)) + 1 else 0)


let rucksacks = File.ReadAllLines "./2022/day_3_input"

rucksacks 
|> Array.map parseCompartments
|> Array.map scoreRucksack
|> List.concat
|> List.sum



