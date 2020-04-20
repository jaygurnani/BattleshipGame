using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Engine.Models
{
    public class GameBoard
    {
        public Square[,] GameBoardArray { get; set; }

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

        public void AddItem(int row, int column, Square square)
        {
            GameBoardArray[row, column] = square;
        }

        public Square GetItem(int row, int column)
        {
            return GameBoardArray[row, column];
        }
    }
}
