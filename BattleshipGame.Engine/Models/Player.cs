using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Engine.Models
{
    public class Player
    {
        public string Name { get; set; }
        public GameBoard GameBoard { get; set; }
        Dictionary<int, Ship> Ships { get; set; }

        public Player(string name)
        {
            Name = name;
            GameBoard = new GameBoard();
            Ships = new Dictionary<int, Ship>();
        }

        public void AddShip(int shipId, int lengthOrWidth, int startingRow, int startingColumn, OrientationType orientation)
        {
            // Check to see if we have it in our dictionary
            if (Ships.ContainsKey(shipId))
            {
                throw new ApplicationException("Ship Id with the same key already exists, please use another key");
            }
            
            // If not we add it to the Ship Dictionary
            var ship = new Ship()
            {
                LengthOrWidth = lengthOrWidth,
                Hits = 0,
                Id = shipId,
            };
            Ships.Add(shipId, ship);

            // Add it to the Gameboard
            for(int i = 0; i < lengthOrWidth; i++)
            {
                int currentRow;
                int currentColumn;

                if (orientation == OrientationType.Horizontal)
                {
                    currentRow = startingRow;
                    currentColumn = startingColumn + i;
                } else
                {
                    currentRow = startingRow + i;
                    currentColumn = startingColumn;
                }

                var currentSquare = GameBoard.GetItem(currentRow, currentColumn);
                if (currentSquare.GetCurrentShip() != null)
                {
                    throw new ApplicationException($"Square row: {currentRow} column: {currentColumn + i}  already contains a ship");
                }

                currentSquare.AddShip(shipId);
                GameBoard.AddItem(currentRow, currentColumn, currentSquare);
            }
        }

        public void AttackSquare()
        {

        }
    }
}
