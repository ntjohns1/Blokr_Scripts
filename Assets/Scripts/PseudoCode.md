Game mananger:
- [x] Organize Piece game obects into collections
- [x] Confirm before placing piece
- [x] 
- [x] 

Board:
- [X] keep track of which cells are occupied and which are not.
- [ ] sprite to make grid spaces more visible.

Piece: 

- [ ] Select a piece (GUI)

Player:
- [ ] Keep track of played/unplayed pieces

PieceSelector:
- [ ] 

MoveSelector:
- [ ] determine what is a valid move
- [X] determine valid move for first turn

TurnHandler:
- [ ]

12/8 Notes / Workflow

Board -> Player -> GameManager

Board
 - add piece
 - remove piece
 - confirm move
-> Player
 - pieces/playedPieces
-> GameManager
 - Board, DoesPieceBelongToCurrentPlayer


 1/6/23 
 Place a Piece:
 - public boolean IsOverGameGrid()
    - check if raycast hits within confines of board
 - public void AddPiece
    - move validity checks 
        - IsValidMove
        - 
    - this.transform.location = tileHighlight.transform.location
        - tileHighLight.SetActive(false)


Selectors to Reorganize:
√ A4
√ C4
√ C5
√ E4
√ E5
√ B5
√ C4
√ D5
√ E5
√ G5
√ H5
√ I5
√ J5￼
√ K5
√ L5

