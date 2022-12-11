open System.IO;



type Item =
| Rock = 1
| Paper = 2
| Scissors = 3

let toRoundItem = function
| "A" | "X" -> Item.Rock
| "B" | "Y" -> Item.Paper
| "C" | "Z" -> Item.Scissors
| _ -> Item.Rock


let parseRounds = Array.map (fun (rounds: string) -> rounds.Split " " |> fun str -> (toRoundItem str[0], toRoundItem str[1]))

let valueOfEnum v = int v

let scoreRound = function
| (Item.Rock, Item.Rock) -> valueOfEnum Item.Rock + 3
| (Item.Rock, Item.Paper) -> valueOfEnum Item.Paper + 6
| (Item.Rock, Item.Scissors) -> valueOfEnum Item.Scissors + 0
| (Item.Paper, Item.Rock) -> valueOfEnum Item.Rock + 0
| (Item.Paper, Item.Paper) -> valueOfEnum Item.Paper + 3
| (Item.Paper, Item.Scissors) -> valueOfEnum Item.Scissors + 6
| (Item.Scissors, Item.Rock) -> valueOfEnum Item.Rock + 6
| (Item.Scissors, Item.Paper) -> valueOfEnum Item.Paper + 0
| (Item.Scissors, Item.Scissors) -> valueOfEnum Item.Scissors + 3
| _ -> 0


let strategyGuide = File.ReadAllLines "./2022/day_2_input"

strategyGuide 
|> parseRounds
|> Array.map scoreRound
|> Array.sum
