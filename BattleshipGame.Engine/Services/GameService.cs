using BattleshipGame.Engine.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BattleshipGame.Engine.Services
{
    public class GameService : IGameService
    {
        public void AddShip(int shipId, int lengthOrWidth, int startingRow, int startingColumn, OrientationType orientation, Player player)
        {
            // Check to see if we have it in our dictionary
            if (player.Ships.ContainsKey(shipId))
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
            player.Ships.Add(shipId, ship);

            // Add it to the Gameboard
            for (int i = 0; i < lengthOrWidth; i++)
            {
                int currentRow;
                int currentColumn;

                if (orientation == OrientationType.Horizontal)
                {
                    currentRow = startingRow;
                    currentColumn = startingColumn + i;
                }
                else
                {
                    currentRow = startingRow + i;
                    currentColumn = startingColumn;
                }

                var currentSquare = player.PlayerGameBoard.GetItem(currentRow, currentColumn);
                if (currentSquare.GetSquareContent() != null)
                {
                    throw new ApplicationException($"Square row: {currentRow} column: {currentColumn + i}  already contains a ship");
                }

                currentSquare.AddShip(shipId);
                player.PlayerGameBoard.AddItem(currentRow, currentColumn, currentSquare);
            }
        }

        public bool AttackSquare(int row, int column, Player player)
        {
            // Get the current square
            var currentSquare = player.PlayerGameBoard.GetItem(row, column);
            var currentSquareContent = currentSquare.GetSquareContent();
            if (currentSquareContent == null)
            {
                // Return miss
                return false;
            }

            var shipId = currentSquareContent.Value;
            var currentShip = player.Ships[shipId];
            currentShip.Hits = currentShip.Hits + 1;

            // If it has been sunk
            if (currentShip.IsSunk())
            {
                // Remove it from the dictionary
                player.Ships.Remove(shipId);
            }

            // Update the square
            currentSquare.RemoveContent();
            player.PlayerGameBoard.AddItem(row, column, currentSquare);
            return true;
        }
    }
}
