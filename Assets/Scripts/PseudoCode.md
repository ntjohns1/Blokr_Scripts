Game mananger:
- [x] Organize Piece game obects into collections

Board:
- [ ] keep track of which cells are occupied and which are not.

Piece: 

- [x] Select a piece (world position)
- [x] move it to a location
- [x] rotate a Piece
- [ ] place a piece 
- [ ] outline / highlight squares
- [ ] determine what is a valid move

- [ ] Select a piece (GUI)
- [ ] highlight gridspace
- [ ] outline preview of occupied squares

Player:
- [ ] Limit interactions to player's own color
- [x] Set of player's pieces.
- [ ] Futher divide set into played/unplayed pieces

12/8 Notes / Workflow

Board -> Player -> GameManager

Board
 - add/remove/confirm move
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



￼

