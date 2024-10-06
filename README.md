# Chess Coding Challenge (C#)
This is my attempt on Sebastian's Lague [chess coding challenge](https://github.com/SebLague/Chess-Challenge).

## My bot
You can find my bot's file [here](https://github.com/Vag-Soft/SmallChessChallenge/blob/a0efba619dbb88412ac471b087d24ccd9174a2cf/Chess-Challenge/src/My%20Bot/MyBot.cs).
It lacks many features which makes it very simple, slow, and exceptionally bad at check-mating the opponent. :P

It implements a MiniMax search algorithm with Alpha-Beta pruning to search through all the possible moves.
Its depth is set to 4 due to speed limitations which, consequently, makes it very short-sighted.

Its leaf evaluation function takes into consideration only the material, the center squares, and the capture moves of a board.


## Results
### Placement in Tournament 469/624

| ID  | Bot Name | Author Name/s | Score (win = 2, draw = 1, loss = 0) | Tiebreak
| :---: | :---: | :---: | :---: | :---: |
| Bot_417  | ShallowBot | Vaggelis Softsis  | 59  | 2842  |


### Rating
Calculated from swiss and knockout games using BayesElo. Thanks to Gediminas Masaitis (an author of smol.cs).
Ratings are adjusted to Boychesser = 2772 as measured in CCRL Blitz https://www.computerchess.org.uk/ccrl/404/

| Rank  | Name | Elo | + | - | games | score | oppo. | draws |
| :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: |
| 466  | ShallowBot (by: Vaggelis Softsis)  | 442  | 67  | 67  | 64  | 46%  | 471  | 64%  |
