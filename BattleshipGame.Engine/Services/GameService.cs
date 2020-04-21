using BattleshipGame.Engine.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;

namespace BattleshipGame.Engine.Services
{
    public class GameService : IGameService
    {
        /// <summary>
        /// Adds a ship to a player gameboard
        /// </summary>
        /// <param name="shipId"></param>
        /// <param name="lengthOrWidth"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="orientation"></param>
        /// <param name="player"></param>
        public void AddShip(int shipId, int lengthOrWidth, int startingRow, int startingColumn, OrientationType orientation, Player player)
        {
            IsValidShipAddition(lengthOrWidth, startingRow, startingColumn, orientation);

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

        /// <summary>
        /// Return false if miss, returns true if hit
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool AttackSquare(int row, int column, Player player)
        {
            IsValidateRowsAndColumns(row, column);

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

        /// <summary>
        /// Basic validation
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void IsValidateRowsAndColumns(int row, int column)
        {
            if (row > 10 || column > 10)
            {
                throw new ApplicationException($"Input row: {row} and column {column} is not valid");
            }
        }

        /// <summary>
        /// Basic validation
        /// </summary>
        /// <param name="lengthOrWidth"></param>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="orientation"></param>
        public void IsValidShipAddition(int lengthOrWidth, int startingRow, int startingColumn, OrientationType orientation)
        {
            IsValidateRowsAndColumns(startingRow, startingColumn);
            
            if (lengthOrWidth > 10)
            {
                throw new ApplicationException($"Ship is too large to fit on the board");
            }

            if (orientation == OrientationType.Horizontal)
            {
                var endLength = startingRow + lengthOrWidth;
                if (endLength > 10)
                {
                    throw new ApplicationException($"Ship will not fit on the board horizonatally");
                }
            } 
            else
            {
                var endLength = startingColumn + lengthOrWidth;
                if (endLength > 10)
                {
                    throw new ApplicationException($"Ship will not fit on the board vertically");
                }
            }
            
        }
    }
}
