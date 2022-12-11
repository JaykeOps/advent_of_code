open System.IO;


exception ParsingError

type Item =
| Rock = 1
| Paper = 2
| Scissors = 3

let valueOfItem v = int v

type Strategy = Win | Draw | Loose

let parseItem = function
| "A" | "X" -> Item.Rock
| "B" | "Y" -> Item.Paper
| "C" | "Z" -> Item.Scissors
| _ -> Item.Rock

let parseStrategy = function
| "X" -> Loose
| "Y" -> Draw
| "Z" -> Win
| _ -> raise ParsingError

let playRoundStrategy = function
| (Item.Rock, Loose) -> (Item.Rock, Item.Scissors)
| (Item.Rock, Draw) -> (Item.Rock, Item.Rock)
| (Item.Rock, Win) -> (Item.Rock, Item.Paper)
| (Item.Paper, Loose) -> (Item.Paper, Item.Rock)
| (Item.Paper, Draw) -> (Item.Paper, Item.Paper)
| (Item.Paper, Win) -> (Item.Paper, Item.Scissors)
| (Item.Scissors, Loose) -> (Item.Scissors, Item.Paper)
| (Item.Scissors, Draw) -> (Item.Scissors, Item.Scissors)
| (Item.Scissors, Win) -> (Item.Scissors, Item.Rock)
| _ -> raise ParsingError


let parseRounds = Array.map (fun (rounds: string) -> rounds.Split " " |> fun str -> (parseItem str[0], parseStrategy str[1]))

let scoreRound = function
| (Item.Rock, Item.Rock) -> valueOfItem Item.Rock + 3
| (Item.Rock, Item.Paper) -> valueOfItem Item.Paper + 6
| (Item.Rock, Item.Scissors) -> valueOfItem Item.Scissors + 0
| (Item.Paper, Item.Rock) -> valueOfItem Item.Rock + 0
| (Item.Paper, Item.Paper) -> valueOfItem Item.Paper + 3
| (Item.Paper, Item.Scissors) -> valueOfItem Item.Scissors + 6
| (Item.Scissors, Item.Rock) -> valueOfItem Item.Rock + 6
| (Item.Scissors, Item.Paper) -> valueOfItem Item.Paper + 0
| (Item.Scissors, Item.Scissors) -> valueOfItem Item.Scissors + 3
| _ -> 0


let strategyGuide = File.ReadAllLines "./2022/day_2_input"

strategyGuide 
|> parseRounds
|> Array.map playRoundStrategy
|> Array.map scoreRound
|> Array.sum
