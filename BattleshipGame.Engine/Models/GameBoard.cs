using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Engine.Models
{
    public class GameBoard
    {
        public Square[,] GameBoardArray { get; set; }

        /// <summary>
        /// Creates a new 10 x 10 array
        /// </summary>
        public GameBoard()
        {
            GameBoardArray = new Square[10, 10];

            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    var square = new Square();
                    GameBoardArray[row, column] = square;
                }
            }
        }

        /// <summary>
        /// Adds an square to the array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="square"></param>
        public void AddItem(int row, int column, Square square)
        {
            GameBoardArray[row, column] = square;
        }

        /// <summary>
        /// Gets the square in the array
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public Square GetItem(int row, int column)
        {
            return GameBoardArray[row, column];
        }
    }
}
