using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipGame.Engine.Models
{
    public class Player
    {
        public string Name { get; set; }
        public GameBoard PlayerGameBoard { get; set; }
        public Dictionary<int, Ship> Ships { get; set; }

        public Player(string name)
        {
            Name = name;
            PlayerGameBoard = new GameBoard();
            Ships = new Dictionary<int, Ship>();
        }

        /// <summary>
        /// If the player has no more ships in the dictionary then the player has lost
        /// </summary>
        /// <returns></returns>
        public bool HasPlayerLost()
        {
            if (Ships.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
