# BattleshipGame
## Project Structure
- BattleshipGame - WebApi
- BattleshipGame.Engine - Class library for the Game Engine
- BattleshipGame.Tests - NUnit Test Project

## Design Considerations
- An 2d array is used to hold the game board. This allows for quick access
- Where possible game states are passed in rather than stored in a global context. This allows for more testable code.
- Interfaces are used for the Game Service.
- NLog is used for logging throughout the system.
- We use interfaces and link this with dependency injection to control the lifecycle of classes.
- Private variables are read only.
- Basic validation is done to ensure invalid data cannot be passed.
- The user needs to keep track of the shipId when they add a ship as well as playing user id.

## Testing
There are 2 mechanism to test the application:
1. Unit tests
These are the following unit tests that are run:
    - Correct Game board setup
    - Can ship be added to a square successfully/unsuccessfully
    - Exceptions are thrown if the ship we are trying to add goes outside the board.
    - Can attack an empty/full space
    - Win states are tested

2. Postman API Tests
Postman tests have the following functions: 
    - CreateGame
    - Add Ship
    - Attack Ship (This will return if you have won or not)

## To Run
Web application runs under: http://localhost:61881/BattleshipGame

Sample Input: 
Create Game- HTTP Post - http://localhost:61881/BattleshipGame/CreateGame

    {
	    "player1Name": "Alice",
	    "player2Name": "Bob"
    }

Add Ship - HTTP Post - http://localhost:61881/BattleshipGame/AddShip

    {
        "shipId": 1,
        "lengthOrWidth": 4,
        "startingRow": 1,
        "startingColumn": 1,
        "orientation": 1,
        "playerId": 1
    }

Attack Ship - HTTP Post - http://localhost:61881/BattleshipGame/AttackShip
    {
        "row": 4,
        "column": 1,
        "playerToAttack": 1
    }

## Limitations
- The board can only be 10 x 10 size.
- The Game is 0-indexed rather than 1-indexed. Ideally we should change this.

## Performance considerations
- Everytime a ship is attacked, we check to see if the player has won.

## To do
- Make game 1-indexed rather than 0-index.
- Users should be able to add a ship without worrying about the shipId.
- More validation needs to be done to make sure invalid data cannot be passed.
