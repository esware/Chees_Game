# Chees Game
When designing for a chess game, it is important to first understand the logic of the business. The game of chess is played by two people and each player has 16 pieces.
The aim of the players is to checkmate the opponent's king. To checkmate, it is necessary to detect situations where the opposing king is threatened in any position and to prevent these threats.
 
![image](https://user-images.githubusercontent.com/48649947/234627541-53827fab-15e3-474d-a86a-95c97d890d7e.png)

The movements of the stones are made according to certain rules.
For example, the pawn can only move forward one square or two, and the opponent can eat the pieces only diagonally.
The king piece can perform special moves like any other piece, and when threatened by an opponent piece it must move in a way that blocks that threat.
 
When designing a game of chess, you must code the rules that determine the movements of each piece.
You also need to create variables to keep track of the positions of the pieces and the game state.
To finish the game, you need to write a function that checks if each player's king is checkmate. 

![image](https://user-images.githubusercontent.com/48649947/234630695-c0d8de1f-3bf1-4636-b15c-0d2b09602f28.png)

To design these functions in a modular way, you can manage each stone's own movements, position, and properties by creating a class for each stone.
You can also create a "GameManager" class to manage the game state. This class can track the positions of the pieces, control the movements of the pieces and monitor the game state.

![image](https://user-images.githubusercontent.com/48649947/234631148-15ec6cb9-a665-4110-9e4c-9f21f3196123.png)

When designing a chess game, you can take several steps to adhere to Solid principles.
For example, each class should have a single responsibility, and a class should only deal with its own functions.
You should also pay attention to principles such as minimizing dependencies and limiting interactions with each other.

 ## Some of tasks is "ChessBoard" class:
 
_-Build the chessboard and number all the squares on the board._

_-Storing what tile you have for each square on the board._

_-To rotate or move a piece in a given position._

_-To check if a piece can move in a given position._

_-Checking if there is a checkmate situation on the board._

_-Providing special methods to store and retrieve the current position._

_-Tracking and storing the state of the game and the history of moves._

_-Besides these tasks, the board class may also contain other auxiliary methods required for the game of chess. _

![image](https://user-images.githubusercontent.com/48649947/234632794-e84e365e-0c31-4eee-b534-0507a79447d1.png)
